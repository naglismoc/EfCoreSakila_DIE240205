using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using SakilaConsoleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp
{
    public class ApplicationUI
    {
        private FilmsHandler _filmsHandler;
        public ApplicationUI()
        {
            init();
        }
        public async Task init()
        {
            _filmsHandler = new FilmsHandler();
        }
        public async Task RunAsync()
        {
            await Console.Out.WriteLineAsync("1. Filmai");
            await Console.Out.WriteLineAsync("2. Klientai");
            await Console.Out.WriteLineAsync("3. Parduotuvė");
            await Console.Out.WriteLineAsync("4. Exit");
            while (true)
            {
                await Console.Out.WriteLineAsync("Sakilos valdymo menu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        await _filmsHandler.HandleAsync();
                        break;
                    case "2":
                        //  await _customersHandler.HandleAsync();
                        break;
                    case "3":
                        // await _storesHandler.HandleAsync();
                        break;
                    case "4":

                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}
