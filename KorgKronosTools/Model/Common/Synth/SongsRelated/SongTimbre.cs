﻿using System.ComponentModel;
using System.Diagnostics;
using Common.Mvvm;
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.OldParameters;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.PatchInterfaces;
using PcgTools.Model.Common.Synth.PatchPrograms;

namespace PcgTools.Model.Common.Synth.SongsRelated
{
    /// <summary>
    /// 
    /// </summary>
    public class SongTimbre : Timbre, ISongTimbre
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ITimbres _timbres;


        /// <summary>
        /// 
        /// </summary>
        private ITimbres Timbres { get { return _timbres; } }


        /// <summary>
        /// 
        /// </summary>
        private int TimbresSize { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="timbres"></param>
        /// <param name="index"></param>
        /// <param name="timbresSize"></param>
        public SongTimbre(ITimbres timbres, int index, int timbresSize) 
            : base(timbres, index, timbresSize)
        {
            Debug.Assert(timbresSize > 0);

            _timbres = timbres;
            Index = index;
            TimbresSize = timbresSize;
        }


        public override IMemory Root
        {
            get { return (IMemory)(Timbres.Parent.Parent); }
        }


        public override INavigable Parent
        {
            get { return Timbres; }
        }


        public override bool IsLoaded
        {
            get { return true; }
            set { throw new System.NotImplementedException(); }
        }

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override int GetFixedParameterValue(FixedParameter.EType type)
        {
            return -1;
        }

        
        /// <summary>
        /// 
        /// </summary>
        public override IProgramBank UsedProgramBank
        {
            get { return null; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override IProgram UsedProgram
        {
            get; set;
        }


        /// <summary>
        /// 
        /// </summary>
        public override string ColumnProgramId
        {
            get { return "ID"; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override string ColumnProgramName
        {
            get { return "TODO"; }
        } //TODO
    }
}
