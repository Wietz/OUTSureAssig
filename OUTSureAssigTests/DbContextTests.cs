using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OUTsureAssig.DAL;

namespace OUTSureAssigTests
{
    [TestClass]
    public class DbContextTests
    {
        private string DataFileName = @"C:\Users\WietzM\Documents\visual studio 2013\Projects\OUTsureAssig\OUTsureAssig\bin\Debug\People.txt";
        [TestMethod]
        public void DbContextDataLoadTest()
        {
            CSVFileContext dbCtx = new CSVFileContext(DataFileName);
            dbCtx.LoadData();

            Assert.IsTrue(dbCtx.People.Count == 4);
        }
    }
}
