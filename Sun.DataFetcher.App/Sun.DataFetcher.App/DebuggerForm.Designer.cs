
namespace Sun.DataFetcher.App
{
    partial class DebuggerForm
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
            this.btnGetRecords = new System.Windows.Forms.Button();
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.btnUpdateTest = new System.Windows.Forms.Button();
            this.txtTransID = new System.Windows.Forms.TextBox();
            this.btnWebSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSyncTest = new System.Windows.Forms.Button();
            this.txtEnc_Dec = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetRecords
            // 
            this.btnGetRecords.Location = new System.Drawing.Point(13, 13);
            this.btnGetRecords.Name = "btnGetRecords";
            this.btnGetRecords.Size = new System.Drawing.Size(150, 23);
            this.btnGetRecords.TabIndex = 0;
            this.btnGetRecords.Text = "Get Records by Limit";
            this.btnGetRecords.UseVisualStyleBackColor = true;
            this.btnGetRecords.Click += new System.EventHandler(this.btnGetRecords_Click);
            // 
            // rchText
            // 
            this.rchText.Location = new System.Drawing.Point(12, 42);
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(367, 106);
            this.rchText.TabIndex = 1;
            this.rchText.Text = "";
            // 
            // btnUpdateTest
            // 
            this.btnUpdateTest.Location = new System.Drawing.Point(275, 12);
            this.btnUpdateTest.Name = "btnUpdateTest";
            this.btnUpdateTest.Size = new System.Drawing.Size(104, 23);
            this.btnUpdateTest.TabIndex = 2;
            this.btnUpdateTest.Text = "Update Test";
            this.btnUpdateTest.UseVisualStyleBackColor = true;
            this.btnUpdateTest.Click += new System.EventHandler(this.btnUpdateTest_Click);
            // 
            // txtTransID
            // 
            this.txtTransID.Location = new System.Drawing.Point(169, 12);
            this.txtTransID.Name = "txtTransID";
            this.txtTransID.Size = new System.Drawing.Size(100, 23);
            this.txtTransID.TabIndex = 3;
            // 
            // btnWebSend
            // 
            this.btnWebSend.Location = new System.Drawing.Point(395, 84);
            this.btnWebSend.Name = "btnWebSend";
            this.btnWebSend.Size = new System.Drawing.Size(114, 23);
            this.btnWebSend.TabIndex = 4;
            this.btnWebSend.Text = "Send to Web API";
            this.btnWebSend.UseVisualStyleBackColor = true;
            this.btnWebSend.Click += new System.EventHandler(this.btnRabbitSend_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(395, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Get Auth Token";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSyncTest
            // 
            this.btnSyncTest.Location = new System.Drawing.Point(395, 125);
            this.btnSyncTest.Name = "btnSyncTest";
            this.btnSyncTest.Size = new System.Drawing.Size(116, 23);
            this.btnSyncTest.TabIndex = 6;
            this.btnSyncTest.Text = "Sync Test";
            this.btnSyncTest.UseVisualStyleBackColor = true;
            this.btnSyncTest.Click += new System.EventHandler(this.btnSyncTest_Click);
            // 
            // txtEnc_Dec
            // 
            this.txtEnc_Dec.Location = new System.Drawing.Point(13, 199);
            this.txtEnc_Dec.Name = "txtEnc_Dec";
            this.txtEnc_Dec.Size = new System.Drawing.Size(497, 23);
            this.txtEnc_Dec.TabIndex = 8;
            this.txtEnc_Dec.TextChanged += new System.EventHandler(this.txtEnc_Dec_TextChanged);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(294, 228);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(104, 23);
            this.btnEncrypt.TabIndex = 9;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(407, 228);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(104, 23);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Copy and paste the connection string to encrypt or decrypt";
            // 
            // DebuggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 288);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtEnc_Dec);
            this.Controls.Add(this.btnSyncTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWebSend);
            this.Controls.Add(this.txtTransID);
            this.Controls.Add(this.btnUpdateTest);
            this.Controls.Add(this.rchText);
            this.Controls.Add(this.btnGetRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DebuggerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debugger Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetRecords;
        private System.Windows.Forms.RichTextBox rchText;
        private System.Windows.Forms.Button btnUpdateTest;
        private System.Windows.Forms.TextBox txtTransID;
        private System.Windows.Forms.Button btnWebSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSyncTest;
        private System.Windows.Forms.TextBox txtEnc_Dec;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label1;
    }
}