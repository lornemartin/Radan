namespace RadanMaster
{
    partial class AllItems
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControlAllItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewAllItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyNested = new DevExpress.XtraGrid.Columns.GridColumn();
            this.partNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.partDescCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperationCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStructCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchedName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderIsComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageHome});
            this.ribbon.Size = new System.Drawing.Size(1396, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonPageHome
            // 
            this.ribbonPageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPageHome.Name = "ribbonPageHome";
            this.ribbonPageHome.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 604);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1396, 31);
            // 
            // gridControlAllItems
            // 
            this.gridControlAllItems.DataSource = typeof(RadanMaster.Models.OrderItem);
            this.gridControlAllItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAllItems.Location = new System.Drawing.Point(0, 143);
            this.gridControlAllItems.MainView = this.gridViewAllItems;
            this.gridControlAllItems.MenuManager = this.ribbon;
            this.gridControlAllItems.Name = "gridControlAllItems";
            this.gridControlAllItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControlAllItems.Size = new System.Drawing.Size(1396, 461);
            this.gridControlAllItems.TabIndex = 2;
            this.gridControlAllItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAllItems});
            // 
            // gridViewAllItems
            // 
            this.gridViewAllItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colQtyRequired,
            this.colQtyNested,
            this.partNameCol,
            this.partDescCol,
            this.OperationCol,
            this.colStructCode,
            this.colOrderNumber,
            this.colSchedName,
            this.colBatchName,
            this.colIsBatch,
            this.colOrderIsComplete,
            this.colIsComplete,
            this.colNotes});
            this.gridViewAllItems.GridControl = this.gridControlAllItems;
            this.gridViewAllItems.Name = "gridViewAllItems";
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
            this.colQtyRequired.VisibleIndex = 1;
            this.colQtyRequired.Width = 55;
            // 
            // colQtyNested
            // 
            this.colQtyNested.FieldName = "QtyNested";
            this.colQtyNested.Name = "colQtyNested";
            this.colQtyNested.Visible = true;
            this.colQtyNested.VisibleIndex = 0;
            this.colQtyNested.Width = 46;
            // 
            // partNameCol
            // 
            this.partNameCol.Caption = "Part Name";
            this.partNameCol.FieldName = "Part.FileName";
            this.partNameCol.Name = "partNameCol";
            this.partNameCol.Visible = true;
            this.partNameCol.VisibleIndex = 2;
            this.partNameCol.Width = 119;
            // 
            // partDescCol
            // 
            this.partDescCol.Caption = "Description";
            this.partDescCol.FieldName = "Part.Description";
            this.partDescCol.Name = "partDescCol";
            this.partDescCol.Visible = true;
            this.partDescCol.VisibleIndex = 3;
            this.partDescCol.Width = 100;
            // 
            // OperationCol
            // 
            this.OperationCol.Caption = "Operation";
            this.OperationCol.FieldName = "Part.Operations";
            this.OperationCol.Name = "OperationCol";
            this.OperationCol.Visible = true;
            this.OperationCol.VisibleIndex = 5;
            this.OperationCol.Width = 111;
            // 
            // colStructCode
            // 
            this.colStructCode.Caption = "Structural Code";
            this.colStructCode.FieldName = "Part.StructuralCode";
            this.colStructCode.Name = "colStructCode";
            this.colStructCode.Visible = true;
            this.colStructCode.VisibleIndex = 4;
            this.colStructCode.Width = 84;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.Caption = "Order #";
            this.colOrderNumber.FieldName = "Order.OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.Visible = true;
            this.colOrderNumber.VisibleIndex = 6;
            this.colOrderNumber.Width = 78;
            // 
            // colSchedName
            // 
            this.colSchedName.Caption = "Schedule";
            this.colSchedName.FieldName = "Order.ScheduleName";
            this.colSchedName.Name = "colSchedName";
            this.colSchedName.Visible = true;
            this.colSchedName.VisibleIndex = 7;
            this.colSchedName.Width = 78;
            // 
            // colBatchName
            // 
            this.colBatchName.Caption = "Batch";
            this.colBatchName.FieldName = "Order.BatchName";
            this.colBatchName.Name = "colBatchName";
            this.colBatchName.Visible = true;
            this.colBatchName.VisibleIndex = 8;
            this.colBatchName.Width = 78;
            // 
            // colIsBatch
            // 
            this.colIsBatch.Caption = "isBatch";
            this.colIsBatch.FieldName = "Order.IsBatch";
            this.colIsBatch.Name = "colIsBatch";
            this.colIsBatch.Visible = true;
            this.colIsBatch.VisibleIndex = 9;
            this.colIsBatch.Width = 38;
            // 
            // colOrderIsComplete
            // 
            this.colOrderIsComplete.Caption = "Order Complete";
            this.colOrderIsComplete.FieldName = "Order.IsComplete";
            this.colOrderIsComplete.Name = "colOrderIsComplete";
            this.colOrderIsComplete.Visible = true;
            this.colOrderIsComplete.VisibleIndex = 11;
            this.colOrderIsComplete.Width = 50;
            // 
            // colIsComplete
            // 
            this.colIsComplete.FieldName = "IsComplete";
            this.colIsComplete.Name = "colIsComplete";
            this.colIsComplete.Visible = true;
            this.colIsComplete.VisibleIndex = 12;
            this.colIsComplete.Width = 50;
            // 
            // colNotes
            // 
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 10;
            this.colNotes.Width = 620;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // AllItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 635);
            this.Controls.Add(this.gridControlAllItems);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "AllItems";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "AllItems";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl gridControlAllItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAllItems;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyRequired;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyNested;
        private DevExpress.XtraGrid.Columns.GridColumn partNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn colIsComplete;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
        private DevExpress.XtraGrid.Columns.GridColumn partDescCol;
        private DevExpress.XtraGrid.Columns.GridColumn OperationCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colStructCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSchedName;
        private DevExpress.XtraGrid.Columns.GridColumn colBatchName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBatch;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderIsComplete;
    }
}