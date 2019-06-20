using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Repositories.Assets
{
    public class AssetsRepository : IAssetsRepository
    {
        private readonly educoursedbContext _context ;

        public AssetsRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddImage(Asset asset)
        {
            _context.Asset.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsset(int asset_id)
        {
            var asset = await _context.Asset.FindAsync(asset_id);

            _context.Asset.Remove(asset);
            await _context.SaveChangesAsync();
        }

        public async Task<Asset> GetAsset(int asset_id)
        {
            var asset = await _context.Asset.IgnoreQueryFilters()
                    .FirstOrDefaultAsync(p => p.Id == asset_id);

            return asset;
        }

        public async Task<User> GetUserAssetsAsync(int id)
        {
            return await _context.User.Include(user => user.Asset).Where(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Asset>> GetUserDocumentAsync()
        {
            return await _context.Asset.Where(user => user.Type.Contains("application")).ToListAsync();
        }

        public async Task<List<Asset>> GetUserImagesAsync()
        {
            return await _context.Asset.Where(user => user.Type.Contains("image")).ToListAsync();
        }

        public async Task<List<Asset>> GetUserVideosAsync()
        {
            return await _context.Asset.Where(user => user.Type.Contains("video")).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

     
    }
}
