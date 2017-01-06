// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

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
