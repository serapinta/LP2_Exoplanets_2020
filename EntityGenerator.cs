using System;
using System.IO;

namespace LP2_Exoplanets_2020
{
    public static class EntityGenerator
    {

        public static void GenerateStarsAndPlanets(string _filePath)
        {

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
                            if(header == null)
                            header = line.Split(',');
                           
                        }
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Invalid File. Error: " + ioex);

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