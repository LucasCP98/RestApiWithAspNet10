using RestApiWithAspNet10.Controllers.Model;

namespace RestApiWithAspNet10.Controllers.Service.Implementation
{
    public class PersonServicesImplementation : IPersonServices
    {
        public Person FindById(long id)
        {
            var person = MockPerson((int)id);
            return person;// Simulate finding a person by ID
        }
        
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }
        
        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000); // Simulate ID generation
            return person;
        }
        
        public Person Update(Person person)
        {
            return person;
        }
        
        public void Delete(long id)
        {
            // Simulate delete operation
        }
        
        private Person MockPerson(int i)
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "Leandro" + i,
                LastName = "Costa" + + i ,
                Address = "Uberlândia - Minas Gerais - Brasil",
                Gender = "Male"
            };
            return person;
        }
    }
}
