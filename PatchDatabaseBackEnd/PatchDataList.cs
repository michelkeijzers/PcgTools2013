using System.Collections.Generic;
using System.Text;

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
            StringBuilder builder = new StringBuilder();

            foreach (PatchData patch in PatchList)
            {
                builder.AppendLine($"{patch.PatchName}: {patch.Author}, {patch.Description}");
            }

            return builder.ToString();
        }
    }
}
