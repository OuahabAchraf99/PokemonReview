using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class PokemonRepository:IPokemonRepostory
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }
        public Pokemon GetPokemon(int pokeId)
        {
            return _context.Pokemons.Find(pokeId);
        }

        public Pokemon GetPokemon(string pokeName)
        {
            return _context.Pokemons.Where(p => p.Name == pokeName).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var reviews= _context.Reviews.Where(p => p.Pokemon.Id==pokeId);
            if (reviews.Count()<=0)
                    return 0;
            return (decimal)reviews.Average(p=>p.Rating);
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p=>p.Id==pokeId);
        }
    }
}
