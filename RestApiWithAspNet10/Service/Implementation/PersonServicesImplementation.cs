using RestApiWithAspNet10.Model;
using RestApiWithAspNet10.Repositories;
using RestApiWithAspNet10.Service;


namespace RestApiWithAspNet10.Service.Implementation
{
    public class PersonServicesImplementation : IPersonServices
    {   
        private IPersonRepository _repository;
        public PersonServicesImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {

            return _repository.FindAll();
        }
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }
        
        public Person Create(Person person)
        {
            person.Id = 0;
            return _repository.Create(person);
        }
        
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
        
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
