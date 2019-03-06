namespace RadanMaster
{
    partial class AllProduction
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
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControlAllProduction = new DevExpress.XtraGrid.GridControl();
            this.entityServerModeSource2 = new DevExpress.Data.Linq.EntityServerModeSource();
            this.gridViewAllProduction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQtyRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyNested = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThickness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStructCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchedName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllProduction)).BeginInit();
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
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1243, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 588);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1243, 31);
            // 
            // gridControlAllProduction
            // 
            this.gridControlAllProduction.DataSource = this.entityServerModeSource2;
            this.gridControlAllProduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAllProduction.Location = new System.Drawing.Point(0, 143);
            this.gridControlAllProduction.MainView = this.gridViewAllProduction;
            this.gridControlAllProduction.MenuManager = this.ribbon;
            this.gridControlAllProduction.Name = "gridControlAllProduction";
            this.gridControlAllProduction.Size = new System.Drawing.Size(1243, 445);
            this.gridControlAllProduction.TabIndex = 2;
            this.gridControlAllProduction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAllProduction});
            // 
            // entityServerModeSource2
            // 
            this.entityServerModeSource2.ElementType = typeof(RadanMaster.Models.OrderItem);
            this.entityServerModeSource2.KeyExpression = "ID";
            // 
            // gridViewAllProduction
            // 
            this.gridViewAllProduction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQtyRequired,
            this.colQtyNested,
            this.colCategory,
            this.colFileName,
            this.colDescription,
            this.colIsStock,
            this.colThickness,
            this.colOrderNumber,
            this.colStructCode,
            this.colOperation,
            this.colSchedName,
            this.colBatchName,
            this.colNotes,
            this.colIsComplete,
            this.colIsBatch});
            this.gridViewAllProduction.GridControl = this.gridControlAllProduction;
            this.gridViewAllProduction.Name = "gridViewAllProduction";
            // 
            // colQtyRequired
            // 
            this.colQtyRequired.Caption = "Qty Req\'d";
            this.colQtyRequired.FieldName = "QtyRequired";
            this.colQtyRequired.Name = "colQtyRequired";
            this.colQtyRequired.Visible = true;
            this.colQtyRequired.VisibleIndex = 0;
            this.colQtyRequired.Width = 70;
            // 
            // colQtyNested
            // 
            this.colQtyNested.Caption = "Qty Done";
            this.colQtyNested.FieldName = "QtyNested";
            this.colQtyNested.Name = "colQtyNested";
            this.colQtyNested.Visible = true;
            this.colQtyNested.VisibleIndex = 1;
            this.colQtyNested.Width = 56;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Category";
            this.colCategory.FieldName = "CategoryName";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 2;
            this.colCategory.Width = 56;
            // 
            // colFileName
            // 
            this.colFileName.Caption = "Name";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 3;
            this.colFileName.Width = 165;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 292;
            // 
            // colIsStock
            // 
            this.colIsStock.Caption = "Is Stock?";
            this.colIsStock.FieldName = "IsStock";
            this.colIsStock.Name = "colIsStock";
            this.colIsStock.Visible = true;
            this.colIsStock.VisibleIndex = 7;
            this.colIsStock.Width = 84;
            // 
            // colThickness
            // 
            this.colThickness.Caption = "Thickness";
            this.colThickness.FieldName = "Thickness";
            this.colThickness.Name = "colThickness";
            this.colThickness.Visible = true;
            this.colThickness.VisibleIndex = 5;
            this.colThickness.Width = 38;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.Caption = "Order";
            this.colOrderNumber.FieldName = "OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.Visible = true;
            this.colOrderNumber.VisibleIndex = 8;
            this.colOrderNumber.Width = 84;
            // 
            // colStructCode
            // 
            this.colStructCode.Caption = "Structural Code";
            this.colStructCode.FieldName = "StructuralCode";
            this.colStructCode.Name = "colStructCode";
            this.colStructCode.Visible = true;
            this.colStructCode.VisibleIndex = 6;
            this.colStructCode.Width = 84;
            // 
            // colOperation
            // 
            this.colOperation.Caption = "Operation";
            this.colOperation.FieldName = "Name";
            this.colOperation.Name = "colOperation";
            this.colOperation.Visible = true;
            this.colOperation.VisibleIndex = 9;
            this.colOperation.Width = 84;
            // 
            // colSchedName
            // 
            this.colSchedName.Caption = "Schedule";
            this.colSchedName.FieldName = "ScheduleName";
            this.colSchedName.Name = "colSchedName";
            this.colSchedName.Visible = true;
            this.colSchedName.VisibleIndex = 10;
            this.colSchedName.Width = 84;
            // 
            // colBatchName
            // 
            this.colBatchName.Caption = "Batch";
            this.colBatchName.FieldName = "BatchName";
            this.colBatchName.Name = "colBatchName";
            this.colBatchName.Visible = true;
            this.colBatchName.VisibleIndex = 11;
            this.colBatchName.Width = 84;
            // 
            // colNotes
            // 
            this.colNotes.Caption = "Notes";
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 12;
            this.colNotes.Width = 263;
            // 
            // colIsComplete
            // 
            this.colIsComplete.Caption = "Complete?";
            this.colIsComplete.FieldName = "IsComplete";
            this.colIsComplete.Name = "colIsComplete";
            this.colIsComplete.Visible = true;
            this.colIsComplete.VisibleIndex = 13;
            this.colIsComplete.Width = 43;
            // 
            // colIsBatch
            // 
            this.colIsBatch.Caption = "Is Batch?";
            this.colIsBatch.FieldName = "IsBatch";
            this.colIsBatch.Name = "colIsBatch";
            this.colIsBatch.Visible = true;
            this.colIsBatch.VisibleIndex = 14;
            this.colIsBatch.Width = 20;
            // 
            // AllProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 619);
            this.Controls.Add(this.gridControlAllProduction);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "AllProduction";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "AllProduction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AllProduction_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAllProduction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl gridControlAllProduction;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAllProduction;
        private DevExpress.Data.Linq.EntityServerModeSource entityServerModeSource2;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyRequired;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyNested;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colIsStock;
        private DevExpress.XtraGrid.Columns.GridColumn colThickness;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStructCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOperation;
        private DevExpress.XtraGrid.Columns.GridColumn colSchedName;
        private DevExpress.XtraGrid.Columns.GridColumn colBatchName;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
        private DevExpress.XtraGrid.Columns.GridColumn colIsComplete;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBatch;
    }
}