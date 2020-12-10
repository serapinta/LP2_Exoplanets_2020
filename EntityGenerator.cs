using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LP2_Exoplanets_2020
{
    public static class EntityGenerator
    {

        public static List<Planet> GenerateStarsAndPlanets(string _filePath, out Dictionary<string, Star> starDictionary)
        {
            List<Planet> planetList = GeneratePlanetsOnly(_filePath);

           
            starDictionary = GenerateStarsOnly(planetList);

            return planetList;
        }


        public static List<Planet> GeneratePlanetsOnly(string _filePath)
        {
            List<Planet> planets = new List<Planet>();
            try
            {
                using (StreamReader fileCsv = new StreamReader(_filePath))
                {
                    String line;
                    String[] header = null; ;
                    //check if column's title line exists
                    while ((line = fileCsv.ReadLine()) != null)
                    {
                        if (line.Length != 0)
                        {
                            if (line[0] != '#')
                            {
                                if (header == null ||header.Count<string>() == 0 )
                                {
                                    header = line.Split(',');
                                }
                                else
                                {
                                    planets.Add(new Planet(line.Split(','), header));
                                }
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


        public static List<Star> StarDictionaryToList(Dictionary<string, Star> starDictionary)
        {
            List<Star> starList = new List<Star>();
            List<KeyValuePair<string, Star>> list = starDictionary.ToList();

            // Loop over list.
            foreach (KeyValuePair<string, Star> pair in list)
            {
                starList.Add(pair.Value);
            }
            return starList;
        }


        public static Dictionary<string, Star> GenerateStarsOnly(List<Planet> planetList)
        {
            Dictionary<string, Star> starDictionary = new Dictionary<string, Star>();
            for (int i = 0; i < planetList.Count; i++)
            {
                
                if (planetList[i].HostStar != null && planetList[i].HostStar.StarName != " " &&
                    planetList[i].HostStar.StarName != "")
                {
                    if (starDictionary.ContainsKey(planetList[i].HostStar.StarName))
                    {
                        
                        starDictionary[planetList[i].HostStar.StarName].ActualizeValues(planetList[i]);
                    }
                    else
                    {
                        starDictionary.Add(planetList[i].HostStar.StarName, planetList[i].HostStar);

                    }
                }
            }
            return starDictionary;
        }

    }
}