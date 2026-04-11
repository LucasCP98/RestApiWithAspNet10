using RestApiWithAspNet10.Data.DTO;

namespace RestApiWithAspNet10.Service
{
    public interface IPersonServices
    {
        PersonDTO Create(PersonDTO person);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO person);
        void Delete(long id);

    }
}
