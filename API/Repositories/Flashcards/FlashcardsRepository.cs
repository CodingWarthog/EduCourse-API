using API.Models;
using API.Repositories.Flashcards;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace API.Repositories.Flashcards
{
    public class FlashcardsRepository : IFlashcardsRepository
    {
        private readonly educoursedbContext _context;

        public FlashcardsRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddFlashcardAsync(Flashcard flashcard)
        {
            _context.Flashcard.Add(flashcard);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlashcardAsync(int flashcard_id)
        {
            var flashcard = await _context.Flashcard.FindAsync(flashcard_id);

            _context.Flashcard.Remove(flashcard);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindFlashcardAsync(int flashcard_id)
        {
            if (await _context.Flashcard.FindAsync(flashcard_id) != null)
                return true;
            return false;
        }

        public async Task<FlashcardSet> GetFlashcardsListAsync(int id)
        {
            return await _context.FlashcardSet.Include(flash => flash.Flashcard).Where(flashcard => flashcard.Id == id).FirstOrDefaultAsync();
        }
    }
}
