using System;
using System.Collections.Generic;
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
                //tady jsem si poradila, nevedela jsem, jak udelat, aby se mi vypsaly souradnice dle poctu radku a sloupcu, ktere si uzivatel sam navoli https://chatgpt.com/share/675eaaf5-8700-8012-aef2-81e7750c8f9c

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
            string shipCoordinates = "";
            int xCoordinate = 0;
            int yCoordinate = 0;
            while (true)
            {
                Console.Write(message);
                shipCoordinates = Console.ReadLine();

                //kontroluji, jestli jsou zadane souradnice validni

                if (shipCoordinates.Length != 2 || shipCoordinates.Length != 3)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                int.TryParse(shipCoordinates.Substring(1), out yCoordinate);
                if (yCoordinate == 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                xCoordinate = shipCoordinates.Substring(0, 1);
                if (Convert.ToInt32(xCoordinate) > field.GetLength(1))
                {
                    Console.WriteLine("Invalid input. Stay within the field");
                    continue;
                }
                for (int i = 0; i < field.GetLength(1); i++)
                {
                    if (field[i, 0] == (Convert.ToString(shipCoordinates[1])).ToUpper())
                    {
                        yCoordinate = Convert.ToString(i) + 1;
                        break;
                    }
                }
                if (yCoordinate == "")
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

            }
            for (int i = 0; i < shipLenght; i++)
            {
                field[Convert.ToInt32(xCoordinate) + 1, Convert.ToInt32(yCoordinate)] = shipSymbol + " ";
            }
            PrintField(field);
        }

        /*static int PlayerRound() 
        {
            Console.WriteLine("Your turn. Enter coordinates to attack.");
            PrintField(playerField);
        }

        static int ComputerRound()
        {
            Console.WriteLine("Computer's turn");
            Console.WriteLine("The computer attacked " + );
        }*/

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Battleship game");

            //navrhuji pole a kontroluji vstup

            int columns = 0;
            int rows = 0;
            int indexOfAsterisk;
            while ((columns == 0 || rows == 0))
            {
                Console.Write("Choose the size of your field (e.g. 10*10): ");
                string fieldSizeInput = Console.ReadLine();
                if (fieldSizeInput.Contains("*"))
                {
                    indexOfAsterisk = fieldSizeInput.IndexOf("*");
                    int.TryParse(fieldSizeInput.Substring(0, indexOfAsterisk), out columns);
                    int.TryParse(fieldSizeInput.Substring(indexOfAsterisk + 1), out rows);
                }
                if (columns == 0 || rows == 0)
                {
                    Console.WriteLine("Invalid input");
                }                   
            }
            
            //vytvorim si vsechna pole, ktera budu pouzivat (+ 1, protoze mam jeste popisky)

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
 
        }
    }
}
