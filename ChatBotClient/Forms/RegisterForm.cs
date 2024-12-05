using ChatBotClient.Models;
using ChatBotClient.Services;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ChatBotClient
{
    public partial class RegisterForm : Form
    {
        private ApiService apiService;

        public RegisterForm()
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
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var email = txtEmail.Text;

            // Mã hóa mật khẩu bằng MD5
            var encryptedPassword = EncryptToMD5(password);

            var user = await apiService.Register(username, encryptedPassword, email);
            if (user != null)
            {
                MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.");
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                var error = await apiService.GetLastError();
                MessageBox.Show("Đăng ký thất bại, vui lòng thử lại.\nLỗi từ API: " + error);
            }
        }


    }
}
