// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System.Collections.Generic;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.OldParameters;
using PcgTools.Model.Common.Synth.PatchDrumKits;
using PcgTools.Model.Common.Synth.PatchInterfaces;

namespace PcgTools.Model.Common.Synth.PatchPrograms
{
    /// <summary>
    /// IMPR: FixedParameter only used for certain programs (MS2000/micro)
    /// </summary>
    public interface IProgram : IPatch, ICategoriesNamable, IFixedParameterValue, IReferencable, IDrumTrackReference
    {
        List<IDrumKit> UsedDrumKits { get; }

        /// <summary>
        /// Replaces all occurences of patch to the new drum kit.
        /// </summary>
        /// <param name="changes"></param>
        void ReplaceDrumKit(Dictionary<IDrumKit, IDrumKit> changes);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IParameter GetParam(ParameterNames.ProgramParameterName name);
    }
}
