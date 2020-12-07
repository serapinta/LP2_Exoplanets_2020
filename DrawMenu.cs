using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LP2_Exoplanets_2020
{
    public class UIDrawer
    {
        // Is follows the path of the file
        private string path;
        private List<Planet> planetList = new List<Planet>();

        //Draws the begging of the program and ask to put the file
        public void DrawFilePath(string errorMessage = default)
        {
          
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                    WELCOME                    |");
            Console.WriteLine("|                 to Exoplanets                 |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine();
            Console.WriteLine(errorMessage);
            Console.WriteLine();
            Console.WriteLine("Please Insert the complete File Path: ");

            path = Console.ReadLine();

            if (!FileManager.ValidateFile(path))
            {
                DrawFilePath("Warning: Wrong file path or Invalid File ");
            }
            else
            {
                planetList = FileManager.ReadFile(path);
                DrawMenu();
            }

        }

        //Draws the Menu
        private void DrawMenu()
        {

            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                   Exoplanets                  |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                      Menu                     |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| P -Planets table                              |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| S -Stars table                                |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C -Complete table                             |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R -Return                                     |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E -Exit                                       |");
            Console.WriteLine("|_______________________________________________|");
            // Is a swicth where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            Choice(key);
        }

        // Method of a swicth
        private void Choice(ConsoleKey key)
        {

            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.P:
                    // 
                    break;

                case ConsoleKey.S:
                    // 
                    break;

                case ConsoleKey.C:
                    //
                    break;

                case ConsoleKey.R:
                    DrawFilePath();
                    break;

                case ConsoleKey.E:
                    Console.Clear();
                    Environment.Exit(0);
                    break;


                default:
                    DrawMenu();
                    break;
            }

        }
    }
}