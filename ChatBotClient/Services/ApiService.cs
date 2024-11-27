using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChatBotClient.Models;
using System.Windows.Forms;

namespace ChatBotClient.Services
{
    public class ApiService
    {
        private readonly HttpClient client;

        public ApiService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://171.248.149.41:5000/"); // Địa chỉ API server của bạn
        }

        public async Task<User> Login(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync("/api/Users");
            if (response.IsSuccessStatusCode)
            {
                var usersJson = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(usersJson);
                return users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
            return null;
        }
        public async Task<User> Register(string username, string password, string email)
        {
            var newUser = new User { Username = username, Password = password, Email = email };
            var content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Users/register", content);

            if (response.IsSuccessStatusCode)
            {
                var userJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(userJson);
            }
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error during registration: {errorMessage}");
            }

            return null; // Trả về null nếu không thành công
        }

        public async Task<string> GetLastError()
        {
            var lastResponse = await client.GetAsync(client.BaseAddress + "/api/Users");
            if (!lastResponse.IsSuccessStatusCode)
            {
                return await lastResponse.Content.ReadAsStringAsync();
            }
            return "Không có lỗi cụ thể từ API.";
        }

        public async Task<List<Conversation>> GetConversationsByUserId(int userId)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/Conversations/user/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var conversationsJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Conversation>>(conversationsJson);
            }
            return new List<Conversation>();
        }

        public async Task<bool> SendMessage(Models.Message message)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/Messages", content);

                if (response.IsSuccessStatusCode)
                {
                    // Nhận phản hồi từ API
                    var botResponseJson = await response.Content.ReadAsStringAsync();
                    var botResponse = JsonConvert.DeserializeObject<Models.Message>(botResponseJson);

                    // Kiểm tra nếu botResponse không null và là phản hồi từ chatbot
                    if (botResponse != null && botResponse.Sender == "Bot")
                    {
                        //MessageBox.Show($"{botResponse.Timestamp}: {botResponse.Sender}: {botResponse.MessageText}");
                        return true;
                    }
                }
                else
                {
                    // Ghi log hoặc thông báo lỗi chi tiết
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error in SendMessage: {errorMessage}");
                    MessageBox.Show("Gửi tin nhắn thất bại do lỗi từ phía server.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in SendMessage: {ex.Message}");
                MessageBox.Show("Có lỗi xảy ra khi gửi tin nhắn.");
            }

            return false;
        }

        public async Task<Conversation> CreateConversation(int userId)
        {
            var newConversation = new Conversation { UserID = userId, StartTime = DateTime.Now, Status = "Active" };
            var content = new StringContent(JsonConvert.SerializeObject(newConversation), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Conversations", content);

            if (response.IsSuccessStatusCode)
            {
                var conversationJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Conversation>(conversationJson);
            }
            return null;
        }


        public async Task<List<Models.Message>> GetMessages(int conversationId)
        {
            var response = await client.GetAsync($"/api/Messages?conversationId={conversationId}");
            if (response.IsSuccessStatusCode)
            {
                var messagesJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Models.Message>>(messagesJson);
            }
            return new List<Models.Message>();
        }
    }
}
