using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace RadanMaster
{
    public partial class OperationCompleted : Form
    {
        Models.OrderItemOperation OrderItemOp { get; set; }
        bool updateAll { get; set; }
        Models.User currentUser { get; set; }
        List<Models.OrderItemOperation> associatedOrderItemOps { get; set; }
        List<Models.OrderItemOperationPerformed> itemOpsPerformed { get; set; }
        List<Models.OperationPerformed> opsPerformed { get; set; }
        List<Models.OrderItemOperation> unFinishedOrderItemOps { get; set; }
        List<Models.OrderItemOperation> overBatchOrderItemOps { get; set; }

        public OperationCompleted(Models.OrderItemOperation orderItemOp, Models.User curUser)
        {
            InitializeComponent();

            currentUser = curUser;
            OrderItemOp = orderItemOp;
        }

        private void RefreshGridViews()
        {
            // first find all the associated orderItemOperations
            associatedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItem.PartID == OrderItemOp.orderItem.PartID)
                                                                          .Where(o => o.operationID == OrderItemOp.operationID).ToList();
            //.Where(o => o.qtyDone < o.qtyRequired).ToList();

            // then find all the associated orderItemOperations that have not been applied to an order item yet
            overBatchOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItemID == null)
                                                                                                          .Where(o => o.operation.PartID == OrderItemOp.operation.PartID).ToList();
            // now combine the two lists into one.
            associatedOrderItemOps.AddRange(overBatchOrderItemOps);

            gridControlAssociatedOrderItems.DataSource = associatedOrderItemOps;

            opsPerformed = Globals.dbContext.OperationPerformeds.Where(op => op.OrderItemOperationsPerformed.FirstOrDefault().orderItemOperation.operationID == OrderItemOp.operationID).ToList();
            gridControlOpsPerformed.DataSource = opsPerformed;
        }

        private void OperationCompleted_Load(object sender, EventArgs e)
        {
            btnRecordOp.Enabled = false;

            RefreshGridViews();

            // check to see if we have any completed order item operations that have not been matched up with order items yet...
            int qtyOverBatchItemOps = 0;
            if(overBatchOrderItemOps!=null)
                qtyOverBatchItemOps = overBatchOrderItemOps.Sum(x => x.qtyDone);

            int qtyUnAllocatedOrderItemOps = 0;
            if (associatedOrderItemOps != null)
            {
                qtyUnAllocatedOrderItemOps =  associatedOrderItemOps.Where(x => x.qtyDone < x.qtyRequired).Sum(x => x.qtyRequired - x.qtyDone);
            }


            if (qtyOverBatchItemOps > 0 && qtyUnAllocatedOrderItemOps> 0)
            {
                DialogResult result = MessageBox.Show("There are " + qtyOverBatchItemOps + " " + OrderItemOp.operation.Name + " operations for part number " + OrderItemOp.operation.Part.FileName + " that have not been applied to a batch item.  Did you want to apply them now?","Operations not applied",MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {

                    foreach (Models.OrderItemOperation overOp in overBatchOrderItemOps.ToList())
                    {
                        unFinishedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItem.PartID == OrderItemOp.orderItem.PartID)
                                                                          .Where(o => o.operationID == OrderItemOp.operationID)
                                                                          .Where( o => o.qtyDone < o.qtyRequired).ToList();

                        foreach(Models.OrderItemOperation unFinishedOp in unFinishedOrderItemOps.ToList())
                        {
                            if ((unFinishedOp.qtyRequired-unFinishedOp.qtyDone) >= (overOp.qtyDone)) // if overOp 'fits inside' unAllocatedOp
                            {
                                // remove the orderItemOpPerformed associated with this overOp
                                overOp.OrderItemOperationPerformeds.ToList().Remove(overOp.OrderItemOperationPerformeds.FirstOrDefault());
                                Models.OrderItemOperationPerformed newItemOpPerformed = new Models.OrderItemOperationPerformed();
                                newItemOpPerformed.qtyDone = overOp.qtyDone;
                                newItemOpPerformed.opPerformed = opsPerformed.LastOrDefault();
                                unFinishedOp.OrderItemOperationPerformeds.Add(newItemOpPerformed);
                                Globals.dbContext.OrderItemOperationPerformeds.Add(newItemOpPerformed);
                                
                                // modify unFinished op with new quantities
                                unFinishedOp.qtyDone += overOp.qtyDone;

                                // remove overOp 
                                Globals.dbContext.OrderItemOperations.Remove(overOp);

                                
                            }
                            else        // overOp.QtyDone is greater than unFinishedOp.QtyRequired - QtyDone
                            {
                                // modify unallocated op with new quantities

                                // modify overOp with new quantities

                                // 
                            }
                        }
                    }
                    Globals.dbContext.SaveChanges();
                    RefreshGridViews();
                }
                
                else
                {
                    // ignore and carry on
                }
            }


        }

        private void gridViewAssociatedOrderItems_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = sender as GridView;
            int numRows = view.SelectedRowsCount;
            itemOpsPerformed = new List<Models.OrderItemOperationPerformed>();
            Models.OrderItemOperation orderItemOp = new Models.OrderItemOperation();

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewAssociatedOrderItems.GetRow(rowHandle);
                orderItemOp = (Models.OrderItemOperation)o;
            }

            itemOpsPerformed = orderItemOp.OrderItemOperationPerformeds.ToList();
            gridControlOrderItemOpsPerformed.DataSource = itemOpsPerformed;
        }

        private void btnRecordOp_Click(object sender, EventArgs e)
        {
            Models.OrderItemOperation orderItemOp = Globals.dbContext.OrderItemOperations.Where(o => o.ID == OrderItemOp.ID).FirstOrDefault();

            int qtyDone = 0;
            int.TryParse(TextEditQty.Text, out qtyDone);
            Models.OrderItemOperationPerformed itemOpPerformed = new Models.OrderItemOperationPerformed();

            Models.OperationPerformed opPerformed = new Models.OperationPerformed();
            opPerformed.qtyDone = qtyDone;
            opPerformed.timePerformed = DateTime.Now;
            opPerformed.usr = currentUser;
            opPerformed.OrderItemOperationsPerformed = new List<Models.OrderItemOperationPerformed>();

            int totalQtyLeftToDo = qtyDone;
            // assign operations to order items
            foreach (Models.OrderItemOperation associatedOrderItemOp in associatedOrderItemOps)
            {
                if (associatedOrderItemOp.qtyDone < associatedOrderItemOp.qtyRequired)
                {
                    int itemQtyLeftToDo = associatedOrderItemOp.qtyRequired - associatedOrderItemOp.qtyDone;
                    Models.OrderItemOperationPerformed orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                    if (totalQtyLeftToDo <= itemQtyLeftToDo)
                    {
                        orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                        orderItemOpPerformed.qtyDone = totalQtyLeftToDo;
                        associatedOrderItemOp.qtyDone += totalQtyLeftToDo;
                        associatedOrderItemOp.OrderItemOperationPerformeds.Add(orderItemOpPerformed);
                        opPerformed.OrderItemOperationsPerformed.Add(orderItemOpPerformed);
                        totalQtyLeftToDo -= totalQtyLeftToDo;
                        break;
                    }
                    else
                    {
                        orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                        orderItemOpPerformed.qtyDone = itemQtyLeftToDo;
                        associatedOrderItemOp.qtyDone = associatedOrderItemOp.qtyRequired;
                        associatedOrderItemOp.OrderItemOperationPerformeds.Add(orderItemOpPerformed);
                        opPerformed.OrderItemOperationsPerformed.Add(orderItemOpPerformed);
                        totalQtyLeftToDo -= itemQtyLeftToDo;
                    }
                }
            }

            // if we've filled all the order items, we need to do something with the rest...
            if(totalQtyLeftToDo > 0)
            {
                MessageBox.Show(totalQtyLeftToDo + " of these items could not be applied to a batch, they will be put into extra stock");

                Models.Operation overBatchOperation = new Models.Operation();
                overBatchOperation.Location = orderItemOp.operation.Location;
                overBatchOperation.Name = orderItemOp.operation.Name;
                overBatchOperation.Part = orderItemOp.operation.Part;
                Globals.dbContext.Operations.Add(overBatchOperation);

                Models.OrderItemOperation overBatchItemOperation = new Models.OrderItemOperation();
                overBatchItemOperation.operation = overBatchOperation;
                overBatchItemOperation.orderItem = null;
                overBatchItemOperation.qtyDone = totalQtyLeftToDo;
                overBatchItemOperation.qtyRequired = 0;
                Globals.dbContext.OrderItemOperations.Add(overBatchItemOperation);

                Models.OrderItemOperationPerformed overBatchItemOperatonPerformed = new Models.OrderItemOperationPerformed();
                overBatchItemOperatonPerformed.orderItemOperation = overBatchItemOperation;
                overBatchItemOperatonPerformed.qtyDone = totalQtyLeftToDo;
                overBatchItemOperatonPerformed.opPerformed = opPerformed;
                Globals.dbContext.OrderItemOperationPerformeds.Add(overBatchItemOperatonPerformed);

                opPerformed.OrderItemOperationsPerformed.Add(overBatchItemOperatonPerformed);
                overBatchOperation.OrderItemOperations.Add(overBatchItemOperation);
            }

            Globals.dbContext.OperationPerformeds.Add(opPerformed);
            Globals.dbContext.SaveChanges();

            //// reload all the datasets to update datagrids.....

            //// first find all the associated orderItemOperations
            //associatedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItem.PartID == OrderItemOp.orderItem.PartID)
            //                                                         .Where(o => o.operationID == OrderItemOp.operationID).ToList();

            //// then find all the associated orderItemOperations that have not been applied to an order item yet
            //List<Models.OrderItemOperation> overBatchOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItemID == null)
            //                                                                                              .Where(o => o.operation.PartID == OrderItemOp.operation.PartID).ToList();
            //// now combine the two lists into one.
            //associatedOrderItemOps.AddRange(overBatchOrderItemOps);

            //gridControlAssociatedOrderItems.DataSource = associatedOrderItemOps;
            //gridControlAssociatedOrderItems.RefreshDataSource();
            //gridViewAssociatedOrderItems.RefreshData();

            //gridControlAssociatedOrderItems.RefreshDataSource();
            //gridViewAssociatedOrderItems.RefreshData();

            //gridControlOpsPerformed.RefreshDataSource();
            //gridViewOpsPerformed.RefreshData();

            //opsPerformed = Globals.dbContext.OperationPerformeds.Where(op => op.OrderItemOperationsPerformed.FirstOrDefault().orderItemOperation.operationID == OrderItemOp.operationID).ToList();
            //gridControlOpsPerformed.DataSource = opsPerformed;
            //gridControlOpsPerformed.RefreshDataSource();
            //gridViewOpsPerformed.RefreshData();

            RefreshGridViews();

            btnRecordOp.Enabled = false;
        }

        private void TextEditQty_EditValueChanged(object sender, EventArgs e)
        {
            btnRecordOp.Enabled = true;
        }
    }
}
