using ChatBotClient.Models;
using ChatBotClient.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Message = ChatBotClient.Models.Message;

namespace ChatBotClient
{
    public partial class ChatForm : Form
    {
        private int userId;
        private ApiService apiService;
        private int conversationId;

        public ChatForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.apiService = new ApiService();
            LoadConversations();
        }

        private async void LoadConversations()
        {
            var conversations = await apiService.GetConversationsByUserId(userId);
            if (conversations == null || conversations.Count == 0)
            {
                MessageBox.Show("Không có cuộc hội thoại nào.");
                return;
            }
            cmbConversations.DataSource = conversations;
            cmbConversations.DisplayMember = "ConversationID";
            cmbConversations.ValueMember = "ConversationID";
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string messageText = txtMessage.Text;
            if (string.IsNullOrWhiteSpace(messageText))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn trước khi gửi.");
                return;
            }
            if (conversationId <= 0)
            {
                MessageBox.Show("Cuộc hội thoại không hợp lệ.");
                return;
            }

            var message = new Message
            {
                ConversationID = conversationId,
                Sender = "User",
                MessageText = messageText,
                Timestamp = DateTime.Now
            };

            bool isSent = await apiService.SendMessage(message);
            if (isSent)
            {
                txtMessage.Clear();
                LoadMessages(); // Load lại tất cả các tin nhắn bao gồm cả phản hồi của bot
            }
            else
            {
                LoadMessages();
                MessageBox.Show("Gửi tin nhắn thất bại. Vui lòng thử lại.");
            }
        }

        private void cmbConversations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConversations.SelectedValue is int selectedConversationId)
            {
                conversationId = selectedConversationId;
                LoadMessages();
            }
        }

        private async void LoadMessages()
        {
            var messages = await apiService.GetMessages(conversationId); // Đảm bảo bạn đang sử dụng await ở đây
            lstMessages.Items.Clear();
            foreach (var message in messages)
            {
                lstMessages.Items.Add($"{message.Timestamp}: {message.Sender}: {message.MessageText}");
            }
        }

        private async void btnCreateConversation_Click(object sender, EventArgs e)
        {
            var newConversation = await apiService.CreateConversation(userId);
            if (newConversation == null)
            {
                MessageBox.Show("Hộp hội thoại mới đã được tạo.");
                LoadConversations(); // Tải lại danh sách hội thoại để hiển thị hộp hội thoại vừa tạo
            }
            else
            {
                MessageBox.Show("Không thể tạo hộp hội thoại. Vui lòng thử lại.");
            }
        }
    }
}
