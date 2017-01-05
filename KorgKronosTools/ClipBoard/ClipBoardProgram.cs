﻿// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved


using System.Collections.Generic;
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.PatchDrumKits;
using PcgTools.Model.Common.Synth.PatchPrograms;
using PcgTools.Model.KronosSpecific.Pcg;
using PcgTools.Model.KronosSpecific.Synth;

namespace PcgTools.ClipBoard
{
    /// <summary>
    /// 
    /// </summary>
    public class ClipBoardProgram : ClipBoardPatch, IClipBoardProgram
    {

        /// <summary>
        /// Contains PRG2, CMB2 or SLS2? bytes.
        /// </summary>
        public byte[] KronosOs1516Content { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public ClipBoardProgram(IProgram program) : base(program.Root.Content, program.ByteOffset, program.ByteLength)
        {
            OriginalLocation = program;
            ReferencedDrumKits = new ClipBoardPatches();

            KronosOs1516Content = new byte[KronosProgramBanks.ParametersInPbk2Chunk];
            var memory = program.Root as KronosPcgMemory;
            if ((memory != null) && (memory.PcgRoot.Model.OsVersion == Models.EOsVersion.EOsVersionKronos15_16))
                // PRG2 content
            {
                for (var parameter = 0; parameter < KronosProgramBanks.ParametersInPbk2Chunk; parameter++)
                {
                    var patchParameterOffset =
                        ((KronosProgramBank) (program.Parent)).GetParameterOffsetInPbk2(program.Index, parameter);
                    KronosOs1516Content[parameter] = program.Root.Content[patchParameterOffset];
                }
            }
        }
        

        /// <summary>
        /// References to drum kits.
        /// </summary>
        public IClipBoardPatches ReferencedDrumKits { get; set; }
    }
}