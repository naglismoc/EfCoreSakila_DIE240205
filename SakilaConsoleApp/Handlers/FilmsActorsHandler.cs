using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp.Handlers;

public class FilmsActorsHandler : RepositoriesControll
{
    private FilmRepository _filmRepository;
    private ActorRepository _actorRepository;
    public FilmsActorsHandler() : base()
    {
        init();
    }
    private async Task init()
    {
        _filmRepository = await filmsRepositoryInit();
        _actorRepository = await actorsRepositoryInit();
    }
    public async Task HandleAsync()
    {


        bool stayInFilmsActorsMenu = true;
        while (stayInFilmsActorsMenu)
        {

            Console.Out.WriteLine("Filmų ir aktoriu valdymo menu");
            printInfo();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    PrintFilms();
                    break;
                case "2":
                    PrintActors();
                    break;
                case "3":
                    PrintFilm();
                    break;
                case "4":
                    PrintActor();
                    break;
                case "5":
                    AddActor();
                    break;
                case "6":
                    await Console.Out.WriteLineAsync("5.Pašalinti aktorių iš filmo");
                    break;
                case "7":
                    stayInFilmsActorsMenu = false;
                    break;
                case "8":
                    Environment.Exit(1);
                    break;
            }

        }
    }
    public void printInfo()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. rodyti filmus");//
        Console.WriteLine("2. rodyti aktorius");//
        Console.WriteLine("3. Peržiūrėti filmą su aktoriais");//
        Console.WriteLine("4. Peržiūrėti aktorių ir jo filmus");
        Console.WriteLine("5 Pridėti filmui aktorius");//
        Console.WriteLine("6.Pašalinti aktorių iš filmo");//
        Console.WriteLine("7. grįžti atgal");//
        Console.WriteLine("8. Exit");//
        Console.WriteLine();
    }
    public async Task printInfoAsync()
    {
        await Console.Out.WriteLineAsync();
        await Console.Out.WriteLineAsync("1. rodyti filmus");//
        await Console.Out.WriteLineAsync("2. rodyti aktorius");//
        await Console.Out.WriteLineAsync("3. Peržiūrėti filmą su aktoriais");//
        await Console.Out.WriteLineAsync("4. Peržiūrėti aktorių ir jo filmus");
        await Console.Out.WriteLineAsync("5 Pridėti filmui aktorius");//
        await Console.Out.WriteLineAsync("6.Pašalinti aktorių iš filmo");//
        await Console.Out.WriteLineAsync("7. grįžti atgal");//
        await Console.Out.WriteLineAsync("8. Exit");//
        await Console.Out.WriteLineAsync();
    }
    public async Task RemoveActor()
    {
        await Console.Out.WriteLineAsync("iveskite filmo Id");
        long filmId = Convert.ToInt64(Console.ReadLine());
        await Console.Out.WriteLineAsync("iveskite autoriaus Id");
        long actorId = Convert.ToInt64(Console.ReadLine());
        _filmRepository.RemoveActor(filmId, actorId);
    }
    public async Task AddActor()
    {
        await Console.Out.WriteLineAsync("iveskite filmo Id");
        long filmId = Convert.ToInt64(Console.ReadLine());
        await Console.Out.WriteLineAsync("iveskite autoriaus Id");
        long actorId = Convert.ToInt64(Console.ReadLine());
        _filmRepository.AddActor(filmId, actorId);
    }
    public async Task PrintFilm()
    {
        await Console.Out.WriteLineAsync("iveskite filmo Id");
        long filmId = Convert.ToInt64(Console.ReadLine());
        Film film = await _filmRepository.ReadAsync(filmId);
        //Console.Out.WriteLine(films.Count);
        await Console.Out.WriteLineAsync(film.Title);
        foreach (var actor in film.Actors)
        {
            await Console.Out.WriteLineAsync("--" + actor.FirstName + " " + actor.LastName);

        }
    }
    public async Task PrintFilms()
    {
        List<Film> films = await _filmRepository.ReadAllAsync();
        Console.Out.WriteLine(films.Count);
        foreach (var film in films)
        {
            await Console.Out.WriteLineAsync(film.Title);

        }
    }
    public async Task PrintActors()
    {
        List<Actor> actors = await _actorRepository.ReadAllAsync();
        //Console.Out.WriteLine(films.Count);
        foreach (var actor in actors)
        {
            await Console.Out.WriteLineAsync(actor.FirstName + " " + actor.LastName);

        }
    }
    public async Task PrintActor()
    {
        await Console.Out.WriteLineAsync("iveskite aktoriaus Id");
        long actorId = Convert.ToInt64(Console.ReadLine());
        Actor actor = await _actorRepository.ReadAsync(actorId);
        //Console.Out.WriteLine(films.Count);
        await Console.Out.WriteLineAsync(actor.FirstName + " " + actor.LastName);
        foreach (var film in actor.Films)
        {
            await Console.Out.WriteLineAsync("--" + film.Title);

        }
    }
}
