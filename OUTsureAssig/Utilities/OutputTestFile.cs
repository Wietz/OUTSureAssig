using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OUTsureAssig.Utilities
{
    public class OutputTestFile
    {
        public static void WriteData(string fileName, string[] textData)
        {
            File.WriteAllLines(fileName, textData);
        }
    }
}
