﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */


            // V me kalkulacce muzu scitat(+), odcitat(-), nasobit(*), delit(/), mocnit(**), odmocnovat(sqrt) a prevadet na absolutni hodnotu(abs).
            // Muzu pocitat i s desetinnymi cisly.

            // Zacnu tim, ze si zavedu vsechny promenne, ktere budu pouzivat. 

            double num1 = 0;
            double num2 = 0;
            string operation;
            double result = 0;

            while (true)
            {
                // Zjistim od uzivatele, jaky bude priklad, ktery bude moje kalkulacka resit.

                while (true)
                {
                    Console.Write("Napis prvni cislo: ");
                    num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Napis jakou operaci chces provest: ");
                    operation = Console.ReadLine();

                    // Pokud operace neni abs ani sqrt (u kterych mi staci 1 cislo), potrebuju jeste 2. cislo.

                    if (operation != "abs" && operation != "sqrt" && operation != "Abs" && operation != "Sqrt")
                    { 
                        Console.Write("Napis druhe cislo: ");
                        num2 = Convert.ToDouble(Console.ReadLine());
                    }

                    // Ted uz pracuju pro kazdou operaci jinak.
                    // V konzoli se mi pak zobrazi vysledek (+ mezera pro přehlednost) a program mi jede od znova - muzu napsat dalsi priklad.

                    if (operation == "abs" || operation == "Abs")
                    {
                        result = Math.Abs(num1);
                        Console.WriteLine("Vysledek je " + result + "\n");
                        break;
                    }
                    else if (operation == "sqrt" || operation == "Sqrt")
                    {
                        result = Math.Sqrt(num1);
                        Console.WriteLine("Vysledek je " + result + "\n");
                        break;
                    }
                    else if (operation == "+")
                    {
                        result = num1 + num2;
                        Console.WriteLine("Vysledek je " + result + "\n");
                        break;
                    }
                    else if (operation == "-")
                    {
                        result = num1 - num2;
                        Console.WriteLine("Vysledek je " + result + "\n");
                        break;
                    }
                    else if (operation == "*")
                    {
                        result = num1 * num2;
                        Console.WriteLine("Vysledek je " + result + "\n");
                        break;
                    }
                    else if (operation == "/")
                    {
                        result = num1 / num2;
                        Console.WriteLine("Vysledek je " + result + "\n");
                        break;
                    }
                    else if (operation == "**")
                    {
                        result = Math.Pow(num1, num2);
                        Console.WriteLine("Vysledek je " + result + "\n");
                        break;
                    }
                    else
                    {
                        // Tohle se mi zobrazi, pokud napisu operaci, kterou moje kalkulacka neumi nebo je ve spatnem formatu.
                        // Kdyz tohle nastane, zeptam se na priklad znova.

                        Console.WriteLine("Zkus zadat neco jineho.\n");
                    }

                }
            }   

        }
    }
}
