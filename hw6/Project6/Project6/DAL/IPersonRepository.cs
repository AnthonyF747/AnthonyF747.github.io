using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project6.Models;

namespace Project6.DAL
{
    interface IPersonRepository
    {
        IEnumerable<Person> People { get; }
    }
}
