namespace RadanMaster
{
    partial class EditOrderitem
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnRemoveOperation = new System.Windows.Forms.Button();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.gridControlOperations = new DevExpress.XtraGrid.GridControl();
            this.gridViewOperations = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyDone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colisFinalOp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.textEditQtyReqd = new DevExpress.XtraEditors.TextEdit();
            this.textEditQtyDone = new DevExpress.XtraEditors.TextEdit();
            this.textEditNotes = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.operationsTableAdapter = new RadanMaster.RadanMaster2DataSetTableAdapters.OperationsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQtyReqd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQtyDone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNotes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.btnRemoveOperation);
            this.dataLayoutControl1.Controls.Add(this.btnAddOperation);
            this.dataLayoutControl1.Controls.Add(this.gridControlOperations);
            this.dataLayoutControl1.Controls.Add(this.textEditQtyReqd);
            this.dataLayoutControl1.Controls.Add(this.textEditQtyDone);
            this.dataLayoutControl1.Controls.Add(this.textEditNotes);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 143);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(842, 316, 650, 400);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(790, 452);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // btnRemoveOperation
            // 
            this.btnRemoveOperation.Location = new System.Drawing.Point(397, 420);
            this.btnRemoveOperation.Name = "btnRemoveOperation";
            this.btnRemoveOperation.Size = new System.Drawing.Size(381, 20);
            this.btnRemoveOperation.TabIndex = 9;
            this.btnRemoveOperation.Text = "Remove Operation";
            this.btnRemoveOperation.UseVisualStyleBackColor = true;
            this.btnRemoveOperation.Click += new System.EventHandler(this.btnRemoveOperation_Click);
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Location = new System.Drawing.Point(12, 420);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(381, 20);
            this.btnAddOperation.TabIndex = 8;
            this.btnAddOperation.Text = "Add Operation";
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // gridControlOperations
            // 
            this.gridControlOperations.Location = new System.Drawing.Point(12, 186);
            this.gridControlOperations.MainView = this.gridViewOperations;
            this.gridControlOperations.MenuManager = this.mainRibbonControl;
            this.gridControlOperations.Name = "gridControlOperations";
            this.gridControlOperations.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlOperations.Size = new System.Drawing.Size(766, 230);
            this.gridControlOperations.TabIndex = 7;
            this.gridControlOperations.UseEmbeddedNavigator = true;
            this.gridControlOperations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOperations});
            // 
            // gridViewOperations
            // 
            this.gridViewOperations.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colqtyRequired,
            this.colqtyDone,
            this.colName,
            this.colLocation,
            this.colPartID,
            this.colisFinalOp});
            this.gridViewOperations.GridControl = this.gridControlOperations;
            this.gridViewOperations.Name = "gridViewOperations";
            this.gridViewOperations.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewOperations.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewOperations.DoubleClick += new System.EventHandler(this.gridViewOperations_DoubleClick);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colqtyRequired
            // 
            this.colqtyRequired.FieldName = "qtyRequired";
            this.colqtyRequired.Name = "colqtyRequired";
            this.colqtyRequired.Visible = true;
            this.colqtyRequired.VisibleIndex = 0;
            this.colqtyRequired.Width = 104;
            // 
            // colqtyDone
            // 
            this.colqtyDone.FieldName = "qtyDone";
            this.colqtyDone.Name = "colqtyDone";
            this.colqtyDone.Visible = true;
            this.colqtyDone.VisibleIndex = 1;
            this.colqtyDone.Width = 140;
            // 
            // colName
            // 
            this.colName.FieldName = "operation.Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 418;
            // 
            // colLocation
            // 
            this.colLocation.FieldName = "operation.Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 3;
            this.colLocation.Width = 723;
            // 
            // colPartID
            // 
            this.colPartID.FieldName = "PartID";
            this.colPartID.Name = "colPartID";
            // 
            // colisFinalOp
            // 
            this.colisFinalOp.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colisFinalOp.FieldName = "operation.isFinalOp";
            this.colisFinalOp.Name = "colisFinalOp";
            this.colisFinalOp.Visible = true;
            this.colisFinalOp.VisibleIndex = 4;
            this.colisFinalOp.Width = 122;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 10;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(790, 143);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Save And Close";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            this.bbiSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndClose_ItemClick);
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Save And New";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Reset Changes";
            this.bbiReset.Id = 5;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReset_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Home";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndClose);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiReset);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.ShowCaptionButton = false;
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // textEditQtyReqd
            // 
            this.textEditQtyReqd.Location = new System.Drawing.Point(63, 12);
            this.textEditQtyReqd.MenuManager = this.mainRibbonControl;
            this.textEditQtyReqd.Name = "textEditQtyReqd";
            this.textEditQtyReqd.Size = new System.Drawing.Size(330, 20);
            this.textEditQtyReqd.StyleController = this.dataLayoutControl1;
            this.textEditQtyReqd.TabIndex = 4;
            // 
            // textEditQtyDone
            // 
            this.textEditQtyDone.Location = new System.Drawing.Point(448, 12);
            this.textEditQtyDone.MenuManager = this.mainRibbonControl;
            this.textEditQtyDone.Name = "textEditQtyDone";
            this.textEditQtyDone.Size = new System.Drawing.Size(330, 20);
            this.textEditQtyDone.StyleController = this.dataLayoutControl1;
            this.textEditQtyDone.TabIndex = 5;
            // 
            // textEditNotes
            // 
            this.textEditNotes.Location = new System.Drawing.Point(63, 36);
            this.textEditNotes.MenuManager = this.mainRibbonControl;
            this.textEditNotes.Name = "textEditNotes";
            this.textEditNotes.Size = new System.Drawing.Size(715, 146);
            this.textEditNotes.StyleController = this.dataLayoutControl1;
            this.textEditNotes.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(790, 452);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(770, 432);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEditQtyReqd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem1.Text = "Qty Req\'d";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEditQtyDone;
            this.layoutControlItem2.Location = new System.Drawing.Point(385, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem2.Text = "Qty Done";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEditNotes;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem3.Size = new System.Drawing.Size(770, 150);
            this.layoutControlItem3.Text = "Notes";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControlOperations;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 174);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(770, 234);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnAddOperation;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 408);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnRemoveOperation;
            this.layoutControlItem6.Location = new System.Drawing.Point(385, 408);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // operationsTableAdapter
            // 
            this.operationsTableAdapter.ClearBeforeFill = true;
            // 
            // EditOrderitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(790, 595);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "EditOrderitem";
            this.Ribbon = this.mainRibbonControl;
            this.Load += new System.EventHandler(this.EditOrderitem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQtyReqd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQtyDone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNotes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.TextEdit textEditQtyReqd;
        private DevExpress.XtraEditors.TextEdit textEditQtyDone;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.MemoEdit textEditNotes;
        private DevExpress.XtraGrid.GridControl gridControlOperations;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOperations;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private RadanMaster2DataSetTableAdapters.OperationsTableAdapter operationsTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colPartID;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyRequired;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyDone;
        private DevExpress.XtraGrid.Columns.GridColumn colisFinalOp;
        private System.Windows.Forms.Button btnRemoveOperation;
        private System.Windows.Forms.Button btnAddOperation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}