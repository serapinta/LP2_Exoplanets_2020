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
        private Dictionary<string, Star> starDictionary = new Dictionary<string, Star>();


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
                planetList = FileManager.ReadFile(path, out starDictionary);
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


            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            Choice(key);
        }

        // Method of a switch
        private void Choice(ConsoleKey key)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.P:
                    PlanetTable();
                    break;

                case ConsoleKey.S:
                    StarTable();
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

        private void PlanetTable()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                 Planet Table                  |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| S - Set filter                                |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clear filter                              |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            FilterChoice(key, true);
        }
        private void StarTable()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                  Star Table                   |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| S - Set filter                                |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clear filter                              |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            FilterChoice(key, false);
        }
        private void FilterChoice(ConsoleKey key, bool isPlanet)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.S:
                    SetFilter(isPlanet);
                    break;

                case ConsoleKey.C:

                    break;

                case ConsoleKey.R:
                    DrawMenu();
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    DrawMenu();
                    break;
            }
        }

        private void SetFilter(bool isPlanet)
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                  Set Filter                   |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| U - Numeric filter                            |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| A - Name filter                               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            SetChoice(key, isPlanet);
        }

        private void SetChoice(ConsoleKey key, bool isPlanet)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.U:
                    if (isPlanet)
                    {
                        NumericFilterPlanet();
                    }
                    else
                    {
                        NumericFilterStars();
                    }
                    break;

                case ConsoleKey.A:
                    if (isPlanet)
                    {
                        NameFilterPlanet();
                    }
                    else
                    {
                        NameFilterStar();
                    }
                    break;

                case ConsoleKey.R:
                    if (isPlanet)
                    {
                        PlanetTable();
                    }
                    else
                    {
                        StarTable();
                    }
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

        private void NumericFilterPlanet()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|            Numeric filter planet              |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| Y - Disc_year                                 |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| O - Pl_orbper                                 |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| A - Pl_rade                                   |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| M - Pl_masse                                  |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| P - Pl_eqt                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NumericFilterPlanetsChoice(key);
        }

        private void NumericFilterPlanetsChoice(ConsoleKey key)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.Y:
                    // 
                    break;

                case ConsoleKey.O:
                    // 
                    break;

                case ConsoleKey.A:
                    //
                    break;

                case ConsoleKey.M:

                    break;

                case ConsoleKey.P:

                    break;

                case ConsoleKey.R:
                    SetFilter(true);
                    break;

                case ConsoleKey.C:

                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;


                default:
                    DrawMenu();
                    break;
            }
        }

        private void NumericFilterStars()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|             Numeric filters stars             |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| T - St_teff                                   |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| I - St_rad                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| M - St_mass                                   |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| A - St_age                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| V - St_vsin                                   |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| S - St_rotp                                   |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| D - Sy_dist                                   |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
           NumericFilterStarsChoice(key);
        }

        private void NumericFilterStarsChoice(ConsoleKey key)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.T:
                    // 
                    break;

                case ConsoleKey.I:
                    // 
                    break;

                case ConsoleKey.M:
                    // 
                    break;

                case ConsoleKey.A:
                    //
                    break;

                case ConsoleKey.V:

                    break;

                case ConsoleKey.S:

                    break;

                case ConsoleKey.D:

                    break;

                case ConsoleKey.R:
                    SetFilter(false);
                    break;

                case ConsoleKey.C:

                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    DrawMenu();
                    break;
            }
        }

        private void NameFilterPlanet()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|              Name filter planet               |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| N - Pl_name                                   |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| D - Discoverymethod                           |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");

        }
        private void NameFilterPlanetChoice(ConsoleKey key, bool isPlanet)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.N:

                    break;

                case ConsoleKey.D:

                    break;

                case ConsoleKey.R:
                    NumericFilterPlanet();
                    break;

                case ConsoleKey.C:

                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    DrawMenu();
                    break;
            }
        }
        private void NameFilterStar()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|              Name filter star                 |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| S - StarName                                  |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");

        }
        private void NameFilterStarChoice(ConsoleKey key, bool isPlanet)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.S:

                    break;

                case ConsoleKey.R:
                    NumericFilterStars();
                    break;

                case ConsoleKey.C:

                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    DrawMenu();
                    break;
            }
        }
    }
}