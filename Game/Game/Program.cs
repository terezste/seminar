using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        //tvorim si list inventory/inventar
        static List<string> inventory = new List<string>();

        static char Deciding2Options (string optionA, string optionB)
        {
            //Rozhodovani se mezi dvemi moznostmi a kontrola vstupu

            Console.WriteLine("\n   a) " + optionA);
            Console.WriteLine("   b) " + optionB);

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

            Console.WriteLine("\n   a) " + optionA);
            Console.WriteLine("   b) " + optionB);
            Console.WriteLine("   c) " + optionC);

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
            //prostor po dialogu odkliknout a jit dal nebo otevrit voditko nebo inventar
            while (true)
            {
                Console.WriteLine();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                //tady jsem si pomohla: https://chatgpt.com/share/67c1b454-02e8-8012-91b2-9a4b40b65eb8

                if (keyInfo.Key == ConsoleKey.G)
                {
                    PrintGuide();
                }
                else if (keyInfo.Key == ConsoleKey.I)
                {
                    PrintInventory();
                }
                else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatný vstup. Stisknutím 'g' otevřeš vodítko");
                }
            }
        }

        static void PrintGuide()
        {
            Console.WriteLine("zmáčkni Enter nebo mezerník pro pokračování dále\nzmáčkni 'a', 'b', 'c' pro výběr možnosti\nzmáčkni 'i' pro otevření inventáře\nzmáčkni 'g' pro otevření vodítka");
        }

        static void PrintInventory()
        {
            //vypise vse, co je v inventari

            if (inventory.Count == 0)
            {
                Console.WriteLine("Nic tu není.");
            }
            else
            {
                foreach (string i in inventory)
                {
                    Console.WriteLine(i);
                }
            }
        }



        static void Main(string[] args)
        {

            /*PrintGuide();

            PrintInventory();

            Deciding2Options("dbajhb", "bdauib");

            WaitForInput();*/

        }
    }
}
