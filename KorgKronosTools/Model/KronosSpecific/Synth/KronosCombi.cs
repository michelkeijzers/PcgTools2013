﻿// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System.Diagnostics;
using PcgTools.ClipBoard;
using PcgTools.Model.Common;

using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.OldParameters;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.KronosOasysSpecific.Synth;

namespace PcgTools.Model.KronosSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class KronosCombi : KronosOasysCombi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="combiBank"></param>
        /// <param name="index"></param>
        public KronosCombi(CombiBank combiBank, int index)
            : base(combiBank, index)
        {
            Timbres = new KronosTimbres(this);
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            if (PcgRoot.AreFavoritesSupported)
            {
                GetParam(ParameterNames.CombiParameterName.Favorite).Value = false;
            }

            RaisePropertyChanged(string.Empty, false);
        }


        /// <summary>
        /// Sets parameters after initialization.
        /// </summary>
        public override void SetParameters()
        {
        }
                     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPatch"></param>
        /// <param name="includingName"></param>
        /// <param name="maxDiffs"></param>
        /// <returns></returns>
        public override int CalcByteDifferences(IPatch otherPatch, bool includingName, int maxDiffs)
        {
            int diffs = base.CalcByteDifferences(otherPatch, includingName, maxDiffs);

            // Take CBK2 differences into account.
            if (((KronosCombiBank)(Parent)).Cbk2PcgOffset != 0)
            {
                for (int parameterIndex = 0; parameterIndex < KronosCombiBanks.ParametersInCbk2Chunk; parameterIndex++)
                {
                    for (int timbre = 0; timbre < Timbres.TimbresCollection.Count; timbre++)
                    {
                        int patchIndex = ((KronosCombiBank) Parent).GetParameterOffsetInCbk2(Index, timbre, parameterIndex);
                        int otherPatchIndex = ((KronosCombiBank) otherPatch.Parent).GetParameterOffsetInCbk2(Index, timbre, parameterIndex);

                        diffs += (Util.GetInt(PcgRoot.Content, patchIndex, 1) != Util.GetInt(
                            otherPatch.PcgRoot.Content, otherPatchIndex, 1)) ? 1 : 0;
                    }
                }
            }
            return diffs;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPatch"></param>
        /// <param name="includingName"></param>
        /// <param name="maxDiffs"></param>
        /// <returns></returns>
        public override int CalcByteDifferences(IClipBoardPatch otherPatch, bool includingName, int maxDiffs)
        {
            ClipBoardCombi otherCombi = otherPatch as ClipBoardCombi;
            Debug.Assert(otherCombi != null);

            int diffs = base.CalcByteDifferences(otherPatch, includingName, maxDiffs);

            // Take CBK2 differences into account.
            if (((KronosCombiBank)(Parent)).Cbk2PcgOffset != 0)
            {
                for (int parameterIndex = 0; parameterIndex < KronosCombiBanks.ParametersInCbk2Chunk; parameterIndex++)
                {
                    for (int timbre = 0; timbre < Timbres.TimbresCollection.Count; timbre++)
                    {
                        int patchIndex = ((KronosCombiBank)Parent).GetParameterOffsetInCbk2(Index, timbre, parameterIndex);
                        diffs += (Util.GetInt(PcgRoot.Content, patchIndex, 1) != otherCombi.KronosOs1516Content[parameterIndex]) ? 1 : 0;
                    }
                }
            }
            return diffs;
        }


        /// <summary>
        /// 
        /// </summary>
        public static int SizeBetweenCmb2AndCbk2 => 8;
    }
}
