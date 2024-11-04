namespace ChatBotClient.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenLoginForm = new System.Windows.Forms.Button();
            this.btnOpenRegisterForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenLoginForm
            // 
            this.btnOpenLoginForm.Location = new System.Drawing.Point(236, 247);
            this.btnOpenLoginForm.Name = "btnOpenLoginForm";
            this.btnOpenLoginForm.Size = new System.Drawing.Size(109, 35);
            this.btnOpenLoginForm.TabIndex = 0;
            this.btnOpenLoginForm.Text = "Đăng Nhập";
            this.btnOpenLoginForm.UseVisualStyleBackColor = true;
            this.btnOpenLoginForm.Click += new System.EventHandler(this.btnOpenLoginForm_Click);
            // 
            // btnOpenRegisterForm
            // 
            this.btnOpenRegisterForm.Location = new System.Drawing.Point(447, 247);
            this.btnOpenRegisterForm.Name = "btnOpenRegisterForm";
            this.btnOpenRegisterForm.Size = new System.Drawing.Size(109, 35);
            this.btnOpenRegisterForm.TabIndex = 1;
            this.btnOpenRegisterForm.Text = "Đăng Ký";
            this.btnOpenRegisterForm.UseVisualStyleBackColor = true;
            this.btnOpenRegisterForm.Click += new System.EventHandler(this.btnOpenRegisterForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOpenRegisterForm);
            this.Controls.Add(this.btnOpenLoginForm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenLoginForm;
        private System.Windows.Forms.Button btnOpenRegisterForm;
    }
}