using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restwithAsp_net5.Model.Context
{
    public class MysqlContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public MysqlContext()
        {

        }
        public MysqlContext(DbContextOptions<MysqlContext>options):base(options)
        {

        }
       
    }
}
