using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.Entities;
using PersonApp.Exceptions;

namespace PersonApp.Persistence.EntityFramework
{
    public class PersonRepository : IPersonRepository
    {
        public Person Add(Person entity)
        {
            using (PersonDbContext context = new PersonDbContext())
            {
                var _addedEntity = context.Persons.Add(entity.ToPersonEntity());
                return _addedEntity.ToDomainPerson();
            }
        }

        public Person Get(int id)
        {
            using (PersonDbContext context = new PersonDbContext())
            {
                var _personEntity = context.Persons.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (_personEntity != null)
                    return _personEntity.ToDomainPerson();

                return null;
            }
        }

        public IList<Person> GetAll()
        {
            using (PersonDbContext context = new PersonDbContext())
            {
                return context.Persons.Where(x => !x.IsDeleted).ToList().ConvertAll<Person>((entity) => entity.ToDomainPerson());
            }
        }

        public void Remove(int id)
        {
            using (PersonDbContext context = new PersonDbContext())
            {
                var _entityItem = context.Persons.FirstOrDefault(x => x.Id == id);
                if (_entityItem != null)
                {
                    if (!_entityItem.IsDeleted)
                    {
                        _entityItem.IsDeleted = true;
                        context.SaveChanges();
                    }
                }
                else
                    throw new NotFoundException(String.Format("Person with id {0} not found.", id));
            }
        }

        public void Remove(Person entity)
        {
            Remove(entity.Id);
        }

        public void Update(Person entity)
        {
            using (PersonDbContext context = new PersonDbContext())
            {
                var _personEntity = entity.ToPersonEntity();
                context.Entry(_personEntity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
