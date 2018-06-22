namespace parserVideo
{
    partial class MainGrupBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSpead = new System.Windows.Forms.Label();
            this.labKbs = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBoxViev = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViev)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox);
            this.groupBox1.Controls.Add(this.labelSpead);
            this.groupBox1.Controls.Add(this.labKbs);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.pictureBoxViev);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // labelSpead
            // 
            this.labelSpead.AutoSize = true;
            this.labelSpead.Location = new System.Drawing.Point(484, 104);
            this.labelSpead.Name = "labelSpead";
            this.labelSpead.Size = new System.Drawing.Size(32, 17);
            this.labelSpead.TabIndex = 6;
            this.labelSpead.Text = "--,--";
            // 
            // labKbs
            // 
            this.labKbs.AutoSize = true;
            this.labKbs.Location = new System.Drawing.Point(540, 104);
            this.labKbs.Name = "labKbs";
            this.labKbs.Size = new System.Drawing.Size(38, 17);
            this.labKbs.TabIndex = 5;
            this.labKbs.Text = ":kb/s";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(434, 58);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(144, 31);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(150, 104);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(275, 28);
            this.progressBar.TabIndex = 2;
            // 
            // pictureBoxViev
            // 
            this.pictureBoxViev.Location = new System.Drawing.Point(6, 22);
            this.pictureBoxViev.Name = "pictureBoxViev";
            this.pictureBoxViev.Size = new System.Drawing.Size(138, 110);
            this.pictureBoxViev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxViev.TabIndex = 1;
            this.pictureBoxViev.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(434, 22);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(144, 29);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Start Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(150, 21);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(275, 68);
            this.textBox.TabIndex = 7;
            // 
            // MainGrupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MainGrupBox";
            this.Size = new System.Drawing.Size(591, 144);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBoxViev;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label labKbs;
        private System.Windows.Forms.Label labelSpead;
        private System.Windows.Forms.TextBox textBox;
    }
}
