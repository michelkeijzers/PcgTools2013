// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using System.ComponentModel;
using System.Windows.Input;
using Common.Mvvm;
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.SongsRelated;
using PcgTools.Songs;

namespace PcgTools.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISongViewModel : IViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        string WindowTitle { get; }


        /// <summary>
        /// 
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        void UpdateWindowTitle();


        /// <summary>
        /// 
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        ISong Song { get; set; }


        OpenedPcgWindows OpenedPcgWindows { get; }
    }
}
