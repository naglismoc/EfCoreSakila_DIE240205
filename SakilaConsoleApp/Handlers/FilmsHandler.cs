using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp.Handlers
{
    public class FilmsHandler : RepositoriesControll
    {
        private FilmRepository _filmRepository;
        private FilmsActorsHandler _filmsActorsHandler;
        public FilmsHandler() : base()
        {
            init();

        }
        private async Task init()
        {
            _filmRepository = await filmsRepositoryInit();
            _filmsActorsHandler = new FilmsActorsHandler();

        }
        public async Task PrintFilms()
        {
            List<Film> films = await _filmRepository.ReadAllAsync();
            //Console.Out.WriteLine(films.Count);
            foreach (var film in films)
            {
                await Console.Out.WriteLineAsync(film.Title);

            }
        }
        public async Task HandleAsync()
        {
            await Console.Out.WriteLineAsync("Filmų valdymo menu");

            await Console.Out.WriteLineAsync("1. rodyti filmus");
            await Console.Out.WriteLineAsync("2. Peržiūrėti filmą");
            await Console.Out.WriteLineAsync("3 Pridėti filmui aktorius");
            await Console.Out.WriteLineAsync("4 Pridėti filmui kategorijas");
            await Console.Out.WriteLineAsync("5. Kurti filmą");
            await Console.Out.WriteLineAsync("6. Redaguoti filmą");
            await Console.Out.WriteLineAsync("7. trinti filmą");
            await Console.Out.WriteLineAsync("8. grįžti į pagrindinį menu");
            await Console.Out.WriteLineAsync("9. Exit");
            bool stayInFilmsMenu = true;
            while (stayInFilmsMenu)
            {
                await Console.Out.WriteLineAsync("Filmų valdymo menu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        PrintFilms();
                        break;
                    case "2":
                        break;
                    case "3":
                        await _filmsActorsHandler.HandleAsync();
                        break;

                    case "8":
                        stayInFilmsMenu = false;
                        break;
                    case "9":
                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}
