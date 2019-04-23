using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadanMaster.Models
{
    class DisplayItemWrapper
    {
        public int ID { get; set; }
        public int QtyRequired { get; set; }
        public int QtyNested { get; set; }
        public string CategoryName { get; set; }
        public int CategoryIcon { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public bool IsStock { get; set; }
        public double Thickness { get; set; }
        public string OrderNumber { get; set; }
        public string StructuralCode { get; set; }
        //public string Material { get; set; }
        public string Name { get; set; }    // first op name
        public string ScheduleName { get; set; }
        public string BatchName { get; set; }
        public string ProductName { get; set; }
        public string Notes { get; set; }
        public bool IsComplete { get; set; }
        public bool IsBatch { get; set; }
        public string PlantID { get; set; }
        public object item;
    }

    class DisplayNest
    {
        public string NestName { get; set; }
        public string NestPath { get; set; }
        public int QtyOnNest { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}
