using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Repositories.Assets
{
    public interface IAssetsRepository
    {
        Task<User> GetUserAssetsAsync(int id);
        Task<List<Asset>> GetUserImagesAsync();
        Task<List<Asset>> GetUserVideosAsync();
        Task<List<Asset>> GetUserDocumentAsync();
        Task<bool> SaveAll();
        Task AddImage(Asset asset);
        Task<Asset> GetAsset(int asset_id);
        Task DeleteAsset(int asset_id);
    }
}
