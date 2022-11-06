using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IPokemonRepostory
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        int GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
    }
}
