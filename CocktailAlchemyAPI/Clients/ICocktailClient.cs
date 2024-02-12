using CocktailAlchemyAPI.Dtos;
using Refit;

namespace CocktailAlchemyAPI.Clients
{
    public interface ICocktailClient
    {
        [Get("/search.php?s={search}")]
        Task<DrinksInputResponseDto> GetCocktailByName([AliasAs("search")] string search);

        [Get("/search.php?f={search}")]
        Task<DrinksInputResponseDto> GetCocktailByFirstLetter([AliasAs("search")] char search);

        [Get("/filter.php?a=Alcoholic")]
        Task<DrinksInputResponseDto> GetAlcoholicDrinks();

        [Get("/filter.php?a=Non_Alcoholic")]
        Task<DrinksInputResponseDto> GetNonAlcoholicDrinks();
    }
}
