namespace RadanMaster
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.orderItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyNested = new DevExpress.XtraGrid.Columns.GridColumn();
            this.partNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PartDescCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thicknessCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.materialCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialogImport = new System.Windows.Forms.OpenFileDialog();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.openFileDialogAddItem = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogProject = new System.Windows.Forms.OpenFileDialog();
            this.grpBoxRadanProject = new System.Windows.Forms.GroupBox();
            this.btnSyncProject = new System.Windows.Forms.Button();
            this.btnSendSelectionToProject = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxRadanProject = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.grpBoxRadanProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.orderItemsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 149);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1269, 384);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // orderItemsBindingSource
            // 
            //this.orderItemsBindingSource.DataSource = typeof(RadanMaster.Models.OrderItem);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colQtyRequired,
            this.colQtyNested,
            this.partNameCol,
            this.PartDescCol,
            this.thicknessCol,
            this.materialCol,
            this.colIsComplete,
            this.colOrderNum,
            this.IsBatch});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colQtyRequired
            // 
            this.colQtyRequired.FieldName = "QtyRequired";
            this.colQtyRequired.Name = "colQtyRequired";
            this.colQtyRequired.Visible = true;
            this.colQtyRequired.VisibleIndex = 0;
            this.colQtyRequired.Width = 57;
            // 
            // colQtyNested
            // 
            this.colQtyNested.Caption = "Qty Nested";
            this.colQtyNested.FieldName = "QtyNested";
            this.colQtyNested.Name = "colQtyNested";
            this.colQtyNested.Visible = true;
            this.colQtyNested.VisibleIndex = 1;
            this.colQtyNested.Width = 56;
            // 
            // partNameCol
            // 
            this.partNameCol.Caption = "Part Name";
            this.partNameCol.FieldName = "Part.FileName";
            this.partNameCol.Name = "partNameCol";
            this.partNameCol.Visible = true;
            this.partNameCol.VisibleIndex = 2;
            this.partNameCol.Width = 275;
            // 
            // PartDescCol
            // 
            this.PartDescCol.Caption = "Description";
            this.PartDescCol.FieldName = "Part.Description";
            this.PartDescCol.Name = "PartDescCol";
            this.PartDescCol.Visible = true;
            this.PartDescCol.VisibleIndex = 4;
            this.PartDescCol.Width = 98;
            // 
            // thicknessCol
            // 
            this.thicknessCol.Caption = "Thickness";
            this.thicknessCol.FieldName = "Part.Thickness";
            this.thicknessCol.Name = "thicknessCol";
            this.thicknessCol.Visible = true;
            this.thicknessCol.VisibleIndex = 3;
            this.thicknessCol.Width = 98;
            // 
            // materialCol
            // 
            this.materialCol.Caption = "Material";
            this.materialCol.FieldName = "Part.Material";
            this.materialCol.Name = "materialCol";
            this.materialCol.Visible = true;
            this.materialCol.VisibleIndex = 5;
            this.materialCol.Width = 98;
            // 
            // colIsComplete
            // 
            this.colIsComplete.FieldName = "IsComplete";
            this.colIsComplete.Name = "colIsComplete";
            this.colIsComplete.Visible = true;
            this.colIsComplete.VisibleIndex = 6;
            this.colIsComplete.Width = 69;
            // 
            // colOrderNum
            // 
            this.colOrderNum.Caption = "Order Number";
            this.colOrderNum.FieldName = "Order.OrderNumber";
            this.colOrderNum.Name = "colOrderNum";
            this.colOrderNum.Visible = true;
            this.colOrderNum.VisibleIndex = 7;
            this.colOrderNum.Width = 500;
            // 
            // IsBatch
            // 
            this.IsBatch.Caption = "Is Batch";
            this.IsBatch.FieldName = "Order.IsBatch";
            this.IsBatch.Name = "IsBatch";
            this.IsBatch.Visible = true;
            this.IsBatch.VisibleIndex = 8;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1337, 143);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSkins});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // rpgSkins
            // 
            this.rpgSkins.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.rpgSkins.Name = "rpgSkins";
            this.rpgSkins.Text = "Skins";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(33, 565);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(33, 613);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add  Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // grpBoxRadanProject
            // 
            this.grpBoxRadanProject.Controls.Add(this.btnSyncProject);
            this.grpBoxRadanProject.Controls.Add(this.btnSendSelectionToProject);
            this.grpBoxRadanProject.Controls.Add(this.btnBrowse);
            this.grpBoxRadanProject.Controls.Add(this.label1);
            this.grpBoxRadanProject.Controls.Add(this.txtBoxRadanProject);
            this.grpBoxRadanProject.Location = new System.Drawing.Point(292, 565);
            this.grpBoxRadanProject.Name = "grpBoxRadanProject";
            this.grpBoxRadanProject.Size = new System.Drawing.Size(546, 162);
            this.grpBoxRadanProject.TabIndex = 6;
            this.grpBoxRadanProject.TabStop = false;
            this.grpBoxRadanProject.Text = "Radan Project";
            // 
            // btnSyncProject
            // 
            this.btnSyncProject.Enabled = false;
            this.btnSyncProject.Location = new System.Drawing.Point(108, 63);
            this.btnSyncProject.Name = "btnSyncProject";
            this.btnSyncProject.Size = new System.Drawing.Size(75, 49);
            this.btnSyncProject.TabIndex = 3;
            this.btnSyncProject.Text = "Sync Project";
            this.btnSyncProject.UseVisualStyleBackColor = true;
            this.btnSyncProject.Click += new System.EventHandler(this.btnSyncProject_Click);
            // 
            // btnSendSelectionToProject
            // 
            this.btnSendSelectionToProject.Enabled = false;
            this.btnSendSelectionToProject.Location = new System.Drawing.Point(10, 63);
            this.btnSendSelectionToProject.Name = "btnSendSelectionToProject";
            this.btnSendSelectionToProject.Size = new System.Drawing.Size(75, 49);
            this.btnSendSelectionToProject.TabIndex = 3;
            this.btnSendSelectionToProject.Text = "Send Selection To Project";
            this.btnSendSelectionToProject.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(410, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Radan Project File";
            // 
            // txtBoxRadanProject
            // 
            this.txtBoxRadanProject.Location = new System.Drawing.Point(118, 21);
            this.txtBoxRadanProject.Name = "txtBoxRadanProject";
            this.txtBoxRadanProject.Size = new System.Drawing.Size(270, 21);
            this.txtBoxRadanProject.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 739);
            this.Controls.Add(this.grpBoxRadanProject);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.Text = "RadanMaster";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.grpBoxRadanProject.ResumeLayout(false);
            this.grpBoxRadanProject.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSkins;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsComplete;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyRequired;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNum;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.BindingSource orderItemsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn partNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn thicknessCol;
        private DevExpress.XtraGrid.Columns.GridColumn PartDescCol;
        private DevExpress.XtraGrid.Columns.GridColumn materialCol;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyNested;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialogImport;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogAddItem;
        private DevExpress.XtraGrid.Columns.GridColumn IsBatch;
        private System.Windows.Forms.OpenFileDialog openFileDialogProject;
        private System.Windows.Forms.GroupBox grpBoxRadanProject;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxRadanProject;
        private System.Windows.Forms.Button btnSyncProject;
        private System.Windows.Forms.Button btnSendSelectionToProject;
    }
}
