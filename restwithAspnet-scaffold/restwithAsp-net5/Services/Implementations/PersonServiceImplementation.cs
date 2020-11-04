using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using restwithAsp_net5.Model;
using restwithAsp_net5.Model.Context;
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
        private MysqlContext _mysqlContext;

        public PersonServiceImplementation(MysqlContext mysqlContext)
        {
            _mysqlContext = mysqlContext;
        }
        public Person Create(Person person)
        {
            try
            {
                _mysqlContext.Add(person);
                _mysqlContext.SaveChanges();

            }
            catch (Exception e)
            {

                throw e;
            }
            
            return person;
        }

        public void Delete(long id)
        {
            var result = _mysqlContext.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _mysqlContext.Persons.Remove(result);
                    _mysqlContext.SaveChanges();

                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }

        public List<Person> findAll()
        {
            return _mysqlContext.Persons.ToList();
        }


        public Person findById(long id)
        {
            return _mysqlContext.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return new Person();
            }
           var result= _mysqlContext.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _mysqlContext.Entry(result).CurrentValues.SetValues(person);
                    _mysqlContext.SaveChanges();

                }
                catch (Exception e)
                {

                    throw e;
                }

            }
           

            return person;
        }

        private bool Exists(long id)
        {
            return _mysqlContext.Persons.Any(p => p.Id.Equals(id));
        }

       
    }
}
