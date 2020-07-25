

namespace Emails.App
{
    public class EmailSettings
    {
        public string AccessKey { get; set; }
        public string SenderEmail { get; set; } = "srafferty89@gmail.com";
        public string APIURL {get; set;} = "https://localhost:5001/";
    }
}