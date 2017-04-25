using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig.Domain
{
    public class AddressParts : IComparable<AddressParts>
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }

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
