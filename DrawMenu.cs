using System;
using System.IO;
using System.Linq;

namespace LP2_Exoplanets_2020
{
    public class UIDrawer
    {
        // Is follows the path of the file
        private string path;

        //Draws the begging of the program and ask to put the file
        public void DrawFilePath()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                    WELCOME                    |");
            Console.WriteLine("|                 to Exoplanets                 |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please Insert the complete File Path: ");

            path = Console.ReadLine();

            if (!FileManager.ValidateFile(path))
            {
                Console.WriteLine("/nWarning: Wrong file path / Invalid File ");
            }else{
                FileManager.ReadFile(path);
            }

            // If it fails a warning appear in the console screen
            Console.WriteLine("/nWarning: Wrong file path/ Invalid File ");
            Console.ReadKey();

            // Draws the DrawFilePath method again
            DrawFilePath();
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
            Console.WriteLine("|  1. Planets table                             |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|  2. Stars table                               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|  3. Complete table                            |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|  4. Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a swicth where the person will interact with the menu choices
            Choice();
        }

        // Method of a swicth
        private void Choice()
        {

            // Interact with the Menu
            switch (Console.ReadLine())
            {
                case "1":
                    // 
                    break;

                case "2":
                    // 
                    break;

                case "3":
                    //
                    break;

                case "4":
                    Environment.Exit(0);
                    break;

                default:
                    DrawMenu();
                    break;
            }
            DrawMenu();
        }
    }
}