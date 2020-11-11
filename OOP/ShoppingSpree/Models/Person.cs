using System;
using System.Collections.Generic;
using System.Text;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private const string NotEnoughMoneyExcMsg = "{0} can't afford {1}";
        private const string SuccBoughtProductMsg = "{0} bought {1}";
        
        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        private Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            Name = name;
            Money = money;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Common.GlobalConstatnts.EmptyNameExcMsg);
                }
                name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Common.GlobalConstatnts.NegativeMoneyMsg);
                }
                money = value;

            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return (IReadOnlyCollection<Product>)bag;
            }
        }

        public string BuyProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return string.Format(NotEnoughMoneyExcMsg, Name, product.Name);
            }

            Money -= product.Cost;
            bag.Add(product);
            return string.Format(SuccBoughtProductMsg, Name, product.Name);
        }

        public override string ToString()
        {
            string productsOutput = Bag.Count > 0 ? String.Join(", ", Bag) : "Nothing bought";
            return $"{Name} - {productsOutput}";
        }
    }

}
