// (c) 2011-2019 Michel Keijzers

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PCG_Tools_Unittests
{
    [TestClass]
    public class AntiCrashTestsKromeEx : AntiCrashTests
    {
        [TestMethod]
        public void Test_KromeEx_EX08AGO_PCG()
        {
            TestAll(@"Workstations\KromeEx\EX08AGO.PCG");
        }

        [TestMethod]
        public void Test_KromeEx_MSIZ_PCG()
        {
            TestAll(@"Workstations\KromeEx\MSIZ.PCG");
        }

        [TestMethod]
        public void Test_Krome_OLDTOWN_PCG()
        {
            TestAll(@"Workstations\KromeEx\OLDTOWN.PCG");
        }

        [TestMethod]
        public void Test_Krome_INSPIANOEX_PCG()
        {
            TestAll(@"Workstations\KromeEx\INSPIANOEX.PCG");
        }
    }
}
