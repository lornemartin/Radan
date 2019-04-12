namespace RadanMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnNesting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNesting
            // 
            this.btnNesting.Location = new System.Drawing.Point(553, 47);
            this.btnNesting.Name = "btnNesting";
            this.btnNesting.Size = new System.Drawing.Size(201, 98);
            this.btnNesting.TabIndex = 0;
            this.btnNesting.Text = "Nesting";
            this.btnNesting.UseVisualStyleBackColor = true;
            this.btnNesting.Click += new System.EventHandler(this.btnNesting_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 98);
            this.button1.TabIndex = 1;
            this.button1.Text = "All Production";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 570);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNesting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNesting;
        private System.Windows.Forms.Button button1;
    }
}