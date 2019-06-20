using API.DTOs.AssetDTO;
using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.Assets
{
    public interface IAssetsService
    {
        Task<DocumentForCreationResponse> AddImage(DocumentForCreationResponse documentForCreationResponse ,int id);
        Task<DocumentForCreationResponse> AddVideoAsync(DocumentForCreationResponse documentForCreationResponse, int id);
        Task<UserAssetListDTO> GetUserAssetsAsync(int id);
        Task<List<AssetListDTO>> GetUserImagesAsync();
        Task<List<AssetListDTO>> GetUserDocumentAsync();
        Task<List<AssetListDTO>> GetUserVideoAsync();
        Task<Asset> GetAsset(int asset_id);
        Task DeleteAsset(int asset_id);
        Task<bool> SaveAll();
    }
}
