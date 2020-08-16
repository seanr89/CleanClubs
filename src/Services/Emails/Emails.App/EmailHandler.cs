using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net;
using Utilities;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Emails.App
{
    public class EmailHandler
    {
        private readonly ILogger<EmailHandler> _Logger;
        private readonly EmailSettings _EmailSettings;
        public EmailHandler(ILogger<EmailHandler> logger, IOptions<EmailSettings> settings)
        {
            _Logger = logger;
            _EmailSettings = settings.Value;
        }

        public async Task<bool> SendEmail(string email, string messageContent, string subject)
        {
            try
            {
                var client = new SendGridClient(_EmailSettings.AccessKey);
                var from = new EmailAddress(_EmailSettings.SenderEmail, "Clubs App");
                var to = new EmailAddress(email);
                var plainTextContent = $@"Message:";
                var htmlContent = messageContent;

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = await client.SendEmailAsync(msg);

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted)
                {
                    return true;
                }
                _Logger.LogError($"{HelperMethods.GetCallerMemberName()} - Failed to send email {email}");
                return false;
            }
            catch (Exception e)
            {
                _Logger.LogError($"EmailManager errored sending an email to {email} with exception: {e.Message}");
                return false;
            }
        }

        private string generateEmailContent(Invite inv, Match match)
        {
            string message = "";

            message = $@"<p>A match has been scheduled</p>
            
                    <p>Please select one of the below options</p>
                    
                    <table cellspacing=""0"" cellpadding=""0"">
                        <tr>
                            <td style=""border-radius: 2px;"" bgcolor=""#ED2939"">
                                <a href=""{_EmailSettings.APIURL}/AcceptInvite/{inv.Id}"" target=""_blank""><button style=""padding: 8px 12px; border: 1px solid #ED2939;border-radius: 2px;font-family: Helvetica, Arial, sans-serif;font-size: 14px; color: #ffffff;text-decoration: none;font-weight:bold"">Accept</button></a>
                                <a href=""{_EmailSettings.APIURL}/DeclineInvite/{inv.Id}"" target=""_blank""><button style=""padding: 8px 12px; border: 1px solid #ED2939;border-radius: 2px;font-family: Helvetica, Arial, sans-serif;font-size: 14px; color: #ffffff;text-decoration: none;font-weight:bold"">Decline</button></a>
                            </td>
                        </tr>
                    </table>
                    
                    <p>Please do not reply to this email</p>
                    <p>Kind regards,</p>
                    <p><strong>Clubs Api</strong></p>";
            return message;
        }
    }
}
