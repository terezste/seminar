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

        static void PlaceShip(int shipLenght, string shipSymbol, string message, string[,] field)
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
                        field[yCoordinate, xCoordinate + i] = shipSymbol + " ";
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
                else
                {
                    break;
                }
            }  
            PrintField(field);
        }

        static void PlayerRound(string[,] opponentField) 
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
                PrintField(opponentField);

                //kontroluji, jestli je delka zadanych souradnic validni

                if (!(attackCoordinates.Length == 2 || attackCoordinates.Length == 3))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                //kontroluji, jestli jsou zadane souradnice x validni

                for (int i = 0; i < opponentField.GetLength(0); i++)
                {
                    if (opponentField[0, i] == attackCoordinates.Substring(0, 1).ToUpper() + " ")
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
                if (yCoordinate == 0 || yCoordinate > opponentField.GetLength(1))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        /*static void ComputerRound()
        {
            Console.WriteLine("Computer's turn");
            Console.WriteLine("The computer attacked " + );
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

                PlaceShip(5, "A", "Place an Aircraft Carrier (A, 1*5): ", playerField);
                PlaceShip(4, "B", "Place a Battleship (B, 1*4): ", playerField);
                PlaceShip(3, "C", "Place a Cruiser (C, 1*3): ", playerField);
                PlaceShip(3, "S", "Place a Submarine (S, 1*3): ", playerField);
                PlaceShip(2, "D", "Place a Destroyer (D, 1*2): ", playerField);

                //rozmistuju lode pocitace

                PlaceShip(5, "A", "", computerField);
                PlaceShip(4, "B", "", computerField);
                PlaceShip(3, "C", "", computerField);
                PlaceShip(3, "S", "", computerField);
                PlaceShip(2, "D", "", computerField);

                //vytvorim si tyto promenne a dle nich budu moct ukoncit hru jakmile jeden z hracu potopi vsechny lode - tedy 17krat uderi cast lode)

                int playersHitCount = 0;
                int computersHitCount = 0;

                //muzu zacit hrat

                while (playersHitCount < 17 || computersHitCount < 17)
                {
                    PlayerRound(computerField);
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
