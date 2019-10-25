using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPdfViewer;
using RadanMaster.Models;
using DevExpress.XtraGrid.Views.Grid;
using static DevExpress.DataAccess.Native.ExpressionEditor.ExpressionEditorController.ErrorInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Caching;
using DevExpress.XtraReports.UI;
using System.Data.Entity;
using DevExpress.XtraPrinting;
using System.Threading;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Menu;
using RadanProjectInterface;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using RadanInterface2;
using ProductionMasterModel;
using DevExpress.XtraSplashScreen;
using RadProject;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace RadanMaster
{
    public partial class Nesting2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        RefreshHelper helper;
        ProductionMasterModel.User currentUser { get; set; }
        RadanProjectInterface.RadanProjectInterface radProjInterface { get; set; }
        RadProject.RadanProject RPrj { get; set; }
        RadanInterface RadInterface { get; set; }
        string RadanProjectName { get; set; }

        public Nesting2(ProductionMasterModel.User curUser)
        {
            InitializeComponent();
            currentUser = curUser;
            radProjInterface = new RadanProjectInterface.RadanProjectInterface((string)AppSettings.AppSettings.Get("SymFilePath"), Globals.dbContext);
            RadanProjectName = (string)AppSettings.AppSettings.Get("RadanProjectPathAndFile");
            RPrj = RPrj.LoadData(RadanProjectName);
            setupView(ribbon.SelectedPage.Text);
        }

        private void Nesting2_Load(object sender, EventArgs e)
        {
            Globals.dbContext.Parts.Load();
            Globals.dbContext.Operations.Load();
            Globals.dbContext.OrderItemOperations.Load();
            Globals.dbContext.Orders.Load();
            Globals.dbContext.OrderItems.Load();
            Globals.dbContext.Parts.Load();
            Globals.dbContext.OperationPerformeds.Load();
            Globals.dbContext.Users.Load();
            Globals.dbContext.Privileges.Load();

            var result1 = from orderitem in Globals.dbContext.OrderItems
                          select new NestingDisplayItemWrapper
                          {
                              ID = orderitem.ID,
                              QtyRequired = orderitem.QtyRequired,
                              QtyNested = orderitem.OrderItemOperations.OrderByDescending(o => o.ID).FirstOrDefault().qtyDone, // lastordefault doesn't work with EF
                              CategoryName = orderitem.Part.CategoryName,
                              CategoryIcon = 0,
                              FileName = orderitem.Part.FileName,
                              Description = orderitem.Part.Description,
                              IsStock = orderitem.Part.IsStock,
                              Thickness = orderitem.Part.Thickness,
                              OrderNumber = orderitem.Order.OrderNumber,
                              StructuralCode = orderitem.Part.StructuralCode,
                              //ProductName = orderitem.ProductName,
                              Name = orderitem.Part.Operations.FirstOrDefault().Name,
                              ScheduleName = orderitem.Order.ScheduleName,
                              BatchName = orderitem.Order.BatchName,
                              Notes = orderitem.Notes,
                              IsComplete = orderitem.Order.IsComplete,
                              IsBatch = orderitem.Order.IsBatch,
                              PlantID = orderitem.Part.PlantID,
                              Thumbnail = orderitem.Part.Thumbnail,
                              item = orderitem,
                              IsInProject = orderitem.IsInProject,
                          };

            var result2 = (from orderitem in Globals.dbContext.OrderItems
                           group orderitem by new
                           {
                               ID = orderitem.ID,
                               QtyRequired = orderitem.QtyRequired,
                               QtyNested = orderitem.OrderItemOperations.OrderByDescending(o => o.ID).FirstOrDefault().qtyDone, // lastordefault doesn't work with EF
                               CategoryName = orderitem.Part.CategoryName,
                               CategoryIcon = 0,
                               FileName = orderitem.Part.FileName,
                               Description = orderitem.Part.Description,
                               IsStock = orderitem.Part.IsStock,
                               Thickness = orderitem.Part.Thickness,
                               OrderNumber = orderitem.Order.OrderNumber,
                               StructuralCode = orderitem.Part.StructuralCode,
                               //ProductName = orderitem.ProductName,
                               Name = orderitem.Part.Operations.FirstOrDefault().Name,
                               ScheduleName = orderitem.Order.ScheduleName,
                               BatchName = orderitem.Order.BatchName,
                               Notes = orderitem.Notes,
                               IsComplete = orderitem.Order.IsComplete,
                               IsBatch = orderitem.Order.IsBatch,
                               PlantID = orderitem.Part.PlantID,
                               Thumbnail = orderitem.Part.Thumbnail,
                               item = orderitem,
                               IsInProject = orderitem.IsInProject,
                           }
                           into grp
                           select new
                           {
                               grp.Key.ID,
                               grp.Key.QtyRequired,
                               grp.Key.QtyNested,
                               CategoryIcon = 0,
                               grp.Key.FileName,
                               grp.Key.Description,
                               grp.Key.IsStock,
                               grp.Key.Thickness,
                               grp.Key.OrderNumber,
                               grp.Key.StructuralCode,
                               //ProductName = orderitem.ProductName,
                               grp.Key.Name,
                               grp.Key.ScheduleName,
                               grp.Key.BatchName,
                               grp.Key.Notes,
                               grp.Key.IsComplete,
                               grp.Key.IsBatch,
                               grp.Key.PlantID,
                               grp.Key.Thumbnail,
                               grp.Key.item,
                               grp.Key.IsInProject,
                               QTY = grp.Sum(NestingDisplayItemWrapper => NestingDisplayItemWrapper.QtyRequired)
                           });

            //var result2 = (from NestingDisplayItemWrapper in result1
            //               group NestingDisplayItemWrapper by new { NestingDisplayItemWrapper.FileName, NestingDisplayItemWrapper.QtyNested }
            //                                           into grp
            //               select new
            //               {
            //                   grp.Key.FileName,
            //                   grp.Key.QtyNested,
            //                   QTY = grp.Sum(NestingDisplayItemWrapper => NestingDisplayItemWrapper.QtyNested)
            //               });

            entityServerModeSource2.QueryableSource = result2;

            // load all symbols for laser parts that don't have any...
            List<Part> partsWithoutSymbols = new List<Part>();
            partsWithoutSymbols = Globals.dbContext.Parts.Where(p => p.Operations.FirstOrDefault().Name == "Laser")
                                                         .Where(p => p.Thumbnail == null).ToList();
            foreach (Part p in partsWithoutSymbols)
            {
                p.Thumbnail = radProjInterface.updateThumbnail(p.FileName);
            }
            Globals.dbContext.SaveChanges();

            // load grid layout from file
            string SettingsFilePath = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\RadanMaster\Nesting2GridLayout.xml";
            if (System.IO.File.Exists(SettingsFilePath))
            {
                gridControlNesting2.ForceInitialize();
                gridControlNesting2.MainView.RestoreLayoutFromXml(SettingsFilePath);
            }

            // load collapsed/expanded state of gridview
            helper = new RefreshHelper(gridViewNesting2, "ID", "Nesting2GridExpansion.xml");
            helper.LoadViewInfo();


            setupView(ribbon.SelectedPage.Text);

            gridViewNesting2.RefreshData();

        }

        private void gridViewNesting2_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            //if (e.Column.FieldName == "calcQtyDone")
            //{
            //    int origQtyNested = 0;

            //    if (RPrj == null)
            //        e.Value = "??";
            //    else
            //    {
            //        int totalNested = 0;
            //        NestingDisplayItemWrapper itemWrapper = (NestingDisplayItemWrapper)e.Row;


            //        OrderItem calcItem = (OrderItem)itemWrapper.item;

            //        origQtyNested = calcItem.QtyNested;

            //        if (calcItem.RadanIDNumber != 0)
            //        {
            //            int radanID = calcItem.RadanIDNumber;

            //            foreach (RadanPart radanPart in RPrj.Parts.Part)
            //            {
            //                if (radanPart.Bin == radanID.ToString())
            //                {
            //                    totalNested += radanPart.Made;
            //                }
            //            }
            //        }

            //        e.Value = calcItem.QtyNested += totalNested;

            //        // for some reason e.Value gets written to calcItem.QtyNested.
            //        //    because this event fires multiple times, the quantity nested gets incremented multiple times.
            //        //    This is not what we want so the following line is a work around.
            //        calcItem.QtyNested = origQtyNested;

            //        if ((int)e.Value >= calcItem.QtyRequired)
            //            calcItem.IsComplete = true;
            //        else
            //            calcItem.IsComplete = false;
            //    }
            //}

            //if (e.Column.FieldName == "calcRemaining")
            //{
            //    int origQtyNested = 0;

            //    if (RPrj == null)
            //        e.Value = "??";
            //    else
            //    {
            //        int totalNested = 0;
            //        OrderItem calcItem = (OrderItem)e.Row;
            //        origQtyNested = calcItem.QtyNested;

            //        if (calcItem.RadanIDNumber != 0)
            //        {
            //            int radanID = calcItem.RadanIDNumber;

            //            foreach (RadanPart radanPart in RPrj.Parts.Part)
            //            {
            //                if (radanPart.Bin == radanID.ToString())
            //                {
            //                    totalNested += radanPart.Made;
            //                }
            //            }
            //        }

            //        e.Value = calcItem.QtyRequired - (calcItem.QtyNested += totalNested);

            //        // for some reason e.Value gets written to calcItem.QtyNested.
            //        //    because this event fires multiple times, the quantity nested gets incremented multiple times.
            //        //    This is not what we want so the following line is a work around.
            //        calcItem.QtyNested = origQtyNested;

            //        //if ((int)e.Value >= calcItem.QtyRequired)
            //        //    calcItem.IsComplete = true;
            //        //else
            //        //    calcItem.IsComplete = false;
            //    }
            //}
        }

        private void Nesting2_FormClosing(object sender, FormClosingEventArgs e)
        {
            string SettingsFilePath = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\RadanMaster\Nesting2GridLayout.xml";
            gridControlNesting2.MainView.SaveLayoutToXml(SettingsFilePath, OptionsLayoutBase.FullLayout);

            //save the expanded/contracted state of grouped rows
            helper.SaveViewInfo();
        }

        private void gridControlNesting2_MouseMove(object sender, MouseEventArgs e)
        {
            //GridHitInfo info = gridViewNesting2.CalcHitInfo(e.Location);
            //GridViewInfo viewInfo = gridViewNesting2.GetViewInfo() as GridViewInfo;
            //GridCellInfo cellInfo = viewInfo.GetGridCellInfo(info);

            //if (cellInfo != null)
            //{
            //    if (cellInfo.Column.Caption == "Name")
            //    {
            //        int handle = cellInfo.RowHandle;
            //        object o = gridViewNesting2.GetRow(handle);
            //        DisplayItemWrapper temp = (DisplayItemWrapper)o;
            //        OrderItem item = (OrderItem)temp.item;

            //        if (item != null)
            //        {
            //            int partIndex = item.PartID;
            //            Part prt = Globals.dbContext.Parts.FirstOrDefault(p => p.ID == partIndex);
            //            if (prt.Files.Count > 0)
            //            {
            //                int fileIndex = prt.Files.FirstOrDefault().FileId;
            //                ProductionMasterModel.File file = Globals.dbContext.Files.FirstOrDefault(f => f.FileId == fileIndex);
            //                Stream stream = new MemoryStream(file.Content);
            //                pdfViewerNesting2.LoadDocument(stream);
            //                pdfViewerNesting2.CurrentPageNumber = 1;
            //                pdfViewerNesting2.ZoomMode = PdfZoomMode.FitToVisible;

            //                Point popupPoint = new Point(e.X + 5, e.Y + 5);
            //                if (popupPoint.Y + popupContainerControlNesting2.Height > gridControlNesting2.Height)
            //                    popupPoint.Y = gridControlNesting2.Height - popupContainerControlNesting2.Height;
            //                popupContainerControlNesting2.Location = popupPoint;
            //                popupContainerControlNesting2.Show();
            //            }
            //            else
            //            {
            //                popupContainerControlNesting2.Hide();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        popupContainerControlNesting2.Hide();
            //    }

            //}
            //else
            //{
            //    popupContainerControlNesting2.Hide();
            //}

        }

        private void gridControlNesting2_ProcessGridKey(object sender, KeyEventArgs e)
        {

            bool canDelete = true;

            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                GridControl control = sender as GridControl;
                GridView view = (GridView)control.MainView;
                int numRows = view.SelectedRowsCount;
                if (MessageBox.Show("Delete " + numRows + " row(s)?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;

                List<int> rowHandleList = view.GetSelectedRows().ToList();
                foreach (int rowHandle in rowHandleList)
                {
                    object o = gridViewNesting2.GetRow(rowHandle);
                    DisplayItemWrapper temp = (DisplayItemWrapper)o;
                    OrderItem itemToDelete = (OrderItem)temp.item;

                    if (itemToDelete.IsInProject == true)
                    {
                        MessageBox.Show("Cannot delete items that are currently in a Radan project.  Please change your selection and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        canDelete = false;
                        break;
                    }
                }

                if (canDelete)
                {
                    foreach (int rowHandle in rowHandleList)
                    {
                        object o = gridViewNesting2.GetRow(rowHandle);
                        DisplayItemWrapper temp = (DisplayItemWrapper)o;
                        OrderItem itemToDelete = (OrderItem)temp.item;

                        if (itemToDelete != null)
                        {
                            Globals.dbContext.OrderItems.Remove(itemToDelete);
                        }
                    }
                    Globals.dbContext.SaveChanges();
                    entityServerModeSource2.Reload();
                    gridViewNesting2.RefreshData();
                }
            }

        }

        private void gridViewNesting2_DoubleClick(object sender, EventArgs e)
        {

            GridView view = sender as GridView;
            int numRows = view.SelectedRowsCount;

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewNesting2.GetRow(rowHandle);
                DisplayItemWrapper temp = (DisplayItemWrapper)o;
                OrderItem itemToEdit = (OrderItem)temp.item;

                Order order = Globals.dbContext.Orders.Where(ordr => ordr.ID == itemToEdit.OrderID).FirstOrDefault();

                EditOrderitem editForm = new EditOrderitem(itemToEdit, currentUser);
                string fileName = "", description = "", batchName = "";
                if (itemToEdit.Part != null)
                {
                    fileName = itemToEdit.Part.FileName;
                    description = itemToEdit.Part.Description;
                }
                if (order != null)
                    batchName = order.BatchName;

                string Title = fileName + "(" + description + ")" + "--->" + batchName;
                editForm.Text = Title;
                editForm.ShowDialog();
                Globals.dbContext.SaveChanges();
                entityServerModeSource2.Reload();
                gridViewNesting2.RefreshData();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reporting.OrderItemsBySchedule testReport = new Reporting.OrderItemsBySchedule();
            testReport.ShowPreview();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reporting.OrderItemByScheduleGroupedByPart report = new Reporting.OrderItemByScheduleGroupedByPart();
            report.ShowPreview();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reporting.TestReport2 report = new Reporting.TestReport2();
            report.ShowPreview();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!gridControlNesting2.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
            }

            gridViewNesting2.OptionsPrint.PrintDetails = true;
            gridViewNesting2.OptionsPrint.ExpandAllDetails = false;
            gridViewNesting2.OptionsPrint.ExpandAllGroups = false;


            gridControlNesting2.ShowPrintPreview();

            gridControlNesting2.Refresh();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {

            Reporting.XtraReport3 report = new Reporting.XtraReport3();
            report.ShowPreview();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reporting.XtraReport2 report = new Reporting.XtraReport2();
            report.ShowPreview();
        }

        private void gridViewNesting2_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
        }

        private void ribbon_SelectedPageChanging(object sender, DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs e)
        {
            this.Text = e.Page.Text;
            setupView(e.Page.Text);
        }

        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            string errMsg = "";
            string path = RadInterface.getOpenProjectName(ref errMsg);
            RadanProjectName = path;
            txtBoxRadanProjectBrowse.EditValue = RadanProjectName;
            radProjInterface.LoadData(path);

        }

        void setupView(string ribbonTitle)
        {
            ViewColumnFilterInfo viewFilterInfo = new ViewColumnFilterInfo(gridViewNesting2.Columns["Name"],
                new ColumnFilterInfo("[Name] = 'Laser'", ""));

            if (ribbonTitle == "Nesting")
            {
                gridViewNesting2.Columns["Name"].ClearFilter();
                gridViewNesting2.Columns.ColumnByFieldName("Thumbnail").Visible = true;
                gridViewNesting2.RowHeight = 80;
                gridViewNesting2.ActiveFilter.Add(viewFilterInfo);

                string radanProjectName = (string)AppSettings.AppSettings.Get("RadanProjectPathAndFile");


                txtBoxRadanProjectBrowse.EditValue = radanProjectName;

                radProjInterface.SetSymFolder((string)AppSettings.AppSettings.Get("SymFilePath"));


                RadInterface = new RadanInterface();
                if (RadInterface.Initialize())
                {
                    toolStripStatusLabel.Text = "Connected to Radan";
                }
                else
                {
                    toolStripStatusLabel.Text = "Could not connect to Radan";
                }
            }
            else
            {
                gridViewNesting2.Columns.ColumnByFieldName("Thumbnail").Visible = false;
                gridViewNesting2.RowHeight = -1;
                gridViewNesting2.Columns["Name"].ClearFilter();

                toolStripStatusLabel.Text = "All Production";
            }

            gridViewNesting2.RefreshData();
            entityServerModeSource2.Reload();
        }

        private void gridViewItems_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                List<int> selectedItemHandles = new List<int>();
                selectedItemHandles = gridViewNesting2.GetSelectedRows().ToList();

                List<OrderItem> selectedItems = new List<OrderItem>();

                foreach (int handle in selectedItemHandles)
                {
                    DisplayItemWrapper wrapper = (DisplayItemWrapper)gridViewNesting2.GetRow(handle);
                    selectedItems.Add((OrderItem)wrapper.item);
                }

                e.Menu.Items.Clear();
                DXMenuItem updateItem = new DXMenuItem("Update Thumbnail", OnUpdateThumbnailClick);
                updateItem.Tag = selectedItems;
                e.Menu.Items.Add(updateItem);

                //DXMenuItem convertItem = new DXMenuItem("Retrieve From Vault", OnRetrieveFromVaultClick);
                //convertItem.Tag = selectedItems;
                //e.Menu.Items.Add(convertItem);
            }
        }

        void OnUpdateThumbnailClick(object sender, EventArgs e)
        {
            {
                DXMenuItem menuItem = sender as DXMenuItem;

                List<OrderItem> selectedItems = (List<OrderItem>)menuItem.Tag;

                foreach (OrderItem item in selectedItems)
                {

                    item.Part.Thumbnail = radProjInterface.updateThumbnail(item.Part.FileName);

                }

                Globals.dbContext.SaveChanges();

                gridViewNesting2.RefreshData();
                entityServerModeSource2.Reload();
            }
        }

        private void barButtonConnectToRadan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (RadInterface.Initialize())
            {
                toolStripStatusLabel.Text = "Connected to Radan";
            }
            else
            {
                toolStripStatusLabel.Text = "Could not connect to Radan";
            }
        }

        private void gridViewNesting2_RowUpdated(object sender, RowObjectEventArgs e)
        {
            Globals.dbContext.SaveChanges();
        }

        private void gridViewNesting2_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Globals.dbContext.SaveChanges();
        }

        private void gridViewNesting2_KeyDown(object sender, KeyEventArgs e)
        {
            {
                bool canDelete = true;
                if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
                {
                    GridView view = sender as GridView;
                    int numRows = view.SelectedRowsCount;
                    if (MessageBox.Show("Delete " + numRows + " row(s)?", "Confirmation", MessageBoxButtons.YesNo) !=
                      DialogResult.Yes)
                        return;

                    List<int> rowHandleList = view.GetSelectedRows().ToList();
                    foreach (int rowHandle in rowHandleList)
                    {
                        object o = view.GetRow(rowHandle);
                        OrderItem itemToDelete = (OrderItem)o;
                        if (itemToDelete.IsInProject == true)
                        {
                            MessageBox.Show("Cannot delete items that are currently in a Radan project.  Please change your selection and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            canDelete = false;
                            break;
                        }
                    }

                    if (canDelete)
                        view.DeleteSelectedRows();
                }
            }
        }

        private void barButtonSendSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            {

                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                List<OrderItem> selectedOrderItems = new List<OrderItem>();

                Int32[] selectedRowHandles = gridViewNesting2.GetSelectedRows();
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    int selectedRowHandle = selectedRowHandles[i];
                    if (selectedRowHandle >= 0)

                    {

                        DisplayItemWrapper dItem = (DisplayItemWrapper)gridViewNesting2.GetRow(selectedRowHandle);

                        OrderItem orderItem = Globals.dbContext.OrderItems.Where(oi => oi.Part.FileName == dItem.FileName)
                                                                  .Where(oi => oi.Order.OrderNumber == dItem.OrderNumber)
                                                                  .Where(oi => oi.Order.BatchName == dItem.BatchName)
                                                                  .Where(oi => oi.Order.ScheduleName == dItem.ScheduleName).FirstOrDefault();
                        selectedOrderItems.Add(orderItem);

                    }
                }

                radProjInterface.SendItemsToRadan(selectedOrderItems, txtBoxRadanProjectBrowse.EditValue.ToString());

                SplashScreenManager.HideImage();

                entityServerModeSource2.Reload();
                gridViewNesting2.RefreshData();
            }
        }

        private void barButtonRetrieveSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (RadInterface.IsProjectReady())
            {
                string errMsg = "";
                if (RadInterface.getOpenProjectName(ref errMsg) == RadanProjectName)
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                    List<OrderItem> selectedItemList = new List<OrderItem>();
                    if (radProjInterface.saveRadan())
                    {
                        int[] rows = gridViewNesting2.GetSelectedRows();

                        foreach (int i in rows)
                        {
                            DisplayItemWrapper displayItem = (DisplayItemWrapper)gridViewNesting2.GetRow(i);
                            OrderItem item = Globals.dbContext.OrderItems.Where(oi => oi.Part.FileName == displayItem.FileName).
                                                                          Where(oi => oi.Order.OrderNumber == displayItem.OrderNumber).FirstOrDefault();
                            selectedItemList.Add(item);
                        }
                        radProjInterface.RetrieveSelectedRadanPartToMasterList(selectedItemList);
                        gridViewNesting2.Invalidate();
                        gridViewNesting2.RefreshData();


                    }
                    SplashScreenManager.HideImage();
                    entityServerModeSource2.Reload();
                    gridViewNesting2.RefreshData();

                }

                else
                {
                    MessageBox.Show("The Radan project that is open does not match the project in RadanMaster.");
                }
            }
            else
            {
                MessageBox.Show("Radan Is Not Ready");
            }
        }

        private void barButtonRadanProjectBrowse_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialogProject.Filter = "rpd files (*.rpd) | *.rpd";
            DialogResult result = openFileDialogProject.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string path = openFileDialogProject.FileName;

                RadanProjectName = openFileDialogProject.FileName;
                txtBoxRadanProjectBrowse.EditValue = RadanProjectName;
                radProjInterface.LoadData(path);
            }
        }

        private void barButtonUpdateFromRadan_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

            if (!radProjInterface.SyncRadanToMaster())
            {
                MessageBox.Show("Sync with Radan Project was not successful" + "\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RPrj = radProjInterface.GetRPrj();
            gridViewNesting2.RefreshData();
            entityServerModeSource2.Reload();

            SplashScreenManager.HideImage();
        }

        private void gridViewNesting2_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo row = e.Info as GridGroupRowInfo;

            DrawGroupRow(e);
        }

        private void DrawGroupRow(RowObjectCustomDrawEventArgs e)
        {
        //    var info = e.Info as GridGroupRowInfo;
        //    ImageList imageList1 = new ImageList();

        //    if (!(info.Column.FieldName == "FileName"))
        //    {
        //        return;
        //    }

        //    int rowhandle = e.RowHandle;

        //    var v = gridViewNesting2.GetRow(rowhandle);
        //    DisplayItemWrapper displayItem = (DisplayItemWrapper)v;

        //    using (var ms = new System.IO.MemoryStream(displayItem.Thumbnail))
        //    {
        //        using (var img1 = Image.FromStream(ms))
        //        {
        //            int bmSize = 32;
        //            Bitmap result = new Bitmap(bmSize, bmSize);
        //            using (Graphics g = Graphics.FromImage(result))
        //            {
        //                g.DrawImage(img1, 0, 0, bmSize, bmSize);
        //            }

        //            gridViewNesting2.GroupRowHeight = 75;
        //            imageList1.Images.Add(result);
        //        }
                
        //    }

        //    if (imageList1.Images != null)
        //    {
        //        GroupRowPaintHelper.CustomDrawNameGroupRow(e, gridViewNesting2, gridControlNesting2.LookAndFeel, imageList1);
        //        e.Handled = true;
        //    }
        }
    }

}