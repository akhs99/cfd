using System;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using System.ComponentModel;
using Windows.ApplicationModel.Email;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using EASendMailRT;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            Windows.UI.Popups.MessageDialog dlg5 = new Windows.UI.Popups.MessageDialog("here");
            this.InitializeComponent();
        }

        private void send_mail_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog dlg3= new Windows.UI.Popups.MessageDialog("clicked");

            SendEmail().Wait();

        }
        private async Task SendEmail()
        {
            String Result = "";
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");
                SmtpClient oSmtp = new SmtpClient();
                
                // Set sender email address, please change it to yours 
                oMail.From = new MailAddress("example@outlook.com");

                // Add recipient email address, please change it to yours
                oMail.To.Add(new MailAddress(address:"example@gmail.com"));

                // Add more recipient email address
                // oMail.To.Add(new MailAddress("supportex@emailarchitect.net"));

                // Add CC recipient email address
                // oMail.Cc.Add(new MailAddress("cc@emailarchitect.net"));

                // Add BCC recipient email address
                // oMail.Bcc.Add(new MailAddress("cc@emailarchitect.net"));

                // Set email subject
                oMail.Subject = "test email from C# XAML project";
               
                // Set email body
                oMail.TextBody = "this is a test email sent from Windows Store App, do not reply";

                // Your SMTP server address
                SmtpServer oServer = new SmtpServer("smtp-mail.outlook.com");

                // User and password for ESMTP authentication            
                oServer.User = "xyz@outlook.com";
                oServer.Password = "qljidsx";
                Windows.UI.Popups.MessageDialog dlg1 = new Windows.UI.Popups.MessageDialog("logging");


                // If your SMTP server requires TLS connection on 25 port, please add this line
                // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                // If your SMTP server requires SSL connection on 465 port, please add this line
                 oServer.Port = 587;
                 oServer.ConnectType = SmtpConnectType.ConnectNormal;
                Windows.UI.Popups.MessageDialog dlg2 = new Windows.UI.Popups.MessageDialog("tere");
                await oSmtp.SendMailAsync(oServer, oMail);
                Result = "Email was sent successfully!";
            }
            catch (Exception ep)
            {
                Result = String.Format("Failed to send email with the following error: {0}", ep.Message);
            }

            // Display Result by Diaglog box
            Windows.UI.Popups.MessageDialog dlg = new
                Windows.UI.Popups.MessageDialog(Result);

            await dlg.ShowAsync();
        }
    



    }
}

