using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OUTsureAssig.Utilities
{
    /// <summary>
    /// A class that exposes a static method tow write string array data out to a text file.
    /// </summary>
    public class OutputTestFile
    {
        /// <summary>
        /// Write an array of strings to a text file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="textData">An array of strings to written to the file.</param>
        public static void WriteData(string fileName, string[] textData)
        {
            File.WriteAllLines(fileName, textData);
        }
    }
}
