using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Util
{
    public class FileReader
    {
        public IList<string> Read(string path)
        {
            IList<string> fileContents = new List<string>();

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                string line;

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while((line = reader.ReadLine())!=null)
                    {
                            fileContents.Add(line);
                    }                    
                }                
           }
           return fileContents;
        }
    }
}