// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.KronosOasysSpecific.Pcg;

namespace PcgTools.Model.KronosSpecific.Pcg
{
    /// <summary>
    /// 
    /// </summary>
    public class KronosPcgFileReader : KronosOasysPcgFileReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPcgMemory"></param>
        /// <param name="content"></param>
        public KronosPcgFileReader(IPcgMemory currentPcgMemory, byte[] content)
            : base(currentPcgMemory, content)
        {
            // PcgFileHeader PcgFileHeader;
            // Pcg1Chunk Pcg1Chunk;
            // Div1Chunk Div1Chunk;
            // Ini2Chunk Ini2Chunk;
            // Ini1Chunk Ini1Chunk;
            // Sls1Chunk Sls1Chunk;
            // Prg1Chunk Prg1Chunk;
            // Cmb1Chunk Cmb1Chunk;
            // Dkt1Chunk Dkt1Chunk;
            // Arp1Chunk Arp1Chunk;
            // Glb1Chunk Glb1Chunk;

            currentPcgMemory.Model = Models.Find(Models.EOsVersion.Nautilus);
            currentPcgMemory.PcgChecksumType = PcgMemory.ChecksumType.Nautilus;
        }

        protected override int Dpi1NumberOfDrumPatternsOffset
        {
            get { throw new NotImplementedException(); }
        }
    }
}
