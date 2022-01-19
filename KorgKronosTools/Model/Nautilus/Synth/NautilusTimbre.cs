// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.OldParameters;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.KronosSpecific.Synth;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusTimbre : KronosTimbre
    {
        /// <summary>
        /// 
        /// </summary>
        private static int TimbresSizeConstant => 188;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="timbres"></param>
        /// <param name="index"></param>
        public NautilusTimbre(ITimbres timbres, int index)
            : base(timbres, index)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override IParameter GetParam(ParameterNames.TimbreParameterName name)
        {
            IParameter parameter;

            switch (name)
            {
            case ParameterNames.TimbreParameterName.Detune:
                parameter = IntParameter.Instance.SetMultiBytes(
                    Root, Root.Content, TimbresOffset + 8, 2, false, true, Parent as IPatch);
                break;

            default:
                parameter = base.GetParam(name);
                break;
            }
            return parameter;
        }
    }
}
