using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.BlockItems
{
    public class BlockItemRepository : IBlockItemRepository
    {
        private readonly educoursedbContext _context;

        public BlockItemRepository(educoursedbContext context)
        {
           _context = context;
        }

        public async Task AddBlockItemAsync(BlockItem blockItem)
        {
            _context.BlockItem.Add(blockItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlockItemAsync(int blockItemId)
        {
            var block = await _context.BlockItem.FindAsync(blockItemId);
            _context.BlockItem.Remove(block);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindBlockItemAsync(int blockItemId)
        {
            if (await _context.BlockItem.FindAsync(blockItemId) != null)
                return true;
            return false;
        }

        public async Task<BlockItem> GetBlockItemAsync(int id)
        {
            return await _context.BlockItem.Where(block => block.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<BlockItem>> GetBlockItemsAsync()
        {
            return await _context.BlockItem.ToListAsync();
        }
    }
}
