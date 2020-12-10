using System;
using System.Collections.Generic;
using System.IO;

namespace LP2_Exoplanets_2020
{
    /// <summary>
    /// class responsible for the file management
    /// </summary>
    public static class FileManager
    {
        public static List<Planet> ReadFile(string _filePath, out Dictionary<string, Star> starDictionary)
        {
            starDictionary = new Dictionary<string, Star>();

            if (ValidateFile(_filePath))
            {

                return EntityGenerator.GenerateStarsAndPlanets(_filePath, out starDictionary);
            }
            else
                return null;

        }

        public static bool ValidateFile(string _filePath)
        {
            if (_filePath.Length != 0 && _filePath != null)
            {

                try
                {
                    using (StreamReader fileCsv = new StreamReader(_filePath))
                    {
                        String line;
                        String[] header = null;
                        //check if column's title line exists
                        while ((line = fileCsv.ReadLine()) != null)
                        {
                            if (line[0] != '#' && header == null)
                            {
                                header = line.Split(',');
                                break;
                            }
                        }
                        //if not return false, the values can't be sorted properly
                        if (header == null)
                        {
                            throw new IOException("The file requires the header line to be valid.");
                        }
                        uint flag = 0;

                        for (int i = 0; i < header.Length; i++)
                        {
                            if (flag == 2) { break; }
                            if (header[i] == "pl_name" || header[i] == "hostname")
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
            else
            { return false; }

        }
    }
}