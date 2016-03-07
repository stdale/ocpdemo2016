using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;
using amaxOcpSummit2016.Dcm;
using System.Net;
using System.Net.Sockets;
using SnmpSharpNet;

//using System.ComponentModel;
using System.Windows;
//using System.Windows.Controls;


namespace amaxOcpSummit2016
{


    public partial class frm_main : Form
    {
        #region class variables

        private BackgroundWorker bwUI = new BackgroundWorker();
        private BackgroundWorker bwSNMP = new BackgroundWorker();

        Dcm.DcmClient dcmClient;
        string dcmSrvAddy;

        List<string> phoneNumbers = new List<string>();
        int rackEntId;
        int[] srvEntId = new int[6];
        int upsEntId;
        int activePolicyId;
        string emailFrom;
        string snmpSrv;
        string emailSubject;
        string emailUser;
        string emailPw;

        int snmpPortListAddy;
        protected Socket _socket;
        protected byte[] _inbuffer;
        protected IPEndPoint _peerIP;
        #endregion

        public frm_main()
        {
            _socket = null;
            activePolicyId = -1;
            InitializeComponent();
            rackEntId = Int32.Parse(ConfigurationSettings.AppSettings["rackEntId"]);
            for (int i = 1; i < 7; i++)   {
                srvEntId[i -1] = Int32.Parse(ConfigurationSettings.AppSettings["srv" + i.ToString() + "EntId"]);
            }
            upsEntId = Int32.Parse(ConfigurationSettings.AppSettings["upsEntId"]);
            snmpPortListAddy = Int32.Parse(ConfigurationSettings.AppSettings["snmpPortListAddy"]);
            emailFrom = ConfigurationSettings.AppSettings["emailFrom"];
            snmpSrv = ConfigurationSettings.AppSettings["snmpSrv"];
            emailSubject = ConfigurationSettings.AppSettings["emailSubject"];
            emailUser = ConfigurationSettings.AppSettings["emailUser"];
            emailPw = ConfigurationSettings.AppSettings["emailPw"];
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            dcmClient = new Dcm.DcmClient();
            string ver = dcmClient.getVersion();

            bwUI.WorkerReportsProgress = true;
            bwUI.WorkerSupportsCancellation = true;
            bwUI.DoWork += new DoWorkEventHandler(bw_DoWorkUI);
            bwUI.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bwSNMP.WorkerReportsProgress = false;
            bwSNMP.WorkerSupportsCancellation = true;
            bwSNMP.DoWork += new DoWorkEventHandler(bw_DoWorkSNMP);
            MessageBox.Show(ver);
            pb_ui.Value = 0;
        }

