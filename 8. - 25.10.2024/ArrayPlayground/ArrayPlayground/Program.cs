using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            
            int[] myArray = {10, 20, 30, 40, 50};

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.

            Console.WriteLine("Vypisovani for cyklem:");
            for (int i = 0; i < myArray.Length; i++)
            { 
                Console.WriteLine(myArray[i]);
            }

            Console.WriteLine("Vypisovani foreachem:");
            foreach (int num in myArray)
            {
                Console.WriteLine(num);
            }

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            
            int sum = 0;

            /*Console.WriteLine("Suma pomoci for cyklu:");
            for (int i = 0; i < myArray.Length; i++)
            {
                sum += myArray[i];
            }

            Console.WriteLine("Suma pomoci foreache:");
            foreach (int num in myArray)
            {
                sum += num;
            }

            Console.WriteLine("\nSuma pomoci funkce:");*/

            sum = myArray.Sum();

            Console.WriteLine("Suma: " + sum);


            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            double average = 0;

            //average = myArray.Sum() / myArray.Length;

            average = myArray.Average();

            Console.WriteLine("Average je: " + average);


            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = 0;

            max = myArray.Max();

            Console.WriteLine("Maximum je: " + max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min;


            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            /*int index;

            Console.Write("Napis cislo, co chces najit: ");
            int numToFind = int.Parse(Console.ReadLine());
            int foundNum = -1;

            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == numToFind)
                {
                    Console.WriteLine("Tvoje cislo je na indexu: " + i);
                    foundNum = i;
                    break;
                }
            }

            if (foundNum == -1)
            {
                Console.WriteLine("Tvoje cislo tu neni");
            }*/


            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.
            Random rng = new Random();

            myArray = new int [100];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rng.Next(0,10);
                Console.WriteLine(myArray[i]);
            }

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.


            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne

            Console.ReadKey();
        }
    }
}
