using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
            //IsAlive = isAlive;
        }

        public string Username 
        {
            get
            {
                return username;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                name = value;
            }
        }
        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                health = value;
            }
        }
        public int Armor 
        {
            get
            {
                return armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                armor = value;
            }
        }
        public IGun Gun
        {
            get
            {
                return gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                gun = value;
            }
        }
        public bool IsAlive => Health > 0;

        public void TakeDamage(int points)
        {
            if (Armor >= points)
            {
                Armor -= points;
                return;
            }
            else
            {
                points -= Armor;
                Armor = 0;
            }

            if (Health >= points)
            {
                Health -= points;
                return;
            }
            else
            {
                Health = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder dd = new StringBuilder();

            dd.AppendLine($"{this.GetType().Name}: {Username}");
            dd.AppendLine($"--Health: {Health}");
            dd.AppendLine($"--Armor: {Armor}");
            dd.AppendLine($"--Gun: {Gun.Name}");

            return dd.ToString().TrimEnd();
        }
    }
}
