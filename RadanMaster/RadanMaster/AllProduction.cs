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

namespace RadanMaster
{
    public partial class AllProduction : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        RefreshHelper helper;
        ProductionMasterModel.User currentUser { get; set; }
        RadanProjectInterface.RadanProjectInterface radProjInterface { get; set; }
        RadanInterface RadInterface { get; set; }
        

        public AllProduction(ProductionMasterModel.User curUser)
        {
            InitializeComponent();
            currentUser = curUser;
            radProjInterface = new RadanProjectInterface.RadanProjectInterface((string)AppSettings.AppSettings.Get("SymFilePath"),Globals.dbContext);

            setupView(ribbon.SelectedPage.Text);
        }

        private void AllProduction_Load(object sender, EventArgs e)
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

            entityServerModeSource2.QueryableSource = from orderitem in Globals.dbContext.OrderItems
                                                      select new DisplayItemWrapper
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
                                                          ProductName = orderitem.ProductName,
                                                          Name = orderitem.Part.Operations.FirstOrDefault().Name,
                                                          ScheduleName = orderitem.Order.ScheduleName,
                                                          BatchName = orderitem.Order.BatchName,
                                                          Notes = orderitem.Notes,
                                                          IsComplete = orderitem.Order.IsComplete,
                                                          IsBatch = orderitem.Order.IsBatch,
                                                          PlantID = orderitem.Part.PlantID,
                                                          Thumbnail = orderitem.Part.Thumbnail,
                                                          item = orderitem,
                                                      };

            // load all symbols for laser parts that don't have any...
            List<Part> partsWithoutSymbols = new List<Part>();
            partsWithoutSymbols = Globals.dbContext.Parts.Where(p => p.Operations.FirstOrDefault().Name == "Laser")
                                                         .Where(p => p.Thumbnail == null).ToList();
            foreach(Part p in partsWithoutSymbols)
            {
                p.Thumbnail = radProjInterface.updateThumbnail(p.FileName);
            }
            Globals.dbContext.SaveChanges();

            // load grid layout from file
            string SettingsFilePath = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\RadanMaster\AllProductionGridLayout.xml";
            if (System.IO.File.Exists(SettingsFilePath))
            {
                gridControlAllProduction.ForceInitialize();
                gridControlAllProduction.MainView.RestoreLayoutFromXml(SettingsFilePath);
            }

            // load collapsed/expanded state of gridview
            helper = new RefreshHelper(gridViewAllProduction, "ID", "AllProductionGridExpansion.xml");
            helper.LoadViewInfo();


            setupView(ribbon.SelectedPage.Text);

            gridViewAllProduction.RefreshData();

        }

        private void AllProduction_FormClosing(object sender, FormClosingEventArgs e)
        {
            string SettingsFilePath = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\RadanMaster\AllProductionGridLayout.xml";
            gridControlAllProduction.MainView.SaveLayoutToXml(SettingsFilePath, OptionsLayoutBase.FullLayout);

            //save the expanded/contracted state of grouped rows
            helper.SaveViewInfo();
        }

        private void gridControlAllProduction_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewAllProduction.CalcHitInfo(e.Location);
            GridViewInfo viewInfo = gridViewAllProduction.GetViewInfo() as GridViewInfo;
            GridCellInfo cellInfo = viewInfo.GetGridCellInfo(info);

            if (cellInfo != null)
            {
                if (cellInfo.Column.Caption == "Name")
                {
                    int handle = cellInfo.RowHandle;
                    object o = gridViewAllProduction.GetRow(handle);
                    DisplayItemWrapper temp = (DisplayItemWrapper)o;
                    OrderItem item = (OrderItem)temp.item;

                    if (item != null)
                    {
                        int partIndex = item.PartID;
                        Part prt = Globals.dbContext.Parts.FirstOrDefault(p => p.ID == partIndex);
                        if (prt.Files.Count > 0)
                        {
                            int fileIndex = prt.Files.FirstOrDefault().FileId;
                            ProductionMasterModel.File file = Globals.dbContext.Files.FirstOrDefault(f => f.FileId == fileIndex);
                            Stream stream = new MemoryStream(file.Content);
                            pdfViewerAllProduction.LoadDocument(stream);
                            pdfViewerAllProduction.CurrentPageNumber = 1;
                            pdfViewerAllProduction.ZoomMode = PdfZoomMode.FitToVisible;

                            Point popupPoint = new Point(e.X + 5, e.Y + 5);
                            if (popupPoint.Y + popupContainerControlAllProduction.Height > gridControlAllProduction.Height)
                                popupPoint.Y = gridControlAllProduction.Height - popupContainerControlAllProduction.Height;
                            popupContainerControlAllProduction.Location = popupPoint;
                            popupContainerControlAllProduction.Show();
                        }
                        else
                        {
                            popupContainerControlAllProduction.Hide();
                        }
                    }
                }
                else
                {
                    popupContainerControlAllProduction.Hide();
                }

            }
            else
            {
                popupContainerControlAllProduction.Hide();
            }

        }

        private void gridControlAllProduction_ProcessGridKey(object sender, KeyEventArgs e)
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
                    object o = gridViewAllProduction.GetRow(rowHandle);
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
                        object o = gridViewAllProduction.GetRow(rowHandle);
                        DisplayItemWrapper temp = (DisplayItemWrapper)o;
                        OrderItem itemToDelete = (OrderItem)temp.item;

                        if (itemToDelete != null)
                        {
                            Globals.dbContext.OrderItems.Remove(itemToDelete);
                        }
                    }
                    Globals.dbContext.SaveChanges();
                    entityServerModeSource2.Reload();
                    gridViewAllProduction.RefreshData();
                }
            }

        }

        private void gridViewAllProduction_DoubleClick(object sender, EventArgs e)
        {

            GridView view = sender as GridView;
            int numRows = view.SelectedRowsCount;

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewAllProduction.GetRow(rowHandle);
                DisplayItemWrapper temp = (DisplayItemWrapper)o;
                OrderItem itemToEdit = (OrderItem)temp.item;

                Order order = Globals.dbContext.Orders.Where(ordr => ordr.ID == itemToEdit.OrderID).FirstOrDefault();

                EditOrderitem editForm = new EditOrderitem(itemToEdit, currentUser);
                string fileName="",description="",batchName = "";
                if (itemToEdit.Part != null)
                {
                    fileName = itemToEdit.Part.FileName;
                    description = itemToEdit.Part.Description;
                }
                if(order!=null)
                    batchName = order.BatchName;

                string Title = fileName + "(" + description + ")" + "--->" + batchName;
                editForm.Text = Title;
                editForm.ShowDialog();
                Globals.dbContext.SaveChanges();
                entityServerModeSource2.Reload();
                gridViewAllProduction.RefreshData();
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
            Reporting.TestReport3 report = new Reporting.TestReport3();
            report.ShowPreview();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!gridControlAllProduction.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
            }

            gridViewAllProduction.OptionsPrint.PrintDetails = true;
            gridViewAllProduction.OptionsPrint.ExpandAllDetails = false;
            gridViewAllProduction.OptionsPrint.ExpandAllGroups = false;


            gridControlAllProduction.ShowPrintPreview();

            gridControlAllProduction.Refresh();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {

            Privilege priv = new Privilege();
            priv.buttonName = "button1";
            priv.HasAccess = true;
            Globals.dbContext.Privileges.Add(priv);

            User usr1 = new User();
            usr1.UserName = "Admin";
            usr1.Privileges = new List<Privilege>();
            usr1.Privileges.Add(priv);
            Globals.dbContext.Users.Add(usr1);

            Globals.dbContext.SaveChanges();
        }

        private void gridViewAllProduction_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
        }

        private void ribbon_SelectedPageChanging(object sender, DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs e)
        {
            setupView(e.Page.Text);
        }

        void setupView(string ribbonTitle)
        {
            ViewColumnFilterInfo viewFilterInfo = new ViewColumnFilterInfo(gridViewAllProduction.Columns["Name"],
                new ColumnFilterInfo("[Name] = 'Laser'",""));

            if (ribbonTitle == "Nesting")
            {
                gridViewAllProduction.Columns["Name"].ClearFilter();
                gridViewAllProduction.Columns.ColumnByFieldName("Thumbnail").Visible = true;
                gridViewAllProduction.RowHeight = 80;
                gridViewAllProduction.ActiveFilter.Add(viewFilterInfo);

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
                gridViewAllProduction.Columns.ColumnByFieldName("Thumbnail").Visible = false;
                gridViewAllProduction.RowHeight = -1;
                gridViewAllProduction.Columns["Name"].ClearFilter();

                toolStripStatusLabel.Text = "All Production";
            }

            gridViewAllProduction.RefreshData();
            entityServerModeSource2.Reload();
        }

        private void gridViewItems_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                List<int> selectedItemHandles = new List<int>();
                selectedItemHandles = gridViewAllProduction.GetSelectedRows().ToList();

                List<OrderItem> selectedItems = new List<OrderItem>();

                foreach (int handle in selectedItemHandles)
                {
                    DisplayItemWrapper wrapper = (DisplayItemWrapper)gridViewAllProduction.GetRow(handle);
                    selectedItems.Add((OrderItem) wrapper.item);
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
               
                gridViewAllProduction.RefreshData();
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

        private void gridViewAllProduction_RowUpdated(object sender, RowObjectEventArgs e)
        {
            Globals.dbContext.SaveChanges();
        }

        private void gridViewAllProduction_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Globals.dbContext.SaveChanges();
        }

        private void gridViewAllProduction_KeyDown(object sender, KeyEventArgs e)
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

                Int32[] selectedRowHandles = gridViewAllProduction.GetSelectedRows();
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    int selectedRowHandle = selectedRowHandles[i];
                    if (selectedRowHandle >= 0)
                    
                    {
                        
                        DisplayItemWrapper dItem = (DisplayItemWrapper) gridViewAllProduction.GetRow(selectedRowHandle);

                        OrderItem orderItem = Globals.dbContext.OrderItems.Where(oi => oi.Part.FileName == dItem.ProductName)
                                                                  .Where(oi => oi.Order.OrderNumber == dItem.OrderNumber)
                                                                  .Where(oi => oi.Order.BatchName == dItem.BatchName)
                                                                  .Where(oi => oi.Order.ScheduleName == dItem.ScheduleName).FirstOrDefault();
                        selectedOrderItems.Add(orderItem);

                    }
                }

                radProjInterface.SendItemsToRadan(selectedOrderItems, txtBoxRadanProjectBrowse.EditValue.ToString());

                SplashScreenManager.HideImage();
            }
        }


                
    }

}