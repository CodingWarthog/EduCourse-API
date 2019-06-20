using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Repositories.Flashcards
{
    public class FlashcardSetsRepository : IFlashcardSetsRepository
    {
        private readonly educoursedbContext _context;

        public FlashcardSetsRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddFlashcardSetAsync(FlashcardSet flashcardSet)
        {
            _context.FlashcardSet.Add(flashcardSet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlashcardSet(int flashcardSet_id)
        {
            var flashcardSet = await _context.FlashcardSet.FindAsync(flashcardSet_id);

            _context.FlashcardSet.Remove(flashcardSet);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindFlashcardSet(int flashcardSet_id)
        {
            if (await _context.FlashcardSet.FindAsync(flashcardSet_id) != null)
                return true;
            return false;
        }

        public async Task<List<FlashcardSet>> GetAllFlashCardSetAsync()
        {
            return await _context.FlashcardSet.ToListAsync();
        }

        public async Task<User> GetUserFlashcardSetAsync(int id)
        {
            return await _context.User.Include(user => user.FlashcardSet).Where(user => user.Id == id).FirstOrDefaultAsync();
        }
    }
}
