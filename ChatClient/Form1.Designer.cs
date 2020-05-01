namespace ChatClient
{
    partial class chatForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorPictureBox = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.ipLabel = new System.Windows.Forms.Label();
            this.serverListLabel = new System.Windows.Forms.Label();
            this.serversListBox = new System.Windows.Forms.ListBox();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.currentDialogLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.dialogsLabel = new System.Windows.Forms.Label();
            this.dialogsListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Location = new System.Drawing.Point(103, 12);
            this.nicknameTextBox.MaxLength = 30;
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Size = new System.Drawing.Size(174, 20);
            this.nicknameTextBox.TabIndex = 0;
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Location = new System.Drawing.Point(1, 15);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(96, 13);
            this.nicknameLabel.TabIndex = 1;
            this.nicknameLabel.Text = "Введите никнейм";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(297, 10);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(90, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(1, 47);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(83, 13);
            this.colorLabel.TabIndex = 3;
            this.colorLabel.Text = "Выберите цвет";
            // 
            // colorPictureBox
            // 
            this.colorPictureBox.BackColor = System.Drawing.Color.Black;
            this.colorPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPictureBox.Location = new System.Drawing.Point(103, 41);
            this.colorPictureBox.Name = "colorPictureBox";
            this.colorPictureBox.Size = new System.Drawing.Size(19, 19);
            this.colorPictureBox.TabIndex = 4;
            this.colorPictureBox.TabStop = false;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(463, 15);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(0, 13);
            this.ipLabel.TabIndex = 5;
            // 
            // serverListLabel
            // 
            this.serverListLabel.AutoSize = true;
            this.serverListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serverListLabel.Location = new System.Drawing.Point(12, 78);
            this.serverListLabel.Name = "serverListLabel";
            this.serverListLabel.Size = new System.Drawing.Size(226, 20);
            this.serverListLabel.TabIndex = 6;
            this.serverListLabel.Text = "Список доступных серверов:";
            // 
            // serversListBox
            // 
            this.serversListBox.FormattingEnabled = true;
            this.serversListBox.Location = new System.Drawing.Point(16, 110);
            this.serversListBox.Name = "serversListBox";
            this.serversListBox.Size = new System.Drawing.Size(222, 212);
            this.serversListBox.TabIndex = 7;
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(297, 148);
            this.chatTextBox.Multiline = true;
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(326, 174);
            this.chatTextBox.TabIndex = 8;
            // 
            // currentDialogLabel
            // 
            this.currentDialogLabel.AutoSize = true;
            this.currentDialogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentDialogLabel.Location = new System.Drawing.Point(293, 116);
            this.currentDialogLabel.Name = "currentDialogLabel";
            this.currentDialogLabel.Size = new System.Drawing.Size(136, 20);
            this.currentDialogLabel.TabIndex = 9;
            this.currentDialogLabel.Text = "Текущий диалог:";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(297, 80);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(326, 20);
            this.messageTextBox.TabIndex = 10;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(629, 78);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(90, 22);
            this.sendButton.TabIndex = 11;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // dialogsLabel
            // 
            this.dialogsLabel.AutoSize = true;
            this.dialogsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dialogsLabel.Location = new System.Drawing.Point(641, 116);
            this.dialogsLabel.Name = "dialogsLabel";
            this.dialogsLabel.Size = new System.Drawing.Size(82, 20);
            this.dialogsLabel.TabIndex = 12;
            this.dialogsLabel.Text = "Диалоги: ";
            // 
            // dialogsListBox
            // 
            this.dialogsListBox.FormattingEnabled = true;
            this.dialogsListBox.Location = new System.Drawing.Point(645, 148);
            this.dialogsListBox.Name = "dialogsListBox";
            this.dialogsListBox.Size = new System.Drawing.Size(143, 173);
            this.dialogsListBox.TabIndex = 13;
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 327);
            this.Controls.Add(this.dialogsListBox);
            this.Controls.Add(this.dialogsLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.currentDialogLabel);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.serversListBox);
            this.Controls.Add(this.serverListLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.colorPictureBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.nicknameTextBox);
            this.Name = "chatForm";
            this.Text = "Чат";
            ((System.ComponentModel.ISupportInitialize)(this.colorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nicknameTextBox;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.PictureBox colorPictureBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label serverListLabel;
        private System.Windows.Forms.ListBox serversListBox;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Label currentDialogLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label dialogsLabel;
        private System.Windows.Forms.ListBox dialogsListBox;
    }
}

