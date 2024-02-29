using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories;
public class ActorRepository
{
    private readonly SakilaDbContext _context;
    public ActorRepository(SakilaDbContext context)
    {
        _context = context;
    }
    public async Task<List<Actor>> ReadAllAsync()
    {
        return await _context.Actors.Include(actor => actor.Films).ToListAsync();
    }
    public async Task<Actor> ReadAsync(long id)
    {
        return await _context.Actors.Include(actor => actor.Films).FirstOrDefaultAsync(a => a.Id == id);
    }
}
