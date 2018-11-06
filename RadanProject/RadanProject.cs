using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections;

namespace RadProject
{
    #region Project
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.radan.com/ns/project", IsNullable = false)]
    public partial class RadanProject
    {
        public string ProjectNestNameTemplate { get; set; }
        public string JobName { get; set; }
        public long FirstNestNumber { get; set; }
        public string RemnantUseFolder { get; set; }
        public string MatchMat { get; set; }
        public RadanSchedule RadanSchedule { get; set; }
        public RadanSheets Sheets { get; set; }
        public RadanParts Parts { get; set; }
        public RadanProjectRemnantSheets RemnantSheets { get; set; }
        private List<Remnant> remnantsField;
        private List<RadanNest> nestsField;

        [System.Xml.Serialization.XmlArrayItemAttribute("Remnant", typeof(Remnant), IsNullable = false)]
        public List<Remnant> Remnants
        {
            get
            {
                return this.remnantsField;
            }
            set
            {
                this.remnantsField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayItemAttribute("Nest", typeof(RadanNest), IsNullable = false)]
        public List<RadanNest> Nests
        {
            get
            {
                return this.nestsField;
            }
            set
            {
                this.nestsField = value;
            }
        }

        /*
        public Boolean RemoveNest(RadanProjectNestsNest nestToRemove)
        {
            try
            {
                this.Nests.Remove(nestToRemove);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        
        // constructor to initialize new object
        public RadanProject()
        {
            ProjectNestNameTemplate = "?";
            JobName = "?";
            FirstNestNumber = 0;
            RemnantUseFolder = "";
            MatchMat = "";
            Remnants = "";
            //RadanSchedule = new MainRadanProjectRadanSchedule[1];
            Parts = new List<RadanProjectParts>();
            Nests = new List<RadanProjectNestsNest>();
        }

        // copy constructor
        public RadanProject(RadanProject prj)
        {
            this.FirstNestNumber = prj.FirstNestNumber;
            this.JobName = prj.JobName;
            this.MatchMat = prj.MatchMat;
            this.Nests = prj.Nests;
            this.Parts = prj.Parts;
            this.ProjectNestNameTemplate = prj.ProjectNestNameTemplate;
            this.RadanSchedule = prj.RadanSchedule;
            this.Remnants = prj.Remnants;
            this.RemnantSheets = prj.RemnantSheets;
            this.RemnantUseFolder = prj.RemnantUseFolder;
            this.Sheets = prj.Sheets;
        }
        */
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RadanSchedule
    {
        public string parts { get; set; }
        public JobDetails JobDetails { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class JobDetails
    {

        public string units { get; set; }
        public string jobName { get; set; }
        public long nextNestNum { get; set; }
        public string annotate { get; set; }
        public string plot { get; set; }
        public string graphics { get; set; }
        public string doShaped { get; set; }
        public string matchMat { get; set; }
        public string useExtra { get; set; }
        public int maxTime { get; set; }
        public string progRed { get; set; }
        public int progRedUtil { get; set; }
        public int primaryDir { get; set; }
        public int secondaryDir { get; set; }
        public string nestInHoles { get; set; }
        public string checkTooling { get; set; }
        public string toolHints { get; set; }
        public int stdToolId { get; set; }
        public string restartResults { get; set; }
        public int numNozzles { get; set; }
        public int numNozzlesPerSheet { get; set; }
        public string mCSpecificFiles { get; set; }
        public string autoUpdate { get; set; }
        public int aUNumNests { get; set; }
        public int aUNumSheets { get; set; }
        public int simplification { get; set; }
        public int ignorePens { get; set; }
        public string readMDBClearances { get; set; }
        public double partGapX { get; set; }
        public double partGapY { get; set; }
        public double partGapXY { get; set; }
        public double minDatumVert { get; set; }
        public double minNondatumVert { get; set; }
        public double optVert { get; set; }
        public string clampStripFlag { get; set; }
        public string clampZoneFlag { get; set; }
        public double clampStripWidth { get; set; }
        public double clampSizeParallel { get; set; }
        public double clampSizePerpendicular { get; set; }
        public double minUnclamped { get; set; }
        public double optUnclamped { get; set; }
        public double minClamped { get; set; }
        public double sheetDrgBorder { get; set; }
        public double pickingClusterBorder { get; set; }
        public double pickingClusterGapXY { get; set; }
        public double pickingClusterMaxArea { get; set; }
        public int pickingClusterPen { get; set; }
        public string includeToolingInShape { get; set; }
        public string autoTool { get; set; }
        public string sheetCut { get; set; }
        public string runPreOrderMacro { get; set; }
        public string preOrderMacroName { get; set; }
        public string runPreAnnotateMacro { get; set; }
        public string preAnnotateMacroName { get; set; }
        public string autoOrder { get; set; }
        public string autoOrderFile { get; set; }
        public string runNestMacro { get; set; }
        public string nestMacroName { get; set; }
        public string autoCompile { get; set; }
        public string lastJobUnloaded { get; set; }
        public string useDefaultStrategy { get; set; }
        public string strategy { get; set; }
        public string strategySheetDwg { get; set; }
        public string strategyMultisheet { get; set; }
        public string nestFolder { get; set; }
        public string useRemnants { get; set; }
        public string remnantUseFolder { get; set; }
        public int remnantPremium { get; set; }
        public int remnantPriority { get; set; }
        public string saveRemnants { get; set; }
        public double remnantAreaWorthSaving { get; set; }
        public string remnantSaveFolder { get; set; }
        public string saveRectangularRemnantsOnly { get; set; }
        public string alignRectanglesWithClampStrip { get; set; }
        public string replaceOrigNest { get; set; }
        public string useProjectParts { get; set; }
        public string useProjectSheets { get; set; }
        private List<JobDetailsSheetSource> sheetSourceField;

        [System.Xml.Serialization.XmlElementAttribute("SheetSource")]
        public List<JobDetailsSheetSource> SheetSource
        {
            get
            {
                return this.sheetSourceField;
            }
            set
            {
                this.sheetSourceField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class JobDetailsSheetSource
    {
        private List<RadanSheet> sheetField;
        private string sourceField;

        [System.Xml.Serialization.XmlElementAttribute("Sheet")]
        public List<RadanSheet> Sheet
        {
            get
            {
                return this.sheetField;
            }
            set
            {
                this.sheetField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }
    }



    #endregion

    #region Sheets
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RadanSheets
    {
        public string NextID { get; set; }
        private List<RadanSheet> sheetField;

        [System.Xml.Serialization.XmlElementAttribute("Sheet")]
        public List<RadanSheet> Sheet
        {
            get
            {
                return this.sheetField;
            }
            set
            {
                this.sheetField = value;
            }
        }
        /*
        // copy constructor
        public RadanProjectSheets(RadanProjectSheets sheets)
        {
            this.NextID = sheets.NextID;
            foreach (Sheet sht in Sheet)
            {
                Sheet newSheet = new Sheet(sht);
                this.Sheet.Add(newSheet);
            }
        }
        */
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.radan.com/ns/project", IsNullable = false)]
    public partial class RadanSheet
    {
        public string Material { get; set; }
        public double Thickness { get; set; }
        public string ThickUnits { get; set; }
        public double SheetX { get; set; }
        public double SheetY { get; set; }
        public string SheetUnits { get; set; }
        public string StockID { get; set; }
        public long ID { get; set; }
        public int NumAvailable { get; set; }
        public string Exclude { get; set; }
        public int Priority { get; set; }
        public int Used { get; set; }
        private List<SheetUsedInNest> usedInNestsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("UsedInNest", typeof(SheetUsedInNest), IsNullable = false)]
        public List<SheetUsedInNest> UsedInNests
        {
            get
            {
                return this.usedInNestsField;
            }
            set
            {
                this.usedInNestsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.radan.com/ns/project", IsNullable = false)]
    public partial class SheetsUsedInNests
    {
        private List<SheetUsedInNest> usedInNestField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UsedInNest")]
        public List<SheetUsedInNest> UsedInNest
        {
            get
            {
                return this.usedInNestField;
            }
            set
            {
                this.usedInNestField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class SheetUsedInNest
    {
        public long ID { get; set; }
        public int Made { get; set; }
        public int Used { get; set; }
    }

    #endregion

    #region RemnantSheets

    // this section needs to be fleshed out yet, i don't think the original project file this code was generated from 
    // had any remanants in it.

    // .......should be done now, but not yet tested....

    public partial class RadanProjectRemnantSheets
    {
        public string NextID { get; set; }
        private List<RadanProjectRemnantSheet> remnantSheetField;

        [System.Xml.Serialization.XmlElementAttribute("RemnantSheet")]
        public List<RadanProjectRemnantSheet> Sheet
        {
            get
            {
                return this.remnantSheetField;
            }
            set
            {
                this.remnantSheetField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RadanProjectRemnantSheet
    {
        public string FileName { get; set; }
        public long ID { get; set; }
        public int Used { get; set; }
        private List<SheetUsedInNest> usedInNestsField;

        [System.Xml.Serialization.XmlArrayItemAttribute("UsedInNest", typeof(SheetUsedInNest), IsNullable = false)]
        public List<SheetUsedInNest> UsedInNests
        {
            get
            {
                return this.usedInNestsField;
            }
            set
            {
                this.usedInNestsField = value;
            }
        }
    }

    #endregion

    #region Remnants
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RemnantMade
    {
        public long ID { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class Remnant
    {
        public string FileName { get; set; }
        public long ID { get; set; }
        private List<RemnantSourceNest> sourceNestField;

        [System.Xml.Serialization.XmlElementAttribute("SourceNest")]
        public List<RemnantSourceNest> SourceNest
        {
            get
            {
                return this.sourceNestField;
            }
            set
            {
                this.sourceNestField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RemnantSourceNest
    {
        public long ID { get; set; }
    }
    #endregion

    #region Parts
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RadanParts : IEnumerable<RadanPart>
    {
        public long NextID { get; set; }

        private List<RadanPart> partField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Part")]
        public List<RadanPart> Part
        {
            get
            {
                return this.partField;
            }
            set
            {
                this.partField = value;
            }
        }

        public Boolean Add(RadanPart rPrt)
        {
            Part.Add(rPrt);
            return true;
        }

        public IEnumerator<RadanPart> GetEnumerator()
        { 
            foreach(RadanPart p in partField)
            {
                yield return p;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RadanPart
    {
        public long ID { get; set; }
        public string Symbol { get; set; }
        public string Kit { get; set; }
        public int Number { get; set; }
        public int NumExtra { get; set; }
        public int Priority { get; set; }
        public string Bin { get; set; }
        public int Orient { get; set; }
        public string Mirror { get; set; }
        public string CCut { get; set; }
        public int MaxCCut { get; set; }
        public string PickingCluster { get; set; }
        public string Material { get; set; }
        public double Thickness { get; set; }
        public string ThickUnits { get; set; }
        public string Strategy { get; set; }
        public string Exclude { get; set; }
        public int Made { get; set; }
        public string CustomColour { get; set; }
        public string ColourWhenPartSaved { get; set; }
        private List<SheetUsedInNest> usedInNestsField;

        [System.Xml.Serialization.XmlArrayItemAttribute("UsedInNest", typeof(SheetUsedInNest), IsNullable = false)]
        public List<SheetUsedInNest> UsedInNests
        {
            get
            {
                return this.usedInNestsField;
            }
            set
            {
                this.usedInNestsField = value;
            }
        }

        // default constructor needed because class is serializeable 
        // and because I added a constructor with parameters.
        private RadanPart()
        {
            this.Bin = "";
            this.CCut = "";
            this.Exclude = "";
            this.ID = 0;
            this.Kit = "";
            this.Made = 0;
            this.Material = "";
            this.MaxCCut = 2;
            this.Mirror = "";
            this.Number = 0;
            this.NumExtra = 0;
            this.Orient = 8;
            this.PickingCluster = "n";
            this.Priority = 5;
            this.Strategy = "";
            this.Symbol = "";
            this.Thickness = 0.0;
            this.ThickUnits = "";
            this.CustomColour = "255,255,255";
            this.ColourWhenPartSaved = "204, 204, 204";
            this.UsedInNests = new List<SheetUsedInNest>();
        }

        // constructor for adding new parts to the project
        public RadanPart(string symFile, long id, string mat, double thick, string thickUnits, int qty)
        {
            this.Bin = "";
            this.CCut = "none";
            this.Exclude = "n";
            this.ID = id;
            this.Kit = "";
            this.Made = 0;
            this.Material = mat;
            this.MaxCCut = 2;
            this.Mirror = "n";
            this.Number = qty;
            this.NumExtra = 0;
            this.Orient = 8;
            this.PickingCluster = "n";
            this.Priority = 5;
            this.Strategy = "";
            this.Symbol = symFile;
            this.Thickness = thick;
            this.ThickUnits = thickUnits;
            this.CustomColour = "255,255,255";
            this.ColourWhenPartSaved = "204, 204, 204";

            this.UsedInNests = new List<SheetUsedInNest>();
        }

        /*
        // copy constructor
        public RadanProjectPartsPart(RadanProjectPartsPart prt)
        {
            this.Bin = prt.Bin;
            this.CCut = prt.CCut;
            this.Exclude = prt.Exclude;
            this.ID = prt.ID;
            this.Kit = prt.Kit;
            this.Made = prt.Made;
            this.Material = prt.Material;
            this.MaxCCut = prt.MaxCCut;
            this.Mirror = prt.Mirror;
            this.Number = prt.Number;
            this.NumExtra = prt.NumExtra;
            this.Orient = prt.Orient;
            this.PickingCluster = prt.PickingCluster;
            this.Priority = prt.Priority;
            this.Strategy = prt.Strategy;
            this.Symbol = prt.Symbol;
            this.Thickness = prt.Thickness;
            this.ThickUnits = prt.ThickUnits;
            this.UsedInNests = new List<UsedInNestsUsedInNest>(prt.UsedInNests);
        }
        */
    }
    #endregion

    #region Nests
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class RadanNest
    {
        public string FileName { get; set; }
        public string ID { get; set; }
        public string Modified { get; set; }
        public string MultiPartSymbols { get; set; }
        private List<NestSheetsUsed> sheetUsedField;
        private List<NestsPartsMade> partsMadeField;

        [System.Xml.Serialization.XmlElementAttribute("SheetUsed")]
        public List<NestSheetsUsed> SheetUsed
        {
            get
            {
                return this.sheetUsedField;
            }
            set
            {
                this.sheetUsedField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayItemAttribute("PartMade", typeof(NestsPartsMade), IsNullable = false)]
        public List<NestsPartsMade> PartsMade
        {
            get
            {
                return this.partsMadeField;
            }
            set
            {
                this.partsMadeField = value;
            }
        }




    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class NestSheetsUsed
    {
        public int Used { get; set; }
        public string Material { get; set; }
        public double Thickness { get; set; }
        public string ThickUnits { get; set; }
        public double SheetX { get; set; }
        public double SheetY { get; set; }
        public string SheetUnits { get; set; }
        public string StockID { get; set; }
        private List<NestSheetsUsedListItem> sheetsListItemsField;

        [System.Xml.Serialization.XmlArrayItemAttribute("SheetsListItem", typeof(NestSheetsUsedListItem), IsNullable = false)]
        public List<NestSheetsUsedListItem> SheetsListItems
        {
            get
            {
                return this.sheetsListItemsField;
            }
            set
            {
                this.sheetsListItemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class NestSheetsUsedListItem
    {
        public long ID { get; set; }
        public int Used { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class NestsPartsMade
    {
        public string File { get; set; }
        public int Made { get; set; }
        private List<NestPartsMadeListItem> partsListItemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PartsListItem", typeof(NestPartsMadeListItem), IsNullable = false)]
        public List<NestPartsMadeListItem> PartsListItems
        {
            get
            {
                return this.partsListItemsField;
            }
            set
            {
                this.partsListItemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.radan.com/ns/project")]
    public partial class NestPartsMadeListItem
    {
        public long ID { get; set; }
        public int Made { get; set; }
    }
    #endregion
}
