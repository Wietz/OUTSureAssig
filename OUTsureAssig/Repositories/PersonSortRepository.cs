using OUTsureAssig.DAL;
using OUTsureAssig.DAL.Models;
using OUTsureAssig.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig.Repositories
{
    /// <summary>
    /// PersonSortRepository extends PersonRepository. This class exposes two methods
    /// that allows for sorting Person.Addresses by street name and to create a sorted list of names/surnames
    /// with the number of instances of each name/surname.
    /// </summary>
    public class PersonSortRepository : PersonRepository, IPersonSortRepository
    {

        public PersonSortRepository(IDbContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Sorts all the addresses in the People database.
        /// </summary>
        /// <returns>A string array that can be written out to a text file.</returns>
        public string[] SortByAddressAsc()
        {
            List<Person> allPeople = this.GetAll();
            List<AddressParts> addrParts = new List<AddressParts>();
            foreach(Person p in allPeople)
            {
                string[] aParts = p.Address.Split(new string[] { " " }, StringSplitOptions.None);
                addrParts.Add(new AddressParts()
                    {
                        StreetNumber = aParts[0],
                        StreetName = aParts[1],
                        StreetType = aParts[2]
                    });
            }

            addrParts.Sort();
            List<string> addrStrings = new List<string>();
            foreach(AddressParts addrPart in addrParts)
            {
                addrStrings.Add(addrPart.ToString());
            }

            return addrStrings.ToArray();
        }


        /// <summary>
        /// Creates a sorted list of names/surnames and the frequency/count of each.
        /// </summary>
        /// <returns>
        /// A string array with each item in the format "Name, Count" e.g:"Jones, 2"
        /// These items can then be written out to a test file.
        /// </returns>
        public string[] GetSortedNameFreq()
        {
            List<Person> allPeople = this.GetAll();
            List<string> names = new List<string>();
            foreach(Person p in allPeople)
            {
                names.Add(p.Name);
                names.Add(p.Surname);
            }

            List<NameFrequency> groupedNames = names.GroupBy(n => n).Select(group => new NameFrequency
            {
                Name = group.Key,
                Frequency = group.Count()
            }).OrderByDescending(n => n.Frequency).ThenBy(n => n.Name).ToList();

            List<string> nameFreqStr = new List<string>();
            foreach(NameFrequency nameFreq in groupedNames)
            {
                nameFreqStr.Add(nameFreq.ToString());
            }

            return nameFreqStr.ToArray();
        }
    }
}
