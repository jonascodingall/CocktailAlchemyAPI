using CocktailAlchemyAPI.Dtos;
using Refit;

namespace CocktailAlchemyAPI.Clients
{
    public interface ICocktailClient
    {
        [Get("/search.php?s={search}")]
        Task<DrinksResponseDto> GetCocktailByName([AliasAs("search")] string search);

        [Get("/search.php?f={search}")]
        Task<DrinksResponseDto> GetCocktailByFirstLetter([AliasAs("search")] char search);
    }
}
