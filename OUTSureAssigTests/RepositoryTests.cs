using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OUTsureAssig.DAL;
using OUTsureAssig.Repositories;
using System.Collections.Generic;
using OUTsureAssig.DAL.Models;
using System.Linq;

namespace OUTSureAssigTests
{
    [TestClass]
    public class RepositoryTests
    {
        private string DataFileName = @"C:\Users\WietzM\Documents\visual studio 2013\Projects\OUTsureAssig\OUTsureAssig\bin\Debug\People.txt";
        [TestMethod]
        public void PeopleRepositoryGetAllTest()
        {
            CSVFileContext ctx = new CSVFileContext(DataFileName);
            PersonRepository personRep = new PersonRepository(ctx);
            List<Person> people = personRep.GetAll();

            Assert.IsTrue(people.Count == 4);
        }

        [TestMethod]
        public void PeopleRepositorySortByAddressTest()
        {
            CSVFileContext ctx = new CSVFileContext(DataFileName);
            PersonSortRepository sortRep = new PersonSortRepository(ctx);
            string[] sortedAddresses = sortRep.SortByAddressAsc();

            string[] testInput = new string[]
            {
                "12 Acton St",
                "98 Chauser St",
                "31 Clifton Rd",
                "22 Jones Rd"  
            };

            CollectionAssert.AreEqual(sortedAddresses, testInput);
            Assert.IsTrue(sortedAddresses.ToList().SequenceEqual(testInput));
        }

        [TestMethod]
        public void GetSortedNameFreqTest()
        {
            CSVFileContext ctx = new CSVFileContext(DataFileName);
            PersonSortRepository sortRep = new PersonSortRepository(ctx);

            string[] sortedFreq = sortRep.GetSortedNameFreq();

            string[] testInput = new string[]
            {
                "Johnson, 2",
                "Brown, 1",
                "Heinrich, 1",
                "Jones, 1",
                "Matt, 1",
                "Smith, 1",
                "Tim, 1"
            };

            CollectionAssert.AreEqual(sortedFreq, testInput);
            Assert.IsTrue(sortedFreq.ToList().SequenceEqual(testInput));
        }
    }
}
