namespace OMSZ
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDP = new System.Windows.Forms.Label();
            this.lblDT = new System.Windows.Forms.Label();
            this.lblSzelirany = new System.Windows.Forms.Label();
            this.lblSzelsebesseg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPressure.Location = new System.Drawing.Point(21, 9);
            this.lblPressure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(75, 32);
            this.lblPressure.TabIndex = 0;
            this.lblPressure.Text = "1024";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTemp.Location = new System.Drawing.Point(21, 51);
            this.lblTemp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(30, 32);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "2";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTime.Location = new System.Drawing.Point(21, 95);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(85, 32);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "16:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDP
            // 
            this.lblDP.AutoSize = true;
            this.lblDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDP.Location = new System.Drawing.Point(111, 18);
            this.lblDP.Name = "lblDP";
            this.lblDP.Size = new System.Drawing.Size(19, 20);
            this.lblDP.TabIndex = 3;
            this.lblDP.Text = "0";
            this.lblDP.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblDT
            // 
            this.lblDT.AutoSize = true;
            this.lblDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDT.Location = new System.Drawing.Point(111, 60);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(19, 20);
            this.lblDT.TabIndex = 4;
            this.lblDT.Text = "0";
            this.lblDT.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblSzelirany
            // 
            this.lblSzelirany.AutoSize = true;
            this.lblSzelirany.Location = new System.Drawing.Point(112, 95);
            this.lblSzelirany.Name = "lblSzelirany";
            this.lblSzelirany.Size = new System.Drawing.Size(29, 13);
            this.lblSzelirany.TabIndex = 5;
            this.lblSzelirany.Text = "ÉNY";
            // 
            // lblSzelsebesseg
            // 
            this.lblSzelsebesseg.AutoSize = true;
            this.lblSzelsebesseg.Location = new System.Drawing.Point(117, 109);
            this.lblSzelsebesseg.Name = "lblSzelsebesseg";
            this.lblSzelsebesseg.Size = new System.Drawing.Size(13, 13);
            this.lblSzelsebesseg.TabIndex = 6;
            this.lblSzelsebesseg.Text = "8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 136);
            this.Controls.Add(this.lblSzelsebesseg);
            this.Controls.Add(this.lblSzelirany);
            this.Controls.Add(this.lblDT);
            this.Controls.Add(this.lblDP);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.lblPressure);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDP;
        private System.Windows.Forms.Label lblDT;
        private System.Windows.Forms.Label lblSzelirany;
        private System.Windows.Forms.Label lblSzelsebesseg;
    }
}

