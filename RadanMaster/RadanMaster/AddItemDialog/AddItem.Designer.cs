namespace RadanMaster.AddItemDialog
{
    partial class AddItem
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
            this.comboBoxOrderNum = new System.Windows.Forms.ComboBox();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxSchedName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBatchName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBoxCheckForBends = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxNotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxOrderNum
            // 
            this.comboBoxOrderNum.FormattingEnabled = true;
            this.comboBoxOrderNum.Location = new System.Drawing.Point(170, 105);
            this.comboBoxOrderNum.Name = "comboBoxOrderNum";
            this.comboBoxOrderNum.Size = new System.Drawing.Size(204, 21);
            this.comboBoxOrderNum.TabIndex = 1;
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.AcceptsTab = true;
            this.txtBoxQty.Location = new System.Drawing.Point(170, 63);
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.Size = new System.Drawing.Size(204, 20);
            this.txtBoxQty.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order Number";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(216, 343);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(100, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxSchedName
            // 
            this.comboBoxSchedName.FormattingEnabled = true;
            this.comboBoxSchedName.Location = new System.Drawing.Point(170, 144);
            this.comboBoxSchedName.Name = "comboBoxSchedName";
            this.comboBoxSchedName.Size = new System.Drawing.Size(204, 21);
            this.comboBoxSchedName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sched Name";
            // 
            // comboBoxBatchName
            // 
            this.comboBoxBatchName.FormattingEnabled = true;
            this.comboBoxBatchName.Location = new System.Drawing.Point(170, 186);
            this.comboBoxBatchName.Name = "comboBoxBatchName";
            this.comboBoxBatchName.Size = new System.Drawing.Size(204, 21);
            this.comboBoxBatchName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Batch Name";
            // 
            // chkBoxCheckForBends
            // 
            this.chkBoxCheckForBends.AutoSize = true;
            this.chkBoxCheckForBends.Checked = true;
            this.chkBoxCheckForBends.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxCheckForBends.Location = new System.Drawing.Point(56, 277);
            this.chkBoxCheckForBends.Name = "chkBoxCheckForBends";
            this.chkBoxCheckForBends.Size = new System.Drawing.Size(108, 17);
            this.chkBoxCheckForBends.TabIndex = 6;
            this.chkBoxCheckForBends.Text = "Check For Bends";
            this.chkBoxCheckForBends.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Notes";
            // 
            // txtBoxNotes
            // 
            this.txtBoxNotes.Location = new System.Drawing.Point(170, 228);
            this.txtBoxNotes.Name = "txtBoxNotes";
            this.txtBoxNotes.Size = new System.Drawing.Size(204, 20);
            this.txtBoxNotes.TabIndex = 7;
            // 
            // AddItem
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(429, 404);
            this.Controls.Add(this.txtBoxNotes);
            this.Controls.Add(this.chkBoxCheckForBends);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBatchName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSchedName);
            this.Controls.Add(this.txtBoxQty);
            this.Controls.Add(this.comboBoxOrderNum);
            this.Name = "AddItem";
            this.Text = "AddItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOrderNum;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBoxSchedName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBatchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBoxCheckForBends;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxNotes;
    }
}