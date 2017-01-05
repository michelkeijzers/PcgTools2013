// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System.ComponentModel;
using PcgTools.Model.Common.Synth.PatchInterfaces;
using PcgTools.OpenedFiles;
using PcgTools.Songs;

namespace PcgTools.Model.Common.Synth.SongsRelated
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISong : ISelectable, INotifyPropertyChanged, INavigable, ILocatable, INamable
    {
        /// <summary>
        /// 
        /// </summary>
        ISongTimbres Timbres { get; }

        
        /// <summary>
        /// 
        /// </summary>
        ISongMemory Memory { get; }
    }
}
