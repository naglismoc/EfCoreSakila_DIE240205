using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Repositories
{
    public class FilmRepository
    {
        private readonly SakilaDbContext _context;
        public FilmRepository(SakilaDbContext context)
        {
            _context = context;
        }
        public async Task<List<Film>> ReadAllAsync()
        {
            return await _context.Films.Include(film => film.Actors).ToListAsync();
        }
        public async Task<Film> ReadAsync(long id)
        {
            return await _context.Films.Include(film => film.Actors).FirstOrDefaultAsync(f => f.Id == id);
        }
        public async Task AddActor(long filmId, long actorId)
        {
            (await ReadAsync(filmId))
                .Actors
                .Add((await _context.Actors.FirstOrDefaultAsync(a => a.Id == actorId)));
            _context.SaveChangesAsync();
        }
        public async Task RemoveActor(long filmId, long actorId)
        {
            (await ReadAsync(filmId))
                .Actors
                .Remove((await _context.Actors.FirstOrDefaultAsync(a => a.Id == actorId)));
            _context.SaveChangesAsync();
        }
    }
}
