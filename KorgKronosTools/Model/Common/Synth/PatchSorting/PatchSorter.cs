// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Common.Extensions;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Properties;

namespace PcgTools.Model.Common.Synth.PatchSorting
{
    /// <summary>
    /// Utility class.
    /// </summary>
    abstract public class PatchSorter
    {
        /// <summary>
        /// 
        /// </summary>
        private PatchSorter()
        {
            // Not implemented.
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        public static string GetTitle(IPatch patch)
        {
            string title;

            int splitIndex = SplitIndex(patch);

            if (splitIndex == -1)
            {
                // No split character found. Return complete string.
                title = patch.Name;
            }
            else
            {
                title = Settings.Default.Sort_ArtistTitleSortOrder ?
                            patch.Name.Substring(splitIndex + 1, patch.Name.Length - splitIndex - 1) :
                            patch.Name.Substring(0, splitIndex);
                title = title.Expand();
            }

            return title;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        public static string GetArtist(IPatch patch)
        {
            string artist;

            int splitIndex = SplitIndex(patch);

            if (splitIndex == -1)
            {
                // No split character found. Return complete string.
                artist = patch.Name;
            }
            else
            {
                artist = Settings.Default.Sort_ArtistTitleSortOrder ?
                             patch.Name.Substring(0, splitIndex) :
                             patch.Name.Substring(splitIndex + 1, patch.Name.Length - splitIndex - 1);
                artist = artist.Expand();
            }

            return artist;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum SortOrder
        {
            ESortOrderNameCategory,
            ESortOrderTitleArtistCategory,
            ESortOrderArtistTitleCategory,
            ESortOrderCategoryName,
            ESortOrderCategoryTitleArtist,
            ESortOrderCategoryArtistTitle
        };


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patches"></param>
        /// <param name="sortOrder"></param>
        public static void SortBy(List<IPatch> patches, SortOrder sortOrder)
        {
            CompositeComparer<IPatch> comparers = new CompositeComparer<IPatch>();
            comparers.Comparers.Add(EmptyOrInitComparer.Instance);

            switch (sortOrder)
            {
                case SortOrder.ESortOrderNameCategory:
                    comparers.Comparers.Add(NameComparer.Instance);
                    comparers.Comparers.Add(CategoricalComparer.Instance);
                    break;

                case SortOrder.ESortOrderTitleArtistCategory:
                    comparers.Comparers.Add(TitleComparer.Instance);
                    comparers.Comparers.Add(ArtistComparer.Instance);
                    comparers.Comparers.Add(CategoricalComparer.Instance);
                    break;

                case SortOrder.ESortOrderArtistTitleCategory:
                    comparers.Comparers.Add(ArtistComparer.Instance);
                    comparers.Comparers.Add(TitleComparer.Instance);
                    comparers.Comparers.Add(CategoricalComparer.Instance);
                    break;

                case SortOrder.ESortOrderCategoryName:
                    comparers.Comparers.Add(CategoricalComparer.Instance);
                    comparers.Comparers.Add(NameComparer.Instance);
                    break;

                case SortOrder.ESortOrderCategoryTitleArtist:
                    comparers.Comparers.Add(CategoricalComparer.Instance);
                    comparers.Comparers.Add(TitleComparer.Instance);
                    comparers.Comparers.Add(ArtistComparer.Instance);
                    break;

                case SortOrder.ESortOrderCategoryArtistTitle:
                    comparers.Comparers.Add(CategoricalComparer.Instance);
                    comparers.Comparers.Add(ArtistComparer.Instance);
                    comparers.Comparers.Add(TitleComparer.Instance);
                    break;

                default:
                    throw new ApplicationException("Illegal case");
            }

            patches.Sort(comparers);
        }


        /// <summary>
        /// Returns the index of the split character. If multiple split characters are found, the one with the
        ///  most spaces around it is selected;
        /// otherwise the last one.
        /// 
        ///      0         1         2
        ///      012345678901234567890
        /// E.g. Good For You - MC-Joe returns 13
        /// 
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        private static int SplitIndex(IPatch patch)
        {
            int splitIndex = -1;

            string defaultSplitCharacter = Settings.Default.Sort_SplitCharacter;

            Debug.Assert(!string.IsNullOrEmpty(defaultSplitCharacter));
            Debug.Assert(defaultSplitCharacter.Length == 1);
            char splitCharacter = defaultSplitCharacter[0];

            int maxSpacesAroundFoundSplitIndex = 0;

            for (int index = 0; index < patch.Name.Length; index++)
            {
                if (patch.Name[index] == splitCharacter)
                {
                    int spacesAroundIndex = patch.Name.CountCharsAroundIndex(index, ' ');
                    if (spacesAroundIndex >= maxSpacesAroundFoundSplitIndex)
                    {
                        // Select that index;
                        splitIndex = index;
                        maxSpacesAroundFoundSplitIndex = spacesAroundIndex;
                    }
                }
            }

            return splitIndex;
        }
    }
}
