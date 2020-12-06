using System;
using System.Collections.Generic;
using System.IO;

namespace LP2_Exoplanets_2020
{
    public static class EntityGenerator
    {

        public static List<Planet> GenerateStarsAndPlanets(string _filePath)
        {
            List<Planet> planets = new List<Planet>();

            try
            {
                using (StreamReader fileCsv = new StreamReader(_filePath))
                {
                    String line;
                    String[] header = null;;
                    //check if column's title line exists
                   while ((line = fileCsv.ReadLine()) != null)
                    {
                        if (line[0] != '#' )
                        {
                            if(header == null){
                            header = line.Split(',');
                            }
                            else{
                                planets.Add(new Planet(line.Split(','),header));
                            }
                        }
                    }
                }
                return planets;
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Invalid File. Error: " + ioex);
                return null;
            }
        }


        public static void GenerateStarsOnly(string _filePath)
        {
        }

        public static void GenerateStarsPlanetsOnly(string _filePath)
        {
        }


    }
}