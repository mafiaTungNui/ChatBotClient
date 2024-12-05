using ChatBotClient.Forms;
using ChatBotClient.Models;
using ChatBotClient.Services;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ChatBotClient
{
    public partial class LoginForm : Form
    {
        private ApiService apiService;

        public LoginForm()
        {
            InitializeComponent();
            apiService = new ApiService();
        }
        private string EncryptToMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi sang chuỗi hexa
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2")); // "X2" để định dạng theo hệ hexa
                }
                return sb.ToString();
            }
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            // Mã hóa mật khẩu bằng MD5
            var encryptedPassword = EncryptToMD5(password);

            var user = await apiService.Login(username, encryptedPassword);
            if (user != null)
            {
                MessageBox.Show("Đăng nhập thành công!");
                ChatForm chatForm = new ChatForm(user.UserID);
                this.Hide();
                chatForm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.Show();
        }
    }
}
