using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_zadanie
{
    internal class Person: IThing
    {
        private string name;
        private int age;

        public string Name { get => name; }
        public int Age { get => age; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual void Print(string prefix = "\t")
        {
            Console.WriteLine($"{this.name} ({this.age} y.o.) {prefix}");
        }

    }
}
