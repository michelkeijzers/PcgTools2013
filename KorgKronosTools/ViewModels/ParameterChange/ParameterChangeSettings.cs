using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcgTools.ViewModels.ParameterChange
{
    public class ParameterChangeSettings
    {

        /// <summary>
        /// 
        /// </summary>
        public enum EChangeType
        {
            AbsoluteValue,
            RelativeValue,
            Percentage
        }


        /// <summary>
        /// 
        /// </summary>
        public EChangeType ChangeType { get; set; }


    }
}
