namespace ContactControl.Helpper;

public interface IEmail
{
    bool SendEmail(string email, string subject, string body);
}
