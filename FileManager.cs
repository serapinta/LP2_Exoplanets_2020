using System;
using System.IO;

namespace LP2_Exoplanets_2020
{
    public class FileManager
    {
        public static bool ReadFile(string _filePath)
        {
            if (ValidateFile(_filePath))
            {
                GenerateStarsAndPlanets(_filePath);
            }
        }

        public static bool ValidateFile(string _filePath)
        {
            try
            {
                using (StreamReader fileCsv = new StreamReader(_filePath))
                {
                    String line;
                    String[] order = null;
                    //check if column's title line exists
                    while ((line = fileCsv.ReadLine()) != null)
                    {
                        if (line[0] != '#' && order == null)
                        {
                            order = line.Split(',');
                            break;
                        }
                    }
                    //if not return false, the values can't be sorted properly
                    if (order == null)
                    {
                        throw new IOException("The file requires the column's title line to be valid.");
                    }
                    uint flag = 0;

                    for (int i = 0; i < order.Length; i++)
                    {
                        if (flag == 2) { break; }
                        if (order[i] == "pl_name" || order[i] == "hostname")
                        {
                            flag++;
                        }
                    }
                    if (flag == 2) { return true; }
                    else
                    {
                        throw new IOException("The file requires the pl_name and hostname columns to be valid.");
                    }

                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Invalid File. Error: " + ioex);
                return false;
            }
        }

        public static void GenerateStarsAndPlanets(string _filePath)
        {

 try
            {
                using (StreamReader fileCsv = new StreamReader(_filePath))
                {
                    String line;
                    bool headerSkipped = false;
                    //check if column's title line exists
                    while ((line = fileCsv.ReadLine()) != null)
                    {
                        if (line[0] != '#' && !headerSkipped)
                        {
                            headerSkipped = true;
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