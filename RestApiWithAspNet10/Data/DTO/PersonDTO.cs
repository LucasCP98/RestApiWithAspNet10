using RestApiWithAspNet10.JsonSerializers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiWithAspNet10.Data.DTO
{
    [Table("person")]
    public class PersonDTO
    {
        public long Id { get; set; }
        
        // Custom serialização" se aplica quando você precisa mudar alguma coisa no json retornando,
        // por exemplo, a propriedade "FirstName" vai ser serializada como "first_name" no json retornado.
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        // Ignorar a propriedade "LastName" no json retornado.
        // ou podemos usar o [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // para ignorar somente quando for null, existe outras condições também.
        [JsonIgnore]
        public string LastName { get; set; }
        
        // ordenar ex address sera o 5 lugar.
        [JsonPropertyOrder(5)]
        public string Address { get; set; }

        // No gender criamos um custom serializer para retornar "M" ou "F" no json,
        // mas internamente na nossa aplicação continuamos usando "Male" e "Female".
        [JsonConverter(typeof(GenderSerializer))]
        public string Gender { get; set; }
    }
}