using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.BlockItemDTO;
using API.Models;
using API.Repositories.BlockItems;
using AutoMapper;

namespace API.Services.BlockItems
{
    public class BlockItemService : IBlockItemService
    {
        private readonly IBlockItemRepository _repository;
        private readonly IMapper _mapper;

        public BlockItemService(IBlockItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddBlockItemAsync(BlockItemForAddDTO blockItemDTO)
        {
            var block = _mapper.Map<BlockItem>(blockItemDTO);
            await _repository.AddBlockItemAsync(block);
            return block.Id;
        }

        public async Task DeleteBlockItemAsync(int blockItemId)
        {
            await _repository.DeleteBlockItemAsync(blockItemId);
        }

        public async Task<bool> FindBlockItemAsync(int blockItemId)
        {
            if (await _repository.FindBlockItemAsync(blockItemId) != false)
                return true;
            return false;
        }

        public async Task<BlockItemForListDTO> GetBlockItemAsync(int id)
        {
            var block = await _repository.GetBlockItemAsync(id);
            return _mapper.Map<BlockItemForListDTO>(block);
        }

        public async Task<List<BlockItemForListDTO>> GetBlockItemsAsync()
        {
            var block = await _repository.GetBlockItemsAsync();
            return _mapper.Map<List<BlockItemForListDTO>>(block);
        }
    }
}
