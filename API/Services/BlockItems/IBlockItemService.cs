using API.DTOs.BlockItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.BlockItems
{
    public interface IBlockItemService
    {
        Task<BlockItemForListDTO> GetBlockItemAsync(int id);
        Task<List<BlockItemForListDTO>> GetBlockItemsAsync();
        Task<int> AddBlockItemAsync(BlockItemForAddDTO blockItemDTO);
        Task DeleteBlockItemAsync(int blockItemId);
        Task<bool> FindBlockItemAsync(int blockItemId);
    }
}
