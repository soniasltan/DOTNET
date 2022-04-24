using System;

namespace SquarefeetOfHouse
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the length of the house: ");
            int Length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the width of the house: ");
            int Width = Convert.ToInt32(Console.ReadLine());

            int SquareFt = Length * Width;

            Console.WriteLine("The house is {0} square feet.", SquareFt);

            Console.ReadKey();
        }
    }
}

