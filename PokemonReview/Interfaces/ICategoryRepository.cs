using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface ICategoryRepository
    {
        public ICollection<Category> GetCategories();
        public Category GetCategory(int id);
        public Category GetCategory(string name);
        public bool CategoryExists(int catId);
        public ICollection<Pokemon> GetPokemonByCategoryId(int catId);
    }
}
