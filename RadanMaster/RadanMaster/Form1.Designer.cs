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
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.barEditRadanProject = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonSendSelectionToRadan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonBrowseRadanProject = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.openFileDialogImport = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogAddItem = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogProject = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.orderItemsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 143);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1337, 596);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.skinRibbonGalleryBarItem1,
            this.barButtonItemAdd,
            this.barButtonItemImport,
            this.barEditRadanProject,
            this.barButtonSendSelectionToRadan,
            this.barButtonGroup1,
            this.barButtonBrowseRadanProject});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(1337, 143);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // barButtonItemAdd
            // 
            this.barButtonItemAdd.Caption = "Add...";
            this.barButtonItemAdd.Hint = "Add an item to the list";
            this.barButtonItemAdd.Id = 2;
            this.barButtonItemAdd.Name = "barButtonItemAdd";
            this.barButtonItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAdd_ItemClick);
            // 
            // barButtonItemImport
            // 
            this.barButtonItemImport.Caption = "Import...";
            this.barButtonItemImport.Hint = "Import a list of items from an xml file.";
            this.barButtonItemImport.Id = 3;
            this.barButtonItemImport.Name = "barButtonItemImport";
            this.barButtonItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemImport_ItemClick);
            // 
            // barEditRadanProject
            // 
            this.barEditRadanProject.Caption = "Radan Project";
            this.barEditRadanProject.Edit = this.repositoryItemTextEdit1;
            this.barEditRadanProject.EditWidth = 300;
            this.barEditRadanProject.Id = 4;
            this.barEditRadanProject.Name = "barEditRadanProject";
            this.barEditRadanProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem1_ItemClick);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonSendSelectionToRadan
            // 
            this.barButtonSendSelectionToRadan.Caption = "Send Selection";
            this.barButtonSendSelectionToRadan.Hint = "Send Selected Items to Radan Project";
            this.barButtonSendSelectionToRadan.Id = 5;
            this.barButtonSendSelectionToRadan.Name = "barButtonSendSelectionToRadan";
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 6;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barButtonBrowseRadanProject
            // 
            this.barButtonBrowseRadanProject.Caption = "Browse";
            this.barButtonBrowseRadanProject.Hint = "Browse For Radan Project";
            this.barButtonBrowseRadanProject.Id = 7;
            this.barButtonBrowseRadanProject.Name = "barButtonBrowseRadanProject";
            this.barButtonBrowseRadanProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonBrowseRadanProject_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSkins,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // rpgSkins
            // 
            this.rpgSkins.Enabled = false;
            this.rpgSkins.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.rpgSkins.Name = "rpgSkins";
            this.rpgSkins.Text = "Skins";
            this.rpgSkins.Visible = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemImport);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Items";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barEditRadanProject);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonBrowseRadanProject);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonSendSelectionToRadan);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonGroup1);
            this.ribbonPageGroup2.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Radan";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 717);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1337, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMain
            // 
            this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            this.toolStripStatusLabelMain.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 739);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.Text = "RadanMaster";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.OpenFileDialog openFileDialogImport;
        private System.Windows.Forms.OpenFileDialog openFileDialogAddItem;
        private DevExpress.XtraGrid.Columns.GridColumn IsBatch;
        private System.Windows.Forms.OpenFileDialog openFileDialogProject;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemImport;
        private DevExpress.XtraBars.BarEditItem barEditRadanProject;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonSendSelectionToRadan;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonBrowseRadanProject;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMain;
    }
}
