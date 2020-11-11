using ShoppingSpree.Models;
using ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;
        public Engine()
        {
            people = new List<Person>();
            products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                ParsePeopleInput();
                ParseProductsInput();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commLine = command.Split();
                    string personName = commLine[0];
                    string productName = commLine[1];

                    Person person = people.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);
                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void ParsePeopleInput()
        {
            string[] personsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var data in personsData)
            {
                string[] item = data.Split('=');
                string personName = item[0];
                decimal personMoney = decimal.Parse(item[1]);

                Person person = new Person(personName, personMoney);
                people.Add(person);
            }
        }

        private void ParseProductsInput()
        {
            string[] productsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var data in productsData)
            {
                string[] item = data.Split('=');
                string productsName = item[0];
                decimal productsCost = decimal.Parse(item[1]);

                Product product = new Product(productsName, productsCost);
                products.Add(product);
            }
        }
    }
}












