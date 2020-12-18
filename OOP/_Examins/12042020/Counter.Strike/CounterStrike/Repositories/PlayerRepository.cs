using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models
            => players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            players.Add(model);
        }

        public IPlayer FindByName(string name)
            => players.FirstOrDefault(x => x.Username == name);

        public bool Remove(IPlayer model)
            => players.Remove(model);
    }
}
