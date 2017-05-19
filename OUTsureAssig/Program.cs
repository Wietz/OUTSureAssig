using OUTsureAssig.DAL;
using OUTsureAssig.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataFileName = "People.txt";

                CSVFileContext ctx = new CSVFileContext(dataFileName);
                IPersonSortRepository sortRep = new PersonSortRepository(ctx);
                string[] sortedAddresses = sortRep.SortByAddressAsc();
                Utilities.OutputTestFile.WriteData("SortedAddresses.txt", sortedAddresses);

                string[] sortedFreq = sortRep.GetSortedNameFreq();
                Utilities.OutputTestFile.WriteData("SortedFreq.txt", sortedFreq);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Done");
                Console.ReadKey();
            }


        }
    }
}
