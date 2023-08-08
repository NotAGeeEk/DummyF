using System;

namespace DependencyInjectionDemo
{
    // Interface representing the dependency
    public interface IEmailService
    {
        void SendEmail(string recipient, string message);
    }

    // Concrete implementation of the dependency
    public class EmailService : IEmailService
    {
        public void SendEmail(string recipient, string message)
        {
            Console.WriteLine($"Sending email to {recipient}: {message}");
        }
    }

    // Class that requires the dependency
    public class NotificationService
    {
        private readonly IEmailService _emailService;

        public NotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void NotifyUser(string username, string message)
        {
            _emailService.SendEmail(username, message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the EmailService
            IEmailService emailService = new EmailService();

            // Create an instance of the NotificationService with the EmailService dependency
            NotificationService notificationService = new NotificationService(emailService);

            // Use the NotificationService to send a notification
            notificationService.NotifyUser("amanhere21@gmail.com", "Your account has been updated.");

            // Output:
            // Sending email to amanhere21@gmail.com: Your account has been updated.
        }
    }
}