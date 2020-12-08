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
        private IEnumerable<Planet> planetList = new List<Planet>();
        private Dictionary<string, Star> starDictionary = new Dictionary<string, Star>();
        private IEnumerable<IFilter> planetFilters = new List<IFilter>();
        private IEnumerable<IFilter> starFilters = new List<IFilter>();

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
                DrawMainMenu();
            }
        }

        //Draw methods
        private void DrawMainMenu()
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
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            MainMenuChoice(key);
        }

        private void MenuPlanetTable()
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
            Console.WriteLine("| C - Clear all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            FilterTypeChoice(key, true);
        }

        private void MenuStarTable()
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
            Console.WriteLine("| C - Clear all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            FilterTypeChoice(key, false);
        }

        private void MenuSetFilter(bool isPlanet)
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
            SetFilterChoice(key, isPlanet);
        }

        private void MenuNumericFilterPlanet()
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
            Console.WriteLine("| C - Clear all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NumericFilterPlanetsChoice(key);
        }

        private void MenuNumericFilterStars()
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
            Console.WriteLine("| C - Clear all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NumericFilterStarsChoice(key);
        }

        private void MenuNameFilterPlanet()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|              Name filter planet               |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| N - Planet name                               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| D - Discovery method                          |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| H - Host name                                 |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| C - Clear all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NameFilterPlanetChoice(key);
        }

        private void MenuNameFilterStar()
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
            Console.WriteLine("| C - Clear all filters                         |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| R - Return                                    |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| E - Exit                                      |");
            Console.WriteLine("|_______________________________________________|");
            // Is a switch where the person will interact with the menu choices
            ConsoleKey key = (Console.ReadKey(true)).Key;
            NameFilterStarChoice(key, false);
        }

        private void MenuMinMaxValue(string fieldName, bool isPlanet)
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                 Exoplanets                    |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine();
            Console.WriteLine(" Please insert Min, Max value (ex.: 0/900): ");

            string[] input = (Console.ReadLine()).Split("/");
            float min = (input[0] != null && input[0].Length != 0) ?
            (float)double.Parse(input[0], System.Globalization.CultureInfo.InvariantCulture) : 0f;

            float max = (input[0] != null && input[0].Length != 0) ?
            (float)double.Parse(input[0], System.Globalization.CultureInfo.InvariantCulture) : 0f;

            if (isPlanet)
            {
                if (!planetFilters.Contains(new NumericFilter(fieldName, min, max)))
                    (planetFilters as List<IFilter>).Add(new NumericFilter(fieldName, min, max));
            }
            else
            {
                if (!starFilters.Contains(new NumericFilter(fieldName, min, max)))
                    (starFilters as List<IFilter>).Add(new NumericFilter(fieldName, min, max));
            }
        }

        private void MenuTextValue(string fieldName, bool isPlanet)
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                 Exoplanets                    |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine();
            Console.WriteLine(" Please insert Text value (ex.: Jup ): ");

            string input = Console.ReadLine();
            if (input != null && input.Length > 0)
            {
                if (isPlanet)
                {
                    if (!planetFilters.Contains(new StringFilter(fieldName, input)))
                        (planetFilters as List<IFilter>).Add(new StringFilter(fieldName, input));
                }
                else
                {
                    if (!starFilters.Contains(new StringFilter(fieldName, input)))
                        (starFilters as List<IFilter>).Add(new StringFilter(fieldName, input));
                }
            }

        }

        // switch methods
        private void MainMenuChoice(ConsoleKey key)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.P:
                    MenuPlanetTable();
                    break;

                case ConsoleKey.S:
                    MenuStarTable();
                    break;

                case ConsoleKey.C:
                    // complete table, WOP
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

        private void SetFilterChoice(ConsoleKey key, bool isPlanet)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.U:
                    if (isPlanet)
                    { MenuNumericFilterPlanet(); }
                    else
                    { MenuNumericFilterStars(); }
                    break;

                case ConsoleKey.A:
                    if (isPlanet)
                    { MenuNameFilterPlanet(); }
                    else
                    { MenuNameFilterStar(); }
                    break;

                case ConsoleKey.R:
                    if (isPlanet)
                    { MenuPlanetTable(); }
                    else
                    { MenuStarTable(); }
                    break;

                case ConsoleKey.E:
                    Console.Clear();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private void FilterTypeChoice(ConsoleKey key, bool isPlanet)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.S:
                    MenuSetFilter(isPlanet);
                    break;

                case ConsoleKey.C:
                    planetFilters = new List<IFilter>();
                    starFilters = new List<IFilter>();
                    if (isPlanet)
                    {
                        MenuPlanetTable();
                    }
                    else
                    {
                        MenuStarTable();
                    }
                    break;

                case ConsoleKey.R:
                    DrawMainMenu();
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private void NumericFilterPlanetsChoice(ConsoleKey key)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.Y:
                    //Disc_year
                    MenuMinMaxValue("disc_year",true);
                    break;

                case ConsoleKey.O:
                    //Pl_orbper
                    MenuMinMaxValue("pl_orbper",true);
                    break;

                case ConsoleKey.A:
                    //Pl_rade
                    MenuMinMaxValue("pl_rade",true);
                    break;

                case ConsoleKey.M:
                    //Pl_masse
                    MenuMinMaxValue("pl_masse",true);
                    break;

                case ConsoleKey.P:
                    //Pl_eqt
                    MenuMinMaxValue("pl_eqt",true);
                    break;

                case ConsoleKey.C:
                    //Clear all filters 
                    planetFilters = new List<IFilter>();
                    starFilters = new List<IFilter>();
                    MenuNumericFilterPlanet();
                    break;

                case ConsoleKey.R:
                    MenuSetFilter(true);
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private void NumericFilterStarsChoice(ConsoleKey key)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.T:

                    MenuMinMaxValue("st_teff",false);
                    break;

                case ConsoleKey.I:

                    MenuMinMaxValue("st_rad",false);
                    break;

                case ConsoleKey.M:

                    MenuMinMaxValue("st_mass",false);
                    break;

                case ConsoleKey.A:

                    MenuMinMaxValue("st_age",false);
                    break;

                case ConsoleKey.V:

                    MenuMinMaxValue("st_vsin",false);
                    break;

                case ConsoleKey.S:

                    MenuMinMaxValue("st_rotp",false);
                    break;

                case ConsoleKey.D:

                    MenuMinMaxValue("sy_dist",false);
                    break;

                case ConsoleKey.C:
                    planetFilters = new List<IFilter>();
                    starFilters = new List<IFilter>();
                    MenuNumericFilterStars();
                    break;

                case ConsoleKey.R:
                    MenuSetFilter(false);
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private void NameFilterPlanetChoice(ConsoleKey key)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.N:

                    MenuTextValue("pl_name",true);
                    break;

                case ConsoleKey.D:

                    MenuTextValue("discoverymethod",true);
                    break;

                case ConsoleKey.H:

                    MenuTextValue("hostname",true);
                    break;


                case ConsoleKey.C:
                    planetFilters = new List<IFilter>();
                    starFilters = new List<IFilter>();
                    MenuNameFilterPlanet();
                    break;

                case ConsoleKey.R:
                    MenuSetFilter(true);
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private void NameFilterStarChoice(ConsoleKey key, bool isPlanet)
        {
            // Interact with the Menu
            switch (key)
            {
                case ConsoleKey.S:
                    MenuTextValue("starname",false);
                    break;

                case ConsoleKey.C:
                    planetFilters = new List<IFilter>();
                    starFilters = new List<IFilter>();
                    MenuNameFilterStar();
                    break;

                case ConsoleKey.R:
                    MenuSetFilter(false);
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

    }
}
