using System;

namespace FirstApp
{
    public class Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        private int gauge;
        private int denominator;

        public Fraction()
        {
            this.gauge = 0;
            this.denominator = 1;
        }

        public Fraction(int gauage, int denominator)
        {
            this.gauge = gauage;
            this.denominator = denominator;
        }

        public Fraction(Fraction fraction)
        {
            gauge = fraction.gauge;
            denominator = fraction.denominator;
        }

        public int Gauge
        {
            get { return gauge; }
        }

        public int Denominator
        {
            get { return denominator; }
        }

        public static Fraction operator +(Fraction a) => a;

        public static Fraction operator -(Fraction a) => new(-a.gauge, a.denominator);

        public static Fraction operator +(Fraction a, Fraction b) =>
               new(a.gauge * b.denominator + b.gauge * a.denominator, a.denominator * b.denominator);

        public static Fraction operator *(Fraction a, Fraction b) =>
                new(a.gauge * b.gauge, a.denominator * b.denominator);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.gauge == 0)
            {
                throw new DivideByZeroException();
            }

            return new Fraction(a.gauge * b.denominator, a.denominator * b.gauge);
        }
        /// <summary>
        /// numeric representation of a fraction
        /// </summary>
        /// <returns>returns the numeric representation of a fraction</returns>
        /// <param name="precision">with what precision should the value return</param>
        /// <exception cref="ArgumentException">when value less than zero</exception>
        public double NumbericRepresentation(int precision = 1)
        {
            if(precision < 0) throw new ArgumentException("wrong argument");

            return Math.Round(((double)gauge / denominator), precision);
        }

        /// <summary>
        /// fraction rounded up or down
        /// </summary>
        /// <returns>returns the fraction rounded up or down</returns>
        /// <param name="value">1 - Returns the smallest integral value, 0 - returns the largest integer</param>
        /// <exception cref="ArgumentException">when value is different from 0 or 1</exception>
        public double RoundFraction(int value = 0)
        {
            if (value == 0)
                return Math.Ceiling(((double)gauge / denominator));
            else if (value == 1)
                return Math.Floor(((double)gauge / denominator));
            else
                throw new ArgumentException("wrong argument");
        }
        /// <summary>
        /// compares two fractions with each other
        /// </summary>
        /// <param name="otherFraction"></param>
        /// <returns>-1 || 0 || 1</returns>
        /// <exception cref="ArgumentException">when argument is not a fraction</exception>
        public int CompareTo(Fraction otherFraction)
        {
            if (otherFraction == null) return 1;

            if (otherFraction != null)
                return ((float)gauge / denominator).CompareTo((float)otherFraction.gauge / otherFraction.denominator);
            else
                throw new ArgumentException("Object is not a Fraction");
        }
        /// <summary>
        /// checks if fractions have the same values
        /// </summary>
        /// <param name="other">other fraction</param>
        /// <returns>return true when are the same, false when not</returns>
        public bool Equals(Fraction other)
        {
            if (other == null)
                return false;

            if (this.gauge == other.gauge && this.denominator == other.denominator)
                return true;
            else
                return false;
        }

        public override string ToString() => $"{gauge} / {denominator}";
    }
}