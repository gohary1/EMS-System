using Demo.DAL.Models;
using System.Net;
using System.Net.Mail;

namespace demo.PL.Helpers
{
    public class EmailSetting
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("abdelrahmanelgohary3@gmail.com", "fskodqbusyvcpwml");
            client.Send("abdelrahmanelgohary2020@gmail.com", email.Recipients, email.Subject, email.Body);
        }
    }
}
