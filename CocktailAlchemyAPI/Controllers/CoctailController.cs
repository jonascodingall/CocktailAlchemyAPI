using AutoMapper;
using CocktailAlchemyAPI.Clients;
using CocktailAlchemyAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailAlchemyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoctailController : ControllerBase
    {
        private readonly ICocktailClient _cocktailClient;
        private readonly IMapper _mapper;

        public CoctailController(ICocktailClient cocktailClient, IMapper mapper)
        {
            _cocktailClient = cocktailClient;
            _mapper = mapper;
        }

        [HttpGet("GetCocktailByName/{search}")]
        public async Task<ActionResult<IEnumerable<CoctailResponseDto>>> GetCocktailByName(string search)
        {
            var drinks = await _cocktailClient.GetCocktailByName(search);
            var response = _mapper.Map<List<CoctailResponseDto>>(drinks.Drinks);
            return drinks.Drinks == null ? NotFound() : Ok(response);
        }

        [HttpGet("GetCocktailByFirstLetter/{search}")]
        public async Task<ActionResult<IEnumerable<CoctailResponseDto>>> GetCocktailByFirstLetter(char search)
        {
            var drinks = await _cocktailClient.GetCocktailByFirstLetter(search);
            var response = _mapper.Map<List<CoctailResponseDto>>(drinks.Drinks);
            return drinks.Drinks == null ? NotFound() : Ok(response);
        }
    }
}
