using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraPdfViewer;
using System.Linq;

namespace RadanMaster.Reporting
{
    public partial class testReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        RadanMaster.DAL.RadanMasterContext dbContext { get; set; }

        public testReport2()
        {
            dbContext = new RadanMaster.DAL.RadanMasterContext();
            InitializeComponent();
            //this.FilterString = @"[Order.OrderNumber] = 'A402969'";
        }

        private void pictureBox1_Draw(object sender, DrawEventArgs e)
        {

            //int fileIndex = prt.Files.FirstOrDefault().FileId;
            //Models.File file = dbContext.Files.FirstOrDefault(f => f.FileId == fileIndex);
            //Stream stream = new MemoryStream(file.Content);
            //pdfViewerAllProduction.LoadDocument(stream);
            //pdfViewerAllProduction.CurrentPageNumber = 1;
            //pdfViewerAllProduction.ZoomMode = PdfZoomMode.FitToVisible;

            //Point popupPoint = new Point(e.X + 5, e.Y + 5);
            //if (popupPoint.Y + popupContainerControlAllProduction.Height > gridControlAllProduction.Height)
            //    popupPoint.Y = gridControlAllProduction.Height - popupContainerControlAllProduction.Height;
            //popupContainerControlAllProduction.Location = popupPoint;
            //popupContainerControlAllProduction.Show();

            //object o = sender;
            //Models.File f = (Models.File)sender;
            //int i = 10;
            
        }

        private void VerticalDetail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRControl control = (XRControl)sender;
            int orderItemID = (int) this.GetCurrentColumnValue("ID");
            Models.OrderItem oItem = new Models.OrderItem();
            oItem = dbContext.OrderItems.FirstOrDefault(o => o.ID == orderItemID);

            int partID = oItem.PartID;
            Models.Part prt = new Models.Part();
            prt = dbContext.Parts.FirstOrDefault(p => p.ID == partID);

            if (prt.Files.Count > 0)
            {
                int fileID = prt.Files.FirstOrDefault().FileId;
                Models.File fileItem = new Models.File();
                fileItem = dbContext.Files.FirstOrDefault(f => f.FileId == fileID);

                if (fileItem.Content!=null)
                {
                    PdfViewer pdfViewer = new PdfViewer();
                    Stream stream = new MemoryStream(fileItem.Content);

                    pdfViewer.LoadDocument(stream);
                    Bitmap bitmap = pdfViewer.CreateBitmap(1,950);
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    
                    pdfViewer.CloseDocument();
                    pdfViewer.Dispose();

                    xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(bitmap);
                    //string name = (string) this.GetCurrentColumnValue("FileName");
                    //xrLabel1.Text = name;
                }
            }



            //Models.OrderItem oItem = dbContext.OrderItems

        }

        
    }
}
