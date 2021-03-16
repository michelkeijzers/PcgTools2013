
using System;
using PcgTools.Model.Common.Synth.PatchDrumKits;
using PcgTools.Model.Common.Synth.PatchSetLists;
using PcgTools.Model.KronosSpecific.Synth;

// (c) 2011 Michel Keijzers

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusDrumKit : KronosDrumKit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drumKitBank"></param>
        /// <param name="index"></param>
        public NautilusDrumKit(DrumKitBank drumKitBank, int index)
            : base(drumKitBank, index)
        {
        }
    }
}
