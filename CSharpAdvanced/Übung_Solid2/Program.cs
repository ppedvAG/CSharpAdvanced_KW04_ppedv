using System;

namespace Übung_Solid2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region Bad Sample
    public class BadEmail
    {
        public void SendEmail()
        {
            // code to send mail
        }
    }

    public class BadNotification
    {
        private BadEmail _email;
        public BadNotification()
        {
            _email = new BadEmail();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }
    #endregion


    #region Better Code
    public interface IEmail
    {
        void SendEmail();
    }

    public class Email : IEmail
    {
        public void SendEmail()
        {
            Console.WriteLine("Sende eine Email");
        }
    }

    public interface INotification
    {
        void PromotionalNotification();
        void PromotionalNotification(IEmail email);
    }


    public class Notification : INotification
    {
        private IEmail email;

        public Notification()
        {
            email = new Email();
        }

        public  Notification(IEmail email) //Konstruktor Injection
        {
            this.email = email;
        }



        public void PromotionalNotification()
        {
            email.SendEmail();
        }

        public void PromotionalNotification(IEmail myEmail) //Methoden Injection 
        {
            myEmail.SendEmail();
        }
    }




    #endregion
}
