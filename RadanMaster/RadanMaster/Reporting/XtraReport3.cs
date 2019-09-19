using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using DevExpress.XtraPdfViewer;
using System.IO;
using ProductionMasterModel;

namespace RadanMaster.Reporting
{
    public partial class XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport3()
        {
            InitializeComponent();
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRControl control = (XRControl)sender;
            try
            {
                xrPictureBox1.ImageSource = null;
                var v = Report.GetCurrentRow();
               
                System.Reflection.PropertyInfo pi = v.GetType().GetProperty("Part");
                ProductionMasterModel.Part part = (ProductionMasterModel.Part)(pi.GetValue(v, null));

                int partID = part.ID;
                ProductionMasterModel.Part prt = new ProductionMasterModel.Part();
                prt = Globals.dbContext.Parts.FirstOrDefault(p => p.ID == partID);

                if (prt.Files != null)
                {
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

                                xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(bitmap);
                                xrPictureBox1.BackColor = Color.AliceBlue;

                                PdfViewer pdfViewer2 = new PdfViewer();
                                Stream stream2 = new MemoryStream(fileItem.Content);
                                pdfViewer2.LoadDocument(stream2);
                                Bitmap bitmap2 = pdfViewer2.CreateBitmap(1, 950);
                                bitmap2.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                //xrPictureBox2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(bitmap2);

                                pdfViewer2.CloseDocument();
                                pdfViewer2.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void CategoryInt_GetValue(object sender, GetValueEventArgs e)
        {
            object p1 = e.Row;

            System.Reflection.PropertyInfo pi = p1.GetType().GetProperty("Part");

            if (pi != null)
            {

                ProductionMasterModel.Part prt = (ProductionMasterModel.Part)(pi.GetValue(p1, null));

                switch (prt.CategoryName)
                {
                    case "Product":
                        e.Value = 0; ;
                        break;
                    case "Assembly":
                        e.Value = 1;
                        break;
                    case "Part":
                        e.Value = 2;
                        break;
                    default:
                        e.Value = 0;
                        break;
                }
            }
            
        }
    }
}
