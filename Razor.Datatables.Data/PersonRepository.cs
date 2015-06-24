using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razor.Datatables.Data
{
    public class PersonRepository : IPersonRepository
    {
        private AdventureWorks2012Entities _entities;

        public PersonRepository(AdventureWorks2012Entities entities)
        {
            _entities = entities;
        }

        public Person GetPersonById(Guid id)
        {
            return _entities.People.FirstOrDefault(p => p.rowguid == id);
        }

        public IEnumerable<Person> GetPersonByName(string last)
        {
            return _entities.People.Where(p => p.LastName.Contains(last));
        }
    }
}
