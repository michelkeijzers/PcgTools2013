﻿// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchCombis;

namespace PcgTools.Model.MicroStationSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class MicroStationCombiBanks : CombiBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public MicroStationCombiBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateBanks()
        {
            //                          0    1    2    3   
            foreach (string id in new[] { "A", "B", "C", "D" })
            {
                Add(new MicroStationCombiBank(this, BankType.EType.Int, id, -1));
            }
        }

    }
}
