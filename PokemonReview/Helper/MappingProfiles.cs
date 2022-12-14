using AutoMapper;
using AutoMapper.Configuration;
using PokemonReview.Dto;
using PokemonReview.Models;

namespace PokemonReview.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
        }
    }
}
