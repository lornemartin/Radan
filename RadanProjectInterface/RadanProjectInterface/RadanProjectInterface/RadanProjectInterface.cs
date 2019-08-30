using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadanInterface2;
using RadProject;
using ProductionMasterModel;
using System.IO;
using System.Windows.Forms;
using File = System.IO.File;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace RadanProjectInterface
{
    public class RadanProjectInterface
    {
        string RadanProjectName { get; set; }
        RadanProject RPrj { get; set; }
        string SymFolder { get; set; }
        RadanInterface RadInterface { get; set; }
        ProductionMasterModel.ProductionMasterModel DbContext { get; set; }


        public RadanProjectInterface(string symFolder, ProductionMasterModel.ProductionMasterModel ctx)
        {
            SymFolder = symFolder;
            RadInterface = new RadanInterface();
            DbContext = ctx;
        }

        public void SetSymFolder(string s)
        {
            SymFolder = s;
        }

        public byte[] updateThumbnail(string fileName)
        {
            char[] thumbnailCharArray = RadInterface.GetThumbnailDataFromSym(System.IO.Path.Combine(SymFolder,fileName + ".sym"));
            if (thumbnailCharArray != null)
            {
                return Convert.FromBase64CharArray(thumbnailCharArray, 0, thumbnailCharArray.Length);
            }
            else
            {
                return null;
            }

        }

        public int CalculateRadanID(OrderItem orderItem)
        {
            //loop through RadanID referene table, till we find an id in the range of 0 to 500 that is available
            for (int i = 1; i <= 500; i++)
            {
                RadanID radanIDItem = (DbContext.RadanIDs.Where(r => r.RadanIDNumber == i).FirstOrDefault());
                if (radanIDItem == null)
                {
                    RadanID newRadanID = new RadanID();
                    newRadanID.OrderItem = orderItem;
                    newRadanID.OrderItemID = orderItem.ID;
                    newRadanID.RadanIDNumber = i;
                    DbContext.RadanIDs.Add(newRadanID);
                    DbContext.SaveChanges();
                    orderItem.RadanID = newRadanID;
                    orderItem.RadanIDNumber = i;
                    DbContext.SaveChanges();
                    return i;
                }
            }


            return -1;
        }

        private bool masterItemToRadanPart(OrderItem oItem)
        {
            try
            {
                //rPrj = new RadanProject();
                //rPrj = rPrj.LoadData(radanProjectName);
                string symName = oItem.Part.FileName;

                // this is only needed if description was not correctly read from sym when part was entered into DB.  It should
                // eventually not be needed anymore, but will be handy for the short term to populate description field in radan project.
                if (RadInterface != null)
                {
                    if (oItem.Part.Description == "")
                    {
                        oItem.Part.Description = RadInterface.GetDescriptionFromSym(SymFolder + symName + ".sym");
                    }
                }

                if (RPrj.Parts != null)
                {
                    RadanPart rPart = new RadanPart();
                    bool matchFound = false;
                    for (int i = 0; i < RPrj.Parts.Count(); i++)
                    {
                        rPart = RPrj.Parts.Part[i];
                        string radanName = Path.GetFileNameWithoutExtension(rPart.Symbol);

                        if (oItem.RadanIDNumber >= 0)
                        {
                            if (radanName == symName && rPart.Bin == oItem.RadanIDNumber.ToString())
                            {
                                matchFound = true;
                                rPart.Number = oItem.QtyRequired - oItem.QtyNested;  // item still exists in project, just need to update 
                                //rPrj.SaveData(radanProjectName);

                                MessageBox.Show(Path.GetFileName(symName) + " already exists in this radan projecs, only qty required will be updated.");
                                oItem.IsInProject = true;
                                DbContext.SaveChanges();
                                break;
                            }
                        }
                    }

                    if (!matchFound)
                    {
                        //create new part in project

                        string calculatedSymPath = "";
                        bool multiple = false;

                        if (File.Exists(SymFolder + "\\" + symName + ".sym"))
                        {
                            calculatedSymPath = CalculateFolderPath(oItem);      // copy sym file from main sym folder to current project so that we can set custom attributes
                            if (!Directory.Exists(Path.GetDirectoryName(calculatedSymPath)))
                            {
                                System.IO.Directory.CreateDirectory(calculatedSymPath);     // create new folder if necessary.
                            }
                            else
                            {
                                if (File.Exists(calculatedSymPath + "\\" + symName + ".sym"))
                                    multiple = true;
                            }

                            File.Copy(SymFolder + symName + ".sym", calculatedSymPath + symName + ".sym", true);

                            // save the custom attributes to the newly copied sym file
                            string orderNumber = "";
                            if (!multiple)
                                orderNumber = oItem.Order.OrderNumber == null ? "" : oItem.Order.OrderNumber;
                            else if (oItem.Order.OrderNumber != "")
                                orderNumber = "mulitiple";

                            string scheduleName = "";
                            if (!multiple)
                            {
                                scheduleName = oItem.Order.ScheduleName == null ? "" : oItem.Order.ScheduleName;
                            }
                            else if (oItem.Order.ScheduleName != "")
                                scheduleName = "multiple";

                            string batchName = "";
                            if (!multiple)
                                batchName = oItem.Order.BatchName == null ? "" : oItem.Order.BatchName;
                            else if (oItem.Order.BatchName != "")
                                batchName = "multiple";

                            string description = oItem.Part.Description == null ? "" : oItem.Part.Description;

                            //bool hasBends = radInterface.GetBendDataFromSym(symFolder + "\\" + symName + ".sym");

                            string errMessage = "";
                            RadInterface.InsertAdditionalAttributes(calculatedSymPath + symName + ".sym", oItem.Part.Material, oItem.Part.Thickness.ToString(), "in", description, orderNumber, scheduleName, batchName, oItem.Part.HasBends, ref errMessage);
                        }

                        rPart = new RadanPart();
                        rPart.Symbol = calculatedSymPath + symName + ".sym";
                        rPart.Number = oItem.QtyRequired - oItem.QtyNested;
                        rPart.Made = 0;
                        rPart.ThickUnits = "in";
                        rPart.Thickness = oItem.Part.Thickness;
                        rPart.Material = oItem.Part.Material;
                        int radanID = CalculateRadanID(oItem);
                        if (radanID != -1) // check to make sure we dont' have more than the max 500 parts in the radan project
                            rPart.Bin = radanID.ToString();
                        else
                            return false;   // 
                        RPrj.AddPart(rPart);
                        //rPrj.SaveData(radanProjectName);

                        oItem.IsInProject = true;
                        DbContext.SaveChanges();
                    }

                }
                RPrj.SaveData(RadanProjectName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool SendItemsToRadan(List<OrderItem> orderItems, string projectName)
        {
            try
            {
                if (RadInterface.IsProjectReady())
                {
                    string errMsg = "";
                    if (RadInterface.getOpenProjectName(ref errMsg) == RadanProjectName)
                    {
                        //SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                        if (saveRadan())
                        {
                            RPrj = new RadanProject();
                            RPrj = RPrj.LoadData(RadanProjectName);

                            foreach (OrderItem item in orderItems)
                            {
                                string partName = item.ProductName;

                                string orderNumber = item.Order.OrderNumber;

                                string batchName = item.Order.BatchName;

                                string schedName = item.Order.ScheduleName;


                                OrderItem orderItem = DbContext.OrderItems.Where(oi => oi.Part.FileName == partName)
                                                                          .Where(oi => oi.Order.OrderNumber == orderNumber)
                                                                          .Where(oi => oi.Order.BatchName == batchName)
                                                                          .Where(oi => oi.Order.ScheduleName == schedName).FirstOrDefault();
                                if (orderItem != null)
                                    if (!masterItemToRadanPart(orderItem))
                                    {
                                        MessageBox.Show("There are more than 500 items in the radan project, not all items have been entered into the project");
                                        break;
                                    }
                            }

                        }

                        // need to open current project here...
                        string errMessage = "";
                        string prjName = RadInterface.getOpenProjectName(ref errMessage);
                        RadInterface.LoadProject(prjName);

                        RPrj.SaveData(projectName);

                        //gridViewItems.RefreshData();

                        //SplashScreenManager.HideImage();
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string CalculateFolderPath(OrderItem orderItem)
        {
            string path = "";

            string symFileName = orderItem.Part.FileName + ".sym";

            List<string> matchingFiles = new List<string>();

            if (Directory.Exists(Path.GetDirectoryName(RadanProjectName) + "\\Symbols\\"))
                matchingFiles = Directory.GetFiles((Path.GetDirectoryName(RadanProjectName) + "\\Symbols\\"), symFileName, SearchOption.AllDirectories).ToList();

            if (matchingFiles.Count() > 0)
            {
                path = Path.GetDirectoryName(matchingFiles[0]) + "\\";
            }
            else
            {
                if (orderItem.Order.IsBatch == false)
                {
                    if (orderItem.Order.OrderNumber == null) orderItem.Order.OrderNumber = "";
                    path = Path.GetDirectoryName(RadanProjectName) + "\\Symbols" + "\\" + orderItem.Order.OrderNumber + "\\" + orderItem.Order.ScheduleName + "\\" + orderItem.Part.FileName + "\\";
                }
                else
                {
                    path = Path.GetDirectoryName(RadanProjectName) + "\\Symbols" + "\\" + orderItem.Order.BatchName + "\\" + orderItem.Part.FileName + "\\";
                }
            }

            return path;
        }

        private bool SyncRadanToMaster()
        {
            try
            {
                if (saveRadan())
                {
                    RPrj = RPrj.LoadData(RadanProjectName);
                    // check for parts in radan project that cannot be synced and warn user accordingly
                    foreach (RadanPart radanPart in RPrj.Parts.Part)
                    {
                        OrderItem masterItem = DbContext.OrderItems.Where(o => o.RadanIDNumber.ToString() == radanPart.Bin).FirstOrDefault();
                        if (masterItem == null || radanPart.Bin == "0")
                        {
                            MessageBox.Show(Path.GetFileName(radanPart.Symbol) + " cannot be synched back to RadanMaster, no matching record found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // check for completed orders....right now this only work one way, it won't uncheck completed orders that are no longer complete
                    bool orderComplete = true;
                    List<OrderItem> orderItemsToSync = DbContext.OrderItems.ToList();   // this may cause performance problems eventually
                    foreach (OrderItem syncItem in orderItemsToSync)
                    {
                        if (syncItem.Order.IsComplete != true)      // no need to check if order is already complete
                        {
                            // check completion status of all associated order items
                            List<OrderItem> associatedOrderItems = DbContext.OrderItems.Where(o => o.Order.ID == syncItem.Order.ID).ToList();
                            orderComplete = true;
                            foreach (OrderItem item in associatedOrderItems)
                            {
                                if (item.IsComplete == false)
                                {
                                    orderComplete = false;
                                    break;
                                }
                            }

                            // if all associated order items are complete, consider whole order as complete
                            if (orderComplete == true)
                            {
                                syncItem.Order.IsComplete = true;
                                syncItem.Order.DateCompleted = DateTime.Now;

                            }
                        }
                    }

                    // check to make sure all order items are still in Radan and notify user if not
                    List<OrderItem> orderItemsInRadan = DbContext.OrderItems.Where(o => o.IsInProject).ToList();

                    foreach (OrderItem item in orderItemsInRadan)
                    {
                        RadanPart radanPart = RPrj.Parts.Part.Where(p => p.Bin == item.RadanIDNumber.ToString()).FirstOrDefault();
                        if (radanPart == null)
                        {
                            MessageBox.Show(item.Part.FileName + " no longer exists in Radan project.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            item.RadanID = null;
                            item.RadanIDNumber = 0;
                            item.IsInProject = false;
                        }
                    }

                    DbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                //*************************************************************************************
                // this should be moved out of radanProjectInterface, don't want any UI code in here.
                //*************************************************************************************
                MessageBox.Show("Sync with Radan Project was not successful" + "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool RetrieveSelectedRadanPartToMasterList(List<OrderItem> selectedItems)
        {
            // this function had originally been set up to get the seleced rows inside the function,
            //  but I want to move that code outside of the function.
            try
            {
                SyncRadanToMaster();

                RPrj = new RadanProject();
                RPrj = RPrj.LoadData(RadanProjectName);

                foreach (OrderItem item in selectedItems)
                {
                    RadanPart rPart = GetPartFromRadanProject(RPrj, item.Part.FileName, item.RadanIDNumber);
                    if (rPart != null)
                    {
                        if (rPart.Made == 0)
                        {
                            item.IsInProject = false;
                            RadanID radanIdToRemove = DbContext.RadanIDs.Where(r => r.RadanIDNumber == item.RadanIDNumber).FirstOrDefault();
                            DbContext.RadanIDs.Remove(radanIdToRemove);
                            RPrj.Parts.Part.Remove(rPart);
                            item.RadanIDNumber = 0;

                            RemoveSymFileFromProject(rPart.Symbol);
                            DbContext.SaveChanges();        // save db before next iteration so RemoveSymFiles calculates properly
                        }

                        else
                        {
                            rPart.Number = rPart.Made;
                        }
                        //rPrj.SaveData(radanProjectName);
                    }
                }

                RPrj.SaveData(RadanProjectName);

                // need to open current project here...
                string errMessage = "";
                string prjName = RadInterface.getOpenProjectName(ref errMessage);
                RadInterface.LoadProject(prjName);

                DbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool RetrieveAllRadanPartToMasterList()
        {
            // this function shouldn't be needed anymore if we do the calculating for the items form the calling function, we can call the above function and pass all the rows to it....
            return false;
        //    try
        //    {
        //        SyncRadanToMaster();

        //        RPrj = new RadanProject();
        //        RPrj = RPrj.LoadData(RadanProjectName);

        //        int[] rows = gridViewItems.GetSelectedRows();

        //        foreach (RadanPart rPart in rPrj.Parts.Part.ToList())
        //        {
        //            OrderItem orderItem = dbContext.OrderItems.Where(o => o.RadanIDNumber.ToString() == rPart.Bin).FirstOrDefault();
        //            if (orderItem != null)
        //            {
        //                if (rPart.Made == 0)
        //                {
        //                    orderItem.IsInProject = false;

        //                    RadanID radanIdToRemove = dbContext.RadanIDs.Where(r => r.RadanIDNumber == orderItem.RadanIDNumber).FirstOrDefault();
        //                    if (radanIdToRemove != null)
        //                    {
        //                        dbContext.RadanIDs.Remove(radanIdToRemove);
        //                        rPrj.Parts.Part.Remove(rPart);
        //                        orderItem.RadanIDNumber = 0;

        //                        RemoveSymFileFromProject(rPart.Symbol);
        //                        dbContext.SaveChanges();    // save db before next iteration so RemoveSymFiles calculates properly
        //                    }

        //                }

        //                else
        //                {
        //                    rPart.Number = rPart.Made;
        //                }
        //            }
        //        }

        //        rPrj.SaveData(radanProjectName);

        //        // need to open current project here...
        //        string errMessage = "";
        //        string prjName = radInterface.getOpenProjectName(ref errMessage);
        //        radInterface.LoadProject(prjName);

        //        dbContext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        
}

        private bool RemoveSymFileFromProject(string symFileName)
        {
            try
            {
                if (RPrj == null)
                {
                    RPrj = new RadanProject();
                    RPrj = RPrj.LoadData(RadanProjectName);
                }

                string symFileNameWithoutPath = Path.GetFileName(symFileName);
                string symFileNameWithoutPathWithoutExtension = Path.GetFileNameWithoutExtension(symFileName);

                List<OrderItem> matchingItemList = DbContext.OrderItems.Where(o => o.Part.FileName == symFileNameWithoutPathWithoutExtension).Where(o => o.IsInProject).ToList();

                if (matchingItemList.Count == 1)
                {
                    List<string> matchingSymFiles = Directory.GetFiles((Path.GetDirectoryName(RadanProjectName) + "\\Symbols\\"), symFileNameWithoutPath, SearchOption.AllDirectories).ToList();
                    File.Delete(matchingSymFiles[0]);   // there should only be one file to delete.
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private RadanPart GetPartFromRadanProject(RadanProject prj, string partName, int ID)
        {
            RadanPart rPart = new RadanPart();

            for (int i = 0; i < prj.Parts.Count(); i++)
            {
                rPart = prj.Parts.Part[i];
                string radanName = Path.GetFileNameWithoutExtension(rPart.Symbol);
                if ((radanName == (partName)) && (rPart.Bin == ID.ToString()))
                    return rPart;
            }

            return null;
        }

        private bool RefreshItemsGridFromActiveProject()
        {
            try
            {
                RPrj = RPrj.LoadData(RadanProjectName);

                foreach (OrderItem item in DbContext.OrderItems)
                {
                    RadanPart rPart = GetPartFromRadanProject(RPrj, item.Part.FileName, item.RadanID.RadanIDNumber);
                    if (rPart != null)
                        item.IsInProject = true;
                    else
                        item.IsInProject = false;
                }

                DbContext.SaveChanges();

                //this should be called outside of this function
                //gridViewItems.RefreshData();


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool CreateNewRadanProject()
        {
            //*********************************************************
            //SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            //*********************************************************

            string oldProjectName = "";
            try
            {
                int numOfNestsSaved = 0;
                int numOfItemsUpdated = 0;
                RPrj.SaveData(RadanProjectName);
                oldProjectName = RadanProjectName;

                SyncRadanToMaster();    // make sure everything is synched before we begin here....

                // first copy all radan nests into DB.
                OrderItem orderItem = new OrderItem();
                if (RPrj.Nests.Count() > 0)
                {
                    foreach (RadanNest radanNest in RPrj.Nests)
                    {
                        Nest newMasterNest = new Nest();
                        newMasterNest.nestName = radanNest.FileName;
                        newMasterNest.nestPath = Path.GetDirectoryName(RadanProjectName);
                        char[] thumbnailCharArray = RadInterface.GetThumbnailDataFromSym(Path.GetDirectoryName(RadanProjectName) + "\\nests\\" + radanNest.FileName);
                        byte[] thumbnailByteArray = null;
                        if (thumbnailCharArray != null)
                            thumbnailByteArray = Convert.FromBase64CharArray(thumbnailCharArray, 0, thumbnailCharArray.Length);
                        newMasterNest.Thumbnail = thumbnailByteArray;
                        newMasterNest.NestedParts = new List<NestedPart>();

                        foreach (NestsPartsMade nestedRadanPart in radanNest.PartsMade)
                        {
                            foreach (NestPartsMadeListItem partMade in nestedRadanPart.PartsListItems)
                            {
                                NestedPart masterNestedPart = new NestedPart();

                                //int radanPartID = (int)nestedRadanPart.PartsListItems[0].ID;
                                int radanPartID = (int)partMade.ID;

                                int radanID = int.Parse(RPrj.Parts.Part.Where(p => p.ID == radanPartID).FirstOrDefault().Bin);
                                orderItem = DbContext.OrderItems.Where(o => o.RadanIDNumber == radanID).FirstOrDefault();

                                masterNestedPart.OrderItem = orderItem;
                                masterNestedPart.Qty = partMade.Made;

                                DbContext.NestedParts.Add(masterNestedPart);

                                newMasterNest.NestedParts.Add(masterNestedPart);

                                if (orderItem.AssociatedNests == null)
                                    orderItem.AssociatedNests = new List<Nest>();

                                if (!orderItem.AssociatedNests.Contains(newMasterNest))
                                {
                                    orderItem.AssociatedNests.Add(newMasterNest);
                                    orderItem.QtyNested += partMade.Made;
                                }

                            }


                        }
                        DbContext.Nests.Add(newMasterNest);
                        numOfNestsSaved++;
                    }
                }

                // shouldn't be necessary to save this specifically, but job details are not serializing properly, so this is a work around...
                long maxNestNumber = 0;
                foreach (RadanNest radanNest in RPrj.Nests)
                {
                    if (long.Parse(radanNest.ID) > maxNestNumber)
                        maxNestNumber = long.Parse(radanNest.ID);
                }

                FileInfo oldProjFile = new FileInfo(RadanProjectName);
                DirectoryInfo prjRootDir = oldProjFile.Directory.Parent;

                string newFolderName = string.Format("{0:yyy/MM/dd}", DateTime.Now);

                string newPrjDirName = prjRootDir.FullName + "\\" + newFolderName;

                DirectoryInfo uniqueNewPrjFolder = MakeUnique(newPrjDirName);

                uniqueNewPrjFolder.Create();

                // copy the old folder structure to a new folder
                CopyFolder(oldProjFile.DirectoryName, uniqueNewPrjFolder.FullName);

                // rename the project file
                string oldPrjFileName = uniqueNewPrjFolder.FullName + "\\" + oldProjFile.Name;
                string newPrjFileName = uniqueNewPrjFolder.FullName + "\\" + uniqueNewPrjFolder.Name + ".rpd";
                System.IO.File.Move(oldPrjFileName, newPrjFileName);

                RadanProjectName = newPrjFileName;
                //  *****************************
                // this will have to be set outside of function
                // *******************************************************
                //barEditRadanProjectBrowse.EditValue = newPrjFileName;

                RPrj = new RadanProject();
                RPrj = RPrj.LoadData(newPrjFileName);

                RPrj.Nests = new List<RadanNest>();
                RPrj.Parts.Part = new List<RadanPart>();
                RPrj.RadanSchedule.JobDetails.nestFolder = uniqueNewPrjFolder.FullName + "\\" + "nests";
                RPrj.RadanSchedule.JobDetails.remnantSaveFolder = uniqueNewPrjFolder.FullName + "\\" + "remnants";
                RPrj.FirstNestNumber = maxNestNumber + 1;

                // calculate the new number of sheets still available
                foreach (RadanSheet sheet in RPrj.Sheets.Sheet)
                {
                    sheet.NumAvailable -= sheet.Used;
                    if (sheet.NumAvailable < 0) sheet.NumAvailable = 0;
                }

                // remove all nests from newly created project
                DirectoryInfo newNestFolder = new DirectoryInfo(uniqueNewPrjFolder + "\\" + "nests");
                foreach (FileInfo file in newNestFolder.GetFiles())
                {
                    file.Delete();
                }

                // remove all symbol files from newly created project
                DirectoryInfo newSymbolFolder = new DirectoryInfo(uniqueNewPrjFolder + "\\" + "Symbols");
                newSymbolFolder.Delete(true);

                // we remove all parts from the radan project, so we clear all the associations from the RadanID table
                DbContext.RadanIDs.RemoveRange(DbContext.RadanIDs);

                //update the nested quantites from the old radan project.  Up till now they have always been calculated rather than stored in DB.
                foreach (OrderItem item in DbContext.OrderItems.ToList())
                {
                    int totalNested = 0;

                    if (item.AssociatedNests != null)
                    {
                        foreach (Nest associatedNest in item.AssociatedNests)
                        {
                            if (associatedNest.NestedParts != null)
                            {
                                foreach (NestedPart p in associatedNest.NestedParts)
                                {
                                    if (p.OrderItem == item && Path.GetDirectoryName(associatedNest.nestPath) == Path.GetDirectoryName(oldProjectName))
                                        totalNested += p.Qty;
                                }
                            }
                        }
                    }

                    item.QtyNested += totalNested;
                    item.IsInProject = false;
                    item.RadanID = null;
                    item.RadanIDNumber = 0;
                    numOfItemsUpdated++;
                }

                RPrj.SaveData(newPrjFileName);

                RadInterface.LoadProject(newPrjFileName);

                // wait until the very end to save the DB, that way if something goes wrong, DB will not be changed.
                DbContext.SaveChanges();

                //*********************************************************
                //SplashScreenManager.HideImage();
                //*********************************************************

                MessageBox.Show("Number of items updated: " + numOfItemsUpdated + "\n" +
                                "Number of nests saved: " + numOfNestsSaved);


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("New Radan Project has not been properly initialized.  Database has not been modified." + "\n" +
                                "New Radan project folder should be manually deleted." + "\n" +
                                "Please shut down and restart RadanMaster." + "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // reset dbContext to original state
                foreach (DbEntityEntry entry in DbContext.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        default: break;
                    }
                }

                // load old radan project again.
                RadanProjectName = oldProjectName;

                //  *****************************
                // this will have to be set outside of function
                // *******************************************************
                //barEditRadanProjectBrowse.EditValue = oldProjectName;

                RPrj = new RadanProject();
                RPrj = RPrj.LoadData(oldProjectName);

                //*********************************************************
                //SplashScreenManager.HideImage();
                //*********************************************************
                return false;
            }
        }

        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        public DirectoryInfo MakeUnique(string path)
        {
            string pathWithoutIncrement = path.Split('(')[0];
            for (int i = 1; ; i++)
            {
                if (!Directory.Exists(path))
                    return new DirectoryInfo(path);

                path = pathWithoutIncrement + "(" + i + ")";
            }
        }

        private bool saveRadan()
        {
            try
            {
                bool proceed = false;
                if (!RadInterface.IsActive())
                {
                    DialogResult dialogResult = MessageBox.Show("Radan is not active, do you want to continue?", "Radan", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        proceed = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        proceed = false;
                    }
                }
                else
                    proceed = true;

                if (proceed)
                {
                    string errMessage = "";
                    string openNestName = RadInterface.getOpenNestName(ref errMessage);
                    if (openNestName != "")
                        RadInterface.SaveNest(ref errMessage);
                    if (RadInterface.isProjectOpen(ref errMessage))
                        RadInterface.SaveProject();

                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    
}
