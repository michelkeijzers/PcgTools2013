using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace ExternalUtilities
{
    /// <summary>
    /// Interaction logic for LanguageCrossReferenceWindow.xaml
    /// </summary>
    public partial class LanguageCrossReferenceWindow : Window
    {
        private const string ResourcePath = 
            @"E:\users\michel\OneDrive\pcgtools2013\korgkronostools\pcgtoolsresources\";

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

            CheckLanguages();
            //CreateReferenceLanguageList();
            //CheckOtherLanguages();

            StringBuilder text = ShowAllTexts();
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
            StringBuilder text = new StringBuilder();
            foreach (string key in _referenceTranslations.Keys)
            {
                text.Append(key + ": ");
                StringBuilder languages = new StringBuilder();
                foreach (char langValue in _referenceTranslations[key])
                {
                    languages.Append(langValue);
                }
                text.AppendLine(languages.ToString());
            }
            return text;
        }

        private void CheckLanguages()
        {
            string[] cultures = new[] { "", "cs", "de", "el", "es", "fr", "nl", "pl",
                "pt-BR", "pt-BR", "ru", "tr" }; // Removed: "sr-Latn-RS",

            _warnings.Append($"{"Phrase/Word/Item",-50} ");
            foreach (string culture in cultures)
            {
                _warnings.Append($"{(culture == "" ? "English" : culture),-6} ");
            }
            _warnings.AppendLine("\n");

            Dictionary<string, List<bool>> dict = new Dictionary<string, List<bool>>(); // Word -> present[culture]

             // Create word list
            for (int cultureIndex = 0; cultureIndex < cultures.Length; cultureIndex++)
            {
                string culture = cultures[cultureIndex];
                string fileName = ResourcePath + "Strings" + (culture == "" ? "" : ".") + culture + ".resx";
                XElement xElement = XDocument.Load(fileName).Root;
                if (xElement != null)
                    foreach (string key in from elem in xElement.Elements("data")
                        let xAttribute = elem.Attribute("name")
                        where xAttribute != null
                        let key = xAttribute.Value
                        let element = elem.Element("value")
                        where element != null
                        let value = element.Value.Replace("\n", "<NL>")
                        where !key.StartsWith("___") && !key.StartsWith("String") select key)
                    {
                        if (dict.ContainsKey(key))
                        {
                            dict[key][cultureIndex] = true;
                        }
                        else
                        {
                            dict[key] = new List<bool>();
                            for (int listIndex = 0; listIndex < cultures.Length; listIndex++)
                            {
                                dict[key].Add(false);
                            }
                            dict[key][cultureIndex] = true;
                        }
                    }
            }

            // show non complete cultures
            List<string> dictKeys = dict.Keys.ToList();
            dictKeys.Sort();

            foreach (string key in dictKeys)
            {
                if (dict[key].Contains(false))
                {
                    List<bool> item = dict[key];
                    _warnings.Append($"{key,-50}: ");
                    for (int listIndex = 0; listIndex < cultures.Length; listIndex++)
                    {
                        _warnings.Append(dict[key][listIndex] ? $"{"",-6} " : $"{cultures[listIndex],-6} ");
                    }

                    _warnings.AppendLine();
                }
            }
        }

        private void CreateReferenceLanguageList()
        {
            const string fileName = ResourcePath + "Strings.resx";
            List<XElement> elements = XDocument.Load(fileName).Root.Elements("data").ToList();
            elements.Sort();
            foreach (XElement elem in elements)
            {
                string key = elem.Attribute("name").Value;
                string value = elem.Element("value").Value.Replace("\n", "<NL>");

                if (!_referenceTranslations.ContainsKey(key))
                {
                    _referenceTranslations.Add(key, value);
                }
                else
                {
                    _warnings.AppendLine(
                        $"In reference language, fragment {key} is defined again with value {value}.");
                }
            }
        }

        private void CheckOtherLanguages()
        {

            string[] cultures = new[] {"cs", "de", "el", "es", "fr", "nl", "pl", "pt-BR", "pt-BR", "ru", "sr-Latn-RS", "tr"};
            foreach (string culture in cultures)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();

                string fileName = ResourcePath + "Strings." + culture + ".resx";
                foreach (XElement elem in XDocument.Load(fileName).Root.Elements("data"))
                {
                    string key = elem.Attribute("name").Value;
                    string value = elem.Element("value").Value.Replace("\n", "<NL>");

                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, value);
                    }
                    else
                    {
                        _warnings.AppendLine(
                            $"In culture {culture}, fragment {key} is defined again with value {value}.");
                    }

                    // Check if the word exists in reference language.
                    if (!_referenceTranslations.ContainsKey(key))
                    {
                        _warnings.AppendLine(
                            $"Reference language does not contain from culture {culture}, fragment {key} with value {value}");
                    }
                }    

                // Check if all English words are translated in culture language.
                foreach (string key in _referenceTranslations.Keys)
                {
                    if (!dict.Keys.Contains(key))
                    {
                        _warnings.AppendLine(
                            $"Culture {culture} does not contain from reference language, fragment {key} with value {_referenceTranslations[key]}");
                    }
                }
            }
        }
    }
}
