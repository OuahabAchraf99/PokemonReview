using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Dto;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(countries);
        }
        [HttpGet("{cntrId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountry(int cntrId)
        {
            if (!_countryRepository.CountryExists(cntrId))
                return NotFound();
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(cntrId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }
        [HttpGet("owner/{cntrId}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Owner>))]
        public IActionResult GetOwnerByCountryId(int cntrId)
        {
            if (!_countryRepository.CountryExists(cntrId))
                return NotFound();
            var owners= _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnerByCountryId(cntrId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);
        }
        [HttpGet("country/{ownerId}")]
        [ProducesResponseType(200,Type=typeof(Country))]
        public IActionResult CountryByOwnerId(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);

        }
    }
}
