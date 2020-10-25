using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {

        public static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            HashSet<Person> personHashSet = new HashSet<Person>();
            SortedSet<Person> personSortedSet = new SortedSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] persArg = Console.ReadLine().Split();
                string name = persArg[0];
                int age = int.Parse(persArg[1]);

                Person p = new Person(name, age);
                personHashSet.Add(p);
                personSortedSet.Add(p);
            }

            Console.WriteLine(personHashSet.Count);
            Console.WriteLine(personSortedSet.Count);

            //string input = Console.ReadLine();
            //List<Person> people = new List<Person>();
            //while (input != "END")
            //{
            //    string[] command = input.Split();
                
            //    string name = command[0];
            //    int age = int.Parse(command[1]);
            //    string town = command[2];


            //    Person p = new Person(name, age, town);
            //    people.Add(p);

            //    input = Console.ReadLine();
            //}
            //int n = int.Parse(Console.ReadLine());
            //Person comparedPerson = people[n - 1];

            //int samePersonCount = 0;

            //foreach (Person person in people)
            //{
            //    if (person.CompareTo(comparedPerson) == 0)
            //    {
            //        samePersonCount++;
            //    }
                
            //}

            //if (samePersonCount == 1)
            //{
            //    Console.WriteLine("No matches");
            //}
            //else
            //{
            //    int notSamePersonCount = people.Count - samePersonCount;
            //    Console.WriteLine($"{samePersonCount} {notSamePersonCount} {people.Count}");
            //}
        }
    }
}
