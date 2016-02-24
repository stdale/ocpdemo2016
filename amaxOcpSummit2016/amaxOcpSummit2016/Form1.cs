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

namespace amaxOcpSummit2016
{

    public partial class frm_main : Form
    {
        
        Dcm.DcmClient dcmClient;
        string dcmSrvAddy;
        int rackEntId;
        int[] srvEntId = new int[6];
        string emailFrom;
        string snmpSrv;
        string emailSubject;
        string emailUser;
        string emailPw;

        public frm_main()
        {
            InitializeComponent();
            rackEntId = Int32.Parse(ConfigurationSettings.AppSettings["rackEntId"]);
            for (int i = 1; i < 7; i++)
            {
                string name = "srv" + i.ToString() + "EntId";
                MessageBox.Show(name);
                srvEntId[i -1] = Int32.Parse(ConfigurationSettings.AppSettings["srv" + i.ToString() + "EntId"]);
                MessageBox.Show(srvEntId[i-1].ToString());
            }
            emailFrom = ConfigurationSettings.AppSettings["emailFrom"];
            snmpSrv = ConfigurationSettings.AppSettings["snmpSrv"];
            emailSubject = ConfigurationSettings.AppSettings["emailSubject"];
            emailUser = ConfigurationSettings.AppSettings["emailUser"];
            emailPw = ConfigurationSettings.AppSettings["emailPw"];
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            dcmClient = new Dcm.DcmClient();
            string ver = dcmClient.getVersion();
            MessageBox.Show(ver);
        }

        bool bSwtich = false;

        private void button1_Click(object sender, EventArgs e)
        {
           if(bSwtich == false)
            {
                pnl_extPwr.BackColor = Color.Lime;
                lbl_extPwr.Text = "ON";
                bSwtich = true;
            }else{
                pnl_extPwr.BackColor = Color.Red;
                lbl_extPwr.Text = "OFF";
                bSwtich = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string rackEntId = ConfigurationSettings.AppSettings["rackEntId"];
            lbl_extPwr.Text = rackEntId;

        }

        private void frm_main_Load(object sender, EventArgs e)
        {

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
