using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_zadanie
{
    internal class Shop : IThing
    {
        private string name;

        private Person[] people;

        private Product[] products;

        public string Name { get => name; }

        public Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;   
            this.people = people;   
            this.products = products;
        }

        public void Print()
        {
            Console.WriteLine($"Shop: {this.name}");

            Console.WriteLine("-- People: --");

            foreach (var people in people)
            {
                people.Print("\t");
            }

            Console.WriteLine("-- Products: --");

            foreach (var product in products)
            {
                product.Print();
            }
        }
    }
}
