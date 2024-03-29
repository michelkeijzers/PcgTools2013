﻿// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System.Collections.Generic;
using System.Diagnostics;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.KronosSpecific.Synth;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusCombiBanks : KronosCombiBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public NautilusCombiBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateBanks()
        {
            foreach (string id in new[] { "A", "B", "C", "D", "E", "F" })
            {
                Add(new NautilusCombiBank(this, BankType.EType.Int, id, -1));
            }

            foreach (string id in new[] { "G", "H", "I", "J", "K", "L", "M", "N" })
            {
                Add(new NautilusCombiBank(this, BankType.EType.User, id, -1));
            }

            CreateVirtualBanks();
        }


        /// <summary>
#pragma warning disable 1570
        /// Create 32 virtual banks (8 groups of 8 banks).
        /// To create virtual banks, name them like V<number><A..H>
        /// 
        /// The PCG file that is created, adds the banks before all internal banks 
        /// (so the bank IDS are 0x30, 0x30 + 1, ... 0x30 + 63, 0, 1, 2, ..
        /// Do not forget to change the IDs (0x30 ... 0x30 + 63, and change the chunk size of CMB1. 
        /// 
        /// Some interesting offsets/values:
        /// 0x8EA2A8 CMB1
        /// 0x8EA2AC  Chunk size: D58F50 (change this).
        /// ...
        /// New banks start at CBK1, bank ID at CBK1 + 16 (change this).
        /// 
        /// The size of one bank is 
        /// </summary>
#pragma warning restore 1570
        protected override void CreateVirtualBanks()
        {
            List<char> bankNames = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            for (int bankGroupIndex = 0; bankGroupIndex < 8; bankGroupIndex++)
            {
                foreach (char bankName in bankNames)
                {
                    Add(
                        new NautilusCombiBank(
                            this, BankType.EType.Virtual,
                            $"V{bankGroupIndex}-{bankName}", -1));
                }
            }
        }
    }
}
