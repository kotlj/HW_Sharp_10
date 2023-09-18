using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sharp_10
{
    struct Fraction
    {
        int num;
        int den;
        void stabilaze()
        {
            if (den == 0)
            {
                den = 1;
            }
            if (num >= den)
            {
                num -= den;
            }
        }
        static int gcd(int f, int s)
        {
            int min = 0;
            int max = 0;
            if (f > s)
            {
                max = f;
                min = s;
            }
            else
            {
                max = s;
                min = f;
            }
            while(min != 0)
            {
                int temp = min;
                min = max % min;
                max = temp;
            }
            return max;
        }
        static int lcm(int f, int s)
        {
            return (f / gcd(f, s)) * s;
        }

        
        public Fraction(int _num, int _den = 1, int _common = 0)
        {
            this.num = _num;
            this.den = (_den == 0 ? 1 : _den);
        }
        public static Fraction operator+(Fraction a, Fraction b)
        {
            Fraction temp = new Fraction();
            temp.den = lcm(a.den, b.den);
            temp.num = (a.num * (lcm(a.den, b.den) / a.den) + b.num * (lcm(a.den, b.den) / b.den));
            return temp;
        }
        public static Fraction operator-(Fraction a, Fraction b)
        {
            Fraction _b = b;
            _b.num *= -1;
            return a + _b;
        }
        public static Fraction operator*(Fraction a, Fraction b)
        {
            Fraction temp = new Fraction();
            temp.num = a.num * b.num;
            temp.den = a.den * b.den;
            return temp;
        }
        public static Fraction operator/(Fraction a, Fraction b)
        {
            Fraction _b = new Fraction(b.den, b.num);
            return a * _b;
        }
        public override string ToString()
        {
            return "Num: " + num + "\nDen: " + den;
        }
    }
    struct Complex
    {
        private int _real;
        private int _imaginary;

        public int Real
        {
            get
            {
                return _real;
            }
            set
            {
                _real = value;
            }
        }
        public int Imaginary
        {
            get
            {
                return _imaginary;
            }
            set
            {
                _imaginary = value;
            }
        }
        
        public Complex(int  real, int imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }

        static public Complex operator+(Complex a, Complex b)
        {
            Complex temp = new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
            return temp;
        }
        static public Complex operator-(Complex a, Complex b)
        {
            Complex temp = new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
            return temp;
        }
        static public Complex operator*(Complex a, Complex b)
        {
            Complex temp = new Complex(a.Real *  b.Real - a.Imaginary * b.Imaginary, a.Imaginary * b.Real + a.Real * b.Imaginary);
            return temp;
        }
        static public Complex operator/(Complex a, Complex b)
        {
            Complex temp = new Complex((int)((a.Real * b.Real + a.Imaginary * b.Imaginary) /
                (Math.Pow(b.Real, 2) + Math.Pow(b.Imaginary, 2))),
                (int)((a.Imaginary * b.Real - a.Real * b.Imaginary) / Math.Pow(b.Real, 2) + Math.Pow(b.Imaginary, 2)));
            return temp;
        }
        public override string ToString()
        { 
            return _real.ToString() + " + " + _imaginary.ToString() + "i";
        }
    }
    struct BirthDate
    {
        public DateTime birth;

        public DateTime Birth
        {
            get
            {
                return birth;
            }
            set
            {
                birth = value;
            }
        }

        public BirthDate(int year, int month, int day)
        {
            birth = new DateTime(year, month, day);
        }

        public void DayOfWeek()
        {
            Console.WriteLine(birth.DayOfWeek);
        }
        public void DayOfWeek(int _year)
        {
            DateTime temp = new DateTime(_year, birth.Month, birth.Day);
            Console.WriteLine(temp.DayOfWeek);
        }
        public float DaysSpan(int _year, int _month, int _day)
        {
            DateTime now = new DateTime(_year, _month, _day);
            DateTime temp = new DateTime(_year, birth.Month, birth.Day);
            if (now > temp)
            {
                temp.AddYears(1);
            }
            TimeSpan ts = temp.Subtract(birth);
            return (float)ts.TotalDays;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BirthDate date = new BirthDate(2023, 1, 1);
            date.DayOfWeek();
            Console.WriteLine(date.DaysSpan(2024, 1, 1));
        }
    }
}
