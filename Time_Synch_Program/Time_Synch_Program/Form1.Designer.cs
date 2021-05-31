
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
            this.SuspendLayout();
            // 
            // PC_Hour
            // 
            this.PC_Hour.Location = new System.Drawing.Point(47, 62);
            this.PC_Hour.Name = "PC_Hour";
            this.PC_Hour.Size = new System.Drawing.Size(115, 23);
            this.PC_Hour.TabIndex = 0;
            this.PC_Hour.Text = "PC_Hour";
            // 
            // PC_Min
            // 
            this.PC_Min.Location = new System.Drawing.Point(168, 62);
            this.PC_Min.Name = "PC_Min";
            this.PC_Min.Size = new System.Drawing.Size(100, 23);
            this.PC_Min.TabIndex = 1;
            this.PC_Min.Text = "PC_Min";
            // 
            // PC_Sec
            // 
            this.PC_Sec.Location = new System.Drawing.Point(274, 62);
            this.PC_Sec.Name = "PC_Sec";
            this.PC_Sec.Size = new System.Drawing.Size(100, 23);
            this.PC_Sec.TabIndex = 2;
            this.PC_Sec.Text = "PC_Sec";
            // 
            // PC_Timer
            // 
            this.PC_Timer.Tick += new System.EventHandler(this.PC_Timer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 361);
            this.Controls.Add(this.PC_Sec);
            this.Controls.Add(this.PC_Min);
            this.Controls.Add(this.PC_Hour);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PC_Hour;
        private System.Windows.Forms.TextBox PC_Min;
        private System.Windows.Forms.TextBox PC_Sec;
        private System.Windows.Forms.Timer PC_Timer;
    }
}

