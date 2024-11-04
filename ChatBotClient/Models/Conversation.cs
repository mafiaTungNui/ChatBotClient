﻿using System;

namespace ChatBotClient.Models
{
    public class Conversation
    {
        public int ConversationID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } // Thay đổi đây
        public string Status { get; set; }
    }

}