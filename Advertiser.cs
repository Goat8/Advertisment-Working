using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace Assignment01
{
    class Advertiser
    {

        delegate void DoubleOp(double x);



        private string username;
        private string password;
        private string emailID;

        public Advertiser(string username, string password, string emailID)
        {
            this.username = username;
            this.password = password;
            this.emailID = emailID;
        }


        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string EmailID
        {
            get
            {
                return emailID;
            }

            set
            {
                emailID = value;
            }
        }
        public Advert createAD(string Interest, int age, string genderr)
        {
            Console.WriteLine("Write subject of Your NewsLetter..  ");
            string subj = Console.ReadLine();
            Console.WriteLine("Write body of Your NewsLetter..  ");
            string mess = Console.ReadLine();
            Advert newad = new Advert(Interest, subj, mess);






            return newad;


        }


       public   void SendEmail(string toAddress, string subject, string body)
        {
            string your_id = "mariarafique12@gmail.com";
            string your_password = "mariarafiquebest";
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(your_id, your_password),
                    Timeout = 10000,
                };
                MailMessage mm = new MailMessage(your_id, toAddress, subject, body);
                client.Send(mm);
                Console.WriteLine("Email Sent");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not end email\n\n" + e.ToString());
            }
        }
    }
}
