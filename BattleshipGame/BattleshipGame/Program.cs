using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    internal class Program
    {
        static void PrintField(string[,] field)
        {
            Console.WriteLine("");
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void InitializeField(string[,] field, int columns, int rows)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = "- ";
                }
            }

            for (int x = 1; x <= rows; x++)
            {
                //tady jsem si poradila, nevedela jsem, jak udelat, aby se mi vypsaly pismenkove souradnice dle poctu sloupcu, ktere si uzivatel sam navoli https://chatgpt.com/share/675eaaf5-8700-8012-aef2-81e7750c8f9c

                field[0, x] = Convert.ToString((char)('A' + x - 1) + " ");
            }        

            for (int y = 1; y <= columns; y++)
            {
                field[y, 0] = y + " ";
                if ((field[y,0]).Length == 2)
                {
                  field[y, 0] += " ";
                }
            }

            field[0, 0] = "   ";
        }

        static void PlacePlayerShip(int shipLenght, string shipSymbol, string message, string[,] field)
        {
            string shipCoordinates;
            int xCoordinate;
            int yCoordinate;
            while (true)
            {
                shipCoordinates = "";
                xCoordinate = 0;
                yCoordinate = 0;
                Console.Write(message);
                shipCoordinates = Console.ReadLine();

                //kontroluji, jestli je delka zadanych souradnic validni

                if (!(shipCoordinates.Length == 2 || shipCoordinates.Length == 3))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                //kontroluji, jestli jsou zadane souradnice x validni

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    if (field[0, i] == shipCoordinates.Substring(0, 1).ToUpper() + " ")
                    {
                        xCoordinate = i;
                        break;
                    }
                }
                if (xCoordinate == 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                //kontroluji, jestli jsou zadane souradnice y validni

                int.TryParse(shipCoordinates.Substring(1), out yCoordinate);
                if (yCoordinate == 0 || yCoordinate > field.GetLength(1))
                {
                    Console.WriteLine("Invalid input");
                    continue;   
                }

                //kontroluji, jestli lod je v poli

                if (xCoordinate + shipLenght > field.GetLength(0))
                {
                    Console.WriteLine("Invalid input. Stay within the field");
                    continue;
                }

                //zadavam podminky, aby se lode neprekryvaly

                bool shipsOverlapping = false;

                for (int i = 0; i < shipLenght; i++)
                {
                    if (field[yCoordinate, xCoordinate + i] == "- ")
                    {
                        shipsOverlapping = false;
                    }
                    else
                    {
                        shipsOverlapping = true;
                        break;
                    }
                }
                if (shipsOverlapping == true)
                {
                    Console.WriteLine("Invalid input. Ships cannot overlap");
                    continue;
                }

                //pokud je vse v poradku, lod zakreslim do pole

                else
                {
                    for (int i = 0; i < shipLenght; i++)
                    {
                        if (field[yCoordinate, xCoordinate + i] == "- ")
                        {
                            field[yCoordinate, xCoordinate + i] = shipSymbol + " ";
                        }
                    }
                }
                break;
            }  
            PrintField(field);
        }

        static void PlaceComputerShip (int shipLenght, string shipSymbol, string[,] field)
        {
            Random rnd = new Random();
            while (true)
            {
                //generuji nahodne souradnice

                int xCoordinate = rnd.Next(1, field.GetLength(0) - 2); //-2, protoze vsechny lode jsou vetsi nez 1 (takze by nedavalo smysl, aby pocitac daval lod na posledni x souradnici, protoze to bude vzdy presahovat)
                int yCoordinate = rnd.Next(1, field.GetLength(1) - 1);

                //kontroluji, jestli lod je v poli

                if (xCoordinate + shipLenght > field.GetLength(0))
                {
                    continue;
                }

                //zadavam podminky, aby se lode neprekryvaly

                bool shipsOverlapping = false;

                for (int i = 0; i < shipLenght; i++)
                {
                    if (field[yCoordinate, xCoordinate + i] == "- ")
                    {
                        shipsOverlapping = false;
                    }
                    else
                    {
                        shipsOverlapping = true;
                        break;
                    }
                }
                if (shipsOverlapping == true)
                {
                    continue;
                }

                //pokud je vse v poradku, lod zakreslim do pole

                else
                {
                    for (int i = 0; i < shipLenght; i++)
                    {
                        if (field[yCoordinate, xCoordinate + i] == "- ")
                        {
                            field[yCoordinate, xCoordinate + i] = shipSymbol + " ";
                        }
                    }
                }
                break;
            }
        }

        static void PlayerRound(string[,] computerField, string[,] revealedComputerField, int playersHitCount) 
        {
            string attackCoordinates;
            int xCoordinate;
            int yCoordinate;
            while (true)
            {
                attackCoordinates = "";
                xCoordinate = 0;
                yCoordinate = 0;
                Console.Write("Your turn. Enter coordinates to attack: ");
                attackCoordinates = Console.ReadLine();
                PrintField(revealedComputerField);

                //kontroluji, jestli je delka zadanych souradnic validni

                if (!(attackCoordinates.Length == 2 || attackCoordinates.Length == 3))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                //kontroluji, jestli jsou zadane souradnice x validni

                for (int i = 0; i < computerField.GetLength(0); i++)
                {
                    if (computerField[0, i] == attackCoordinates.Substring(0, 1).ToUpper() + " ")
                    {
                        xCoordinate = i;
                        break;
                    }
                }
                if (xCoordinate == 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                //kontroluji, jestli jsou zadane souradnice y validni

                int.TryParse(attackCoordinates.Substring(1), out yCoordinate);
                if (yCoordinate == 0 || yCoordinate > computerField.GetLength(1))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                break;
            }

            //vim, ze zadany input je v poradku, kontroluji, jestli hrac zasahl lod, nebo ne a pokud ano

            if (computerField[xCoordinate, yCoordinate] == "- ")
            {
                Console.WriteLine("You miss");
            }
            else
            {
                revealedComputerField[xCoordinate, yCoordinate] = "X ";
                Console.WriteLine("You hit");
                playersHitCount++;
            }
        }

        /*static void ComputerRound()
        {
            Console.WriteLine("Computer's turn");


            Console.WriteLine("The computer attacked " +  + "and " + );
        }*/

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Battleship game");

                //navrhuji pole a kontroluji vstup, zaroven kontroluji, jestli pole neni moc velke nebo moc male

                int columns;
                int rows;
                int indexOfAsterisk;

                while (true)
                {
                    columns = 0;
                    rows = 0;
                    indexOfAsterisk = 0;

                    Console.Write("Choose the size of your field (e.g. 10*12): ");
                    string fieldSizeInput = Console.ReadLine();

                    if (fieldSizeInput.Contains("*"))
                    {
                        indexOfAsterisk = fieldSizeInput.IndexOf("*");
                        int.TryParse(fieldSizeInput.Substring(0, indexOfAsterisk), out columns);
                        int.TryParse(fieldSizeInput.Substring(indexOfAsterisk + 1), out rows);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }

                    if (columns > 26 || rows > 26)
                    {
                        Console.WriteLine("Field is too big");
                        continue;
                    }
                    else if (columns < 5 || rows < 5)
                    {
                        Console.WriteLine("Field is too small");
                        continue;
                    }
                    else if (columns == 0 || rows == 0)
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                //vytvorim si vsechna pole, ktera budu pouzivat (+ 1 radek a sloupec, protoze mam jeste popisky)

                string[,] playerField = new string[columns + 1, rows + 1];
                string[,] computerField = new string[columns + 1, rows + 1];
                string[,] revealedComputerField = new string[columns + 1, rows + 1];

                //zadam si zakladni hodnoty do poli

                InitializeField(playerField, columns, rows);
                InitializeField(computerField, columns, rows);
                InitializeField(revealedComputerField, columns, rows);

                PrintField(playerField);

                //rozmistuji sve lode

                Console.WriteLine("Time to place your ships. You have 5 ships.\nEnter coordinates of the left corner of the ship (e.g. b5)");

                PlacePlayerShip(5, "A", "Place an Aircraft Carrier (A, 1*5): ", playerField);
                PlacePlayerShip(4, "B", "Place a Battleship (B, 1*4): ", playerField);
                PlacePlayerShip(3, "C", "Place a Cruiser (C, 1*3): ", playerField);
                PlacePlayerShip(3, "S", "Place a Submarine (S, 1*3): ", playerField);
                PlacePlayerShip(2, "D", "Place a Destroyer (D, 1*2): ", playerField);

                //rozmistuju lode pocitace

                PlaceComputerShip(5, "A", computerField);
                PlaceComputerShip(4, "B", computerField);
                PlaceComputerShip(3, "C", computerField);
                PlaceComputerShip(3, "S", computerField);
                PlaceComputerShip(2, "D", computerField);

                //vytvorim si tyto promenne a dle nich budu moct ukoncit hru jakmile jeden z hracu potopi vsechny lode - tedy 17krat uderi cast lode)

                int playersHitCount = 0; //kolikrat hrac uderi lod pocitace
                int computersHitCount = 0; //kolikeat pocitac uderi lod hrace

                //muzu zacit hrat

                Console.WriteLine("All set!");

                while (playersHitCount < 17 || computersHitCount < 17)
                {
                    PlayerRound(computerField, revealedComputerField, playersHitCount);
                    //computerround
                }
                if (playersHitCount == 17)
                {
                    Console.WriteLine("You won!");
                }
                else
                {
                    Console.WriteLine("You lost!");
                }

                //uz se jenom ptam, jestli chce hrac hrat znova

                string playAgain;

                while (true)
                {
                    Console.Write("Play again? (y/n): ");
                    playAgain = Console.ReadLine();
                    if (!(playAgain == "y" || playAgain == "Y" || playAgain == "n" || playAgain == "N"))
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (playAgain == "y" || playAgain == "Y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

        }
    }
}
