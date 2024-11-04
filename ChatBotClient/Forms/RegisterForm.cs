using ChatBotClient.Models;
using ChatBotClient.Services;
using System;
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

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var email = txtEmail.Text;

            var user = await apiService.Register(username, password, email);
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
