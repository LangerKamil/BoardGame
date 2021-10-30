using GamesRental.Infrastructure.Repositories.Interfaces;
using System.Net;
using System.Net.Mail;

namespace GamesRental.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public bool SendEmail(string addresses)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("fortestinpurposes007@gmail.com", "1234QWer"),
                EnableSsl = true,
            };

            smtpClient.Send("fortestinpurposes007@gmail.com", addresses, "You're late!", "You haven't returned our game yet!");
            return true;
        }
    }
}
