﻿// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System.Collections.ObjectModel;
using Common.Mvvm;

namespace PcgTools.Model.Common.Synth.SongsRelated
{
    /// <summary>
    /// 
    /// </summary>
    public class Songs : ISongs
    {
                /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionEx<ISong> SongCollection { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public Songs()
        {
            SongCollection = new ObservableCollectionEx<ISong>();
        }
    }
}