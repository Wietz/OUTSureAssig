using OUTsureAssig.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OUTsureAssig.DAL
{
    public class CSVFileContext : IDbContext
    {
        public string FilePath { get; set; }
        public List<Person> People { get; set; }

        public CSVFileContext(string filePath)
        {
            FilePath = filePath;

            People = new List<Person>();

            LoadData();
        }

        public void LoadData()
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new Exception("No file path supplied");

            if (People != null)
                People.Clear();

            string[] csvLines = File.ReadAllLines(FilePath);
            foreach(string line in csvLines)
            {
                string[] personParts = line.Split(new string[] { "," }, StringSplitOptions.None);
                if (personParts.Length != 3)
                    throw new Exception("Invalid line read from data file.");

                People.Add(new Person() 
                {
                    Name = personParts[0],
                    Surname = personParts[1],
                    Address = personParts[2]
                });
            }
        }
    }
}
