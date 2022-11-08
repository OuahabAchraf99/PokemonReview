using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int catId)
        {
            return _context.Categories.Find(catId);
        }

        public Category GetCategory(string name)
        {
            return _context.Categories.Where(c => c.Name == name).FirstOrDefault();
        }
        public bool CategoryExists(int catId)
        {
            return _context.Categories.Any(c => c.Id == catId);
        }
        public ICollection<Pokemon> GetPokemonByCategoryId(int catId)
        {
            return _context.PokemonCategories.Where(p => p.CategoryId == catId).Select(c=>c.Pokemon).ToList();
        }
    }
}
