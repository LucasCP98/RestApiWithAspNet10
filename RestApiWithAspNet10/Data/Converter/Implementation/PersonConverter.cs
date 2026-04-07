using RestApiWithAspNet10.Data.Converter.Contract;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;

namespace RestApiWithAspNet10.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonDTO, Person>, IParser<Person, PersonDTO>
    {
        public Person Parse(PersonDTO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address
            };
        }
        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public PersonDTO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonDTO
            {
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address
            };
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
