namespace RadanMaster.Reporting
{
    partial class testReport2
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.EntityFramework.EFConnectionParameters efConnectionParameters1 = new DevExpress.DataAccess.EntityFramework.EFConnectionParameters();
            DevExpress.DataAccess.EntityFramework.DBSetFilter dbSetFilter1 = new DevExpress.DataAccess.EntityFramework.DBSetFilter();
            this.efDataSource1 = new DevExpress.DataAccess.EntityFramework.EFDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1VerticalFirstRow = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1VerticalLastRow_Even = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderData1VerticalFirstRow = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderData1VerticalLastRow_Even = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.pageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.VerticalHeader = new DevExpress.XtraReports.UI.VerticalHeaderBand();
            this.VerticalDetail = new DevExpress.XtraReports.UI.VerticalDetailBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // efDataSource1
            // 
            efConnectionParameters1.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"M:\\ProductionMaster Database" +
    "\\RadanMaster.mdf\";Integrated Security=True;Connect Timeout=30";
            efConnectionParameters1.ConnectionStringName = "";
            efConnectionParameters1.Source = typeof(RadanMaster.DAL.RadanMasterContext);
            this.efDataSource1.ConnectionParameters = efConnectionParameters1;
            dbSetFilter1.CriteriaOperator = null;
            dbSetFilter1.DBSetName = "OrderItems";
            dbSetFilter1.FilterString = "[Order] Is Not Null";
            this.efDataSource1.Filters.AddRange(new DevExpress.DataAccess.EntityFramework.DBSetFilter[] {
            dbSetFilter1});
            this.efDataSource1.Name = "efDataSource1";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // DetailData1VerticalFirstRow
            // 
            this.DetailData1VerticalFirstRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData1VerticalFirstRow.BorderColor = System.Drawing.Color.White;
            this.DetailData1VerticalFirstRow.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.DetailData1VerticalFirstRow.BorderWidth = 2F;
            this.DetailData1VerticalFirstRow.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1VerticalFirstRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DetailData1VerticalFirstRow.Name = "DetailData1VerticalFirstRow";
            this.DetailData1VerticalFirstRow.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1VerticalFirstRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1VerticalLastRow_Even
            // 
            this.DetailData1VerticalLastRow_Even.BackColor = System.Drawing.Color.Transparent;
            this.DetailData1VerticalLastRow_Even.BorderColor = System.Drawing.Color.White;
            this.DetailData1VerticalLastRow_Even.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.DetailData1VerticalLastRow_Even.BorderWidth = 2F;
            this.DetailData1VerticalLastRow_Even.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1VerticalLastRow_Even.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DetailData1VerticalLastRow_Even.Name = "DetailData1VerticalLastRow_Even";
            this.DetailData1VerticalLastRow_Even.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1VerticalLastRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HeaderData1VerticalFirstRow
            // 
            this.HeaderData1VerticalFirstRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.HeaderData1VerticalFirstRow.BorderColor = System.Drawing.Color.White;
            this.HeaderData1VerticalFirstRow.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.HeaderData1VerticalFirstRow.BorderWidth = 2F;
            this.HeaderData1VerticalFirstRow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderData1VerticalFirstRow.ForeColor = System.Drawing.Color.White;
            this.HeaderData1VerticalFirstRow.Name = "HeaderData1VerticalFirstRow";
            this.HeaderData1VerticalFirstRow.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.HeaderData1VerticalFirstRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HeaderData1VerticalLastRow_Even
            // 
            this.HeaderData1VerticalLastRow_Even.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.HeaderData1VerticalLastRow_Even.BorderColor = System.Drawing.Color.White;
            this.HeaderData1VerticalLastRow_Even.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.HeaderData1VerticalLastRow_Even.BorderWidth = 2F;
            this.HeaderData1VerticalLastRow_Even.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderData1VerticalLastRow_Even.ForeColor = System.Drawing.Color.White;
            this.HeaderData1VerticalLastRow_Even.Name = "HeaderData1VerticalLastRow_Even";
            this.HeaderData1VerticalLastRow_Even.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.HeaderData1VerticalLastRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageInfo1,
            this.pageInfo2});
            this.BottomMargin.HeightF = 109.3329F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // pageInfo1
            // 
            this.pageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 56.00001F);
            this.pageInfo1.Name = "pageInfo1";
            this.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.pageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.pageInfo1.StyleName = "PageInfo";
            // 
            // pageInfo2
            // 
            this.pageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(374.7501F, 56.00001F);
            this.pageInfo2.Name = "pageInfo2";
            this.pageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.pageInfo2.StyleName = "PageInfo";
            this.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.pageInfo2.TextFormatString = "Page {0} of {1}";
            // 
            // VerticalHeader
            // 
            this.VerticalHeader.HeightF = 1284.333F;
            this.VerticalHeader.Name = "VerticalHeader";
            this.VerticalHeader.RepeatEveryPage = true;
            this.VerticalHeader.WidthF = 15.625F;
            // 
            // VerticalDetail
            // 
            this.VerticalDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1});
            this.VerticalDetail.HeightF = 1284.333F;
            this.VerticalDetail.KeepTogether = true;
            this.VerticalDetail.Name = "VerticalDetail";
            this.VerticalDetail.WidthF = 770.0834F;
            this.VerticalDetail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.VerticalDetail_BeforePrint);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.BottomCenter;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(760.0833F, 980.1669F);
            // 
            // testReport2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.VerticalHeader,
            this.VerticalDetail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.efDataSource1});
            this.DataMember = "OrderItems";
            this.DataSource = this.efDataSource1;
            this.FilterString = "[ID] > 1000 And [ID] < 1020";
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(32, 30, 20, 109);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.PageInfo,
            this.DetailData1VerticalFirstRow,
            this.DetailData1VerticalLastRow_Even,
            this.HeaderData1VerticalFirstRow,
            this.HeaderData1VerticalLastRow_Even});
            this.Version = "18.2";
            this.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DataAccess.EntityFramework.EFDataSource efDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1VerticalFirstRow;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1VerticalLastRow_Even;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderData1VerticalFirstRow;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderData1VerticalLastRow_Even;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo2;
        private DevExpress.XtraReports.UI.VerticalHeaderBand VerticalHeader;
        private DevExpress.XtraReports.UI.VerticalDetailBand VerticalDetail;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
    }
}
