using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryGame
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
            Console.WriteLine("\u001b[1m---VODÍTKO---\u001b[0m\nzmáčkni Enter nebo mezerník pro pokračování dále\nzmáčkni 'a', 'b', 'c' pro výběr možnosti\nzmáčkni 'i' pro otevření inventáře\nzmáčkni 'g' pro otevření vodítka");
        }

        static void PrintInventory()
        {
            //vypise vse, co je v inventari

            Console.WriteLine("\u001b[1m---INVENTÁŘ---\u001b[0m");
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
        static string Battle(Player player, Enemy enemy)
        {
            while (!player.IsDead() && !enemy.IsDead())
            {
                WaitForInput();
                char choice = Deciding2Options("Utéct.", "Bojovat.");
                if (choice == 'a')
                {
                    return "escape";
                }
                else
                {
                    //utok hrace
                    enemy.Hurt(player.GetDamage());

                    if (!enemy.IsDead())
                    {
                        //utok nepritele
                        player.Hurt(enemy.GetDamage());

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Máš " + player.GetHealth() + " zdraví.");
                        Console.WriteLine("Nepřítel má " + enemy.GetHealth() + " zdraví.");
                    }
                }
            }
            if (player.IsDead())
            {
                return "lost";
            }
            else
            {
                return "won";
            }
        }

        static void Main(string[] args)
        {
            //poznamka: pri psani textu jsem si pomahala chatgpt, ale to snad nevadi, jelikoz kod jsem delala sama :)

            while (true)
            {

                char choice; //pomocna promenna, kterou si zaznamenam jednotlive vybery hrace

                Player player = new Player(50, 5);

                PrintGuide();
                WaitForInput();

                Console.WriteLine("Je ráno. Tvoje boty se boří do mokré trávy a ve vzduchu visí těžká mlha, která pohlcuje obzor a tlumí všechny zvuky. Jsi znavený z dlouhé cesty a tak ti udělá radost, když konečně spatříš město.");
                WaitForInput();
                Console.WriteLine("Vidíš před sebou kammenné hradby a bránu uprostřed.\nRozhodneš se vstoupit dovnitř. Brána města je otevřená, ale ty nevidíš žádné stráže.");
                WaitForInput();
                Console.WriteLine("Procházíš spletitými ulicemi města. Všude je ticho a ty nevidíš ani živáčka.\nProplétáš se dál bludištěm až nakonec dorazíš na náměstí.");
                WaitForInput();
                Console.WriteLine("Zastavíš se a před tebou stojí žena.\n„Čekala jsem vás,“ promluví jemným hlasem. „Vypadáte znaveně, poutníku, v mém hostinci je ale vždy místo pro unavené nohy a prázdný žaludek. Tudy, pojďte se mnou“\nNemáš důvod odmítat. Jdeš s ní.");
                WaitForInput();
                Console.WriteLine("Následuješ ženu dál a tvá mysl se víří otázkami.");
                WaitForInput();
                choice = Deciding3Options("„Jak dlouho tu vlastně žijete?“", "„Máte tu často poutníky jako jsem já?“", "„Proč je město tak prázdné?“");
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
                Console.WriteLine("Když se rozhlédneš, zjistíš, že hostinec před tebou vypadá skoro jako obyčejný dům.\nŽena ti pokyne, ať vejdeš první.");
                WaitForInput();
                choice = Deciding2Options("Poslechnout ji a vejít.", "Nevcházet a raději zůstat venku.");
                if (choice == 'a')
                {
                    Console.WriteLine("Poslechnout ji a vejít.\n\nPřekročíš prah a vejdeš dovnitř.");
                }
                else
                {
                    Console.WriteLine("Nevcházet a raději zůstat venku\n\n„Víte, já radši pobudu venku.“\nŽena vypadá podiveně.\n„Ale vždyť za chvíli bude tma.“");
                    WaitForInput();
                    choice = Deciding2Options("Nechat se přemluvit a vejít dovnitř.", "Stát si za svým rozhodnutím.");
                    if (choice == 'a')
                    {
                        Console.WriteLine("Nechat se přemluvit a vejít dovnitř.\n\nZdráhavě překročíš prah a vejdeš dovnitř.");
                    }
                    else
                    {
                        Console.WriteLine("Stát si za svým rozhodnutím.\n\nŽena pochopí, že ses už rozhodl a nic to nezmění.\n„Dobře, až se ale budete chtít vrátit, dveře jsou otevřené.“");
                    }
                }

                WaitForInput();
                if (choice == 'a') //hrac je v hostinci
                {
                    Console.WriteLine("Na chvíli se v místnosti zastavíš a rozhlédneš se. Prázdno a šero. Vidíš pár stolů a židlí, ale jinak nic.");
                }
                else //hrac jde ven
                {
                    Console.WriteLine("Otočíš se k odchodu a pokračuješ dál ulicí. Stále ale cítíš, jak tě žena za tebou pozoruje.");
                    WaitForInput();
                    Console.WriteLine("Kudy teď?");
                    WaitForInput();
                    choice = Deciding3Options("Jít doleva ke zvonici.", "Jít rovně, na náměstí.", "Jít doprava ke kostelu.");
                    if (choice == 'a')
                    {
                        Console.WriteLine("Jít doleva ke zvonici.\n\nZvonice ční nad střechami okolních domů. Její zvon je ztichlý a rezavý, ale i z dálky vidíš, že se slabě houpe.");
                    }
                    else if (choice == 'b')
                    {
                        Console.WriteLine("Jít rovně, na náměstí.\n\nNáměstí je kruhové, vydlážděné nerovnými kameny. Uprostřed stojí kašna, ale voda z ní neteče.");
                    }
                    else
                    {
                        Console.WriteLine("Jít doprava ke kostelu.\n\nKostel stojí u okraje města. Jeho kamenné zdi jsou tmavé a místy porostlé mechem. Dveře jsou pootevřené a ve větru se lehce pohupují.");
                    }
                    WaitForInput();
                    Console.WriteLine("Najednou na krku ucítíš ledový závan větru. Vzduch kolem tebe ztěžkne.\nV dálce před sebou vidíš stín.");
                    WaitForInput();
                    Console.WriteLine("Začíná okolo tebe padat hustá mlha. Stín naproti tobě je nehybný.");
                    WaitForInput();
                    Console.WriteLine("Najednou se ale stín pohne a blíží se k tobě.\nTy nemáš čas váhat.");
                    Enemy enemy = new Enemy(100, 20);
                    string status = Battle(player, enemy);
                    if (status == "lost")
                    {
                        WaitForInput();
                        break;
                    }
                    Console.WriteLine("Rozhodneš se raději utéct.\nVzpomeneš si na tu ženu, která ti nabídla místo v jejím hostinci a dojdeš k závěru, že bude nejlepší bežet tam.");
                    WaitForInput();
                    Console.WriteLine("Doklopýtáš až ke dveřím domu a překvapí tě, když je najdeš otevřené.");
                    WaitForInput();
                    Console.WriteLine("Vkročíš dovnitř a hned spatříš ženu. Stojí tam dívá se na tebe, jako kdyby na tebe čekala už dlouho.");
                }
                WaitForInput();
                Console.WriteLine("„Tudy“\nPokyne k tobě žena a vede tě nahoru po dlouhém schodišti.");
                WaitForInput();
                Console.WriteLine("„Tohle je váš pokoj,“ řekne.");
                WaitForInput();
                Console.WriteLine("Vidíš, že pokoj je prázdný.\n„Tady si ale není kam lehnout“");
                WaitForInput();
                Console.WriteLine("„S tím si nedělejte starost. Musíte být zmožený z cesty a pro únavu je spánek výborným slamníkem.“");
                WaitForInput();
                Console.WriteLine("S těmito slovy tě žena opustí a zabouchne dveře.\nNacházíš se teď úplně sám v prázdném pokoji.");
                WaitForInput();
                Console.WriteLine("Co teď?");
                WaitForInput();
                choice = Deciding3Options("Jít spát.", "Prozkoumat dům.", "Vyhledat ženu a zeptat se jí na otázky.");
                if (choice == 'a')
                {
                    Console.WriteLine("Jít spát.\n\nJsi už dost unavený z dlouhé cesty, a tak se rozhodneš raději jít spát.");
                }
                else if (choice == 'b')
                {
                    Console.WriteLine("Prozkoumat dům.\n\nVyjdeš zpátky ke dveřím a opustíš pokoj.");
                    WaitForInput();
                    Console.WriteLine("Vydáš se dál po chodbě. Zkoušíš otevřít dveře k ostatním pokojům, ale všechny jsou zamčené.");
                    WaitForInput();
                    Console.WriteLine("Nakonec na úplném konci chodby něco spatříš.\nJe to truhla.");
                    WaitForInput();
                    choice = Deciding2Options();

                }
                else
                {
                    Console.WriteLine();
                }
                


            }
        }
    }
}
