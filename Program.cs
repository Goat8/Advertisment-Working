using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;

namespace Assignment01
{
    struct report {
     public   string em;
     public  int coun;
    }

    class Program
    {

        public delegate void AdvertiserSendEmail(string x,string y,string z);

        public delegate void EmailSendHandler(object source, EventArgs args);
        public event EmailSendHandler emailsent;

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        protected virtual void OnEmailSent()
        {

            if (emailsent != null)
            {
                // this : is for who is publishing the event e.g our current class
                emailsent(this, EventArgs.Empty);

            }

        }

        public  void SENDINTERESTEDEMAILS(ArrayList InterestList, ArrayList NewsLetters, string emailadd) {

            foreach (object o1 in InterestList)
            {

                foreach (Advert o in NewsLetters)
                {
                    if (o != null)
                    {

                        if (o.Interest1.Equals(o1))
                        {

                            Console.WriteLine("the interest is" + o.Interest1);
                            SendEmail1(emailadd, o.Mailsubject1, o.Message);

                        }


                    }

                    //use o her
                }


            }
           
            OnEmailSent();
        }
        public static void ReportGeneration(string ID , int count, ArrayList temprep) {

            //bramshq@gmail.com

            string path = @"C:\Users\MariaFeelFree\Documents\Visual Studio 2015\Projects\Assignment01\Assignment01\report.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine("The very first line!");
                tw.Close();

            }
            else if (File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path);
                foreach (report r in temprep){
                    
                    tw.WriteLine(r.em+":"+r.coun);
                }

