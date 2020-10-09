using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }
        public void AddMember(Person person)
        {
            people.Add(person);
        }

        public Person GetOlderMember()
        {
            var person = people.OrderByDescending(x => x.Age).FirstOrDefault();

            return person;

        }
    }
}
