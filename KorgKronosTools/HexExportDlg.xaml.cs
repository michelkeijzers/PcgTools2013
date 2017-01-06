using System;
using System.Collections.Generic;
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

namespace PcgTools
{
    /// <summary>
    /// Interaction logic for HexExportDlg.xaml
    /// </summary>
    public partial class HexExportDlg : Window
    {
        public HexExportDlg(string text)
        {
            InitializeComponent();
            TextBlock.Text = text;
        }
    }
}
