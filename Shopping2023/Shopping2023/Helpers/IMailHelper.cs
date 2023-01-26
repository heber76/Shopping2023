using Shopping2023.Common;

namespace Shopping2023.Helpers
{
    public interface IMailHelper
    {

        Response SendMail(string toName, string toEmail, string subject, string body);
    }
}
