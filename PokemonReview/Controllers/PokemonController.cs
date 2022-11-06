using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Interfaces;
using PokemonReview.Models;
using PokemonReview.Repository;

namespace PokemonReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private  readonly IPokemonRepostory _pokemonRepository;

        public PokemonController(IPokemonRepostory pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200,Type=typeof(Pokemon))]
        public IActionResult GetPokemonById(int pokeId)
        {
            var pokemon= _pokemonRepository.GetPokemon(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }
        [HttpGet("{pokeName}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public IActionResult GetPokemonByName(string pokeName)
        {
            var pokemon = _pokemonRepository.GetPokemon(pokeName);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }
    }
}
