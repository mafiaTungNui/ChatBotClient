namespace ChatBotClient
{
    partial class ChatForm
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.cmbConversations = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateConversation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(200, 413);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(507, 25);
            this.txtMessage.TabIndex = 0;
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 17;
            this.lstMessages.Location = new System.Drawing.Point(203, 46);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(585, 361);
            this.lstMessages.TabIndex = 3;
            // 
            // cmbConversations
            // 
            this.cmbConversations.FormattingEnabled = true;
            this.cmbConversations.Location = new System.Drawing.Point(12, 46);
            this.cmbConversations.Name = "cmbConversations";
            this.cmbConversations.Size = new System.Drawing.Size(185, 25);
            this.cmbConversations.TabIndex = 5;
            this.cmbConversations.SelectedIndexChanged += new System.EventHandler(this.cmbConversations_SelectedIndexChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(714, 413);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(74, 25);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hộp hội thoại";
            // 
            // btnCreateConversation
            // 
            this.btnCreateConversation.Location = new System.Drawing.Point(12, 78);
            this.btnCreateConversation.Name = "btnCreateConversation";
            this.btnCreateConversation.Size = new System.Drawing.Size(75, 23);
            this.btnCreateConversation.TabIndex = 8;
            this.btnCreateConversation.Text = "new";
            this.btnCreateConversation.UseVisualStyleBackColor = true;
            this.btnCreateConversation.Click += new System.EventHandler(this.btnCreateConversation_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateConversation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cmbConversations);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.txtMessage);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.ComboBox cmbConversations;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateConversation;
    }
}