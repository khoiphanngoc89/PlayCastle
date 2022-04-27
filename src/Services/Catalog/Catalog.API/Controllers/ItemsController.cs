using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Entities;
using Catalog.API.Models;
using Common.SharedKernel.DatabaseProvider;
using Serilog;

namespace Catalog.API.Controllers
{
    // https://localhost:7242/api/items
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IRepository<Item> _repository;
        public ItemsController(IMapper mapper, IRepository<Item> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        // GET /items
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            return Ok(item);
        }

        // POST /items
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePlayCastleItemDto request)
        {
            var item = _mapper.Map<CreatePlayCastleItemDto, Item>(request);
            await _repository.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePlayCastleItemDto request)
        {
            var original = await _repository.GetByIdAsync(id);
            if(original == null)
            {
                return NotFound();
            }

            var updated = _mapper.Map<UpdatePlayCastleItemDto, Item>(request, original);
            await _repository.UpdateAsync(updated);

            return NoContent();
        }

        // DELETE /items
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}