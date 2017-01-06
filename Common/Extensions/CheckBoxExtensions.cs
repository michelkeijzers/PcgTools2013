// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System.Windows.Controls;

namespace Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class CheckBoxExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static bool IsReallyChecked(this CheckBox box)
        {
            return (box.IsChecked.HasValue && box.IsChecked.Value);
        }
    }
}
