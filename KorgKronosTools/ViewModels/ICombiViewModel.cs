using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcgTools.Model.Common.Synth.PatchCombis;

namespace PcgTools.ViewModels
{
    public interface ICombiViewModel : IViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        ICombi Combi { get; }


        /// <summary>
        /// 
        /// </summary>
        Action UpdateUiContent { get; }
    }
}
