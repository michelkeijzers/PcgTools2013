﻿using System;
using Common.Mvvm;
using Common.Utils;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.PcgToolsResources;
using PcgTools.Properties;

namespace PcgTools.MasterFiles
{
    /// <summary>
    /// 
    /// </summary>
    public class MasterFile : ObservableObject, IMasterFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public MasterFile(IModel model, string fileName)
        {
            Model = model;
            FileName = fileName;
        }


        /// <summary>
        /// 
        /// </summary>
        private string _fileName;


        /// <summary>
        /// Used for UI control binding for selections.
        /// </summary>
        private bool _isSelected;


        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public IModel Model { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        [UsedImplicitly]
        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    UpdateState();
                    OnPropertyChanged("FileName");
                }
            }
        }


        /// <summary>
        /// Sets a master file with file name to the model specified. Use an empty string to remove.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public void SetModel(IModel model, string fileName)
        {
            Model = model;
            FileName = fileName;

            switch (model.OsVersion)
            {
                case Models.EOsVersion.Kronos3x:
                    Settings.Default.MasterFile_KronosOS3x = fileName;
                    break;

                case Models.EOsVersion.Kronos2x:
                    Settings.Default.MasterFile_KronosOS2x = fileName;
                    break;

                case Models.EOsVersion.Kronos15_16:
                    Settings.Default.MasterFile_KronosOS15_16 = fileName;
                    break;

                case Models.EOsVersion.Kronos10_11:
                    Settings.Default.MasterFile_KronosOS10_11 = fileName;
                    break;

                case Models.EOsVersion.Oasys:
                    Settings.Default.MasterFile_Oasys = fileName;
                    break;

                case Models.EOsVersion.Krome:
                    Settings.Default.MasterFile_Krome = fileName;
                    break;

                case Models.EOsVersion.KromeEx:
                    Settings.Default.MasterFile_Krome = fileName;
                    break;

                case Models.EOsVersion.Kross:
                    Settings.Default.MasterFile_Kross = fileName;
                    break;

                case Models.EOsVersion.Kross2:
                    Settings.Default.MasterFile_Kross2 = fileName;
                    break;

                case Models.EOsVersion.M3_20:
                    Settings.Default.MasterFile_M3_OS20 = fileName;
                    break;

                case Models.EOsVersion.M3_1X:
                    Settings.Default.MasterFile_M3_OS1x = fileName;
                    break;

                case Models.EOsVersion.M50:
                    Settings.Default.MasterFile_M50 = fileName;
                    break;

                case Models.EOsVersion.MicroStation:
                    Settings.Default.MasterFile_MicroStation = fileName;
                    break;

                case Models.EOsVersion.TritonExtreme:
                    Settings.Default.MasterFile_TritonExtreme = fileName;
                    break;

                case Models.EOsVersion.TritonTrClassicStudioRack:
                    Settings.Default.MasterFile_TritonTrClassicStudioRack = fileName;
                    break;

                case Models.EOsVersion.TritonLe:
                    Settings.Default.MasterFile_TritonLe = fileName;
                    break;

                case Models.EOsVersion.TritonKarma:
                    Settings.Default.MasterFile_TritonKarma = fileName;
                    break;

                case Models.EOsVersion.TrinityV2:
                    Settings.Default.MasterFile_TrinityV2 = fileName;
                    break;

                case Models.EOsVersion.TrinityV3:
                    Settings.Default.MasterFile_TrinityV3 = fileName;
                    break;
                    
                default:
                    throw new ApplicationException("Illegal work station model");
            }

            UpdateState();
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdateState()
        {
            if (FileName == string.Empty)
            {
                FileState = EFileState.Unassigned;
            }
            else
            {
                MasterFiles masterFiles = MasterFiles.Instances;
                if (masterFiles != null)
                {
                    ViewModels.IPcgViewModel pcgWindow = masterFiles.MainViewModel.FindPcgViewModelWithName(FileName);
                    if (pcgWindow == null)
                    {
                        FileState = System.IO.File.Exists(FileName) ? EFileState.Unloaded : EFileState.NotPresent;
                    }
                    else
                    {
                        FileState = EFileState.Loaded;
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [UsedImplicitly]
        public enum EFileState
        {
            Unassigned,
            NotPresent,
            Unloaded,
            Loaded
        }


        /// <summary>
        /// 
        /// </summary>
        private EFileState _fileState;
        [UsedImplicitly]
        public EFileState FileState
        {
            get { return _fileState; }
            private set
            {
                if (_fileState != value)
                {
                    _fileState = value;
                    FileStateAsString = FileState2String();
                    //Console.WriteLine("propertychanged"); //TMP
                    OnPropertyChanged("FileState");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string FileState2String()
        {
            string str;
            switch (FileState)
            {
                case EFileState.Unassigned:
                    str = Strings.Unassigned_mastd;
                    break;

                case EFileState.NotPresent:
                    str = Strings.NotPresent_mastd;
                    break;

                case EFileState.Unloaded:
                    str = Strings.Unloaded_mastd;
                    break;

                case EFileState.Loaded:
                    str = Strings.Loaded_mastd;
                    break;

                default:
                    throw new ApplicationException("Illegal file state enum");
            }
            return str;
        }


        /// <summary>
        /// 
        /// </summary>
        private string _fileStateAsString;


        /// <summary>
        /// 
        /// </summary>
        [UsedImplicitly]
        public string FileStateAsString
        {
            get { return _fileStateAsString; }
            set { if (_fileStateAsString != value) { _fileStateAsString = value; OnPropertyChanged("FileStateAsString"); } }
        }


        /// <summary>
        /// 
        /// </summary>
        [UsedImplicitly]
        public string WorkStationModel
        {
            get { return Model.ModelAsString; }
            set
            {
                // Needed for WPF.
                throw new ApplicationException("Not implemented");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [UsedImplicitly]
        public string OsVersion
        {
            get { return Model.OsVersionString; }
            set
            {
                // Needed for WPF.
                throw new NotSupportedException("Not implemented");
            }
        }
    }
}
