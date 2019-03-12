using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraPdfViewer;

namespace RadanMaster.Reporting
{
    public partial class testReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public testReport1()
        {
            InitializeComponent();
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
            byte []pData = (byte[]) this.GetCurrentColumnValue("Content");

            if (pData != null)
            {
                PdfViewer pdfViewer = new PdfViewer();
                Stream stream = new MemoryStream((byte[])this.GetCurrentColumnValue("Content"));

                pdfViewer.LoadDocument(stream);
                Bitmap bitmap = pdfViewer.CreateBitmap(1, 500);
                pdfViewer.CloseDocument();
                pdfViewer.Dispose();

                xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(bitmap);
                //string name = (string) this.GetCurrentColumnValue("FileName");
                //xrLabel1.Text = name;
            }
        }

        
    }
}
