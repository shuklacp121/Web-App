using Web_App.Models;

namespace Web_App.Interfaces
{
    public interface IPersonServices
    {
        public List<Person> GetPersonDetails();
        public Person GetPerson(int id);
        public Person AddPerson(Person person);
        public Person UpdatePerson(Person person);
        public bool DeletePerson(int id);
    }
}
