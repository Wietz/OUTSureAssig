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
        private string DataFileName = @"People.txt";

        /// <summary>
        /// Test the PeopleRepository.GetAll() method
        /// </summary>
        [TestMethod]
        public void PeopleRepositoryGetAllTest()
        {
            CSVFileContext ctx = new CSVFileContext(DataFileName);
            PersonRepository personRep = new PersonRepository(ctx);
            List<Person> people = personRep.GetAll();

            //There should be for persons in the people list
            Assert.IsTrue(people.Count == 4);
        }

        /// <summary>
        /// Test the PeopleSortRepository.SortByAddress() method.
        /// </summary>
        [TestMethod]
        public void PeopleRepositorySortByAddressTest()
        {
            CSVFileContext ctx = new CSVFileContext(DataFileName);
            PersonSortRepository sortRep = new PersonSortRepository(ctx);
            string[] sortedAddresses = sortRep.SortByAddressAsc();

            //The expected output
            string[] testOutput = new string[]
            {
                "12 Acton St",
                "98 Chauser St",
                "31 Clifton Rd",
                "22 Jones Rd"  
            };

            //Assert if the output is equel to the expected output.
            CollectionAssert.AreEqual(sortedAddresses, testOutput);

            //Assert if the sequence of the output is the same as that of the expected output.
            Assert.IsTrue(sortedAddresses.ToList().SequenceEqual(testOutput));
        }


        /// <summary>
        /// Test the PersonSortRepository.GetSortedNameFreq() method.
        /// </summary>
        [TestMethod]
        public void GetSortedNameFreqTest()
        {
            CSVFileContext ctx = new CSVFileContext(DataFileName);
            PersonSortRepository sortRep = new PersonSortRepository(ctx);

            string[] sortedFreq = sortRep.GetSortedNameFreq();

            //The expected output
            string[] testOutput = new string[]
            {
                "Johnson, 2",
                "Brown, 1",
                "Heinrich, 1",
                "Jones, 1",
                "Matt, 1",
                "Smith, 1",
                "Tim, 1"
            };

            //Assert if the output is equel to the expected output.
            CollectionAssert.AreEqual(sortedFreq, testOutput);

            //Assert if the sequence of the output is the same as that of the expected output.
            Assert.IsTrue(sortedFreq.ToList().SequenceEqual(testOutput));
        }
    }
}
