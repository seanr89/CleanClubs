

namespace Emails.App
{
    /// <summary>
    /// Abstract class to move out and support different email content being created!
    /// TOOD: review match creation logic to enhance the abstraction!
    /// </summary>
    public abstract class AbstractMessageGenerator
    {
        public abstract string GenerateMessage();
    }
}