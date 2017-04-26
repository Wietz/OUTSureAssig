using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig.DAL.Models
{
    /// <summary>
    /// The Person model representing a person in the People database.
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
