using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp.Handlers
{
    public class ActorsHandler : RepositoriesControll
    {
        private ActorRepository _actorRepository;
        public ActorsHandler() : base()
        {
            init();
        }
        private async Task init()
        {
            _actorRepository = await actorsRepositoryInit();
        }
        public async Task HandleAsync()
        {
            await Console.Out.WriteLineAsync("Aktorių valdymo menu");
        }
    }
}
