
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
            this.PC_Hour = new System.Windows.Forms.TextBox();
            this.PC_Min = new System.Windows.Forms.TextBox();
            this.PC_Sec = new System.Windows.Forms.TextBox();
            this.PC_Timer = new System.Windows.Forms.Timer(this.components);
            this.txtComNum = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_RX = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PC_Hour
            // 
            this.PC_Hour.Location = new System.Drawing.Point(47, 163);
            this.PC_Hour.Name = "PC_Hour";
            this.PC_Hour.Size = new System.Drawing.Size(115, 23);
            this.PC_Hour.TabIndex = 0;
            this.PC_Hour.Text = "PC_Hour";
            // 
            // PC_Min
            // 
            this.PC_Min.Location = new System.Drawing.Point(168, 163);
            this.PC_Min.Name = "PC_Min";
            this.PC_Min.Size = new System.Drawing.Size(100, 23);
            this.PC_Min.TabIndex = 1;
            this.PC_Min.Text = "PC_Min";
            // 
            // PC_Sec
            // 
            this.PC_Sec.Location = new System.Drawing.Point(274, 163);
            this.PC_Sec.Name = "PC_Sec";
            this.PC_Sec.Size = new System.Drawing.Size(100, 23);
            this.PC_Sec.TabIndex = 2;
            this.PC_Sec.Text = "PC_Sec";
            // 
            // PC_Timer
            // 
            this.PC_Timer.Tick += new System.EventHandler(this.PC_Timer_Tick);
            // 
            // txtComNum
            // 
            this.txtComNum.Location = new System.Drawing.Point(77, 13);
            this.txtComNum.Name = "txtComNum";
            this.txtComNum.Size = new System.Drawing.Size(100, 23);
            this.txtComNum.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(40, 15);
            this.label.TabIndex = 4;
            this.label.Text = "Port : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud : ";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(77, 46);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(100, 23);
            this.txtBaudRate.TabIndex = 6;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(63, 285);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 7;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(168, 285);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_RX
            // 
            this.btn_RX.Location = new System.Drawing.Point(274, 285);
            this.btn_RX.Name = "btn_RX";
            this.btn_RX.Size = new System.Drawing.Size(75, 23);
            this.btn_RX.TabIndex = 9;
            this.btn_RX.Text = "RX";
            this.btn_RX.UseVisualStyleBackColor = true;
            this.btn_RX.Click += new System.EventHandler(this.btn_RX_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 361);
            this.Controls.Add(this.btn_RX);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.txtComNum);
            this.Controls.Add(this.PC_Sec);
            this.Controls.Add(this.PC_Min);
            this.Controls.Add(this.PC_Hour);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PC_Hour;
        private System.Windows.Forms.TextBox PC_Min;
        private System.Windows.Forms.TextBox PC_Sec;
        private System.Windows.Forms.Timer PC_Timer;
        private System.Windows.Forms.TextBox txtComNum;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_RX;
    }
}

