using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.SongsRelated;

namespace PcgTools.ViewModels
{
    public interface ISngTimbresViewModel : IViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        ISong Song { get; }


        /// <summary>
        /// 
        /// </summary>
        Action UpdateUiContent { get; }
    }
}
