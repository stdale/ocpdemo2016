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

//using System.ComponentModel;
using System.Windows;
//using System.Windows.Controls;


namespace amaxOcpSummit2016
{


    public partial class frm_main : Form
    {
        #region class variables

        private BackgroundWorker bwUI = new BackgroundWorker();
        Dcm.DcmClient dcmClient;
        string dcmSrvAddy;
        int rackEntId;
        int[] srvEntId = new int[6];
        int upsEntId;
        string emailFrom;
        string snmpSrv;
        string emailSubject;
        string emailUser;
        string emailPw;
        #endregion

        public frm_main()
        {
            InitializeComponent();
            rackEntId = Int32.Parse(ConfigurationSettings.AppSettings["rackEntId"]);
            for (int i = 1; i < 7; i++)   {
                srvEntId[i -1] = Int32.Parse(ConfigurationSettings.AppSettings["srv" + i.ToString() + "EntId"]);
            }
            upsEntId = Int32.Parse(ConfigurationSettings.AppSettings["upsEntId"]);
            emailFrom = ConfigurationSettings.AppSettings["emailFrom"];
            snmpSrv = ConfigurationSettings.AppSettings["snmpSrv"];
            emailSubject = ConfigurationSettings.AppSettings["emailSubject"];
            emailUser = ConfigurationSettings.AppSettings["emailUser"];
            emailPw = ConfigurationSettings.AppSettings["emailPw"];
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            dcmClient = new Dcm.DcmClient();
            string ver = dcmClient.getVersion();

            bwUI.WorkerReportsProgress = false;
            bwUI.WorkerSupportsCancellation = true;
            bwUI.DoWork += new DoWorkEventHandler(bw_DoWorkUI);
            MessageBox.Show(ver);
        }

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
                    System.Threading.Thread.Sleep(10000);
                    
                }
            }
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
            sendEmailAsText(addy, "recieved battery offline notification");
        }

    }
}
