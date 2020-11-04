using restwithAsp_net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace restwithAsp_net5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> findAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 9; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }


        public Person findById(long id)
        {
            return new Person
            {
                Id=this.IncrementAndGet(),
                Adress = "Montes Claros",
                Gender = "Male",
                FirstName = "Farley",
                LastName = "Melo"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id=IncrementAndGet(),
                Adress = "Person Adress"+i,
                Gender = "Person Gender"+i,
                FirstName = "Person Name"+i,
                LastName = "Person Last Name"+i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
