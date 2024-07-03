using System.Text.Json.Serialization;

namespace CocktailAlchemyAPI.Dtos
{
#nullable disable
    public class DrinksInputResponseDto
    {
        [JsonPropertyName("drinks")]
        public List<CoctailInputResponseDto> Drinks { get; set; }
    }
}
