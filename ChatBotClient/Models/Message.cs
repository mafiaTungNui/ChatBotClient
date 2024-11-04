using System;

namespace ChatBotClient.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int ConversationID { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
