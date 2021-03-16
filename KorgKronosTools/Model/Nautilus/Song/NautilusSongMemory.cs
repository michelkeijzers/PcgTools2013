// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.SongsRelated;
using PcgTools.PcgToolsResources;

namespace PcgTools.Model.NautilusSpecific.Song
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusSongMemory : SongMemory
    {
        /// <summary>
        /// 
        /// </summary>
        public Models.EOsVersion InitOsVersion { private get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public NautilusSongMemory(string fileName)
            : base(fileName)
        {
            Model = Models.Find(Models.EOsVersion.Nautilus); // Songs are always considered Nautilus files
        }
    }
}
