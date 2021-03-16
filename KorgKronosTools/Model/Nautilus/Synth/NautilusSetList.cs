// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common;

using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchSetLists;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusSetList : SetList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="setLists"></param>
        /// <param name="index"></param>
        public NautilusSetList(SetLists setLists, int index)
            : base(setLists, BankType.EType.Int, index, -1)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public override void CreatePatch(int index)
        {
            Add(new NautilusSetListSlot(this, index));
        }

        
        // Name

        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return Util.GetChars(Root.Content, ByteOffset, MaxNameLength); }

            set
            {
                if (Name != value)
                {
                    Util.SetChars(PcgRoot, Root.Content, ByteOffset, MaxNameLength, value);
                    OnPropertyChanged("", false);
                }
            }
        }
    }
}
