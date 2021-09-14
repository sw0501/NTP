
namespace Time_Synch_Program
{
    partial class Main
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
            this.PC_Timer = new System.Windows.Forms.Timer(this.components);
            this.Serial_Port = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BaudRate = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Intranet_Server_Time = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Port_Connect_Status = new System.Windows.Forms.PictureBox();
            this.Sync_Status = new System.Windows.Forms.PictureBox();
            this.TX_Status = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Voip_Server_Time = new System.Windows.Forms.Label();
            this.Delayed_Time = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Port_Connect_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sync_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TX_Status)).BeginInit();
            this.SuspendLayout();
            // 
            // PC_Timer
            // 
            this.PC_Timer.Tick += new System.EventHandler(this.PC_Timer_Tick);
            // 
            // Serial_Port
            // 
            this.Serial_Port.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Serial_Port.Location = new System.Drawing.Point(472, 317);
            this.Serial_Port.Name = "Serial_Port";
            this.Serial_Port.Size = new System.Drawing.Size(100, 43);
            this.Serial_Port.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(375, 317);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(91, 37);
            this.label.TabIndex = 4;
            this.label.Text = "Port : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(375, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud : ";
            // 
            // BaudRate
            // 
            this.BaudRate.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BaudRate.Location = new System.Drawing.Point(472, 366);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(100, 43);
            this.BaudRate.TabIndex = 6;
            // 
            // btn_Open
            // 
            this.btn_Open.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Open.Location = new System.Drawing.Point(52, 350);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(100, 50);
            this.btn_Open.TabIndex = 7;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Close.Location = new System.Drawing.Point(188, 350);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 50);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-13, -185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("배달의민족 주아", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(18, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 53);
            this.label3.TabIndex = 12;
            this.label3.Text = "인트라넷 서버";
            // 
            // Intranet_Server_Time
            // 
            this.Intranet_Server_Time.AutoSize = true;
            this.Intranet_Server_Time.BackColor = System.Drawing.SystemColors.Control;
            this.Intranet_Server_Time.Font = new System.Drawing.Font("배달의민족 주아", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Intranet_Server_Time.Location = new System.Drawing.Point(305, 48);
            this.Intranet_Server_Time.Name = "Intranet_Server_Time";
            this.Intranet_Server_Time.Size = new System.Drawing.Size(680, 53);
            this.Intranet_Server_Time.TabIndex = 13;
            this.Intranet_Server_Time.Text = "Intranet_Server_Time_Delayed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(676, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 28);
            this.label5.TabIndex = 16;
            this.label5.Text = "포트 연결 상태";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(676, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 28);
            this.label6.TabIndex = 17;
            this.label6.Text = "동기화 상태";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(676, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 28);
            this.label7.TabIndex = 18;
            this.label7.Text = "수신 여부 확인";
            // 
            // Port_Connect_Status
            // 
            this.Port_Connect_Status.Image = global::Time_Synch_Program.Properties.Resources.RC1;
            this.Port_Connect_Status.Location = new System.Drawing.Point(832, 284);
            this.Port_Connect_Status.Name = "Port_Connect_Status";
            this.Port_Connect_Status.Size = new System.Drawing.Size(60, 60);
            this.Port_Connect_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Port_Connect_Status.TabIndex = 19;
            this.Port_Connect_Status.TabStop = false;
            // 
            // Sync_Status
            // 
            this.Sync_Status.Image = global::Time_Synch_Program.Properties.Resources.RC1;
            this.Sync_Status.Location = new System.Drawing.Point(832, 350);
            this.Sync_Status.Name = "Sync_Status";
            this.Sync_Status.Size = new System.Drawing.Size(60, 60);
            this.Sync_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sync_Status.TabIndex = 20;
            this.Sync_Status.TabStop = false;
            // 
            // TX_Status
            // 
            this.TX_Status.Image = global::Time_Synch_Program.Properties.Resources.RC1;
            this.TX_Status.Location = new System.Drawing.Point(832, 416);
            this.TX_Status.Name = "TX_Status";
            this.TX_Status.Size = new System.Drawing.Size(60, 60);
            this.TX_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TX_Status.TabIndex = 21;
            this.TX_Status.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("배달의민족 주아", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(84, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 53);
            this.label8.TabIndex = 22;
            this.label8.Text = "Voip 서버";
            // 
            // Voip_Server_Time
            // 
            this.Voip_Server_Time.AutoSize = true;
            this.Voip_Server_Time.BackColor = System.Drawing.SystemColors.Control;
            this.Voip_Server_Time.Font = new System.Drawing.Font("배달의민족 주아", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Voip_Server_Time.Location = new System.Drawing.Point(305, 153);
            this.Voip_Server_Time.Name = "Voip_Server_Time";
            this.Voip_Server_Time.Size = new System.Drawing.Size(406, 53);
            this.Voip_Server_Time.TabIndex = 23;
            this.Voip_Server_Time.Text = "Voip_Server_Time";
            // 
            // Delayed_Time
            // 
            this.Delayed_Time.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Delayed_Time.Location = new System.Drawing.Point(472, 415);
            this.Delayed_Time.Name = "Delayed_Time";
            this.Delayed_Time.Size = new System.Drawing.Size(100, 43);
            this.Delayed_Time.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(375, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 37);
            this.label9.TabIndex = 24;
            this.label9.Text = "Delay :";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.Delayed_Time);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Voip_Server_Time);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TX_Status);
            this.Controls.Add(this.Sync_Status);
            this.Controls.Add(this.Port_Connect_Status);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.Serial_Port);
            this.Controls.Add(this.Intranet_Server_Time);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Port_Connect_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sync_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TX_Status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer PC_Timer;
        private System.Windows.Forms.TextBox Serial_Port;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BaudRate;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        //private System.Windows.Forms.Button btn_RX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Intranet_Server_Time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox Port_Connect_Status;
        private System.Windows.Forms.PictureBox Sync_Status;
        private System.Windows.Forms.PictureBox TX_Status;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Voip_Server_Time;
        private System.Windows.Forms.TextBox Delayed_Time;
        private System.Windows.Forms.Label label9;
    }
}

