using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.Entities;
using PersonApp.Persistence;

namespace PersonApp.Services
{
    public class PersonService : IPersonService
    {
        IPersonRepository m_PersonRepository;

        public PersonService(IPersonRepository personRepository)
        {
            m_PersonRepository = personRepository;
        }

        public Person Add(Person entity)
        {
            //1. Check security

            //2. Do the operation
            var _addedEntity = m_PersonRepository.Add(entity);

            //3. Add log 

            //4. Return result
            return _addedEntity;
        }

        public Person Get(int id)
        {
            //Check security

            return m_PersonRepository.Get(id);
        }

        public Person[] GetAll()
        {
            return m_PersonRepository.GetAll().ToArray();
        }

        public bool Remove(int id)
        {
            try
            {
                m_PersonRepository.Remove(id);
            }
            catch(Exception ex)
            {
                //TODO: Log the exception

                return false;
            }
            return true;
        }

        public bool Update(Person entity)
        {
            try
            {
                m_PersonRepository.Update(entity);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception

                return false;
            }
            return true;
        }
    }
}
