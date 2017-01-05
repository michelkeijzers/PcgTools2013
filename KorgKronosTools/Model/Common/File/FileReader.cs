using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcgTools.Model.Common.File
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class FileReader
    {
        /// <summary>
        /// Byte offset where timbres start.
        /// </summary>
        protected virtual int TimbresByteOffset
        {
            get { return -1; }
        }
    }
}
