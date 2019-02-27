﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Entity;

namespace RadanMaster
{
    public partial class AllItems : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public AllItems()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            RadanMaster.DAL.RadanMasterContext dbContext = new RadanMaster.DAL.RadanMasterContext();
            // Call the Load method to get the data for the given DbSet from the database.
            dbContext.OrderItems.Load();
            // This line of code is generated by Data Source Configuration Wizard
            gridControl1.DataSource = dbContext.OrderItems.Local.ToBindingList();
        }
    }
}