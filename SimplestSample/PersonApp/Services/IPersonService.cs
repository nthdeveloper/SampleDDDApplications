using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.Entities;

namespace PersonApp.Services
{
    public interface IPersonService
    {
        Person Add(Person entity);        
        bool Remove(int id);
        bool Update(Person entity);
        Person Get(int id);
        Person[] GetAll();
    }
}
