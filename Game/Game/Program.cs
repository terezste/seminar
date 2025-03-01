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
            //rozhodovani se mezi dvemi moznostmi a kontrola vstupu

            Console.WriteLine("   a) " + optionA);
            Console.WriteLine("   b) " + optionB + "\n");

            while (true)
            {
                char decision = char.ToLower(Console.ReadKey(true).KeyChar);

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
                    Console.WriteLine("\nNeplatný vstup. Stiskni a, nebo b");
                    continue;
                }
            }
        }

        static char Deciding3Options(string optionA, string optionB, string optionC)
        {
            //rozhodovani se mezi tremi moznostmi a kontrola vstupu

            Console.WriteLine("   a) " + optionA);
            Console.WriteLine("   b) " + optionB);
            Console.WriteLine("   c) " + optionC + "\n");

            while (true)
            {
                char decision = char.ToLower(Console.ReadKey(true).KeyChar);

                if (decision == 'a' || decision == 'b' || decision == 'c')
                {
                    return decision;
                }
                else
                {
                    Console.WriteLine("\nNeplatný vstup. Stiskni a, b, nebo c");
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
                    Console.WriteLine("Neplatný vstup. Stisknutím tlačítka 'g' otevřeš vodítko.");
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

            Console.WriteLine("---INVENTÁŘ---");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Je tu prázdno.");
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

            PrintGuide();
            WaitForInput();

            Console.WriteLine("Je ráno. Tvoje boty se boří do mokré trávy a ve vzduchu visí těžká mlha, která pohlcuje obzor a tlumí všechny zvuky. Jsi znavený z dlouhé cesty a tak ti udělá radost, když konečně spatříš město.");
            WaitForInput();
            Console.WriteLine("Vidíš před sebou kammenné hradby a bránu uprostřed.\nRozhodneš se vstoupit dovnitř. Brána města je otevřená, ale ty nevidíš žádné stráže.");
            WaitForInput();
            Console.WriteLine("Procházíš spletitými ulicemi města. Všude je ticho a ty nevidíš ani živáčka.\nProplétáš se dál bludištěm až nakonec dorazíš na náměstí.");
            WaitForInput();
            Console.WriteLine("Zastavíš se a před tebou stojí žena.\n„Čekala jsem tě,“ promluví jemným hlasem. „Vypadáš znaveně, poutníku, v mém hostinci je ale vždy místo pro unavené nohy a prázdný žaludek. Tudy, pojď se mnou“\nNemáš důvod odmítat. Jdeš s ní.");
            WaitForInput();
            Console.WriteLine("Následuješ ženu dál a tvá mysl se víří otázkami.");
            WaitForInput();
            char choice = Deciding3Options("„Jak dlouho tu vlastně žijete?“", "„Máte tu často poutníky jako jsem já?“", "„Proč je město tak prázdné?“");
            if (choice == 'a')
            {
                Console.WriteLine("„Jak dlouho tu vlastně žijete?“\n\n„Odjakživa. Jestli si pamatuju správně.“");
            }
            else if (choice == 'b')
            {
                Console.WriteLine("„Máte tu často poutníky jako jsem já?“\n\n„Ano, někteří přijdou. Ale většinou tu dlouho nezůstanou.“");
            }
            else
            {
                Console.WriteLine("„Proč je město tak prázdné?“\n\n„Prázdné? To bych zrovna neřekla.“");
            }
            WaitForInput();
            Console.WriteLine("Než stačíš nějak zareagovat, žena se zastaví a otočí se k tobě:\n„Tady to je.“");
            WaitForInput();
            Console.WriteLine("Když se rozhlédneš, zjistíš, že před tebou nestojí hostinec, jak bys čekal. Je to obyčejný dům. Žena ti pokyne, ať vejdeš první.");
            WaitForInput();
            choice = Deciding2Options("Poslechnout ji a vejít.", "Nevcházet a raději zůstat venku.");
            if (choice == 'a')
            {
                Console.WriteLine("Poslechnout ji a vejít.\n\nPřekročíš prah a vejdeš dovnitř.");
                char storyLine = '1';
            }
            else
            {
                Console.WriteLine("Nevcházet a raději zůstat venku\n\n„Víte, já radši pobudu venku.“\nŽena vypadá podiveně.\n„Ale vždyť za chvíli bude tma.“");
                WaitForInput();
                choice = Deciding2Options("Nechat se přemluvit a vejít dovnitř.","Stát si za svým rozhodnutím.");
                if (choice == 'a')
                {
                    Console.WriteLine("Nechat se přemluvit a vejít dovnitř.\n\nZdráhavě překročíš prah a vejdeš dovnitř.");
                    char storyLine = '1';
                }
                else
                {
                    Console.WriteLine("Stát si za svým rozhodnutím.\n\nŽena pochopí, že ses už rozhodl a nic to nezmění.\n„Dobře, až se ale budeš chtít vrátit, dveře jsou otevřené.“");
                    char storyLine = '2';
                }
            }

            WaitForInput();
            //if charstoryLine
        }
    }
}