        #region UI Thread code
        delegate void SetTextCallback(Form form, Control ctrl, string text);
        private void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { form,ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
            Application.DoEvents();
        }
        delegate void SetColorCallback(Form form, Control ctrl, Color clr);
        private void SetColor(Form form, Control ctrl, Color clr)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctrl.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetColor);
                this.Invoke(d, new object[] { form, ctrl, clr });
            }
            else
            {
                ctrl.BackColor = clr;
            }
            Application.DoEvents();
        }
        #endregion 

        #region workerSNMP
        public void StopReceiver()  {
            if (_socket != null)  {
                _socket.Close();
                _socket = null;
            }
        }
        public bool InitializeReceiver() {
            if (_socket != null)  {
                StopReceiver();
            }
            try  {
                // create an IP/UDP socket
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("SNMP trap receiver socket initialization failed with error: " + ex.Message);
                // there is no need to close the socket because it was never correctly created
                _socket = null;
            }
            if (_socket == null)
                return false;
            try    {
                // prepare to "bind" the socket to the local port number
                // binding notifies the operating system that application 
                // wishes to receive data sent to the specified port number

                // prepare EndPoint that will bind the application to all available 
                //IP addresses and port 162 (snmp-trap)
                EndPoint localEP = new IPEndPoint(IPAddress.Any, snmpPortListAddy);
                // bind socket
                _socket.Bind(localEP);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("SNMP trap receiver initialization failed with error: " + ex.Message);
                _socket.Close();
                _socket = null;
            }
            if (_socket == null)
                return false;

            if (!RegisterReceiveOperation())
                return false;

            return true;
        }

        public bool RegisterReceiveOperation()
        {
            if (_socket == null)
                return false;
            // socket has been closed
            try
            {
                _peerIP = new IPEndPoint(IPAddress.Any, 0);
                // receive from anybody
                EndPoint ep = (EndPoint)_peerIP;
                _inbuffer = new byte[64 * 1024];
                // nice and big receive buffer
                _socket.BeginReceiveFrom(_inbuffer, 0, 64 * 1024,
                    SocketFlags.None, ref ep, new AsyncCallback(ReceiveCallback), _socket);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Registering receive operation failed with message: " + ex.Message);
                _socket.Close();
                _socket = null;
            }
            if (_socket == null)
                return false;
            return true;
        }

        private void ReceiveCallback(IAsyncResult result)  {
            // get a reference to the socket. This is handy if socket has been closed elsewhere in the class
            Socket sock = (Socket)result.AsyncState;

            _peerIP = new IPEndPoint(IPAddress.Any, 0);

            // variable to store received data length
            int inlen;

            try    {
                EndPoint ep = (EndPoint)_peerIP;
                inlen = sock.EndReceiveFrom(result, ref ep);
                _peerIP = (IPEndPoint)ep;
            }
            catch (System.Exception ex)
            {
                // only post messages if class socket reference is not null
                // in all other cases, user has terminated the socket
                if (_socket != null)
                {
                    PostAsyncMessage("Receive operation failed with message: " + ex.Message);
                }
                inlen = -1;
            }
            // if socket has been closed, ignore received data and return
            if (_socket == null)
                return;
            // check that received data is long enough
            if (inlen <= 0)
            {
                // request next packet
                RegisterReceiveOperation();
                return;
            }
            int packetVersion = SnmpPacket.GetProtocolVersion(_inbuffer, inlen);
  
            if (packetVersion == (int)SnmpVersion.Ver2)  {
                SnmpV2Packet pkt = new SnmpV2Packet();
                try  {
                    pkt.decode(_inbuffer, inlen);
                }
                catch (System.Exception ex)
                {
                    PostAsyncMessage("Error parsing SNMPv2 Trap: " + ex.Message);
                    pkt = null;
                }
                if (pkt != null) {
                    if (pkt.Pdu.Type == PduType.V2Trap) {
                        PostAsyncMessage(String.Format("** SNMPv2 TRAP from {0}", _peerIP.ToString()));
                    }
                    if (pkt != null)    {
                        /*PostAsyncMessage(
                            String.Format("*** community {0} sysUpTime: {1} trapObjectID: {2}",
                                pkt.Community, pkt.Pdu.TrapSysUpTime.ToString(), pkt.Pdu.TrapObjectID.ToString())
                        );*/
                        //PostAsyncMessage(String.Format("*** PDU count: {0}", pkt.Pdu.VbCount));
                        foreach (Vb vb in pkt.Pdu.VbList)  {
                            /*PostAsyncMessage(
                                String.Format("**** Vb oid: {0} type: {1} value: {2}",
                                    vb.Oid.ToString(), SnmpConstants.GetTypeName(vb.Value.Type), vb.Value.ToString())
                            );*/
                            if(vb.Oid.ToString() == "1.3.6.1.4.1.6302.3.1.46.2" ||
                               vb.Oid.ToString() == "1.3.6.1.4.1.6302.3.1.42.2")
                            {
                                // we caught the trap and foudn the one we awnt... do the business
                                PostAsyncMessage(
                                String.Format("**** Got AC FAIL trap -> oid: {0} type: {1} value: {2}",
                                    vb.Oid.ToString(), SnmpConstants.GetTypeName(vb.Value.Type), vb.Value.ToString()));
                                SetText(this, lbl_extPwr, "Off");
                                SetColor(this, pnl_extPwr, Color.Red);
                                //updateActiveCap(true);
                            }else if(vb.Oid.ToString() == "1.3.6.1.4.1.6302.3.1.42.3")
                            {
                                PostAsyncMessage(
                                String.Format("**** Got AC RETURN Trap -> oid: {0} type: {1} value: {2}",
                                    vb.Oid.ToString(), SnmpConstants.GetTypeName(vb.Value.Type), vb.Value.ToString()));
                                SetText(this, lbl_extPwr, "On");
                                SetColor(this, pnl_extPwr, Color.Lime);
                                //updateActiveCap(false);
                            }
                        }
                        if (pkt.Pdu.Type == PduType.V2Trap)
                            PostAsyncMessage("** End of SNMPv2 TRAP");
                    }
                }
            }
            RegisterReceiveOperation();
        }

        protected delegate void PostAsyncMessageDelegate(string msg);
        protected void PostAsyncMessage(string msg)
        {
            if (InvokeRequired)
                Invoke(new PostAsyncMessageDelegate(PostAsyncMessage), new object[] { msg });
            else
                lb_log.Items.Add(msg);
        }

        private void bw_DoWorkSNMP(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (;;)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {

                }
            }
        } 
        #endregion

        #region workerThreadUI
        private void bw_DoWorkUI(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool bSwitch = false;

            /* examples of how to update UI
                 SetColor(this, pnl_extPwr, Color.Lime);
                 SetText(this,lbl_extPwr,"ON");
            */
            for (;;) {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    /* stuff to do
                       1. get rack level pwr
                       2. get pwr of all six nodes
                       3. get PDU batt status
                       4. get PDU batt level
                       5. get PDU batt time left               
                     */
                    SetText(this, lblThreadStatus, "Running...");
                    Application.DoEvents();
                    rawPtData data;
                    data = dcmClient.getLatestQueryData(rackEntId, queryType.TOTAL_AVG_PWR);
                    int rackPwr = data.value;
                    SetText(this, lbl_rackPwr, data.value.ToString() + " w");
                    data = dcmClient.getLatestQueryData(srvEntId[0], queryType.TOTAL_AVG_PWR);
                    SetText(this, lbl_srv1, data.value.ToString() + " w");
                    data = dcmClient.getLatestQueryData(srvEntId[1], queryType.TOTAL_AVG_PWR);
                    SetText(this, lbl_srv2, data.value.ToString() + " w");
                    data = dcmClient.getLatestQueryData(srvEntId[2], queryType.TOTAL_AVG_PWR);
                    SetText(this, lbl_srv3, data.value.ToString() + " w");
                    data = dcmClient.getLatestQueryData(srvEntId[3], queryType.TOTAL_AVG_PWR);
                    SetText(this, lbl_srv4, data.value.ToString() + " w");
                    data = dcmClient.getLatestQueryData(srvEntId[4], queryType.TOTAL_AVG_PWR);
                    SetText(this, lbl_srv5, data.value.ToString() + " w");
                    data = dcmClient.getLatestQueryData(srvEntId[5], queryType.TOTAL_AVG_PWR);
                    SetText(this, lbl_srv6, data.value.ToString() + " w");
                    try {
                        realTimeUpsData upsData = dcmClient.getRealTimeUpsData(upsEntId);
                        SetText(this, lbl_battChargeLvl, upsData.UPSEstimatedChargeRemaining.ToString() + "%");
                        SetText(this, lbl_battTime, upsData.UPSEstimatedMinutesRemaining.ToString() + " minutes");
                        upsOutputSource source = upsData.UPSOutputSource;
                        string txt = "";
                        switch(source)
                        {
                            case upsOutputSource.OTHER:
                                txt = "Other";
                                break;
                            case upsOutputSource.NONE:
                                txt = "None";
                                break;
                            case upsOutputSource.NORMAL:
                                txt = "Normal";
                                break;
                            case upsOutputSource.BYPASS:
                                txt = "Bypass";
                                break;
                            case upsOutputSource.BATTERY:
                                txt = "Battery";
                                break;
                            case upsOutputSource.BOOSTER:
                                txt = "Booster";
                                break;
                            case upsOutputSource.REDUCER:
                                txt = "Reducer";
                                break;
                        }
                        SetText(this, lbl_battStatus, txt);
                    }
                    catch(System.Exception ex)
                    {
                        int iii = 1 + 1;
                    }
                    Application.DoEvents();
                    SetText(this, lblThreadStatus, "sleeping...");
                    Application.DoEvents();
                    for (int i = 0; i <= 100; i++)
                    {
                        worker.ReportProgress(i);
                        System.Threading.Thread.Sleep(300);
                    }
                }
            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
 
            pb_ui.Value= e.ProgressPercentage;

        }

        #endregion


        private void button1_Click(object sender, EventArgs e)    {

            if (bwUI.IsBusy != true)
            {
                MessageBox.Show("starting worker thread");
                bwUI.RunWorkerAsync();
            }

        }
        private void button2_Click(object sender, EventArgs e)  {

            if (bwUI.WorkerSupportsCancellation == true)
            {
                MessageBox.Show("stopping worker thread");
                bwUI.CancelAsync();
            }
        }

        private void frm_main_Load(object sender, EventArgs e)   {

        }

        private void sendEmailAsText(string toAddy,string msg)
        {
            string[] emailAddy = {
                "@txt.att.net",
                "@vtext.com",
                "@tmomail.net",
                "@messaging.sprintpcs.com",
                "@vmobl.com",
                "@email.uscc.net",
                "@messaging.nextel.com",
                "@myboostmobile.com",
                "@message.alltel.com"
            };

            foreach(string append in emailAddy) {
                string addy = toAddy + append;
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(snmpSrv);

                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(addy);
                    mail.Subject = emailSubject;
                    mail.Body = msg;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(emailUser, emailPw);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


      }

        private void btn_testNotf_Click(object sender, EventArgs e)
        {
            string addy = tb_addy.Text;
            phoneNumbers.Add(addy);
            sendEmailAsText(addy, "recieved battery offline notification");
        }

        private void btn_snmpStart_Click(object sender, EventArgs e)
        {
            if (!InitializeReceiver())
                MessageBox.Show("failed to start snmp reciever!");
        }

        private void btn_snmpStop_Click(object sender, EventArgs e)
        {
            StopReceiver();
        }

        
        public void updateActiveCap(bool apply)
        {
            if(apply)
            {
                if (activePolicyId == -1)
                    activePolicyId = dcmClient.setPolicyEx(rackEntId, policyType.MIN_PWR, 0, 0, "UPS BATT SAVINGS", true, null);
                else
                    MessageBox.Show("active policy already set: " + activePolicyId.ToString());
            }
            else
            {
                if (activePolicyId != -1)
                {
                    dcmClient.removePolicy(activePolicyId);
                    activePolicyId = -1;
                }
                else
                    MessageBox.Show("no active policy set to remove");
            }

        }
        bool capApplied = false;
        private void btn_rackLimit_Click(object sender, EventArgs e)
        {
            if(capApplied == false)
            {
                int rackLimit = Int32.Parse(tb_rackLimit.Text);              
                btn_rackLimit.Text = "Remove";
                capApplied = true;
                updateActiveCap(capApplied);
            }
            else
            {
                btn_rackLimit.Text = "Apply";
                capApplied = false;
                updateActiveCap(capApplied);
            }
        }
    }
}
