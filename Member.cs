using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{
    class Member
    {

        private string fullname;
        private string gender; // validate F/M check lagana at time of entry
        private int age;        //  always greater that zero 0
        private string Uemail;
        private string Password;
        private int varrificationCode;
        private ArrayList Interests;
        private int NumberOfEmails=0;

        public Member(string fullname, string gender, int age, string Uemail,  string Password, int varrificationCode, string inter)
        {
            this.fullname = fullname;
            this.gender = gender;
            this.age = age;
            this.Uemail = Uemail;
            this.varrificationCode= varrificationCode;
            this.NumberOfEmails = 0;
            this.Password = Password;
      
            this.Interests = new ArrayList();
            if (inter.Contains(","))
            {
                string[] namesArray = inter.Split(',');
                for (int i = 0; i < namesArray.Length; i++)
                {
                    if (namesArray[i]==null)
                    {
                        Console.WriteLine("null");

                    }
                    Interests.Add(namesArray[i]);

                }
            }
            else {
                if (inter!=null) {
                   
                    Interests.Add(inter); }
            }
        }
        public string Fullname
        {
            get
            {
                return fullname;
            }

            set
            {
                fullname = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Uemail1
        {
            get
            {
                return Uemail;
            }

            set
            {
                Uemail = value;
            }
        }

        public int VarrificationCode
        {
            get
            {
                return varrificationCode;
            }

            set
            {
                varrificationCode = value;
            }
        }

        public ArrayList Interests1
        {
            get
            {
                return Interests;
            }

            set
            {
                Interests = value;
            }
        }

        public int NumberOfEmails1
        {
            get
            {
                return NumberOfEmails;
            }

            set
            {
                NumberOfEmails = value;
            }
        }

        public string Password1
        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }

        public  int ReturnCounter() {

            this.NumberOfEmails++;
            return this.NumberOfEmails;
        }
    }
}
