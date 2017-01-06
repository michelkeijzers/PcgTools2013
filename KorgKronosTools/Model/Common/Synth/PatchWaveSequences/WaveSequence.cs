// (c) 2011 Michel Keijzers

using System;
using System.Text;
using Common.Extensions;
using Common.Utils;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.PcgToolsResources;

namespace PcgTools.Model.Common.Synth.PatchWaveSequences
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class WaveSequence : Patch<WaveSequence>, IWaveSequence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveSeqBank"></param>
        /// <param name="index"></param>
        protected WaveSequence(IBank waveSeqBank, int index)
        {
            Bank = waveSeqBank;
            Index = index;
            Id = string.Format("{0}{1}", waveSeqBank.Id, index.ToString("000"));
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Clear()
        {
            Name = String.Empty;
            RaisePropertyChanged(String.Empty, false);
        }


        /// <summary>
        /// 
        /// </summary>
        public override void SetNotifications()
        {
            // No implementation needed for now.
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public override void Update(string name)
        {
            //  No implementation needed for now.
        }
        

        /// <summary>
        /// 
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public string PatchTypeAsString
        {
            get { return Strings.WaveSequence; }
        }

        /// <summary>
        /// Change all references to the current patch, towards the specified patch.
        /// </summary>
        /// <param name="newPatch"></param>
        public override void ChangeReferences(IPatch newPatch)
        {
            throw new NotImplementedException();
        }

        public override void SetParameters()
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool ToolTipEnabled
        {
            get { return !IsEmptyOrInit; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override string ToolTip
        {
            get
            {
                var builder = new StringBuilder();
                if (IsEmptyOrInit)
                {
                    builder.Append(Strings.EmptyOrInitPatchName);
                }

                return builder.ToString().RemoveLastNewLine();
            }
        }
    }
}
