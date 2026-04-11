using RestApiWithAspNet10.Data.Converter.Implementation;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;
using RestApiWithAspNet10.Repositories;


namespace RestApiWithAspNet10.Service.Implementation
{
    public class PersonServicesImplementation : IPersonServices
    {   
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonServicesImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonDTO> FindAll()
        {

            return _converter.ParseList(_repository.FindAll());
        }
        public PersonDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        
        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }
        
        public PersonDTO Update(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }
        
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
