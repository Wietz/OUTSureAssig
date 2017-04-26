using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig.Domain
{
    /// <summary>
    /// AddressParts domain object that allows the three parts of a typical address in the People
    /// database (Number Name Type) e.g.: 98 Chauser St
    /// to be split up and sorted according to the street name.
    /// </summary>
    public class AddressParts : IComparable<AddressParts>
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }

        /// <summary>
        /// CompareTo is implemented to allow the IEnumerable Sort method
        /// to sort the AddressParts object according to Street Name
        /// </summary>
        public int CompareTo(AddressParts other)
        {
            return this.StreetName.CompareTo(other.StreetName);
        }

        public string ToString()
        {
            return string.Format("{0} {1} {2}", StreetNumber, StreetName, StreetType);
        }
    }
}
