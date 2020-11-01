using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return firstTeam.AsReadOnly();
            }
        }
        public IReadOnlyCollection<Person> ReserveTeam 
        {
            get
            {
                return reserveTeam.AsReadOnly();
            } 
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder bb = new StringBuilder();
            bb.AppendLine($"First team has {firstTeam.Count} players.");
            bb.AppendLine($"Reserve team has {reserveTeam.Count} players.");

            return bb.ToString().TrimEnd();
        }
    }
}
