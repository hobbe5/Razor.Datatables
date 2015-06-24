using System;
using System.Collections.Generic;

namespace Razor.Datatables.Data
{
    public interface IPersonRepository
    {
        Person GetPersonById(Guid id);
        IEnumerable<Person> GetPersonByName(string last);
    }
}
