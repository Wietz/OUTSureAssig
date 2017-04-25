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
    public class PersonSortRepository : PersonRepository, IPersonSortRepository
    {

        public PersonSortRepository(IDbContext dbContext) : base(dbContext) { }
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
