namespace parserVideo
{
    partial class MainForm
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
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonStartPars = new System.Windows.Forms.Button();
            this.buttonStopPars = new System.Windows.Forms.Button();
            this.buttonSaveFolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAutoSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(30, 43);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(26, 17);
            this.labelUrl.TabIndex = 0;
            this.labelUrl.Text = "Url";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUrl.Location = new System.Drawing.Point(62, 43);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(809, 22);
            this.textBoxUrl.TabIndex = 1;
            // 
            // buttonStartPars
            // 
            this.buttonStartPars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartPars.Location = new System.Drawing.Point(741, 89);
            this.buttonStartPars.Name = "buttonStartPars";
            this.buttonStartPars.Size = new System.Drawing.Size(117, 35);
            this.buttonStartPars.TabIndex = 2;
            this.buttonStartPars.Text = "Start pars";
            this.buttonStartPars.UseVisualStyleBackColor = true;
            this.buttonStartPars.Click += new System.EventHandler(this.buttonStartPars_Click);
            // 
            // buttonStopPars
            // 
            this.buttonStopPars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopPars.Location = new System.Drawing.Point(742, 140);
            this.buttonStopPars.Name = "buttonStopPars";
            this.buttonStopPars.Size = new System.Drawing.Size(117, 35);
            this.buttonStopPars.TabIndex = 3;
            this.buttonStopPars.Text = "Stop Pars";
            this.buttonStopPars.UseVisualStyleBackColor = true;
            this.buttonStopPars.Click += new System.EventHandler(this.buttonStopPars_Click);
            // 
            // buttonSaveFolder
            // 
            this.buttonSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveFolder.Location = new System.Drawing.Point(741, 192);
            this.buttonSaveFolder.Name = "buttonSaveFolder";
            this.buttonSaveFolder.Size = new System.Drawing.Size(117, 35);
            this.buttonSaveFolder.TabIndex = 5;
            this.buttonSaveFolder.Text = "Slect Folder\r\n";
            this.buttonSaveFolder.UseVisualStyleBackColor = true;
            this.buttonSaveFolder.Click += new System.EventHandler(this.buttonSaveFolder_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(62, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 264);
            this.panel1.TabIndex = 6;
            // 
            // buttonAutoSave
            // 
            this.buttonAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoSave.Location = new System.Drawing.Point(742, 300);
            this.buttonAutoSave.Name = "buttonAutoSave";
            this.buttonAutoSave.Size = new System.Drawing.Size(116, 52);
            this.buttonAutoSave.TabIndex = 7;
            this.buttonAutoSave.Text = "Save All";
            this.buttonAutoSave.UseVisualStyleBackColor = true;
            this.buttonAutoSave.Click += new System.EventHandler(this.buttonAutoSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(882, 378);
            this.Controls.Add(this.buttonAutoSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSaveFolder);
            this.Controls.Add(this.buttonStopPars);
            this.Controls.Add(this.buttonStartPars);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.labelUrl);
            this.MinimumSize = new System.Drawing.Size(900, 425);
            this.Name = "MainForm";
            this.Text = "Graber";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonStartPars;
        private System.Windows.Forms.Button buttonStopPars;
        private System.Windows.Forms.Button buttonSaveFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAutoSave;
    }
}

