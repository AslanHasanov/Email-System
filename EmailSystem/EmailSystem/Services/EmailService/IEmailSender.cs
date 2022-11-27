namespace EmailSystem.Services.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
