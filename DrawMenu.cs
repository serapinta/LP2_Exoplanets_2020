using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LP2_Exoplanets_2020
{
    public class UIDrawer
    {
        // File path
        private string path;
        // Planet list returned by the csv file
        private List<Planet> planetList = new List<Planet>();
        // Stars dictionary returned by the csv file
        private Dictionary<string, Star> starDictionary = new Dictionary<string, Star>();

        /// <summary>
        /// Draws the begging of the program and ask to put the file
        /// </summary>
        /// <param name="errorMessage">shows the error when the file is rejected</param>
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
        /// <summary>
        /// Method to draw the MainMenu
        /// </summary>
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
            Console.WriteLine("| P - Planets table                             |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| S - Stars table                               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Complete table - WORK IN PROGRESS -       |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Checks if it a star or a planet table
            ConsoleKey key = (Console.ReadKey(true)).Key;
            Choice(key);
        }

        /// <summary>
        /// Method with a switch to interact with MainMenu  
        /// </summary>
        /// <param name="key">read the user input</param>
        private void Choice(ConsoleKey key)
        {
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
                    break;
            }
        }
        /// <summary>
        /// Method to draw the menu Planet Table
        /// </summary>
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
            // Checks if it a star or a planet filter
            ConsoleKey key = (Console.ReadKey(true)).Key;
            FilterChoice(key, true);
        }

        /// <summary>
        /// Method to draw the menu Star Table
        /// </summary>
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
            // Checks if it a star or a planet filter
            ConsoleKey key = (Console.ReadKey(true)).Key;
            FilterChoice(key, false);
        }

        /// <summary>
        /// Method with a switch to interact with menu Star Table  
        /// </summary>
        /// <param name="key">read the user input</param>
        /// <param name="isPlanet">to know if its a planet or a star</param>
        private void FilterChoice(ConsoleKey key, bool isPlanet)
        {
            switch (key)
            {
                case ConsoleKey.S:
                    SetFilter(isPlanet);
                    break;

                case ConsoleKey.C:
                    //TableManager.ClearAllFilters();
                    break;

                case ConsoleKey.R:
                    DrawMenu();
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// Method to draw the menu Set filter
        /// </summary>
        /// <param name="isPlanet">to know if its planet ou star</param>
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
            // Checks if it a star or a planet filter
            ConsoleKey key = (Console.ReadKey(true)).Key;
            SetChoice(key, isPlanet);
        }
        /// <summary>
        /// Method with a switch to interact with menu Set filter 
        /// </summary>
        /// <param name="key">read the user input</param>
        /// <param name="isPlanet">to know if its a planet or a star</param>
        private void SetChoice(ConsoleKey key, bool isPlanet)
        {
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
                    break;
            }
        }
        /// <summary>
        /// Method to draw the menu Numeric filter planet
        /// </summary>
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
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Checks if it a star or a planet filter
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NumericFilterPlanetsChoice(key);
        }
        /// <summary>
        /// Method with a switch to interact with menu Numeric filter planet
        /// </summary>
        /// <param name="key">read the user input</param>
        private void NumericFilterPlanetsChoice(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D:
                    //TableManager.ClearFilters(true); 
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.O:
                    //TableManager.ClearFilters(true); 
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.A:
                    //TableManager.ClearFilters(true); 
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.M:
                    //TableManager.ClearFilters(true); 
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.P:
                    //TableManager.ClearFilters(true); 
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.C:
                    //TableManager.ClearAllFilters();
                    break;

                case ConsoleKey.R:
                    SetFilter(true);
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// Method to draw the menu Numeric filter star
        /// </summary>
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
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Checks if it a star or a planet filter
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NumericFilterStarsChoice(key);
        }
        /// <summary>
        /// Method with a switch to interact with menu Numeric filter star 
        /// </summary>
        /// <param name="key">read the user input</param>
        private void NumericFilterStarsChoice(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.T:
                    //TableManager.ClearFilters(false);
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.I:
                    //TableManager.ClearFilters(false);
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.M:
                    //TableManager.ClearFilters(false);
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.A:
                    //TableManager.ClearFilters(false);
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.V:
                    //TableManager.ClearFilters(false);
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.S:
                    //TableManager.ClearFilters(false);
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.D:
                    //TableManager.ClearFilters(false);
                    MenuMinMaxValue();
                    break;

                case ConsoleKey.C:
                    //TableManager.ClearAllFilters();
                    break;

                case ConsoleKey.R:
                    SetFilter(false);
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// Method to draw the menu Name filter planet
        /// </summary>
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
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Checks if it a star or a planet filter
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NameFilterPlanetChoice(key);
        }

        /// <summary>
        /// Method with a switch to interact with menu Name filter Star 
        /// </summary>
        /// <param name="key">read the user input</param>
        private void NameFilterPlanetChoice(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.N:
                    //TableManager.ClearFilters(true);
                    MenuTextValue();
                    break;

                case ConsoleKey.D:
                    //TableManager.ClearFilters(true);
                    MenuTextValue();
                    break;

                case ConsoleKey.C:
                    //TableManager.ClearAllFilters();
                    break;

                case ConsoleKey.R:
                    NumericFilterPlanet();
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// Method to draw the menu Name filter star
        /// </summary>
        private void NameFilterStar()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|              Name filter star                 |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| N - StarName                                  |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clean all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Checks if it a star or a planet filter
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NameFilterStarChoice(key, false);
        }

        /// <summary>
        /// Method with a switch to interact with menu Name filter Star
        /// </summary>
        /// <param name="key">read the user input</param>
        /// <param name="isPlanet">to know if its a planet or a star</param>
        private void NameFilterStarChoice(ConsoleKey key, bool isPlanet)
        {
            switch (key)
            {
                case ConsoleKey.N:
                    //TableManager.ClearFilters(false);
                    MenuTextValue();
                    break;

                case ConsoleKey.C:
                    //TableManager.ClearAllFilters();
                    break;

                case ConsoleKey.R:
                    NumericFilterStars();
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// Method to ask to write Min Max filter values 
        /// </summary>
        private void MenuMinMaxValue()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                 Exoplanets                    |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" Please insert Min, Max value (ex.: 0, 900): ");
        }
        /// <summary>
        /// Method to ask to write text value
        /// </summary>
        private void MenuTextValue()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                 Exoplanets                    |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" Please insert Text value (ex.: Jupiter): ");
        }
    }
}
