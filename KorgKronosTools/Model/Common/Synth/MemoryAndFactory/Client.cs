﻿// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.Synth.SongsRelated;

namespace PcgTools.Model.Common.Synth.MemoryAndFactory
{
    /// <summary>
    /// From abstract factory design pattern.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// 
        /// </summary>
        readonly IPcgMemory _pcgMemory;


        /// <summary>
        /// 
        /// </summary>
        readonly ISongMemory _songMemory;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="fileName"></param>
        public Client(IFactory factory, string fileName)
        {
            _pcgMemory = factory.CreatePcgMemory(fileName);
            _songMemory = factory.CreateSongMemory(fileName);
        }


        /// <summary>
        /// 
        /// </summary>
        public IPcgMemory PcgMemory { get { return _pcgMemory; }}


        /// <summary>
        /// 
        /// </summary>
        public ISongMemory SongMemory { get { return _songMemory; }}
    }
}
