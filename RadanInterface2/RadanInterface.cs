using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace RadanInterface2
{
    public class RadanInterface
    {
        XNamespace symNameSpace = "http://www.radan.com/ns/rcd";
        const string MATERIAL_ATT_NUMBER = "119";
        const string THICKNESS_ATT_NUMBER = "120";
        const string UNIT_ATT_NUMBER = "121";
        const string DESCRIPTION_ATT_NUMBER = "200";
        const string ATT_ELEMENT = "Attr";
        const string NUM_ATTRIBUTE = "num";
        const string VALUE_ATTRIBUTE = "num";

        private static Radraft.Interop.Application rApp;

        public Boolean Initialize()
        {
            try
            {
                Object obj = null;
                obj = Marshal.GetActiveObject("Radraft.Application");
                rApp = (Radraft.Interop.Application)obj;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Open3DFileInRadan(string FilePath, string MaterialName, ref string ErrorMessage)
        {
            double ModelScale = 1;
            double PartThickness = 1;

            try
            {
                rApp.Mac.Execute("set_gui_state(GS_NEW3D)");
                rApp.NewDrawing(true);

                if (rApp.Mac.mfl_read_model("inventor", false, false, false, false, false, ModelScale, PartThickness, MaterialName, FilePath) != true)
                {
                    ErrorMessage = "Unable to read the Inventor file: " + FilePath;
                    return false;
                }

                ErrorMessage = "";
                return true;
            }
            catch (Exception x)
            {
                ErrorMessage = "An error occured trying to read the Inventor model " + FilePath + ".\r\n\r\nError Reports:" + x.Message;
                return false;
            }
        }

        public bool UnfoldActive3DFile(ref string partName, ref string MaterialName, ref string PartThickness, ref string TopPattern, ref string ErrorMessage)
        {
            string sIdnet = "";
            bool ContinueProcess = false;
            int type = 0;
            int nIDCount = 0;

            try
            {
                rApp.Mac.mfl_info_scan_start();
                ContinueProcess = rApp.Mac.mfl_info_scan_start();

                if (ContinueProcess == true)
                {
                    nIDCount = nIDCount + 1;
                    sIdnet = rApp.Mac.mfl_info_scan_next();

                    if (sIdnet != "")
                    {
                        TopPattern = "/NEW RAD 3D/Developments/unfold" + nIDCount.ToString() + "TOP";
                        rApp.Mac.mfl_ray_start(0, 0, 0);
                        type = rApp.Mac.MFL_U_TYPE_DEFAULT;

                        rApp.Mac.MFL_U_TOP_SURFACE_SPEC = true;
                        rApp.Mac.MFL_U_MATERIAL_SPEC = MaterialName;
                        rApp.Mac.mfl_object_info(sIdnet, false);
                        rApp.Mac.MFL_U_DEV_NAME_SPEC = "/unfold" + nIDCount.ToString() + "TOP";

                        if (rApp.Mac.mfl_auto_unfold(sIdnet))
                        {
                            try
                            {
                                if (String.IsNullOrEmpty(PartThickness))
                                {
                                    PartThickness = Math.Round(Convert.ToDecimal(rApp.Mac.MFL_U_THICKNESS_RES), 3).ToString();
                                }
                                else
                                {
                                    PartThickness = Math.Round(Convert.ToDecimal(PartThickness), 3).ToString();
                                }
                            }
                            catch (Exception)
                            {
                                if (String.IsNullOrEmpty(PartThickness))
                                {
                                    PartThickness = rApp.Mac.MFL_U_THICKNESS_RES.ToString();
                                }
                            }

                            try
                            {
                                if (String.IsNullOrEmpty(MaterialName))
                                {
                                    MaterialName = rApp.Mac.ND_MATERIAL1;
                                }
                                else
                                {
                                    MaterialName = "Undefined Material";
                                }
                            }
                            catch (Exception)
                            {
                                if (String.IsNullOrEmpty(MaterialName))
                                {
                                    MaterialName = "Undefined Material";
                                }
                            }

                            try
                            {
                                if (String.IsNullOrEmpty(partName))
                                {
                                    partName = rApp.Mac.ND_NAME1;
                                }
                                else
                                {
                                    MaterialName = "Undefined Name";
                                }
                            }
                            catch (Exception)
                            {
                                if (String.IsNullOrEmpty(partName))
                                {
                                    MaterialName = "Undefined Name";
                                }
                            }


                            return true;
                        }
                        else
                        {
                            ErrorMessage = "There was an unknown error unfolding the Inventor part within Radan.";
                            return false;
                        }
                    }
                    else
                    {
                        ErrorMessage = "There were no 3D entites found within the Inventor model for Radan to process.";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "Radan was unable to initialize 3D entities within Radan";
                    return false;
                }
            }
            catch (Exception)
            {
                ErrorMessage = "There was a process error within Radan when the 3D model was unfolded";
                return false;
            }
        }

        public bool SavePart(string TopPattern, string SymFilePath, ref string ErrorMessage)
        {
            string command = "save_symbol(S0, S1, G0, G1, G2)";

            try
            {
                if (SymFilePath.Contains('_'))
                {
                    ErrorMessage = "Sym File contains an illegal character, cannot save.";
                    return false;
                }
                rApp.Mac.SetString("S0", TopPattern);
                rApp.Mac.SetString("S1", SymFilePath);
                rApp.Mac.SetNumber("G0", 0);
                rApp.Mac.SetNumber("G1", 5);
                rApp.Mac.SetNumber("G2", 0);

                if (rApp.Mac.Execute(command) == true)
                {
                    return true;
                }
                else
                {
                    ErrorMessage = "Unable to save the part " + SymFilePath;
                    return false;
                }
            }
            catch (Exception x)
            {
                ErrorMessage = "Error saving the part " + SymFilePath + "\r\n\r\nError Reports:\r\n" + x.Message;
                return false;
            }
        }

        public bool InsertAttributes(string SymFilePath, string MaterialName, string MaterialThickness, string unitType, string partDesc, ref string ErrorMessage)
        {
            if (!System.IO.File.Exists(SymFilePath))
            {
                ErrorMessage = "The SYM file does not exist and material and thickness cannot be inserted";
                return false;
            }
            try
            {
                XDocument symDoc = XDocument.Load(SymFilePath);

                // set material name attribute
                XElement temp = symDoc.Descendants(symNameSpace + ATT_ELEMENT)
                                                .Where(t => t.Attribute(NUM_ATTRIBUTE).Value == MATERIAL_ATT_NUMBER).FirstOrDefault();
                if (temp == null)
                {
                    ErrorMessage = "The material element (" + MATERIAL_ATT_NUMBER + ") is missing in the SYM file, material cannot be inserted";
                    return false;
                }
                if (temp.Attribute(VALUE_ATTRIBUTE) == null)
                {
                    XAttribute value = new XAttribute(VALUE_ATTRIBUTE, MaterialName);
                    temp.Add(value);
                }
                else
                {
                    temp.SetAttributeValue("value", MaterialName);
                }

                // set material thickness attribute
                temp = symDoc.Descendants(symNameSpace + ATT_ELEMENT)
                            .Where(t => t.Attribute(NUM_ATTRIBUTE).Value == THICKNESS_ATT_NUMBER).FirstOrDefault();
                if (temp == null)
                {
                    ErrorMessage = "The material thickness element (" + THICKNESS_ATT_NUMBER + ") is missing in the SYM file, thickness cannot be inserted";
                    return false;
                }
                if (temp.Attribute(VALUE_ATTRIBUTE) == null)
                {
                    XAttribute value = new XAttribute(VALUE_ATTRIBUTE, MaterialThickness);
                    temp.Add(value);
                }
                else
                {
                    temp.SetAttributeValue("value", MaterialThickness);
                }

                // set part description attribute
                temp = symDoc.Descendants(symNameSpace + ATT_ELEMENT)
                            .Where(t => t.Attribute(NUM_ATTRIBUTE).Value == DESCRIPTION_ATT_NUMBER).FirstOrDefault();
                if (temp == null)
                {
                    ErrorMessage = "The part description element (" + DESCRIPTION_ATT_NUMBER + ") is missing in the SYM file, description cannot be inserted";
                    return false;
                }
                if (temp.Attribute(VALUE_ATTRIBUTE) == null)
                {
                    XAttribute value = new XAttribute(VALUE_ATTRIBUTE, partDesc);
                    temp.Add(value);
                }
                else
                {
                    temp.SetAttributeValue("value", partDesc);
                }


                // set part unit attribute
                temp = symDoc.Descendants(symNameSpace + ATT_ELEMENT)
                            .Where(t => t.Attribute(NUM_ATTRIBUTE).Value == UNIT_ATT_NUMBER).FirstOrDefault();
                if (temp == null)
                {
                    ErrorMessage = "The part unit element (" + UNIT_ATT_NUMBER + ") is missing in the SYM file, description cannot be inserted";
                    return false;
                }
                if (temp.Attribute(VALUE_ATTRIBUTE) == null)
                {
                    XAttribute value = new XAttribute(VALUE_ATTRIBUTE, partDesc);
                    temp.Add(value);
                }
                else
                {
                    temp.SetAttributeValue("value", unitType);
                }

                // save sym file
                try
                {
                    symDoc.Save(SymFilePath);
                    return true;
                }
                catch (Exception x)
                {
                    ErrorMessage = "An IO Error occured and material and thickness cannot be inserted\r\n\r\nError Reports\r\n" + x.Message;
                    return false;
                }
            }
            catch (Exception x)
            {
                ErrorMessage = "An IO Error occured and material and thickness cannot be inserted\r\n\r\nError Reports\r\n" + x.Message;
                return false;
            }
        }

        public bool isProjectOpen(ref string errMsg)
        {
            try
            {
                if (rApp.Mac.prj_is_open())
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                errMsg = "Error in checking project state.";
                return false;
            }
        }

        public string getOpenProjectName(ref string errMsg)
        {
            try
            {
                if (rApp.Mac.prj_is_open())
                    return rApp.Mac.prj_get_file_path();
                else
                    return "";
            }
            catch (Exception)
            {
                errMsg = "Error in checking project state.";
                return "";
            }
        }

        public string getOpenNestName(ref string errMsg)
        {
            try
            {
                // this does not work
                if (rApp.ActiveDocument.Type == Radraft.Interop.RadDocumentType.radDrawingDocument &&
                        rApp.GUIState == Radraft.Interop.RadGUIState.radNest)
                {
                    // this does not work
                    //return rApp.Mac.NST_NAME;

                    return rApp.Mac.C_DWGDIR + "\\" + rApp.Mac.C_DWG + ".drg";
                }
                else return "";
            }
            catch (Exception)
            {
                errMsg = "Error in getting open nest name";
                return "";
            }
        }

        public bool openNest(string nestName,ref string errMsg)
        {
            try
            {
                rApp.OpenDrawing(nestName, true, "");
                return true;
            }
            catch (Exception)
            {
                errMsg = "Could not open nest";
                return false;
            }
        }

        public bool SaveNest(ref string errMsg)
        {
            try
            {
                if (rApp.ActiveDocument.Type == Radraft.Interop.RadDocumentType.radDrawingDocument &&
                    rApp.GUIState == Radraft.Interop.RadGUIState.radNest &&
                    rApp.ActiveDocument.Dirty)
                {
                    rApp.ActiveDocument.Save();
                }
                if (rApp.Mac.prj_is_edited() == true)
                {
                    rApp.Mac.prj_save();
                }
                return true;
            }
            catch (Exception)
            {
                errMsg = "Error in saving nest.";
                return false;
                //return true;    // just for now till I get time to fix it.
            }
        }

        public bool LoadProject(string projectFileName)
        {
            return rApp.Mac.prj_open(projectFileName);
        }

        public bool SaveProject()
        {
            return rApp.Mac.prj_save();
        }

        public string GetThicknessFromSym(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(fileName))
            {
                doc.Load(fileName);
            }
            else
            {
                return "No Thickness Calculated";
            }

            // cycle through each child node
            foreach (XmlNode node in doc.DocumentElement.FirstChild)
            {
                if (node.InnerXml.Contains("Thickness"))
                {
                    foreach (XmlNode subNode in node)
                    {
                        if (subNode.OuterXml.Contains("Thickness"))
                        {
                            string attr = subNode.Attributes["value"].Value;
                            return attr;
                        }
                    }
                }

            }
            return "Error, No Thickness Found.";
        }

        public string GetMaterialTypeFromSym(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(fileName))
            {
                doc.Load(fileName);
            }
            else
            {
                return "No Material Specified";
            }

            // cycle through each child node
            foreach (XmlNode node in doc.DocumentElement.FirstChild)
            {
                if (node.InnerXml.Contains("Material"))
                {
                    foreach (XmlNode subNode in node)
                    {
                        if (subNode.OuterXml.Contains("Material"))
                        {
                            string attr = subNode.Attributes["value"].Value;
                            return attr;
                        }
                    }
                }

            }
            return "Error, No Material Specified.";
        }
    }
}
