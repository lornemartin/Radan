using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using DevExpress.XtraPdfViewer;
using System.IO;

namespace RadanMaster.Reporting
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        private void pictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRControl control = (XRControl)sender;
            try
            {
                string qty = (string)DetailReport.GetCurrentColumnValue("QtyRequired");

                var v = DetailReport.GetCurrentRow();
                System.Reflection.PropertyInfo pi = v.GetType().GetProperty("OrderItem");
                ProductionMasterModel.OrderItem oItem = (ProductionMasterModel.OrderItem)(pi.GetValue(v, null));

                int partID = oItem.PartID;
                ProductionMasterModel.Part prt = new ProductionMasterModel.Part();
                prt = Globals.dbContext.Parts.FirstOrDefault(p => p.ID == partID);

                if (prt.Files.Count > 0)
                {
                    int fileID = prt.Files.FirstOrDefault().FileId;
                    ProductionMasterModel.File fileItem = new ProductionMasterModel.File();
                    fileItem = Globals.dbContext.Files.FirstOrDefault(f => f.FileId == fileID);

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

                            PdfViewer pdfViewer2 = new PdfViewer();
                            Stream stream2 = new MemoryStream(fileItem.Content);
                            pdfViewer2.LoadDocument(stream2);
                            Bitmap bitmap2 = pdfViewer2.CreateBitmap(1, 950);
                            bitmap2.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            xrPictureBox2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(bitmap2);

                            pdfViewer2.CloseDocument();
                            pdfViewer2.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
