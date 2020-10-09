using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {

        class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);
                var person = new Person(name, age);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());

            Func<Person, bool> predicate;

            if (condition == "older")
            {
                predicate = x => x.Age >= conditionAge;
            }
            else if (condition == "younger")
            {
                predicate = y => y.Age < conditionAge;
            }
            else
            {
                predicate = p => true;
            }

            var filteredPeople = people.Where(predicate);
            string format = Console.ReadLine();
            foreach (var item in filteredPeople)
            {
                if (format == "name age")
                {
                    Console.WriteLine($"{item.Name} - {item.Age}");
                }
                else if (format == "name")
                {
                    Console.WriteLine($"{item.Name}");
                }
                if (format == "age")
                {
                    Console.WriteLine($"{item.Age}");
                }
            }



        }


    }

}
