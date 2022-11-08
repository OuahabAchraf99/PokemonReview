using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface ICountryRepository
    {
        public ICollection<Country> GetCountries();
        public Country GetCountry(int cntrId);
        public Country GetCountry(string cntrName);
        public bool CountryExists(int cntrId);
        public ICollection<Owner> GetOwnerByCountryId(int cntrId);
        public Country GetCountryByOwner(int ownerId);
    }
}
