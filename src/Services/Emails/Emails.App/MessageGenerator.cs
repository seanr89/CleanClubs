

namespace Emails.App
{
    /// <summary>
    /// Abstract class to move out and support different email content being created!
    /// </summary>
    public abstract class MessageGenerator
    {
        public abstract string GenerateMessage();
    }
}