using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using DevExpress.XtraPdfViewer;
using System.IO;
using DevExpress.XtraPrinting.Drawing;

namespace RadanMaster.Reporting
{
    public partial class TestReport12 : DevExpress.XtraReports.UI.XtraReport
    {
        RadanMaster.DAL.RadanMasterContext dbContext { get; set; }

        public TestReport12()
        {
            InitializeComponent();
            dbContext = new RadanMaster.DAL.RadanMasterContext();
        }

        private void pictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRControl control = (XRControl)sender;

            int orderItemID = (int)DetailReport.GetCurrentColumnValue("ID");

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

                if (fileItem.Content != null)
                {
                    if (fileItem.Content != null)
                    {
                        PdfViewer pdfViewer = new PdfViewer();
                        Stream stream = new MemoryStream(fileItem.Content);

                        pdfViewer.LoadDocument(stream);
                        Bitmap bitmap = pdfViewer.CreateBitmap(1, 950);

                        pdfViewer.CloseDocument();
                        pdfViewer.Dispose();
                        pictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(bitmap);
                        pictureBox1.BackColor = Color.AliceBlue;

                        pdfViewer.CloseDocument();
                        pdfViewer.Dispose();
                    }
                }
            }
        }
    }
}
