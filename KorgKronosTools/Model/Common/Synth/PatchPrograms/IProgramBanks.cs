// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.Synth.Meta;

namespace PcgTools.Model.Common.Synth.PatchPrograms
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProgramBanks : IBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="changes"></param>
        void ChangeDrumKitReferences(
            System.Collections.Generic.Dictionary<PatchDrumKits.IDrumKit, PatchDrumKits.IDrumKit> changes);
    }
}
