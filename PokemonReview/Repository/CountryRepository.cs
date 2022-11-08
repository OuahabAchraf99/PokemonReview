using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountry(int cntrId)
        {
            return _context.Countries.Find(cntrId);
        }

        public Country GetCountry(string cntrName)
        {
            return _context.Countries.Where(c => c.Name == cntrName).FirstOrDefault();
        }
        public bool CountryExists(int cntrName)
        {
            return _context.Countries.Any(c => c.Id == cntrName);
        }
        public ICollection<Owner> GetOwnerByCountryId(int cntrId)
        {
            return _context.Owners.Where(p => p.Country.Id == cntrId).ToList();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }
    }
}
