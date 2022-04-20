using System;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 

            // 1. MULTIPLY

            float n1;
            float n2;

            Console.Write("Enter the first number: ");
            n1 = float.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            n2 = float.Parse(Console.ReadLine());

            float Product = n1 * n2;
            Console.WriteLine("The product of {0} and {1} is {2}", n1, n2, Product);
            Console.ReadLine();

            */

            /* 

            // 2. QUOTIENT & REMAINDER

            int n1;
            int n2;

            Console.Write("Enter the first number: ");
            n1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter the second number: ");
            n2 = Convert.ToInt16(Console.ReadLine());

            int Quotient = n1 / n2;
            int Remainder = n1 % n2;
            Console.WriteLine("The quotient of {0} and {1} is {2}, and the remainder is {3}", n1, n2, Quotient, Remainder);
            Console.ReadLine();

            */

            /* 

            // 3. SIMPLE INTEREST

            float p;
            float r;
            float t;

            Console.Write("Enter the prinicpal amount ($): ");
            p = float.Parse(Console.ReadLine());
            Console.Write("Enter the annual rate of interest (%): ");
            r = float.Parse(Console.ReadLine())/100;
            Console.Write("Enter the time period (years): ");
            t = float.Parse(Console.ReadLine());

            float TotalAccrued = p*(1 + (r*t));
            float Interest = TotalAccrued - p;
            Console.WriteLine("The amount of simple interest based on a principal amount of {0}, interest rate of {1}%, and time period of {2} years is {3}", p.ToString("C"), (r*100), t, Interest.ToString("C"));
            Console.ReadLine();

            */

            /* 

            // 4. AVERAGE OF 3 NUMBERS

            float n1;
            float n2;
            float n3;

            Console.Write("Enter the first number: ");
            n1 = float.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            n2 = float.Parse(Console.ReadLine());
            Console.Write("Enter the third number: ");
            n3 = float.Parse(Console.ReadLine());

            float Average = (n1 + n2 + n3) / 3;
            Console.WriteLine("The average of {0}, {1}, and {2} is {3}", n1, n2, n3, Average);
            Console.ReadLine();

            */

            /* 

            // 5. COUNT NUMBER OF WORDS IN A STRING

            Console.Write("Enter a string of words: ");
            string Text = Console.ReadLine();
            string[] Arr = Text.Split(" ");

            int Words = Arr.Length;
            Console.WriteLine("There are {0} words in the string '{1}'.", Words, Text);
            Console.ReadLine();

            */

        }
    }
}

