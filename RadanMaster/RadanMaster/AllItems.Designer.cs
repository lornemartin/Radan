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
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControlAllItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewAllItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyNested = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPartName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.partDescCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperationCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThickness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStructCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchedName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderIsComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.popupControlContainerAllItems = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.pdfViewerAllItems = new DevExpress.XtraPdfViewer.PdfViewer();
            this.entityServerModeSource1 = new DevExpress.Data.Linq.EntityServerModeSource();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerAllItems)).BeginInit();
            this.popupControlContainerAllItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).BeginInit();
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
            this.gridControlAllItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridControlAllItems_MouseMove);
            // 
            // gridViewAllItems
            // 
            this.gridViewAllItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colQtyRequired,
            this.colQtyNested,
            this.colCategory,
            this.colIsStock,
            this.gridColPartName,
            this.partDescCol,
            this.OperationCol,
            this.colThickness,
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
            this.gridViewAllItems.OptionsBehavior.Editable = false;
            this.gridViewAllItems.OptionsSelection.MultiSelect = true;
            this.gridViewAllItems.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridViewAllItems.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colThickness, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewAllItems.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridViewAllItems_RowDeleted);
            this.gridViewAllItems.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewAllItems_RowUpdated);
            this.gridViewAllItems.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewAllItems_CustomUnboundColumnData);
            this.gridViewAllItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewAllItems_KeyDown_1);
            this.gridViewAllItems.DoubleClick += new System.EventHandler(this.gridViewAllItems_DoubleClick);
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
            this.colQtyRequired.Width = 47;
            // 
            // colQtyNested
            // 
            this.colQtyNested.FieldName = "QtyNested";
            this.colQtyNested.Name = "colQtyNested";
            this.colQtyNested.Visible = true;
            this.colQtyNested.VisibleIndex = 1;
            this.colQtyNested.Width = 40;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Category";
            this.colCategory.FieldName = "Part.CategoryName";
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colCategory.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 2;
            this.colCategory.Width = 108;
            // 
            // colIsStock
            // 
            this.colIsStock.Caption = "Stock";
            this.colIsStock.FieldName = "Part.IsStock";
            this.colIsStock.Name = "colIsStock";
            this.colIsStock.Visible = true;
            this.colIsStock.VisibleIndex = 5;
            this.colIsStock.Width = 38;
            // 
            // gridColPartName
            // 
            this.gridColPartName.Caption = "Part Number";
            this.gridColPartName.FieldName = "Part.FileName";
            this.gridColPartName.Name = "gridColPartName";
            this.gridColPartName.Visible = true;
            this.gridColPartName.VisibleIndex = 3;
            this.gridColPartName.Width = 179;
            // 
            // partDescCol
            // 
            this.partDescCol.Caption = "Description";
            this.partDescCol.FieldName = "Part.Description";
            this.partDescCol.Name = "partDescCol";
            this.partDescCol.Visible = true;
            this.partDescCol.VisibleIndex = 4;
            this.partDescCol.Width = 149;
            // 
            // OperationCol
            // 
            this.OperationCol.Caption = "Operation";
            this.OperationCol.FieldName = "Ops";
            this.OperationCol.Name = "OperationCol";
            this.OperationCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.OperationCol.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.OperationCol.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.OperationCol.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.True;
            this.OperationCol.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.OperationCol.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.OperationCol.Visible = true;
            this.OperationCol.VisibleIndex = 8;
            this.OperationCol.Width = 77;
            // 
            // colThickness
            // 
            this.colThickness.Caption = "Thickness";
            this.colThickness.FieldName = "Part.Thickness";
            this.colThickness.Name = "colThickness";
            this.colThickness.Visible = true;
            this.colThickness.VisibleIndex = 6;
            this.colThickness.Width = 58;
            // 
            // colStructCode
            // 
            this.colStructCode.Caption = "Structural Code";
            this.colStructCode.FieldName = "Part.StructuralCode";
            this.colStructCode.Name = "colStructCode";
            this.colStructCode.Visible = true;
            this.colStructCode.VisibleIndex = 7;
            this.colStructCode.Width = 59;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.Caption = "Order #";
            this.colOrderNumber.FieldName = "Order.OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.Visible = true;
            this.colOrderNumber.VisibleIndex = 9;
            this.colOrderNumber.Width = 53;
            // 
            // colSchedName
            // 
            this.colSchedName.Caption = "Schedule";
            this.colSchedName.FieldName = "Order.ScheduleName";
            this.colSchedName.Name = "colSchedName";
            this.colSchedName.Visible = true;
            this.colSchedName.VisibleIndex = 10;
            this.colSchedName.Width = 53;
            // 
            // colBatchName
            // 
            this.colBatchName.Caption = "Batch";
            this.colBatchName.FieldName = "Order.BatchName";
            this.colBatchName.Name = "colBatchName";
            this.colBatchName.Visible = true;
            this.colBatchName.VisibleIndex = 11;
            this.colBatchName.Width = 53;
            // 
            // colIsBatch
            // 
            this.colIsBatch.Caption = "isBatch";
            this.colIsBatch.FieldName = "Order.IsBatch";
            this.colIsBatch.Name = "colIsBatch";
            this.colIsBatch.Visible = true;
            this.colIsBatch.VisibleIndex = 14;
            this.colIsBatch.Width = 23;
            // 
            // colOrderIsComplete
            // 
            this.colOrderIsComplete.Caption = "Order Complete";
            this.colOrderIsComplete.FieldName = "Order.IsComplete";
            this.colOrderIsComplete.Name = "colOrderIsComplete";
            this.colOrderIsComplete.Visible = true;
            this.colOrderIsComplete.VisibleIndex = 13;
            this.colOrderIsComplete.Width = 33;
            // 
            // colIsComplete
            // 
            this.colIsComplete.FieldName = "IsComplete";
            this.colIsComplete.Name = "colIsComplete";
            this.colIsComplete.Visible = true;
            this.colIsComplete.VisibleIndex = 15;
            this.colIsComplete.Width = 84;
            // 
            // colNotes
            // 
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 12;
            this.colNotes.Width = 453;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // popupControlContainerAllItems
            // 
            this.popupControlContainerAllItems.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerAllItems.Controls.Add(this.pdfViewerAllItems);
            this.popupControlContainerAllItems.Location = new System.Drawing.Point(318, 201);
            this.popupControlContainerAllItems.Name = "popupControlContainerAllItems";
            this.popupControlContainerAllItems.Ribbon = this.ribbon;
            this.popupControlContainerAllItems.Size = new System.Drawing.Size(482, 403);
            this.popupControlContainerAllItems.TabIndex = 5;
            this.popupControlContainerAllItems.Visible = false;
            // 
            // pdfViewerAllItems
            // 
            this.pdfViewerAllItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerAllItems.Location = new System.Drawing.Point(0, 0);
            this.pdfViewerAllItems.Name = "pdfViewerAllItems";
            this.pdfViewerAllItems.Size = new System.Drawing.Size(482, 403);
            this.pdfViewerAllItems.TabIndex = 0;
            // 
            // entityServerModeSource1
            // 
            this.entityServerModeSource1.ElementType = typeof(RadanMaster.Models.OrderItem);
            this.entityServerModeSource1.KeyExpression = "ID";
            // 
            // AllItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 635);
            this.Controls.Add(this.popupControlContainerAllItems);
            this.Controls.Add(this.gridControlAllItems);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "AllItems";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "AllItems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AllItems_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerAllItems)).EndInit();
            this.popupControlContainerAllItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPartName;
        private DevExpress.XtraGrid.Columns.GridColumn colThickness;
        private DevExpress.XtraGrid.Columns.GridColumn colIsStock;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainerAllItems;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerAllItems;
        private DevExpress.Data.Linq.EntityServerModeSource entityServerModeSource1;
    }
}