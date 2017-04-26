using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OUTsureAssig.DAL;

namespace OUTSureAssigTests
{
    [TestClass]
    public class DbContextTests
    {
        private string DataFileName = @"People.txt";

        /// <summary>
        /// Test the data load process for the CSVFileContext class.
        /// </summary>
        [TestMethod]
        
        public void DbContextDataLoadTest()
        {
            CSVFileContext dbCtx = new CSVFileContext(DataFileName);
            dbCtx.LoadData();

            Assert.IsTrue(dbCtx.People.Count == 4);
        }
    }
}
