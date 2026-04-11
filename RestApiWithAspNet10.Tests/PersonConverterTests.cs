using FluentAssertions;
using RestApiWithAspNet10.Data.Converter.Implementation;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;

namespace RestApiWithAspNet10.Tests
{
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }
        [Fact]
        // PersonDTO to Person conversion tests.
        public void Parse_ShouldConvertePersonDTOToPerson()
        {
            // Todo teste unitario segue esses passos:
            // 1. Arrange: Configura os dados de entrada e o resultado esperado.
            // 2. Act: Chama o método que está sendo testado.
            // 3. Assert: Verifica se o resultado obtido é igual ao resultado esperado.

            // Arrange.
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "Luka",
                LastName = "Cota",
                Address = "Valparadaise - Brazil",
                Gender = "Male",
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "Luka",
                LastName = "Cota",
                Address = "Valparadaise - Brazil",
                Gender = "Male"
            };

            // Act.
            var person = _converter.Parse(dto);

            // Assert.
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Should().BeEquivalentTo(expectedPerson);

        }
        [Fact]
        public void Parse_NullPersonDTOShouldReturnNull()
        {
            // Arrange.
            PersonDTO dto = null;
            // Act.
            var person = _converter.Parse(dto);
            // Assert.
            person.Should().BeNull();
        }
    }
}
