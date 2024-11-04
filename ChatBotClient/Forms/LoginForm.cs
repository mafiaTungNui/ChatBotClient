using ChatBotClient.Forms;
using ChatBotClient.Models;
using ChatBotClient.Services;
using System;
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            var user = await apiService.Login(username, password);
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
