using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{
    class Advert
    {

        private string message;
        private string Interest;
        private string Mailsubject;
        private double payment;

        public Advert(string inter, string subject, string messag)
        {

            this.Interest = inter;
            this.Mailsubject = subject;
            this.message = messag;

        }
        public Advert() {

        }
        

        public static void OnEmailSent(object source, EventArgs args)
        {
            Console.WriteLine("WOAH Emails/NewsLetters Sent To Your ID !!!!");
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public string Interest1
        {
            get
            {
                return Interest;
            }

            set
            {
                Interest = value;
            }
        }

        public double Payment
        {
            get
            {
                return payment;
            }

            set
            {
                payment = value;
            }
        }

        public string Mailsubject1
        {
            get
            {
                return Mailsubject;
            }

            set
            {
                Mailsubject = value;
            }
        }
    }
}
