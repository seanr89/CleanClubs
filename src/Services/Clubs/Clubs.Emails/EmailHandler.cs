using System;
using System.Threading;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Logging;

namespace Clubs.Emails
{
    public class EmailHandler
    {
        private readonly ILogger<EmailHandler> _Logger;
        public EmailHandler(ILogger<EmailHandler> logger)
        {
            _Logger = logger;
        }

        public async Task<bool> SendEmail(string email, string messageContent, string subject)
        {
             {
                //Send email with report to users.
                var client = new SendGridClient("apiKey");
                var from = new EmailAddress("srafferty89@gmail.com", "Sean");
                var to = new EmailAddress(email);
                var subject = "Match Invitation";
                var plainTextContent = $@"Message:";
                
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, messageContent);
                
                var response = await client.SendEmailAsync(msg);

                if(response.StatusCode == HttpStatusCode.BadRequest)
                    _Logger.LogError($"Email Manager error triggered in the method: {HelperMethods.GetCallerMemberName()} while sending an email to {testData.Email} with exception: {response}");

                return (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted); ;
            }
            catch
            {
                return false;
            }
        }
    }
}
