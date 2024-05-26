using Web_App.Interfaces;
using Web_App.Models;

namespace Web_App.Services
{
    public class PersonService : IPersonServices
    {
        private readonly FirstAppContext _firstAppContext;
        public PersonService(FirstAppContext firstAppContext)
        {
            _firstAppContext = firstAppContext;
        }
        public Person AddPerson(Person person)
        {

            var per = _firstAppContext.Add(person);
            _firstAppContext.SaveChanges();
            return per.Entity;
            
        }

        public bool DeletePerson(int id)
        {
            try
            {
                var per = _firstAppContext.Persons.SingleOrDefault(v => v.Id == id);
                if (per != null)
                {
                    _firstAppContext.Persons.Remove(per);
                    _firstAppContext.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Person GetPerson(int id)
        {
            var per = _firstAppContext.Persons.SingleOrDefault(v => v.Id == id);
            return per;
        }

        public List<Person> GetPersonDetails()
        {
            var persons = _firstAppContext.Persons.ToList();
            return persons;
        }

        public Person UpdatePerson(Person person)
        {
            var updated_per = _firstAppContext.Persons.Update(person);
            _firstAppContext.SaveChanges();
            return updated_per.Entity;
        }
    }
}
