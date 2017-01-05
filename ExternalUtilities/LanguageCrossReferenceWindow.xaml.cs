using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace ExternalUtilities
{
    /// <summary>
    /// Interaction logic for LanguageCrossReferenceWindow.xaml
    /// </summary>
    public partial class LanguageCrossReferenceWindow : Window
    {
        private const string ResourcePath = 
            @"c:\users\michel\source\repos\pcgtools2013\korgkronostools\pcgtoolsresources\";

        // Key: text fragment to translate (keyword)
        // Value: English translation.
        private SortedDictionary<string, string> _referenceTranslations;

        private StringBuilder _warnings;

        public LanguageCrossReferenceWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _referenceTranslations = new SortedDictionary<string, string>();
            _warnings = new StringBuilder();

            CreateReferenceLanguageList();
            CheckOtherLanguages();

            var text = ShowAllTexts();
            TranslationsTextBox.Text = text.ToString();
            WarningsTextBox.Text = _warnings.ToString();

            File.WriteAllText("warnings.txt", _warnings.ToString());
            Process.Start(new ProcessStartInfo("warnings.txt"));
        }

        /// <summary>
        /// Not used, but maybe for later; shows all strings and values.
        /// </summary>
        /// <returns></returns>
        private StringBuilder ShowAllTexts()
        {
            var text = new StringBuilder();
            foreach (var key in _referenceTranslations.Keys)
            {
                text.Append(key + ": ");
                var languages = new StringBuilder();
                foreach (var langValue in _referenceTranslations[key])
                {
                    languages.Append(langValue);
                }
                text.AppendLine(languages.ToString());
            }
            return text;
        }

        void CreateReferenceLanguageList()
        {
            const string fileName = ResourcePath + "Strings.resx";
            foreach (var elem in XDocument.Load(fileName).Root.Elements("data"))
            {
                var key = elem.Attribute("name").Value;
                var value = elem.Element("value").Value.Replace("\n", "<NL>");

                if (!_referenceTranslations.ContainsKey(key))
                {
                    _referenceTranslations.Add(key, value);
                }
                else
                {
                    _warnings.AppendLine(
                        String.Format("In reference language, fragment {0} is defined again with value {1}.", key, value));
                }
            }
        }

        void CheckOtherLanguages()
        {

            var cultures = new[] {"cs", "de", "el", "es", "fr", "nl", "pl", "pt-BR", "pt-BR", "ru", "sr-Latn-RS", "tr"};
            foreach (var culture in cultures)
            {
                var dict = new Dictionary<string, string>();

                var fileName = ResourcePath + "Strings." + culture + ".resx";
                foreach (var elem in XDocument.Load(fileName).Root.Elements("data"))
                {
                    var key = elem.Attribute("name").Value;
                    var value = elem.Element("value").Value.Replace("\n", "<NL>");

                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, value);
                    }
                    else
                    {
                        _warnings.AppendLine(
                            String.Format("In culture {0}, fragment {1} is defined again with value {2}.", culture, key,
                                value));
                    }

                    // Check if the word exists in reference language.
                    if (!_referenceTranslations.ContainsKey(key))
                    {
                        _warnings.AppendLine(
                            String.Format(
                                "Reference language does not contain from culture {0}, fragment {1} with value {2}",
                                culture, key, value));
                    }
                }    

                // Check if all English words are translated in culture language.
                foreach (var key in _referenceTranslations.Keys)
                {
                    if (!dict.Keys.Contains(key))
                    {
                        _warnings.AppendLine(
                            String.Format(
                                "Culture {0} does not contain from reference language, fragment {1} with value {2}",
                                culture, key, _referenceTranslations[key]));
                    }
                }
            }
        }
    }
}
