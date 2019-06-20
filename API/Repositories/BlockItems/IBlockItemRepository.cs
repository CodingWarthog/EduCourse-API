using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.BlockItems
{
    public interface IBlockItemRepository
    {
        Task<BlockItem> GetBlockItemAsync(int id);
        Task<List<BlockItem>> GetBlockItemsAsync();
        Task AddBlockItemAsync(BlockItem blockItem);
        Task DeleteBlockItemAsync(int blockItemId);
        Task<bool> FindBlockItemAsync(int blockItemId);
    }
}
