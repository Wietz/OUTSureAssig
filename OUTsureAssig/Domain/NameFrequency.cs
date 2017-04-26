using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig.Domain
{
    /// <summary>
    /// NameFrequency domain model to create objects with a name/surname and count/frequency
    /// value. These can then be used in an IEnumerable list for further processing.
    /// </summary>
    public class NameFrequency
    {
        public string Name { get; set; }
        public int Frequency { get; set; }

        public string ToString()
        {
            return string.Format("{0}, {1}", Name, Frequency);
        }

    }
}
