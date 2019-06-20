using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.BlockItemDTO;
using API.Services.BlockItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BlockItems
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockItemsController : ControllerBase
    {
        private readonly IBlockItemService _service;

        public BlockItemsController(IBlockItemService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlockItemAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetBlockItemAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBlockItemsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetBlockItemsAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddBlockItemAsync([FromBody]BlockItemForAddDTO blockItemForAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddBlockItemAsync(blockItemForAddDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlockItemAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _service.FindBlockItemAsync(id);
            if (course == false)
            {
                return NotFound();
            }

            await _service.DeleteBlockItemAsync(id);

            return Ok(course);
        }
    }
}