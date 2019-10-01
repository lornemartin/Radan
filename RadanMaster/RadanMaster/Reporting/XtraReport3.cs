using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using DevExpress.XtraPdfViewer;
using System.IO;
using ProductionMasterModel;
using DevExpress.DataAccess;
using System.Collections.Generic;

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

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Retrieve the current row and get the "Country" member's value.
            var v = (ProductionMasterModel.OrderItem)(GetCurrentRow());
            string productName = v.ProductName;
            string orderNumber = v.Order.OrderNumber;
            

            if (v.Part.CategoryName == "Product")
            {
                int itemQty = v.QtyRequired;

                List<ProductionMasterModel.OrderItem> associatedItemsList = Globals.dbContext.OrderItems.Where(i => i.Order.OrderNumber == orderNumber)
                                                                                                        .Where(i => i.ProductName == productName)
                                                                                                        .Where(i => i.Part.CategoryName == "Part")
                                                                                                        .Where(i => i.Part.IsStock == false)
                                                                                                        .Where(i => i.Part.Operations.FirstOrDefault().Name == "Bandsaw").ToList();

                XRTable table = new XRTable();
                table.SizeF = new SizeF(300, 100);
                table.BeginInit();
                table.BorderWidth = 2;
                table.Borders = DevExpress.XtraPrinting.BorderSide.All;


                foreach (ProductionMasterModel.OrderItem associatedItem in associatedItemsList)
                {

                    //if (associatedItem.OrderItemOperations.FirstOrDefault().Operation.Name == "Bandsaw")
                    //{
                    if (associatedItem.Part.RequiresPDF == false)
                    {
                        table.BeginInit();
                        XRTableRow row = new XRTableRow();

                        XRTableCell qtyCell = new XRTableCell();
                        qtyCell.WidthF = 100;
                        qtyCell.Text = (associatedItem.QtyRequired * itemQty).ToString();
                        XRTableCell nameCell = new XRTableCell();
                        nameCell.WidthF = 500;
                        nameCell.Text = associatedItem.Part.FileName;
                        XRTableCell descCell = new XRTableCell();
                        descCell.Text = associatedItem.Part.Description;
                        descCell.WidthF = 500;

                        row.Cells.Add(qtyCell);
                        row.Cells.Add(nameCell);
                        row.Cells.Add(descCell);


                        table.Rows.Add(row);
                    }
                }
                table.EndInit();

                GroupHeader2.Controls.Clear();
                GroupHeader2.Controls.Add(table);
            }
        }
    }
}
