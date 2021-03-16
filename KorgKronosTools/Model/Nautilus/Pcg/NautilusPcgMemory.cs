// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System.Collections.Generic;
using System.Diagnostics;
using PcgTools.ClipBoard;
using PcgTools.Model.Common;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.KronosSpecific.Pcg;
using PcgTools.Model.NautilusSpecific.Synth;
using System;
using System.Linq;
using PcgTools.Model.Common.Synth.PatchPrograms;

namespace PcgTools.Model.NautilusSpecific.Pcg
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusPcgMemory : KronosPcgMemory
    {
        public NautilusPcgMemory(string fileName)
            : base(fileName)
        {
            CombiBanks = new NautilusCombiBanks(this);
            ProgramBanks = new NautilusProgramBanks(this);
            SetLists = new NautilusSetLists(this);
            WaveSequenceBanks = new NautilusWaveSequenceBanks(this);
            DrumKitBanks = new NautilusDrumKitBanks(this);
            DrumPatternBanks = new NautilusDrumPatternBanks(this);
            Global = new NautilusGlobal(this);
        }
    }
}
