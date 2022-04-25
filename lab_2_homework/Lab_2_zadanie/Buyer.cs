using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_zadanie
{
    internal class Buyer: Person
    {
        protected List<Product> products = new();

        public Buyer(string name, int age): base(name, age)
        {
            this.products = new List<Product>(); 
        }

        public void AddProduct(Product product)
        {
            if (product == null) return;
            products.Add(product); 
        }

        public void RemoveProduct(int index)
        {
            if(index > this.products.Count - 1 || index < 0) return;

            products.RemoveAt(index);
        }

        public override void Print(string prefix = "\t")
        {
            Console.Write($"{prefix} Buyer: ");
            base.Print();

            if(products.Count > 0)
            {
                Console.WriteLine($"{prefix}{prefix}-- Products: --");

                foreach (Product product in products)
                {
                    Console.Write(prefix); 
                    product.Print();
                }
            }
        }
    }
}
