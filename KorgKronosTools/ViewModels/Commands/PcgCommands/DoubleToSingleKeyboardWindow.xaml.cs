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
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.PatchSetLists;

namespace PcgTools.ViewModels.Commands.PcgCommands
{
    /// <summary>
    /// Interaction logic for DoubleToSingleKeyboardWindow.xaml
    /// </summary>
    public partial class DoubleToSingleKeyboardWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IPcgMemory _memory;


        /// <summary>
        /// 
        /// </summary>
        private DoubleToSingleKeyboardCommands _commands;


        /// <summary>
        /// 
        /// </summary>
        public DoubleToSingleKeyboardWindow(IPcgMemory memory, DoubleToSingleKeyboardCommands commands)
        {
            _memory = memory;
            _commands = commands;
            InitializeComponent();
        }


        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            FillSetListComboBoxes();
            FillTargetCombiBankComboBox();
            SetupMidiChannelNumerics();

            InitializeDefaults();
        }

        private void FillSetListComboBoxes()
        {
            if (_memory.SetLists != null)
            {
                foreach (var setList in _memory.SetLists.BankCollection)
                {
                    var item = new ComboBoxItem();
                    item.Tag = setList;
                    item.Content = String.Format("{0} {1}", setList.Id, setList.Name);

                    var item2 = new ComboBoxItem();
                    item2.Tag = setList;
                    item2.Content = String.Format("{0} {1}", setList.Id, setList.Name);
                

                    SourceSetListListBox.Items.Add(item);
                    TargetSetListListBox.Items.Add(item2);
                }
            }
        }

        private void FillTargetCombiBankComboBox()
        {
            if (_memory.CombiBanks != null)
            {
                foreach (var bank in _memory.CombiBanks.BankCollection)
                {
                    var item = new ComboBoxItem
                    {
                        Tag = bank,
                        Content = String.Format("{0}", bank.Id)
                    };

                    TargetCombiBankListBox.Items.Add(item);
                }
            }
        }

        private void SetupMidiChannelNumerics()
        {
            NumericUpDownMidiChannelMainKeyboard.Minimum = 1;
            NumericUpDownMidiChannelMainKeyboard.Maximum = 16;
            NumericUpDownMidiChannelSecondaryKeyboard.Minimum = 1;
            NumericUpDownMidiChannelSecondaryKeyboard.Maximum = 16;
        }

        private void InitializeDefaults()
        {
            SourceSetListListBox.SelectedIndex = 0;
            TargetSetListListBox.SelectedIndex = 0;
            TargetCombiBankListBox.SelectedIndex = 0;
            NumericUpDownMidiChannelMainKeyboard.Value = 1;
            NumericUpDownMidiChannelSecondaryKeyboard.Value = 2;
        }

        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            _commands.Process((ISetList) ((SourceSetListListBox.SelectedItem as ComboBoxItem).Tag), 
                (ISetList) ((TargetSetListListBox.SelectedItem as ComboBoxItem).Tag),
                (ICombiBank) ((TargetCombiBankListBox.SelectedItem as ComboBoxItem).Tag),
                // ReSharper disable once PossibleInvalidOperationException
                NumericUpDownMidiChannelMainKeyboard.Value.Value, // Value is preset 
                // ReSharper disable once PossibleInvalidOperationException
                NumericUpDownMidiChannelSecondaryKeyboard.Value.Value); // Value is preset
            Close();
        }


        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
