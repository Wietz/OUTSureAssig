using OUTsureAssig.DAL;
using OUTsureAssig.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsureAssig.Repositories
{
    public class PersonRepository : IRepository<Person>
    {

        private IDbContext _dbContext;

        public PersonRepository(IDbContext dbContext)
        {
            if (dbContext == null)
                throw new Exception("Initialised with invalid Db Context object.");
            _dbContext = dbContext;
        }
        public List<Person> GetAll()
        {
            return _dbContext.People;
        }


    }
}
