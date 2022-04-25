using System;
using System.Collections.Generic;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fracion1 = new Fraction(1, 2);
            var fracion2 = new Fraction(1, 3);
            Console.WriteLine(fracion1.CompareTo(fracion2));
        }
    }
}
