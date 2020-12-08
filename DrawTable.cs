using System;
using System.Collections.Generic;
using System.Linq;

namespace LP2_Exoplanets_2020
{
    public static class DrawTable
    {


        public static void PrintTable<T>(List<T> entities) where T:IEntity
        {
            Console.Clear();
            



        }



        public static void PrintEntity<T>(T entity) where T : IEntity
        {
            if (entity != null)

            {


                if (entity is Planet)
                { Console.WriteLine("------------------------------------------------------------------------------------------------------");
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
        public static void DrawUI()
        {
            int ActualPage = default;
            int TotalPage = default;
            Console.WriteLine("M - Menu   P << {0}/{1} >> N    E - Exit", ActualPage, TotalPage);

        }





    }
}