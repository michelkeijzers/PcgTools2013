using System;
using System.ComponentModel;
using System.Diagnostics;
using Common.Utils;

namespace Common.Mvvm
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="verifyPropertyName"></param>
        void RaisePropertyChanged(string propertyName, bool verifyPropertyName = true);    
    }
}
