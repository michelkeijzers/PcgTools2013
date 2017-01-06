using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchDatabaseBackEnd
{
    /// <summary>
    /// 
    /// </summary>
    public class PatchDataList
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PatchData> PatchList { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public PatchDataList()
        {
            PatchList = new List<PatchData>();
        }


        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var patch in PatchList)
            {
                builder.AppendLine(String.Format("{0}: {1}, {2}", patch.PatchName, patch.Author, patch.Description));
            }

            return builder.ToString();
        }
    }
}
