using Mapster;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;
using RestApiWithAspNet10.Repositories;


namespace RestApiWithAspNet10.Service.Implementation
{
    public class PersonServicesImplementation : IPersonServices
    {   
        private IRepository<Person> _repository;
        public PersonServicesImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<PersonDTO> FindAll()
        {

            return _repository.FindAll().Adapt<List<PersonDTO>>();
        }
        public PersonDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<PersonDTO>();
        }
        
        public PersonDTO Create(PersonDTO person)
        {
            var entity = person.Adapt<Person>();
            entity = _repository.Create(entity);
            return entity.Adapt<PersonDTO>();
        }
        
        public PersonDTO Update(PersonDTO person)
        {
            var entity = person.Adapt<Person>();
            entity = _repository.Update(entity);
            return entity.Adapt<PersonDTO>();
        }
        
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
