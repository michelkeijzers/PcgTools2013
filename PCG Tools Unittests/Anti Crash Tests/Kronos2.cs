﻿// (c) 2011-2016 Michel Keijzers

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PCG_Tools_Unittests
{
    [TestClass]
    public class AntiCrashTestsKronos2 : AntiCrashTests
    {
        [TestMethod]
        public void Test_Kronos2_PRELOAD_V3_PCG()
        {
            TestAll(@"Workstations\Kronos2\PRELOAD_V3.PCG");
        }
    }
}
