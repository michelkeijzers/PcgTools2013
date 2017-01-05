// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.File;
using PcgTools.Model.Common.Synth.MemoryAndFactory;

namespace PcgTools.Model.MSpecific.Pcg
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MPcgFileReader : PcgFileReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPcgMemory"></param>
        /// <param name="content"></param>
        protected MPcgFileReader(IPcgMemory currentPcgMemory, byte[] content)
            : base(currentPcgMemory, content)
        {
            // PcgFileHeader PcgFileHeader;
            // Pcg1Chunk Pcg1Chunk;
            // Div1Chunk Div1Chunk;
            // Ini2Chunk Ini2Chunk;
            // Ini1Chunk Ini1Chunk;
            // Prg1Chunk Prg1Chunk;
            // Cmb1Chunk Cmb1Chunk;
            // Dkt1Chunk Dkt1Chunk;
            // Arp1Chunk Arp1Chunk;
            // Glb1Chunk Glb1Chunk;
        }


        /// <summary>
        /// 
        /// </summary>
        protected override int Div1Offset { get { return 0x1C; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int BetweenChunkGapSize { get { return 12; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int GapSizeAfterMbk1ChunkName { get { return 4; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int Pbk1NumberOfProgramsOffset { get { return 12; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int SizeBetweenCmb1AndCbk1 { get { return 8; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int Cbk1NumberOfCombisOffset { get { return 12; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int Dbk1NumberOfDrumKitsOffset { get { return 12; } }



        protected override int Dpi1NumberOfDrumPatternsOffset
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
