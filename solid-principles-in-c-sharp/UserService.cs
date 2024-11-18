using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;


namespace solid_principles_in_c_sharp
{
    public class UserService
    {
        EmailService _emailService;
        ILogger _logger;
        public UserService(EmailService emailService, ILogger logger)
        {
            _emailService = emailService;
            _logger = logger;
        }
        public void Register(string email, string password)
        {
            if (!_emailService.ValidateEmail(email))
                throw new ValidationException("Email is not an email");

            _emailService.SendEmail(new MailMessage("myname@mydomain.com", email) { Subject = "Hi. How are you!" });
        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class EmailService
    {
        SmtpClient _smtpClient;
        ILogger _logger;

        public EmailService(SmtpClient smtpClient, ILogger logger)
        {
            _smtpClient = smtpClient;
            _logger = logger;
        }
        public virtual bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
        public virtual bool SendEmail(MailMessage message)
        {
            //_smtpClient.Send(message);
            _logger.Log(LogLevel.Information, "Email sent To: {To} Subject: {Subject}", message.To, message.Subject);
            return true;
        }
    }
}
