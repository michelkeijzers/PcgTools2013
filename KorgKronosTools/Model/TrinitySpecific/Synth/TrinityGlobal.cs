// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System;

using PcgTools.Model.Common.Synth.Global;
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Properties;

namespace PcgTools.Model.TrinitySpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class TrinityGlobal : Global
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public TrinityGlobal(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override int PcgOffsetCategories { get { return 146; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int SizeOfProgramsCategoriesAndSubCategories
        {
            get { return NrOfCategories * 2 * CategoryNameLength; } // For both A and B categories
        }


        /// <summary>
        /// 
        /// </summary>
        protected override int CategoryNameLength { get { return 16; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int NrOfCategories { get { return 16; } } // 16 for A and 16 for B.


        /// <summary>
        /// 
        /// </summary>
        protected override int NrOfSubCategories { get { throw new NotSupportedException("No sub categories supported"); } }


        /// <summary>
        /// Returns offset from global.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override int CalcCategoryNameOffset(ECategoryType type, int index)
        {
            var offset = ByteOffset + PcgOffsetCategories;
            if (!Settings.Default.TrinityCategorySetA)
            {
                offset += CategoryNameLength * NrOfCategories;
            }

            offset += (type == ECategoryType.Program) ? 0 : SizeOfProgramsCategoriesAndSubCategories;
            offset += index * CategoryNameLength;
            return offset;
        }
    }
}
