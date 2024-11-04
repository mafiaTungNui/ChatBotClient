using ChatBotClient.Forms;
using System;
using System.Windows.Forms;

namespace ChatBotClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // Màn hình chính của ứng dụng
        }
    }
}
