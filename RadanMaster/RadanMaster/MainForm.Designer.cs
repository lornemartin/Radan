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
            this.buttonAllItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNesting
            // 
            this.btnNesting.Location = new System.Drawing.Point(137, 64);
            this.btnNesting.Name = "btnNesting";
            this.btnNesting.Size = new System.Drawing.Size(75, 23);
            this.btnNesting.TabIndex = 0;
            this.btnNesting.Text = "Nesting";
            this.btnNesting.UseVisualStyleBackColor = true;
            this.btnNesting.Click += new System.EventHandler(this.btnNesting_Click);
            // 
            // buttonAllItems
            // 
            this.buttonAllItems.Location = new System.Drawing.Point(137, 127);
            this.buttonAllItems.Name = "buttonAllItems";
            this.buttonAllItems.Size = new System.Drawing.Size(75, 23);
            this.buttonAllItems.TabIndex = 0;
            this.buttonAllItems.Text = "All Items";
            this.buttonAllItems.UseVisualStyleBackColor = true;
            this.buttonAllItems.Click += new System.EventHandler(this.buttonAllItems_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 570);
            this.Controls.Add(this.buttonAllItems);
            this.Controls.Add(this.btnNesting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNesting;
        private System.Windows.Forms.Button buttonAllItems;
    }
}