using System.Threading.Tasks;
using API.DTOs.AssetDTO;
using API.Helpers;
using API.Services.Assets;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace webapi.Controllers.Assets
{
    [AllowAnonymous]
    [Route("api/assets")]
    [ApiController]
    public class AssetsController : ControllerBase
    {

        private readonly IOptions<CloudinarySettings> _options;
        private readonly IAssetsService _service;
        private Cloudinary _cloudinary;

        public AssetsController(IMapper mapper,
            IOptions<CloudinarySettings> options, IAssetsService service)
        {

            _options = options;
            _service = service;

            Account acc = new Account(
               _options.Value.CloudName,
               _options.Value.ApiKey,
               _options.Value.ApiSecret
           );

            _cloudinary = new Cloudinary(acc);
        }
        [RequestSizeLimit(40000000)]
        [HttpPost("{id}")]
        public async Task<IActionResult> AddAsset([FromForm]DocumentForCreationResponse documentForCreationResponse, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = await _service.AddImage(documentForCreationResponse, id);
            return Ok(asset);
        }
        [RequestSizeLimit(40000000)]
        [HttpPost("videos/{id}")]
        public async Task<IActionResult> AddVideo([FromForm]DocumentForCreationResponse documentForCreationResponse, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = await _service.AddVideoAsync(documentForCreationResponse, id);

            return Ok(asset);
        }


        [HttpGet("documents/{id}")]
        public async Task<IActionResult> GetUserSharedDocument(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserAssetsAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("images")]
        public async Task<IActionResult> GetUserImages()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserImagesAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("document")]
        public async Task<IActionResult> GetUserDocument()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserDocumentAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("videos")]
        public async Task<IActionResult> GetUserVideos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserVideoAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("videos/{id}")]
        public async Task<IActionResult> GetUserVideos(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserAssetsAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var asset = await _service.GetAsset(id);

            if (asset.PublicId != null)
            {
                var deleteParams = new DeletionParams(asset.PublicId);
                var result = _cloudinary.Destroy(deleteParams);

 
                    await _service.DeleteAsset(id);
                
            }

            if (asset.PublicId == null)
            {
                await _service.DeleteAsset(id);
            }
            return Ok(asset);

        }
    }
}