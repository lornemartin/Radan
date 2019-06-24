namespace RadanMaster
{
    partial class OperationCompleted
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
            this.OperationCompletedlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.TextEditQty = new DevExpress.XtraEditors.TextEdit();
            this.btnRecordOp = new System.Windows.Forms.Button();
            this.gridControlOpsPerformed = new DevExpress.XtraGrid.GridControl();
            this.gridViewOpsPerformed = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlOrderItemOpsPerformed = new DevExpress.XtraGrid.GridControl();
            this.gridViewOrderItemOpsPerformed = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlAssociatedOrderItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewAssociatedOrderItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyReqd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyDone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.OperationCompletedlayoutControl1ConvertedLayout)).BeginInit();
            this.OperationCompletedlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOpsPerformed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOpsPerformed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrderItemOpsPerformed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderItemOpsPerformed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAssociatedOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssociatedOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // OperationCompletedlayoutControl1ConvertedLayout
            // 
            this.OperationCompletedlayoutControl1ConvertedLayout.Controls.Add(this.TextEditQty);
            this.OperationCompletedlayoutControl1ConvertedLayout.Controls.Add(this.btnRecordOp);
            this.OperationCompletedlayoutControl1ConvertedLayout.Controls.Add(this.gridControlOpsPerformed);
            this.OperationCompletedlayoutControl1ConvertedLayout.Controls.Add(this.gridControlOrderItemOpsPerformed);
            this.OperationCompletedlayoutControl1ConvertedLayout.Controls.Add(this.gridControlAssociatedOrderItems);
            this.OperationCompletedlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationCompletedlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.OperationCompletedlayoutControl1ConvertedLayout.Name = "OperationCompletedlayoutControl1ConvertedLayout";
            this.OperationCompletedlayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(699, 212, 650, 400);
            this.OperationCompletedlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.OperationCompletedlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(1023, 543);
            this.OperationCompletedlayoutControl1ConvertedLayout.TabIndex = 1;
            // 
            // TextEditQty
            // 
            this.TextEditQty.Location = new System.Drawing.Point(65, 511);
            this.TextEditQty.Name = "TextEditQty";
            this.TextEditQty.Size = new System.Drawing.Size(206, 20);
            this.TextEditQty.StyleController = this.OperationCompletedlayoutControl1ConvertedLayout;
            this.TextEditQty.TabIndex = 5;
            // 
            // btnRecordOp
            // 
            this.btnRecordOp.Location = new System.Drawing.Point(275, 511);
            this.btnRecordOp.Name = "btnRecordOp";
            this.btnRecordOp.Size = new System.Drawing.Size(736, 20);
            this.btnRecordOp.TabIndex = 4;
            this.btnRecordOp.Text = "Record Operation Done";
            this.btnRecordOp.UseVisualStyleBackColor = true;
            this.btnRecordOp.Click += new System.EventHandler(this.btnRecordOp_Click);
            // 
            // gridControlOpsPerformed
            // 
            this.gridControlOpsPerformed.Location = new System.Drawing.Point(12, 251);
            this.gridControlOpsPerformed.MainView = this.gridViewOpsPerformed;
            this.gridControlOpsPerformed.Name = "gridControlOpsPerformed";
            this.gridControlOpsPerformed.Size = new System.Drawing.Size(999, 256);
            this.gridControlOpsPerformed.TabIndex = 3;
            this.gridControlOpsPerformed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOpsPerformed});
            // 
            // gridViewOpsPerformed
            // 
            this.gridViewOpsPerformed.GridControl = this.gridControlOpsPerformed;
            this.gridViewOpsPerformed.Name = "gridViewOpsPerformed";
            // 
            // gridControlOrderItemOpsPerformed
            // 
            this.gridControlOrderItemOpsPerformed.Location = new System.Drawing.Point(513, 12);
            this.gridControlOrderItemOpsPerformed.MainView = this.gridViewOrderItemOpsPerformed;
            this.gridControlOrderItemOpsPerformed.Name = "gridControlOrderItemOpsPerformed";
            this.gridControlOrderItemOpsPerformed.Size = new System.Drawing.Size(498, 235);
            this.gridControlOrderItemOpsPerformed.TabIndex = 2;
            this.gridControlOrderItemOpsPerformed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrderItemOpsPerformed});
            // 
            // gridViewOrderItemOpsPerformed
            // 
            this.gridViewOrderItemOpsPerformed.GridControl = this.gridControlOrderItemOpsPerformed;
            this.gridViewOrderItemOpsPerformed.Name = "gridViewOrderItemOpsPerformed";
            // 
            // gridControlAssociatedOrderItems
            // 
            this.gridControlAssociatedOrderItems.Location = new System.Drawing.Point(12, 12);
            this.gridControlAssociatedOrderItems.MainView = this.gridViewAssociatedOrderItems;
            this.gridControlAssociatedOrderItems.Name = "gridControlAssociatedOrderItems";
            this.gridControlAssociatedOrderItems.Size = new System.Drawing.Size(497, 235);
            this.gridControlAssociatedOrderItems.TabIndex = 0;
            this.gridControlAssociatedOrderItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAssociatedOrderItems});
            // 
            // gridViewAssociatedOrderItems
            // 
            this.gridViewAssociatedOrderItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colQtyReqd,
            this.colQtyDone,
            this.colName,
            this.colProduct,
            this.colBatch});
            this.gridViewAssociatedOrderItems.GridControl = this.gridControlAssociatedOrderItems;
            this.gridViewAssociatedOrderItems.Name = "gridViewAssociatedOrderItems";
            this.gridViewAssociatedOrderItems.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewAssociatedOrderItems_RowClick);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colQtyReqd
            // 
            this.colQtyReqd.Caption = "Qty Req\'d";
            this.colQtyReqd.FieldName = "qtyRequired";
            this.colQtyReqd.Name = "colQtyReqd";
            this.colQtyReqd.Visible = true;
            this.colQtyReqd.VisibleIndex = 0;
            this.colQtyReqd.Width = 146;
            // 
            // colQtyDone
            // 
            this.colQtyDone.Caption = "Qty Done";
            this.colQtyDone.FieldName = "qtyDone";
            this.colQtyDone.Name = "colQtyDone";
            this.colQtyDone.Visible = true;
            this.colQtyDone.VisibleIndex = 1;
            this.colQtyDone.Width = 116;
            // 
            // colName
            // 
            this.colName.Caption = "Op Name";
            this.colName.FieldName = "operation.Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 404;
            // 
            // colProduct
            // 
            this.colProduct.Caption = "Product";
            this.colProduct.FieldName = "orderItem.ProductName";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 3;
            this.colProduct.Width = 448;
            // 
            // colBatch
            // 
            this.colBatch.Caption = "Batch";
            this.colBatch.FieldName = "orderItem.Order.BatchName";
            this.colBatch.Name = "colBatch";
            this.colBatch.Visible = true;
            this.colBatch.VisibleIndex = 4;
            this.colBatch.Width = 393;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1023, 543);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlAssociatedOrderItems;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(501, 239);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControlOrderItemOpsPerformed;
            this.layoutControlItem2.Location = new System.Drawing.Point(501, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(502, 239);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControlOpsPerformed;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 239);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1003, 260);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRecordOp;
            this.layoutControlItem4.Location = new System.Drawing.Point(263, 499);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(740, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.TextEditQty;
            this.layoutControlItem5.CustomizationFormText = "Qty Donez:";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 499);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem5.Text = "Qty Done:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 13);
            // 
            // OperationCompleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 543);
            this.Controls.Add(this.OperationCompletedlayoutControl1ConvertedLayout);
            this.Name = "OperationCompleted";
            this.Text = "OperationCompleted";
            this.Load += new System.EventHandler(this.OperationCompleted_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OperationCompletedlayoutControl1ConvertedLayout)).EndInit();
            this.OperationCompletedlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOpsPerformed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOpsPerformed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrderItemOpsPerformed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderItemOpsPerformed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAssociatedOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssociatedOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl OperationCompletedlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Button btnRecordOp;
        private DevExpress.XtraGrid.GridControl gridControlOpsPerformed;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOpsPerformed;
        private DevExpress.XtraGrid.GridControl gridControlOrderItemOpsPerformed;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrderItemOpsPerformed;
        private DevExpress.XtraGrid.GridControl gridControlAssociatedOrderItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAssociatedOrderItems;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyReqd;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyDone;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colBatch;
        private DevExpress.XtraEditors.TextEdit TextEditQty;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}