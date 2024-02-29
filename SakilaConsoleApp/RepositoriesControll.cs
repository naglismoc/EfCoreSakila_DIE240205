using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using SakilaConsoleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp;

public class RepositoriesControll
{


    private readonly SakilaDbContext _context;
    public RepositoriesControll()
    {
        SakilaDbContextFactory dbcf = new SakilaDbContextFactory();
        _context = dbcf.CreateDbContext([]);


    }
    public async Task<FilmRepository> filmsRepositoryInit()
    {
        return new FilmRepository(_context);
    }
    public async Task<ActorRepository> actorsRepositoryInit()
    {
        return new ActorRepository(_context);
    }
}
