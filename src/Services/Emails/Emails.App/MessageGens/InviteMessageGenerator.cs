

using System;
using Emails.Domain;
using Microsoft.Extensions.Options;

namespace Emails.App
{
    public class InviteMessageGenerator : AbstractMessageGenerator
    {
        private readonly EmailSettings _EmailSettings;
        public InviteMessageGenerator(IOptions<EmailSettings> settings)
        {
            _EmailSettings = settings.Value;
        }

        public string generateInviteEmailContent(Invitation inv)
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

        public override string GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}