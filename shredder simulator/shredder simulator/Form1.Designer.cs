namespace shredder_simulator
{
    partial class shredsimForm
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
            this.searchButton = new System.Windows.Forms.Button();
            this.fileTextbox = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.folderTextbox = new System.Windows.Forms.TextBox();
            this.folderLabel = new System.Windows.Forms.Label();
            this.folderButton = new System.Windows.Forms.Button();
            this.shredButton = new System.Windows.Forms.Button();
            this.vertUpDown = new System.Windows.Forms.NumericUpDown();
            this.horUpDown = new System.Windows.Forms.NumericUpDown();
            this.vertLabel = new System.Windows.Forms.Label();
            this.horLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.vertUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(64, 85);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // fileTextbox
            // 
            this.fileTextbox.Location = new System.Drawing.Point(145, 88);
            this.fileTextbox.Name = "fileTextbox";
            this.fileTextbox.Size = new System.Drawing.Size(383, 20);
            this.fileTextbox.TabIndex = 1;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(142, 72);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(131, 13);
            this.fileLabel.TabIndex = 2;
            this.fileLabel.Text = "Choose image file to shred";
            // 
            // folderTextbox
            // 
            this.folderTextbox.Location = new System.Drawing.Point(145, 181);
            this.folderTextbox.Name = "folderTextbox";
            this.folderTextbox.Size = new System.Drawing.Size(383, 20);
            this.folderTextbox.TabIndex = 5;
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(142, 165);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(126, 13);
            this.folderLabel.TabIndex = 6;
            this.folderLabel.Text = "Choose destination folder";
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(64, 178);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(75, 23);
            this.folderButton.TabIndex = 7;
            this.folderButton.Text = "search";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // shredButton
            // 
            this.shredButton.Location = new System.Drawing.Point(433, 239);
            this.shredButton.Name = "shredButton";
            this.shredButton.Size = new System.Drawing.Size(95, 37);
            this.shredButton.TabIndex = 8;
            this.shredButton.Text = "shred!";
            this.shredButton.UseVisualStyleBackColor = true;
            this.shredButton.Click += new System.EventHandler(this.shredButton_Click);
            // 
            // vertUpDown
            // 
            this.vertUpDown.Location = new System.Drawing.Point(82, 267);
            this.vertUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.vertUpDown.Name = "vertUpDown";
            this.vertUpDown.Size = new System.Drawing.Size(61, 20);
            this.vertUpDown.TabIndex = 9;
            // 
            // horUpDown
            // 
            this.horUpDown.Location = new System.Drawing.Point(236, 267);
            this.horUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.horUpDown.Name = "horUpDown";
            this.horUpDown.Size = new System.Drawing.Size(61, 20);
            this.horUpDown.TabIndex = 10;
            // 
            // vertLabel
            // 
            this.vertLabel.AutoSize = true;
            this.vertLabel.Location = new System.Drawing.Point(79, 251);
            this.vertLabel.Name = "vertLabel";
            this.vertLabel.Size = new System.Drawing.Size(122, 13);
            this.vertLabel.TabIndex = 11;
            this.vertLabel.Text = "Number of vertical slices";
            // 
            // horLabel
            // 
            this.horLabel.AutoSize = true;
            this.horLabel.Location = new System.Drawing.Point(233, 251);
            this.horLabel.Name = "horLabel";
            this.horLabel.Size = new System.Drawing.Size(83, 13);
            this.horLabel.TabIndex = 12;
            this.horLabel.Text = "Horizontal slices";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(64, 327);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "randomize shred location";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // shredsimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(589, 366);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.horLabel);
            this.Controls.Add(this.vertLabel);
            this.Controls.Add(this.horUpDown);
            this.Controls.Add(this.vertUpDown);
            this.Controls.Add(this.shredButton);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.folderTextbox);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileTextbox);
            this.Controls.Add(this.searchButton);
            this.Name = "shredsimForm";
            this.Text = "shredder simulator";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            ((System.ComponentModel.ISupportInitialize)(this.vertUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox fileTextbox;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox folderTextbox;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Button shredButton;
        private System.Windows.Forms.NumericUpDown vertUpDown;
        private System.Windows.Forms.NumericUpDown horUpDown;
        private System.Windows.Forms.Label vertLabel;
        private System.Windows.Forms.Label horLabel;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}

