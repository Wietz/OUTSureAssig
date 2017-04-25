using OUTsureAssig.DAL.Models;
using OUTsureAssig.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig.Repositories
{
    public interface IPersonSortRepository
    {
        string[] SortByAddressAsc();

        string[] GetSortedNameFreq();
    }
}
