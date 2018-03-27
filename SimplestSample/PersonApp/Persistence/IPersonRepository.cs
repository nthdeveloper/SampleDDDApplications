using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.Entities;

namespace PersonApp.Persistence
{
    public interface IPersonRepository
    {
        Person Add(Person entity);
        void Remove(Person entity);
        void Remove(int id);
        void Update(Person entity);
        Person Get(int id);
        IList<Person> GetAll();        
    }
}
