using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.PcgToolsResources;

namespace PcgTools.Model.Common.File
{
    public abstract class MkxlPProgFileReader : MkxlFileReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPcgMemory"></param>
        /// <param name="content"></param>
        protected MkxlPProgFileReader(IPcgMemory currentPcgMemory, byte[] content)
            : base(currentPcgMemory, content)
        {
        }
    }
}