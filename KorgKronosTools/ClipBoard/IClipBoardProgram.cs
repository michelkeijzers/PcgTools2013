// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System.Collections.Generic;
using PcgTools.Model.Common.Synth.PatchDrumKits;

namespace PcgTools.ClipBoard
{
    /// <summary>
    /// 
    /// </summary>
    public interface IClipBoardProgram : IClipBoardPatch
    {
        /// <summary>
        /// References to drum kits.
        /// </summary>
        IClipBoardPatches ReferencedDrumKits { get; set; }
    }
}
