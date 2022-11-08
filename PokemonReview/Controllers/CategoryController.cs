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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);
        }
        [HttpGet("{catId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetCategory(int catId)
        {
            if (!_categoryRepository.CategoryExists(catId))
                return NotFound();
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(catId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }
        [HttpGet("pokemon/{catId}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemonByCategoryId(int catId)
        {
            if (!_categoryRepository.CategoryExists(catId))
                return NotFound();
            var pokemons= _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategoryId(catId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
        }
    }
}
