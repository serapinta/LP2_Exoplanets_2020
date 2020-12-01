using System.IO;
using System;
namespace LP2_Exoplanetas_2020
{
    public class FileManager
    {
        private string _filePath;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }
        public StreamReader ReadFile()
        {
            StreamReader fileCsv = new StreamReader(_filePath);
            return fileCsv;
        }

        




    }
}