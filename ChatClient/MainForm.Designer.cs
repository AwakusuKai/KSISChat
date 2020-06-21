namespace ChatClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorPictureBox = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.ipLabel = new System.Windows.Forms.Label();
            this.serverListLabel = new System.Windows.Forms.Label();
            this.serversListBox = new System.Windows.Forms.ListBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.dialogsLabel = new System.Windows.Forms.Label();
            this.dialogsListBox = new System.Windows.Forms.ListBox();
            this.ShowServersButton = new System.Windows.Forms.Button();
            this.sendPrivateMessageButton = new System.Windows.Forms.Button();
            this.messagesListBox = new System.Windows.Forms.ListBox();
            this.attachedFilesListBox = new System.Windows.Forms.ListBox();
            this.deleteFileButton = new System.Windows.Forms.Button();
            this.addFileButton = new System.Windows.Forms.Button();
            this.messageFileListBox = new System.Windows.Forms.ListBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.chatPartisipantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.colorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatPartisipantBindingSource)).BeginInit();
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
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
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
            this.serverListLabel.Location = new System.Drawing.Point(0, 81);
            this.serverListLabel.Name = "serverListLabel";
            this.serverListLabel.Size = new System.Drawing.Size(226, 20);
            this.serverListLabel.TabIndex = 6;
            this.serverListLabel.Text = "Список доступных серверов:";
            // 
            // serversListBox
            // 
            this.serversListBox.FormattingEnabled = true;
            this.serversListBox.Location = new System.Drawing.Point(4, 104);
            this.serversListBox.Name = "serversListBox";
            this.serversListBox.Size = new System.Drawing.Size(106, 212);
            this.serversListBox.TabIndex = 7;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(244, 80);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(326, 20);
            this.messageTextBox.TabIndex = 10;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(576, 76);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(93, 22);
            this.sendButton.TabIndex = 11;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // dialogsLabel
            // 
            this.dialogsLabel.AutoSize = true;
            this.dialogsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dialogsLabel.Location = new System.Drawing.Point(695, 104);
            this.dialogsLabel.Name = "dialogsLabel";
            this.dialogsLabel.Size = new System.Drawing.Size(137, 20);
            this.dialogsLabel.TabIndex = 12;
            this.dialogsLabel.Text = "Участники чата: ";
            // 
            // dialogsListBox
            // 
            this.dialogsListBox.FormattingEnabled = true;
            this.dialogsListBox.Location = new System.Drawing.Point(689, 149);
            this.dialogsListBox.Name = "dialogsListBox";
            this.dialogsListBox.ScrollAlwaysVisible = true;
            this.dialogsListBox.Size = new System.Drawing.Size(143, 173);
            this.dialogsListBox.TabIndex = 13;
            // 
            // ShowServersButton
            // 
            this.ShowServersButton.Location = new System.Drawing.Point(147, 41);
            this.ShowServersButton.Name = "ShowServersButton";
            this.ShowServersButton.Size = new System.Drawing.Size(178, 23);
            this.ShowServersButton.TabIndex = 14;
            this.ShowServersButton.Text = "Показать доступные сервера";
            this.ShowServersButton.UseVisualStyleBackColor = true;
            this.ShowServersButton.Click += new System.EventHandler(this.ShowServersButton_Click);
            // 
            // sendPrivateMessageButton
            // 
            this.sendPrivateMessageButton.Location = new System.Drawing.Point(576, 104);
            this.sendPrivateMessageButton.Name = "sendPrivateMessageButton";
            this.sendPrivateMessageButton.Size = new System.Drawing.Size(93, 23);
            this.sendPrivateMessageButton.TabIndex = 15;
            this.sendPrivateMessageButton.Text = "Отправить ЛС";
            this.sendPrivateMessageButton.UseVisualStyleBackColor = true;
            this.sendPrivateMessageButton.Click += new System.EventHandler(this.sendPrivateMessageButton_Click);
            // 
            // messagesListBox
            // 
            this.messagesListBox.FormattingEnabled = true;
            this.messagesListBox.Location = new System.Drawing.Point(244, 149);
            this.messagesListBox.Name = "messagesListBox";
            this.messagesListBox.Size = new System.Drawing.Size(425, 160);
            this.messagesListBox.TabIndex = 16;
            this.messagesListBox.SelectedIndexChanged += new System.EventHandler(this.messagesListBox_SelectedIndexChanged);
            // 
            // attachedFilesListBox
            // 
            this.attachedFilesListBox.FormattingEnabled = true;
            this.attachedFilesListBox.Location = new System.Drawing.Point(685, 12);
            this.attachedFilesListBox.Name = "attachedFilesListBox";
            this.attachedFilesListBox.Size = new System.Drawing.Size(147, 69);
            this.attachedFilesListBox.TabIndex = 17;
            // 
            // deleteFileButton
            // 
            this.deleteFileButton.Location = new System.Drawing.Point(576, 40);
            this.deleteFileButton.Name = "deleteFileButton";
            this.deleteFileButton.Size = new System.Drawing.Size(93, 23);
            this.deleteFileButton.TabIndex = 19;
            this.deleteFileButton.Text = "Удалить";
            this.deleteFileButton.UseVisualStyleBackColor = true;
            this.deleteFileButton.Click += new System.EventHandler(this.deleteFileButton_Click);
            // 
            // addFileButton
            // 
            this.addFileButton.Location = new System.Drawing.Point(576, 12);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(93, 22);
            this.addFileButton.TabIndex = 18;
            this.addFileButton.Text = "Добавить";
            this.addFileButton.UseVisualStyleBackColor = true;
            this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
            // 
            // messageFileListBox
            // 
            this.messageFileListBox.FormattingEnabled = true;
            this.messageFileListBox.Location = new System.Drawing.Point(116, 236);
            this.messageFileListBox.Name = "messageFileListBox";
            this.messageFileListBox.Size = new System.Drawing.Size(122, 82);
            this.messageFileListBox.TabIndex = 20;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(133, 207);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(93, 23);
            this.buttonDownload.TabIndex = 21;
            this.buttonDownload.Text = "Скачать";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // chatPartisipantBindingSource
            // 
            this.chatPartisipantBindingSource.DataSource = typeof(ChatLibrary.ChatPartisipant);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 327);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.messageFileListBox);
            this.Controls.Add(this.deleteFileButton);
            this.Controls.Add(this.addFileButton);
            this.Controls.Add(this.attachedFilesListBox);
            this.Controls.Add(this.messagesListBox);
            this.Controls.Add(this.sendPrivateMessageButton);
            this.Controls.Add(this.ShowServersButton);
            this.Controls.Add(this.dialogsListBox);
            this.Controls.Add(this.dialogsLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.serversListBox);
            this.Controls.Add(this.serverListLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.colorPictureBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.nicknameTextBox);
            this.Name = "MainForm";
            this.Text = "Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.colorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatPartisipantBindingSource)).EndInit();
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
        public System.Windows.Forms.ListBox serversListBox;
        public System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label dialogsLabel;
        public System.Windows.Forms.ListBox dialogsListBox;
        private System.Windows.Forms.Button ShowServersButton;
        private System.Windows.Forms.Button sendPrivateMessageButton;
        private System.Windows.Forms.BindingSource chatPartisipantBindingSource;
        private System.Windows.Forms.ListBox messagesListBox;
        private System.Windows.Forms.ListBox attachedFilesListBox;
        private System.Windows.Forms.Button deleteFileButton;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.ListBox messageFileListBox;
        private System.Windows.Forms.Button buttonDownload;
    }
}

