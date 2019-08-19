using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadanInterface2;
using RadProject;
using ProductionMasterModel;

namespace RadanProjectInterface
{
    public class RadanProjectInterface
    {
        string RadanProjectName { get; set; }
        RadanProject RPrj { get; set; }
        string SymFolder { get; set; }
        RadanInterface RadInterface { get; set; }


        public RadanProjectInterface(string symFolder)
        {
            SymFolder = symFolder;
            RadInterface = new RadanInterface();
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
            // loop through RadanID referene table, till we find an id in the range of 0 to 500 that is available
            for (int i = 1; i <= 500; i++)
            {
                
                RadanID radanIDItem = (dbContext.RadanIDs.Where(r => r.RadanIDNumber == i).FirstOrDefault());
                if (radanIDItem == null)
                {
                    RadanID newRadanID = new RadanID();
                    newRadanID.OrderItem = orderItem;
                    newRadanID.OrderItemID = orderItem.ID;
                    newRadanID.RadanIDNumber = i;
                    dbContext.RadanIDs.Add(newRadanID);
                    dbContext.SaveChanges();
                    orderItem.RadanID = newRadanID;
                    orderItem.RadanIDNumber = i;
                    dbContext.SaveChanges();
                    return i;
                }
            }


            return -1;
        }

    }

    
}
