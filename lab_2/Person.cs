using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab_2
{
    class Person: IEquatable<Person>
    {
        protected string name;
        protected int age;

        public string Name { get => name; }
        public int Age { get => age; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public bool Equals(Person other)
        {
            if (other == null) return false;

            if (name == other.name && age == other.age) 
                return true;
            else 
                return false;
        }

        public override string ToString() => $"name: {name}, age: {age}";
    }
}
