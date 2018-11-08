using Project6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project6.DAL
{
    public class WWINameRepository
    {
        private WWINameRepository wwiDb = new WWINameRepository();

        public IEnumerable<Person> People
        {
            get { return wwiDb.People; }
        }
    }
}