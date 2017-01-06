using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common.Mvvm;
using PcgTools.Annotations;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.ViewModels;

namespace PcgTools.Edit
{
    /// <summary>
    /// Interaction logic for WindowEditParameter.xaml
    /// </summary>
    public partial class WindowEditParameterOld : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public EditParameterViewModel ViewModel { get; private set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        public WindowEditParameterOld(ObservableCollectionEx<IPatch> patches)
        {
            InitializeComponent();
            ViewModel = new EditParameterViewModel(patches);
            DataContext = ViewModel;
        }
    }
}
