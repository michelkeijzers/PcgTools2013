using System.Collections.Generic;
using System.IO;

namespace PatchDatabaseBackEnd
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CsvHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public static void WriteAsCsv(PatchDataList list)
        {
            
        }


        public static PatchDataList ReadAsCsv()
        {
            PatchDataList patchDataList = new PatchDataList();

            string allText = File.ReadAllText(@"h:\patches.txt");
            foreach (string line in allText.Split('\n'))
            {
                List<object> columns = ReadColumns(line);
                if (columns.Count == 3)
                {
                    PatchData patchData = new PatchData
                    {
                        PatchName = (string) columns[0],
                        Author = (string) columns[1],
                        Description = (string) columns[2]
                    };
                    patchDataList.PatchList.Add(patchData);
                }
            }

            return patchDataList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static List<object> ReadColumns(string line)
        {
            List<object> columns = new List<object>();

            object column;
            do
            {
                column = ReadColumn(line);
                if (column != null)
                {
                    columns.Add(column);
                }
            }
            while (column != null);

            return columns;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static object ReadColumn(string line)
        {
            line = line.Trim();
            if (line.StartsWith("\""))
            {
                // Treat as string, read until next ".
            }
            return null; //TODO
        }
    }
}
