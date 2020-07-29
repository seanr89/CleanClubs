

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Clubs.Domain.Entities;
using Emails.App;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Utilities;

namespace Clubs.Application.Business
{
    public class SimpleEmailHandler
    {
        private readonly ILogger<SimpleEmailHandler> _Logger;
        private readonly EmailSettings _EmailSettings;
        public SimpleEmailHandler(ILogger<SimpleEmailHandler> logger, IOptions<EmailSettings> settings)
        {
            _Logger = logger;
            _EmailSettings = settings.Value;
        }

        public async Task GenerateAndSendInviteEmails(IEnumerable<Invite> invites, Match match)
        {
            foreach (var invite in invites)
            {
                var content = generateEmailContent(invite, match);

                await SendEmail(invite, content);
            }
        }

        private string generateEmailContent(Invite inv, Match match)
        {
            string message = "";

            message = $@"<p>A match has been scheduled</p>
            
                    <p>Please select one of the below options</p>
                    
                    <span>
                    <a href=""{_EmailSettings.APIURL}/AcceptInvite/{inv.Id}"" target=""_blank""><button>Accept</button></a>
                    <a href=""{_EmailSettings.APIURL}/DeclineInvite/{inv.Id}"" target=""_blank""><button>Decline</button></a>
                    </span>
                    
                    <p>Please do not reply to this email</p>
                    <p>Kind regards,</p>
                    <p><strong>Clubs Api</strong></p>";



            return message;
        }

        private async Task<bool> SendEmail(Invite invite, string message)
        {
            try
            {
                var client = new SendGridClient(_EmailSettings.AccessKey);
                var from = new EmailAddress(_EmailSettings.SenderEmail, "Clubs App");
                var to = new EmailAddress(invite.Email);
                var subject = "Match Invitation";
                var plainTextContent = $@"Message:";
                var htmlContent = message;

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = await client.SendEmailAsync(msg);

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted)
                {
                    return true;
                }
                _Logger.LogError($"{HelperMethods.GetCallerMemberName()} - Failed to send email {invite.Email}");
                return false;
            }
            catch (Exception e)
            {
                _Logger.LogError($"EmailManager errored sending an email to {invite.Email} with exception: {e.Message}");
                return false;
            }
        }
    }
}