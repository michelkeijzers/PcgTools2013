using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using PcgTools.PcgToolsResources;

// (c) 2011 Michel Keijzers

namespace PcgTools.Help
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class ExternalLinksOasysVoucherCodeSponsorsWindow // : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public ExternalLinksOasysVoucherCodeSponsorsWindow()
        {
            InitializeComponent();

            List<ExternalItem> externalItems = new List<ExternalItem>
            {
                new ExternalItem
                {
                    Name = "Ian Hutty (Ianhu)", Description = "Oasys Voucher Code Sponsor",
                },
                new ExternalItem
                {
                    Name = "Patrick Dumas (Fzero)", Description = "Oasys Voucher Code Sponsor",
                },
                new ExternalItem
                {
                    Name = "Steve D (steve53)", Description = "Oasys Voucher Code Sponsor",
                },
                new ExternalItem
                {
                    Name = "Frans van den Berg (Paulifra)", Description = "Oasys Voucher Code Sponsor",
                },
                new ExternalItem
                {
                    Name = "Tim (t_tangent)", Description = "Oasys Voucher Code Sponsor",
                },
                new ExternalItem
                {
                    Name = "SoulBe", Description = "Oasys Voucher Code Sponsor",
                },
                new ExternalItem
                {
                    Name = "Adam P (Kontrol 49)", Description = "Oasys Voucher Code Sponsor",
                },
            };

            List<UserControlExternalLink> linkButtons = new List<UserControlExternalLink>
            {
                ButtonLink1,
                ButtonLink2,
                ButtonLink3,
                ButtonLink4,
                ButtonLink5,
                ButtonLink6,
                ButtonLink7,
                ButtonLink8,
                ButtonLink9,
                ButtonLink10,
                ButtonLink11,
                ButtonLink12,
                ButtonLink13,
                ButtonLink14,
                ButtonLink15,
                ButtonLink16,
                ButtonLink17,
                ButtonLink18,
                ButtonLink19,
                ButtonLink20,
                ButtonLink21,
                ButtonLink22,
                ButtonLink23,
                ButtonLink24,
                ButtonLink25,
                ButtonLink26,
                ButtonLink27,
                ButtonLink28,
                ButtonLink29,
                ButtonLink30
            };

            for (int index = 0; index < externalItems.Count; index++)
            {
                UserControlExternalLink userControl = linkButtons[index];
                userControl.PreviewMouseLeftButtonUp += ButtonLinkOnPreviewMouseLeftButtonUp;
                userControl.Tag = externalItems[index];
                userControl.DataContext = externalItems[index];
            }

            for (int index = externalItems.Count; index < linkButtons.Count; index++)
            {
                linkButtons[index].Visibility = Visibility.Collapsed;
            }
        }


        private void ButtonLinkOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            UserControlExternalLink userControlExternalLink = sender as UserControlExternalLink;
            if (userControlExternalLink != null)
            {
                ExternalItem item = userControlExternalLink.Tag as ExternalItem;
                if ((item != null) && (item.Url != null))
                {
                    ShowUrl(item.Url);
                }
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        private void ShowUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url));
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, $"{Strings.LinkWarning}.\n{Strings.Message}:{exception.Message}", 
                    Strings.PcgTools,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


