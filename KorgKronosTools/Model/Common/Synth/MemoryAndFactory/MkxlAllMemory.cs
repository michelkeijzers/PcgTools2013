// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.PcgToolsResources;

namespace PcgTools.Model.Common.Synth.MemoryAndFactory
{
    /// <summary>
    /// 
    /// </summary>
    public class MkxlAllMemory : PcgMemory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="modelType"></param>
        protected MkxlAllMemory(string fileName, Models.EModelType modelType)
            : base(fileName, modelType)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool HasSubCategories { get { return true; } }


        /// <summary>
        /// 
        /// </summary>
        public override int NumberOfCategories { get { return 8; } }


        /// <summary>
        /// 
        /// </summary>
        public override int NumberOfSubCategories { get { return 8; } }


        /// <summary>
        /// On the MicroKorg XL, programs are divided into genres, then into categories.
        /// </summary>
        public override string CategoryName
        {
            get { return Strings.Genre; }
        }


        /// <summary>
        /// On the MicroKorg XL, programs are divided into genres, then into categories.
        /// </summary>
        public override string SubCategoryName
        {
            get { return Strings.Category; }
        }


        /// <summary>
        /// MicroKorg XL uses genres and categories instead of categories and sub categories.
        /// </summary>
        public override bool UsesCategoriesAndSubCategories
        {
            get { return false; }
        }


        /// <summary>
        /// On the MicroKorg XL, categories (actually genres and categories) are not editable.
        /// </summary>
        public override bool AreCategoriesEditable
        {
            get { return false; }
        }
    }
}
