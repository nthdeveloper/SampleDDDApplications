using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.Entities;

namespace PersonApp.Persistence.EntityFramework
{
    static class MapperExtensionMethods
    {
        public static PersonEntity ToPersonEntity(this Person person)
        {
            return new PersonEntity()
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname            
            };
        }

        public static Person ToDomainPerson(this PersonEntity entity)
        {
            return new Person()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname
            };
        }
    }
}
