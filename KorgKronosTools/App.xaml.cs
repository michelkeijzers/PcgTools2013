// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using System.Windows;
using System.Globalization;
using System.IO;
using System.Threading;
using Common.Utils;
using PcgTools.PcgToolsResources;
using PcgTools.Properties;

namespace PcgTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string[] Arguments { get; private set;  }
        
        void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                Arguments = e.Args;
            }
        }

        /// <summary>
        /// Do not remove, although 0 references are mentioned, this method takes care of the
        /// resource regeneration problem, making a default public instead of internal constructor.
        /// There is also another method copied in the ResourceHelper.
        /// </summary>
        /// <returns></returns>
        public static Strings GetStringResources()
        {
            return new PcgToolsResources.Strings();
        }
    }
}
