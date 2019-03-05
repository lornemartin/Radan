using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadanMaster.Models
{
    class DisplayItem
    {
        public int QtyRequired { get; set; }
        public int QtyDone { get; set; }
        public string Category { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] PDFThumbnail { get; set; }
        public string PartName { get; set; }
        public double Thickness { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string StructCode { get; set; }
        public string FirstOperation { get; set; }
        public bool IsComplete { get; set; }
        public bool IsBatch { get; set; }
        public bool IsStock { get; set; }
        public string ScheduleName { get; set; }
        public string BatchName { get; set; }
        public string OrderNumber { get; set; }
        public DateTime DateEntered { get; set; }
        public string Notes { get; set; }
        public bool OrderIsComplete { get; set; }
        public OrderItem OrderItem { get; set; }

        public DisplayItem(OrderItem item, DAL.RadanMasterContext ctx)
        {
            Part p = ctx.Parts.Where(prt => prt.ID == item.PartID).FirstOrDefault();
            Order o = ctx.Orders.Where(order => order.ID == item.OrderID).FirstOrDefault();
            Operation op = ctx.Operations.Where(oper => oper.Name == p.Operations.FirstOrDefault().Name).FirstOrDefault();
            

            QtyRequired = item.QtyRequired;
            QtyDone = item.QtyNested;
            Category = p.CategoryName == null ? null : p.CategoryName;
            Thumbnail = p.Thumbnail == null ? null : p.Thumbnail;
            PDFThumbnail = p.Files.FirstOrDefault().Content == null ? null : p.Files.FirstOrDefault().Content;
            PartName = item.Part.FileName;
            Thickness = p.Thickness;
            Description = item.Part.Description;
            Material = p.Material == null ? null : p.Material;
            StructCode = p.StructuralCode == null ? null: p.StructuralCode;
            FirstOperation = op == null ? string.Empty ? op.Name;
            IsComplete = item.IsComplete;
            IsBatch = item.Order.IsBatch;
            IsStock = item.Part.IsStock;
            ScheduleName = item.Order.ScheduleName;
            BatchName = item.Order.BatchName;
            OrderNumber = item.Order.OrderNumber;
            DateEntered = item.Order.EntryDate;
            Notes = item.Notes;
            OrderIsComplete = item.Order.IsComplete;
            OrderItem = item;

        }
    }

    class DisplayNest
    {
        public string NestName { get; set; }
        public string NestPath { get; set; }
        public int QtyOnNest { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}