                tw.Close();
            }




        }


        protected static void SendEmail1(string toAddress, string subject, string body)
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
                Console.WriteLine("Sending Email . . . .");
                client.Send(mm);
                
               // Console.WriteLine("Email Sent");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not end email\n\n" + e.ToString());
            }
        }

        static void Main(string[] args)
        {
            ArrayList Subscribers = new ArrayList();
            ArrayList reportarray = new ArrayList();
            
         /* 
            int counter1 = 0;
            string line1;

            // Read the file and display it line by line.
            System.IO.StreamReader file1 =
               new System.IO.StreamReader(@"H:\report.txt");
            while ((line1 = file1.ReadLine()) != null)
            {
                string[] namesArray1 = line1.Split(':');
                report obj;
                obj.em = namesArray1[0];
                obj.coun =  Convert.ToInt32(namesArray1[1]);
                reportarray.Add(obj);
                Console.WriteLine(line1);
                counter1++;
            }

            file1.Close();*/


            // ====================
            int counter = 0;
                    string line;

                    // Read the file and display it line by line.
                    System.IO.StreamReader file =
                       new System.IO.StreamReader(@"C:\Users\MariaFeelFree\Documents\Visual Studio 2015\Projects\Assignment01\Assignment01\subsription.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] namesArray = line.Split(':');
                        Subscribers.Add(new Member(namesArray[0], namesArray[1], int.Parse(namesArray[2]), namesArray[3], namesArray[4], int.Parse(namesArray[5]), namesArray[6]));
                      //  Console.WriteLine(line);
                        counter++;
                    }

                    file.Close();

            //======================
            ArrayList NewsLetters = new ArrayList();
            NewsLetters.Add(new Advert("Games","NewAreaForGamers","Hello Do you know"));
            NewsLetters.Add(new Advert("Fashion", "Fashion with 2016", "JenniferLawrence on Red Carpet"));
            NewsLetters.Add(new Advert("Sports", "RONADLO", "FIFA WORLD"));
            NewsLetters.Add(new Advert("Food", "JUK", "MACDONAL RE"));
            NewsLetters.Add(new Advert("Vehicles", "RERRARI", "LOG MA"));
            NewsLetters.Add(new Advert("Books", "khalil Gibran", "the prophet"));
            NewsLetters.Add(new Advert("Travel", "MARGALLA", "YOLO"));
            NewsLetters.Add(new Advert("Finance", "home expesne", "balance them.."));
            bool SignOut = false;
            do {
                Console.WriteLine("******************WELCOME TO OUR NEWSLETTER**************");
                if (args.Length != 0)
                {

                    string user = args[0];
                    string pass = args[1];
                    Console.WriteLine("Advertiser  :   " + user);
                    Console.WriteLine("Password  :" + pass);
                    Advertiser Publisher = new Advertiser(user, pass, "mariarafique12@gmail.com");
                    Console.WriteLine("*************Welcome******************");
                    Console.WriteLine("*************CREATE AD******************");
                    Console.WriteLine("On what Interest basis do you want to create ad for members");
                    Console.WriteLine("*******************INTERESTS**************************");
                    Console.WriteLine("1.BOOKS/Literature");
                    Console.WriteLine("2.Fashion");
                    Console.WriteLine("3.Finance");
                    Console.WriteLine("4.Food/Drinks");
                    Console.WriteLine("5.Games/Sports");
                    Console.WriteLine("6.News");
                    Console.WriteLine("7.Travel");
                    Console.WriteLine("8.Vehicles");
                    int InterestOption = 0;// Convert.ToInt32(Console.ReadLine());
                    ArrayList InterestList = new ArrayList();
                    string x = "y";
                    int agee = 0;
                    string gend = "";
                    string inter = "";
                    do
                    {

                        Console.WriteLine("**************Enter Interest *********************");
                        InterestOption = Convert.ToInt32(Console.ReadLine());
                        switch (InterestOption)
                        {
                            case 1:
                                InterestList.Add("BOOKS");
                                inter = "BOOKS";
                                Console.WriteLine("Enter Age Group !!");
                                agee=  Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op = Convert.ToInt32(Console.ReadLine());
                                if (op==1) {
                                    gend = "female";
                                }
                                else if (op==2) {
                                    gend = "male";
                                }

                                break;
                            case 2:
                                InterestList.Add("Fashion");
                                InterestList.Add("Fashion");
                                inter = "Fashion";
                                Console.WriteLine("Enter Age Group !!");
                                agee = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op3 = Convert.ToInt32(Console.ReadLine());
                                if (op3 == 1)
                                {
                                    gend = "female";
                                }
                                else if (op3 == 2)
                                {
                                    gend = "male";
                                }
                                break;
                            case 3:
                                InterestList.Add("Finance");
                                InterestList.Add("Finance");
                                inter = "Finance";
                                Console.WriteLine("Enter Age Group !!");
                                agee = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op4 = Convert.ToInt32(Console.ReadLine());
                                if (op4 == 1)
                                {
                                    gend = "female";
                                }
                                else if (op4 == 2)
                                {
                                    gend = "male";
                                }
                                break;
                            case 4:
                                InterestList.Add("Food");
                              
                                InterestList.Add("Food");
                                inter = "Food";
                                Console.WriteLine("Enter Age Group !!");
                                agee = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op5 = Convert.ToInt32(Console.ReadLine());
                                if (op5 == 1)
                                {
                                    gend = "female";
                                }
                                else if (op5 == 2)
                                {
                                    gend = "male";
                                }
                                break;
                            case 5:
                                InterestList.Add("Games");
                                inter = "Games";
                                Console.WriteLine("Enter Age Group !!");
                                agee = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op1 = Convert.ToInt32(Console.ReadLine());
                                if (op1 == 1)
                                {
                                    gend = "female";
                                }
                                else if (op1 == 2)
                                {
                                    gend = "male";
                                }



                                break;
                            case 6:
                                InterestList.Add("News");
                                
                             
                                inter = "News";
                                Console.WriteLine("Enter Age Group !!");
                                agee = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op6 = Convert.ToInt32(Console.ReadLine());
                                if (op6 == 1)
                                {
                                    gend = "female";
                                }
                                else if (op6 == 2)
                                {
                                    gend = "male";
                                }
                                break;
                            case 7:
                                InterestList.Add("Travel");
                               
                                InterestList.Add("Travel");
                                inter = "Travel";
                                Console.WriteLine("Enter Age Group !!");
                                agee = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op7 = Convert.ToInt32(Console.ReadLine());
                                if (op7 == 1)
                                {
                                    gend = "female";
                                }
                                else if (op7 == 2)
                                {
                                    gend = "male";
                                }
                                break;
                            case 8:
                                InterestList.Add("Vehicles");
                              
                                InterestList.Add("Vehilces");
                                inter = "Vehicles";
                                Console.WriteLine("Enter Age Group !!");
                                agee = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("For which Gender Group");
                                Console.WriteLine("    1.Female");
                                Console.WriteLine("    2.Male");
                                int op8 = Convert.ToInt32(Console.ReadLine());
                                if (op8 == 1)
                                {
                                    gend = "female";
                                }
                                else if (op8 == 2)
                                {
                                    gend = "male";
                                }
                                break;
                            default:

                                break;
                        }




                        Console.WriteLine("Do You want to choose more y/n ?? ");
                        x = Console.ReadLine();
                    } while (x.Equals("y"));

                    Advert caller = new Advert();
                   
                    Advert AD= Publisher.createAD(inter, agee, gend);
                    AdvertiserSendEmail Sending = new AdvertiserSendEmail(Publisher.SendEmail);
                    //===========================================
                    foreach (Member m1 in Subscribers) {


                        ArrayList intt  = m1.Interests1;
                        foreach (string t in intt) {
                            if (t.Equals(inter) && (m1.Age ==agee) && (m1.Gender.Equals(gend))) {
                                Sending(m1.Uemail1, AD.Mailsubject1,AD.Message);
                                m1.ReturnCounter();
                               
                                int counter1 = 0;
                                string line1;

                                // Read the file and display it line by line.
                                System.IO.StreamReader file1 =
                                   new System.IO.StreamReader(@"H:\report.txt");
                                while ((line1 = file1.ReadLine()) != null)
                                {
                                    string[] namesArray1 = line1.Split(':');
                                    report obj;
                                    obj.em = namesArray1[0];
                                    obj.coun = Convert.ToInt32(namesArray1[1]);
                                    reportarray.Add(obj);
                                    Console.WriteLine(line1);
                                    counter1++;
                                }

                                file1.Close();
                                int count1 = 0;
                                for (int k = 0; k < reportarray.Count; k++)
                                {
                                    report obj = (report)reportarray[k];
                                    string g = obj.em;
                                    if (g.Equals(m1.Uemail1))
                                    {
                                        count1 = obj.coun;
                                        count1++;
                                        obj.coun = count1;
                                        reportarray[k] = obj;
                                        m1.NumberOfEmails1 = count1;

                                    }

                                }
                                ReportGeneration(m1.Uemail1, m1.NumberOfEmails1, reportarray);

                            }

                        }
                           



                    }


                    //===========================================

                }
                else {
                   // Upper:
                    Console.WriteLine("************     1. SignUp      ***********");
                    Console.WriteLine("************     2. SignIn      ***********");
                    int Option = Convert.ToInt32(Console.ReadLine());
                    if (Option == 1) {
                        Console.WriteLine("------Enter Full Name--------");
                        string enteredName = Console.ReadLine();
                        if (enteredName.Contains(" "))
                        {

                        }
                        else {

                            Console.WriteLine("!!! Enter Full Name Please ");
                            enteredName = Console.ReadLine();

                        }
                        Console.WriteLine("--------Gender--------");
                        string Gend = Console.ReadLine();
                        Console.WriteLine("---------Age--------");
                        int Ag = Convert.ToInt32(Console.ReadLine());
                        if (Ag <= 0) {
                            Console.WriteLine("!!! Enter Your Right Age Please ");
                            Ag = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("--------Email ID--------");
                        string emailadd = Console.ReadLine();
                        if (emailadd.Contains("@"))
                        {

                        }
                        else {
                            Console.WriteLine("!!! Please Include an '@' in the email address ");
                            Console.WriteLine("An account with that email address already exists.Please login with your email");
                            emailadd = Console.ReadLine();
                        }
                        Console.WriteLine("---------Set Password--------");
                        string passwrd = Console.ReadLine();
                        Console.WriteLine("---------Confirm Password--------");
                        passwrd = Console.ReadLine();

                        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                        // Now i have to generate random number --
                        int VerriCode = RandomNumber(1, 1000);
                        string myString1 = VerriCode.ToString();
                        string myString = "Your VerrificationCode Is :     " + myString1;

                        //  SendEmail1(emailadd, "VerrificationCode", myString); ************************************
                        Console.WriteLine("VERRIFICATION EMAIL HAVE BEEN SENT");
                  //      goto Upper;

                        //=========================MEMEBR LOGIN VIEW=======================
                        Console.WriteLine("**SIGNED IN**");
                        
                        // Subscribers.Add(currentmemb);
                        Console.WriteLine("*******************INTERESTS**************************");
                        Console.WriteLine("1.BOOKS/Literature");
                        Console.WriteLine("2.Fashion");
                        Console.WriteLine("3.Finance");
                        Console.WriteLine("4.Food/Drinks");
                        Console.WriteLine("5.Games/Sports");
                        Console.WriteLine("6.News");
                        Console.WriteLine("7.Travel");
                        Console.WriteLine("8.Vehicles");



                        int InterestOption = 0;// Convert.ToInt32(Console.ReadLine());
                        ArrayList InterestList = new ArrayList();
                        string x = "y";

                        do
                        {

                            Console.WriteLine("**************Enter Interest *********************");
                            InterestOption = Convert.ToInt32(Console.ReadLine());
                            switch (InterestOption) {
                                case 1:
                                    InterestList.Add("BOOKS");
                                    break;
                                case 2:
                                    InterestList.Add("Fashion");
                                    break;
                                case 3:
                                    InterestList.Add("Finance");
                                    break;
                                case 4:
                                    InterestList.Add("Food");
                                    break;
                                case 5:
                                    InterestList.Add("Games");
                                    break;
                                case 6:
                                    InterestList.Add("News");
                                    break;
                                case 7:
                                    InterestList.Add("Travel");
                                    break;
                                case 8:
                                    InterestList.Add("Vehicles");
                                    break;
                                default:

                                    break;
                            }


                            Console.WriteLine("Do You want to choose more y/n ?? ");
                            x = Console.ReadLine();
                        } while (x.Equals("y"));
                        
                        string INTT = "";
                        int i = 1;
                        foreach(string g in InterestList) {
                            if (i == 1)
                            {
                                INTT = g;
                            }
                            else {
                                INTT = INTT+","+g;

                            }
                            i++;
                            
                        }

                        Console.WriteLine("INNT IS"+INTT);
                            
                            Member currentmemb = new Member(enteredName, Gend, Ag, emailadd, passwrd, VerriCode, INTT); 
                        currentmemb.Interests1 = InterestList;
                        // subscriber
                        Program p = new Program();                                         //before encode mathod, we need subscription
                        p.emailsent += Advert.OnEmailSent;
                        p.SENDINTERESTEDEMAILS(InterestList, NewsLetters, emailadd);

                        string path = @"C:\Users\MariaFeelFree\Documents\Visual Studio 2015\Projects\Assignment01\Assignment01\subsription.txt";
                        if (!File.Exists(path))
                        {
                            File.Create(path);
                            TextWriter tw = new StreamWriter(path);
                          //  tw.WriteLine("The very first line!");
                            tw.Close();
                            
    }
                        else if (File.Exists(path))
                        {
                            TextWriter tw = new StreamWriter(path, true);
                            
                            tw.WriteLine(currentmemb.Fullname+":"+currentmemb.Gender+":"+currentmemb.Age+":"+currentmemb.Uemail1+":"+currentmemb.Password1+":"+currentmemb.VarrificationCode+":"+INTT);
                             
                                tw.Close();
                        }
                        //*************************************************************************************
                        // when user done with choosing interest , the event  generated to notify










                    }
                    else if (Option == 2) {

                        Console.WriteLine("************Login View****************");
                        Reenter:
                        Console.WriteLine("-------Email ID------");
                        string uEmail = Console.ReadLine();
                        Console.WriteLine("-------Password------");
                        string uPasswrd = Console.ReadLine();
                        Console.WriteLine("-------Verrification Code------");
                        int Uverfi = Convert.ToInt32(Console.ReadLine());
                        bool check = false;
                        foreach (Member m in Subscribers) {
                          //  Console.WriteLine(m.Uemail1);
                            if (uEmail.Equals(m.Uemail1) && uPasswrd.Equals(m.Password1) && (m.VarrificationCode == Uverfi))
                            {
                                            
                                            check = true;
                                            Console.WriteLine("*******************INTERESTS**************************");
                                            Console.WriteLine("1.BOOKS/Literature");
                                            Console.WriteLine("2.Fashion");
                                            Console.WriteLine("3.Finance");
                                            Console.WriteLine("4.Food/Drinks");
                                            Console.WriteLine("5.Games/Sports");
                                            Console.WriteLine("6.News");
                                            Console.WriteLine("7.Travel");
                                            Console.WriteLine("8.Vehicles");
                                int InterestOption = 0;// Convert.ToInt32(Console.ReadLine());
                                ArrayList InterestList = new ArrayList();
                                string x = "y";

                                do
                                {

                                    Console.WriteLine("**************Enter Interest *********************");
                                    InterestOption = Convert.ToInt32(Console.ReadLine());
                                    switch (InterestOption)
                                    {
                                        case 1:
                                            InterestList.Add("BOOKS");
                                            break;
                                        case 2:
                                            InterestList.Add("Fashion");
                                            break;
                                        case 3:
                                            InterestList.Add("Finance");
                                            break;
                                        case 4:
                                            InterestList.Add("Food");
                                            break;
                                        case 5:
                                            InterestList.Add("Games");
                                            break;
                                        case 6:
                                            InterestList.Add("News");
                                            break;
                                        case 7:
                                            InterestList.Add("Travel");
                                            break;
                                        case 8:
                                            InterestList.Add("Vehicles");
                                            break;
                                        default:

                                            break;
                                    }


                                    Console.WriteLine("Do You want to choose more y/n ?? ");
                                    x = Console.ReadLine();
                                } while (x.Equals("y"));

                                string INTT = "";
                                int i = 1;
                                foreach (string g in InterestList)
                                {
                                    if (i == 1)
                                    {
                                        INTT = g;
                                    }
                                    else {
                                        INTT = INTT + "," + g;

                                    }
                                    i++;

                                }
                                
                                m.Interests1 = InterestList;
                                Program p = new Program();                                         //before encode mathod, we need subscription
                                p.emailsent += Advert.OnEmailSent;
                                p.SENDINTERESTEDEMAILS(InterestList, NewsLetters, uEmail);
                                m.ReturnCounter();

                                int counter1 = 0;
                                string line1;

                                // Read the file and display it line by line.
                                System.IO.StreamReader file1 =
                                   new System.IO.StreamReader(@"C:\Users\MariaFeelFree\Documents\Visual Studio 2015\Projects\Assignment01\Assignment01\report.txt");
                                while ((line1 = file1.ReadLine()) != null)
                                {
                                    string[] namesArray1 = line1.Split(':');
                                    report obj;
                                    obj.em = namesArray1[0];
                                    obj.coun = Convert.ToInt32(namesArray1[1]);
                                    reportarray.Add(obj);
                                    Console.WriteLine(line1);
                                    counter1++;
                                }

                                file1.Close();

                                if (reportarray.Count==0) {
                                    Console.WriteLine("y i m else");
                                    report obj1;
                                    obj1.em = m.Uemail1;
                                    
                                    obj1.coun = m.NumberOfEmails1;
                                    reportarray.Add(obj1);
                                }


                                int count1 = 0;
                                for (int k=0; k< reportarray.Count;k++) {
                                      report obj = (report)reportarray[k];
                                      string g = obj.em;
                                    Console.WriteLine("^^^^^^^^^^^^^^^"+ m.Uemail1);
                                    Console.WriteLine(g);
                                    if (g.Equals(m.Uemail1)) {
                                        count1 = obj.coun;
                                        Console.WriteLine("***********************"+count1);
                                        count1++;
                                        obj.coun = count1;
                                        reportarray[k] = obj;
                                        Console.WriteLine("**********%%*************" + obj.coun);
                                        m.NumberOfEmails1 = count1;
                                        break;
                                        }

                                }
                               ReportGeneration(m.Uemail1, m.NumberOfEmails1,reportarray);




                                break;
                            }




                          


                        }
                        if (check ==false) {
                            Console.WriteLine("Eneterd Email Or Password Or Uverfi are incorrect!!");
                            Console.WriteLine("Eneterd Again!!");
                            goto Reenter;
                        }

                    }




                }

            } while (!SignOut);

        }
    }
}
