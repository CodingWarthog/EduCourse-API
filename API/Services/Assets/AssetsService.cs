using API.DTOs.AssetDTO;
using API.Helpers;
using API.Models;
using API.Repositories.Assets;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.Assets
{
    public class AssetsService : IAssetsService
    {
        private readonly IAssetsRepository _repository;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IMapper _mapper;
        private Cloudinary _cloudinary;

        public AssetsService(IAssetsRepository repository, IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper)
        {
            _repository = repository;
           _cloudinaryConfig = cloudinaryConfig;
           _mapper = mapper;

            Account acc = new Account(
             _cloudinaryConfig.Value.CloudName,
             _cloudinaryConfig.Value.ApiKey,
             _cloudinaryConfig.Value.ApiSecret
         );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<DocumentForCreationResponse> AddImage(DocumentForCreationResponse documentForCreationResponse, int id)
        {
            var file = documentForCreationResponse.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            documentForCreationResponse.Url = uploadResult.Uri.ToString();
            documentForCreationResponse.PublicId = uploadResult.PublicId;
            documentForCreationResponse.Name = documentForCreationResponse.File.FileName;
            documentForCreationResponse.Type = documentForCreationResponse.File.ContentType;
            documentForCreationResponse.UserId = id;

            var assetForReturn = documentForCreationResponse;
            Asset asset = new Asset()
            {
                Name = documentForCreationResponse.Name,
                Type = documentForCreationResponse.Type,
                Url = documentForCreationResponse.Url,
                PublicId = documentForCreationResponse.PublicId,
                UserId = documentForCreationResponse.UserId
            };

            await _repository.AddImage(asset);
            return assetForReturn;
        }

        public async Task<DocumentForCreationResponse> AddVideoAsync(DocumentForCreationResponse documentForCreationResponse, int id)
        {
            var file = documentForCreationResponse.File;
            var uploadResult = new VideoUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new VideoUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            documentForCreationResponse.Url = uploadResult.Uri.ToString();
            documentForCreationResponse.PublicId = uploadResult.PublicId;
            documentForCreationResponse.Name = documentForCreationResponse.File.FileName;
            documentForCreationResponse.Type = documentForCreationResponse.File.ContentType;
            documentForCreationResponse.UserId = id;

            var assetForReturn = documentForCreationResponse;
            Asset asset = new Asset()
            {
                Name = documentForCreationResponse.Name,
                Type = documentForCreationResponse.Type,
                Url = documentForCreationResponse.Url,
                PublicId = documentForCreationResponse.PublicId,
                UserId = documentForCreationResponse.UserId
            };

            await _repository.AddImage(asset);
            return assetForReturn;
        }

        public async Task DeleteAsset(int asset_id)
        {
            await _repository.DeleteAsset(asset_id);
        }

        public async Task<Asset> GetAsset(int asset_id)
        {
            return await _repository.GetAsset(asset_id);
        }

        public async Task<UserAssetListDTO> GetUserAssetsAsync(int id)
        {
            var assets = await _repository.GetUserAssetsAsync(id);
            return _mapper.Map<UserAssetListDTO>(assets);
        }

        public async Task<List<AssetListDTO>> GetUserDocumentAsync()
        {
            var assets = await _repository.GetUserDocumentAsync();
            return _mapper.Map<List<AssetListDTO>>(assets);
        }

        public async Task<List<AssetListDTO>> GetUserImagesAsync()
        {
            var assets = await _repository.GetUserImagesAsync();
            return _mapper.Map<List<AssetListDTO>>(assets);
        }

        public async Task<List<AssetListDTO>> GetUserVideoAsync()
        {
            var assets = await _repository.GetUserVideosAsync();
            return _mapper.Map<List<AssetListDTO>>(assets);
        }

        public async Task<bool> SaveAll()
        {
            return await _repository.SaveAll();
        }
    }
}
