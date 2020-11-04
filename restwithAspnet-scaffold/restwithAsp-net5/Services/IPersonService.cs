using restwithAsp_net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restwithAsp_net5.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person findById(long id);
        List<Person> findAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
