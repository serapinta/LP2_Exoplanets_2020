using System;
using System.Collections.Generic;
using System.Linq;

namespace LP2_Exoplanets_2020
{
    public static class DrawTable
    {
        public static void PrintBook<T>(List<List<T>> book, out string stringError) where T : IEntity
        {
            bool stay = true;
            int actualPage = 0;
            stringError = "";

            if (ValidateBook(book))
            {
                while (stay)
                {
                    PrintPage(book[actualPage]);
                    actualPage = DrawPageUI(actualPage, book.Count - 1, out stay);

                }
            }
            else
            {
                stringError = "the planet list is empty, try another values at the filters.";
            }

        }

        public static bool ValidateBook<T>(List<List<T>> book) where T : IEntity
        {
            if (book != null)
            {
                if (book.Count > 0)
                {
                    return true;
                }
            }
            return false;

        }


        public static void PrintPage<T>(List<T> page) where T : IEntity
        {
            Console.Clear();
            Console.WriteLine("******************************************************************************************************");
            foreach (T entity in page)
            {
                PrintEntity<T>(entity);
            }
            Console.WriteLine("******************************************************************************************************");
        }


        public static void PrintEntity<T>(T entity) where T : IEntity
        {
            if (entity != null)

            {


                if (entity is Planet)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(" Planet.Name: {0} ||| Host Star: {1} ",
                        (entity as Planet).Pl_name, (entity as Planet).HostStar.StarName);
                    Console.WriteLine(" Disc. method: {0} | Disc. year: {1} | Orb. period: {2} days",
                        (entity as Planet).DiscoveryMethod, (entity as Planet).Disc_year, (entity as Planet).Pl_eqt);
                    Console.WriteLine(" Plnt. Radius: {0} earths | Plnt. mass: {1} earths |Equilib. temp: {2} Kelvin ",
                        (entity as Planet).Pl_rade, (entity as Planet).Pl_masse, (entity as Planet).Pl_eqt);
                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                }
                else if (entity is Star)
                {
                    Console.WriteLine(" Star Name:{0} | Hosting: {1} planets | distance fom sun: {2}",
                     (entity as Star).StarName, (entity as Star).CountHostedPlanets(), (entity as Star).Sy_dist);
                    Console.WriteLine(" Age: {0} Giga-years | Rot. velocity: {1} km/s | Rot. period: {2} days",
                    (entity as Star).St_age, (entity as Star).St_vsin, (entity as Star).St_rotp);
                    Console.WriteLine(" Star Radius: {0} earths | Star mass: {1} Suns | Efective Temp: {2} Kelvin ",
                    (entity as Star).St_rad, (entity as Star).St_mass, (entity as Star).St_teff);

                }
            }

        }


        public static int DrawPageUI(int actualPage, int totalPage, out bool stay)
        {
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("           M - Menu   P << {0} / {1} >> N    E - Exit", actualPage, totalPage);
            Console.WriteLine("-----------------------------------------------------------------------");



            ConsoleKey key = (Console.ReadKey(true)).Key;


            switch (key)
            {
                case ConsoleKey.M:
                    stay = false;
                    return 0;

                case ConsoleKey.P:
                    stay = true;
                    return (actualPage <= 0 ? 0 : actualPage - 1);

                case ConsoleKey.N:
                    stay = true;
                    return actualPage >= totalPage ? actualPage : actualPage + 1;


                case ConsoleKey.E:
                    Environment.Exit(0);
                    break;

                default:
                    stay = true;
                    return actualPage;

            }
            stay = true;
            return actualPage;
        }

    }

}
