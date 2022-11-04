
namespace Sun.DataFetcher.App
{
    partial class MainForms
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDebugger = new System.Windows.Forms.Button();
            this.txtRecLimit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQueue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grbConfig = new System.Windows.Forms.GroupBox();
            this.txtNextTrigger = new System.Windows.Forms.TextBox();
            this.btnSyncTest = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.dgLoglist = new System.Windows.Forms.DataGridView();
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.timerCountDown = new System.Windows.Forms.Timer(this.components);
            this.btnDownload = new System.Windows.Forms.Button();
            this.grbConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoglist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "API URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(95, 30);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(174, 23);
            this.txtURL.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(95, 71);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(174, 23);
            this.txtUser.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "User Name";
            // 
            // txtSecret
            // 
            this.txtSecret.Location = new System.Drawing.Point(399, 74);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.PasswordChar = '#';
            this.txtSecret.ReadOnly = true;
            this.txtSecret.Size = new System.Drawing.Size(124, 23);
            this.txtSecret.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "SecretKey";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(399, 115);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(39, 23);
            this.txtInterval.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sync Interval in Min";
            // 
            // btnDebugger
            // 
            this.btnDebugger.Location = new System.Drawing.Point(3, 180);
            this.btnDebugger.Name = "btnDebugger";
            this.btnDebugger.Size = new System.Drawing.Size(122, 23);
            this.btnDebugger.TabIndex = 11;
            this.btnDebugger.Text = "Debugger";
            this.btnDebugger.UseVisualStyleBackColor = true;
            this.btnDebugger.Click += new System.EventHandler(this.btnDebugger_Click);
            // 
            // txtRecLimit
            // 
            this.txtRecLimit.Location = new System.Drawing.Point(95, 113);
            this.txtRecLimit.Name = "txtRecLimit";
            this.txtRecLimit.ReadOnly = true;
            this.txtRecLimit.Size = new System.Drawing.Size(174, 23);
            this.txtRecLimit.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Read Limit";
            // 
            // txtQueue
            // 
            this.txtQueue.Location = new System.Drawing.Point(398, 32);
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.ReadOnly = true;
            this.txtQueue.Size = new System.Drawing.Size(124, 23);
            this.txtQueue.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Queue Name";
            // 
            // grbConfig
            // 
            this.grbConfig.Controls.Add(this.btnDownload);
            this.grbConfig.Controls.Add(this.txtNextTrigger);
            this.grbConfig.Controls.Add(this.btnSyncTest);
            this.grbConfig.Controls.Add(this.btnClear);
            this.grbConfig.Controls.Add(this.label7);
            this.grbConfig.Controls.Add(this.txtToken);
            this.grbConfig.Controls.Add(this.dgLoglist);
            this.grbConfig.Controls.Add(this.label6);
            this.grbConfig.Controls.Add(this.txtQueue);
            this.grbConfig.Controls.Add(this.label5);
            this.grbConfig.Controls.Add(this.txtRecLimit);
            this.grbConfig.Controls.Add(this.btnDebugger);
            this.grbConfig.Controls.Add(this.label4);
            this.grbConfig.Controls.Add(this.txtInterval);
            this.grbConfig.Controls.Add(this.label3);
            this.grbConfig.Controls.Add(this.txtSecret);
            this.grbConfig.Controls.Add(this.label2);
            this.grbConfig.Controls.Add(this.txtUser);
            this.grbConfig.Controls.Add(this.txtURL);
            this.grbConfig.Controls.Add(this.label1);
            this.grbConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbConfig.Location = new System.Drawing.Point(0, 0);
            this.grbConfig.Name = "grbConfig";
            this.grbConfig.Size = new System.Drawing.Size(535, 419);
            this.grbConfig.TabIndex = 0;
            this.grbConfig.TabStop = false;
            this.grbConfig.Text = "Configuration";
            // 
            // txtNextTrigger
            // 
            this.txtNextTrigger.Location = new System.Drawing.Point(444, 115);
            this.txtNextTrigger.Name = "txtNextTrigger";
            this.txtNextTrigger.ReadOnly = true;
            this.txtNextTrigger.Size = new System.Drawing.Size(78, 23);
            this.txtNextTrigger.TabIndex = 21;
            // 
            // btnSyncTest
            // 
            this.btnSyncTest.Location = new System.Drawing.Point(131, 180);
            this.btnSyncTest.Name = "btnSyncTest";
            this.btnSyncTest.Size = new System.Drawing.Size(125, 23);
            this.btnSyncTest.TabIndex = 20;
            this.btnSyncTest.Text = "Sync Test";
            this.btnSyncTest.UseVisualStyleBackColor = true;
            this.btnSyncTest.Click += new System.EventHandler(this.btnSyncTest_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(397, 180);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "JWT Token";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(96, 151);
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(427, 23);
            this.txtToken.TabIndex = 17;
            // 
            // dgLoglist
            // 
            this.dgLoglist.AllowUserToDeleteRows = false;
            this.dgLoglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLoglist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgLoglist.Location = new System.Drawing.Point(3, 209);
            this.dgLoglist.Name = "dgLoglist";
            this.dgLoglist.ReadOnly = true;
            this.dgLoglist.RowTemplate.Height = 25;
            this.dgLoglist.Size = new System.Drawing.Size(529, 207);
            this.dgLoglist.TabIndex = 16;
            // 
            // timerSync
            // 
            this.timerSync.Enabled = true;
            this.timerSync.Interval = 5000;
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // timerCountDown
            // 
            this.timerCountDown.Enabled = true;
            this.timerCountDown.Interval = 1000;
            this.timerCountDown.Tick += new System.EventHandler(this.timerCountDown_Tick);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(294, 180);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(97, 23);
            this.btnDownload.TabIndex = 22;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // MainForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 419);
            this.Controls.Add(this.grbConfig);
            this.MaximizeBox = false;
            this.Name = "MainForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Fetcher Form";
            this.Load += new System.EventHandler(this.MainForms_Load);
            this.grbConfig.ResumeLayout(false);
            this.grbConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoglist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDebugger;
        private System.Windows.Forms.TextBox txtRecLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQueue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbConfig;
        private System.Windows.Forms.DataGridView dgLoglist;
        private System.Windows.Forms.Timer timerSync;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSyncTest;
        private System.Windows.Forms.TextBox txtNextTrigger;
        private System.Windows.Forms.Timer timerCountDown;
        private System.Windows.Forms.Button btnDownload;
    }
}

