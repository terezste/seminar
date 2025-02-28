using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static char Deciding2Options (string optionA, string optionB)
        {
            //Rozhodovani se mezi dvemi moznostmi a kontrola vstupu

            Console.WriteLine("\na) " + optionA);
            Console.WriteLine("b) " + optionB);

            while (true)
            {
                char decision = char.ToLower(Console.ReadKey().KeyChar);

                if (decision == 'a')
                {
                    return decision;
                }
                else if (decision == 'b')
                {
                    return decision;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Enter a, or b");
                    continue;
                }
            }
        }

        static char Deciding3Options(string optionA, string optionB, string optionC)
        {
            //Rozhodovani se mezi tremi moznostmi a kontrola vstupu

            Console.WriteLine("\na) " + optionA);
            Console.WriteLine("b) " + optionB);
            Console.WriteLine("c) " + optionC);

            while (true)
            {
                char decision = char.ToLower(Console.ReadKey().KeyChar);

                if (decision == 'a' || decision == 'b' || decision == 'c')
                {
                    return decision;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Enter a, b, or c");
                    continue;
                }
            }
        }

        static void WaitForInput()
        {
            if
            {
                
            }
            else
            {

            }
        }




        static void Main(string[] args)
        {

            string[] inventory;

            Console.WriteLine();

        }
    }
}
