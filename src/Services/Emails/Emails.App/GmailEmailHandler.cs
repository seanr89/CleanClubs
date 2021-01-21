using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.Extensions.Options;
using Emails.Domain;
namespace Emails.App
{
    public class GmailEmailHandler
    {
        private readonly ILogger<GmailEmailHandler> _Logger;
        private readonly EmailSettings _EmailSettings;
        public GmailEmailHandler(ILogger<GmailEmailHandler> logger, IOptions<EmailSettings> settings)
        {
            _Logger = logger;
            _EmailSettings = settings.Value;
        }

        /// <summary>
        /// Handle the generation of an invite email!
        /// </summary>
        /// <param name="invites">the collection of invitations to be emailed</param>
        /// <param name="match">The corresponding match!</param>
        /// <returns></returns>
        public async Task GenerateAndSendInviteEmail(Invitation invite)
        {
            var content = generateEmailContent(invite);
            await SendEmail(invite.Email, content, "Match Invitation");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="messageContent"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public async Task<bool> SendEmail(string email, string messageContent, string subject)
        {
            try
            {

                return false;
            }
            catch (Exception e)
            {
                _Logger.LogError($"GmailEmailHandler errored on email: {email}, exception: {e.Message}");
                return false;
            }
        }

    }
}
