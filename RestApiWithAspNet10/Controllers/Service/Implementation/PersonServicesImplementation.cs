using RestApiWithAspNet10.Controllers.Model;
using RestApiWithAspNet10.Controllers.Model.Context;

namespace RestApiWithAspNet10.Controllers.Service.Implementation
{
    public class PersonServicesImplementation : IPersonServices
    {   
        private MSSQLContext _context;

        public PersonServicesImplementation(MSSQLContext context)
        {
            _context = context;
        }
        public Person FindById(long id)
        {
            var person = MockPerson((int)id);
            return person;// Simulate finding a person by ID
        }
        
        public List<Person> FindAll()
        {
            
            return _context.Persons.ToList();
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
                FirstName = "Leandro " + i,
                LastName = "Costa " + + i ,
                Address = "Uberlândia - Minas Gerais - Brasil",
                Gender = "Male"
            };
            return person;
        }
    }
}
