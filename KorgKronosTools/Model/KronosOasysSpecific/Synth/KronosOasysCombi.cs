// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.OldParameters;

namespace PcgTools.Model.KronosOasysSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KronosOasysCombi: Combi
    {
        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return GetChars(0, MaxNameLength); }

            set
            {
                if (Name != value)
                {
                    SetChars(0, MaxNameLength, value);
                    OnPropertyChanged("Name");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int MaxNameLength => 24;


        /// <summary>
        /// 
        /// </summary>
        public override bool IsEmptyOrInit => ((Name == string.Empty) || (Name.Contains("Init") && Name.Contains("Combi")));


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combiBank"></param>
        /// <param name="index"></param>
        protected KronosOasysCombi(ICombiBank combiBank, int index)
            : base(combiBank, index)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override Common.Synth.OldParameters.IParameter GetParam(ParameterNames.CombiParameterName name)
        {
            IParameter parameter;

            switch (name)
            {
                case ParameterNames.CombiParameterName.Category:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 4790, 4, 0, false, this);
                    break;

                case ParameterNames.CombiParameterName.SubCategory:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 4790, 7, 5, false, this);
                    break;

                case ParameterNames.CombiParameterName.Favorite:
                    parameter = BoolParameter.Instance.Set(Root, Root.Content, ByteOffset + 4791, 0, this);
                    break;

                case ParameterNames.CombiParameterName.Tempo:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 1304, false, 100, this);
                    break;

                case ParameterNames.CombiParameterName.DrumTrackCommonPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 1292, true, 1, this);
                    break;

                case ParameterNames.CombiParameterName.DrumTrackCommonPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 1294, 1, 0, false, this);
                    break;

                default:
                    parameter = base.GetParam(name);
                    break;
            }
            return parameter;
        }
     }
}
