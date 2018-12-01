using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1(startingFrequency:0);
            Console.WriteLine("Hello World!");
        }
        
        static void Day1(int startingFrequency)        
        {
            int result = startingFrequency;

            using (FileStream fileStream = new FileStream("input.txt", FileMode.Open))
            {
                string line;
                int delta = 0;

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while((line = reader.ReadLine())!=null)                        
                    {                        
                        if(int.TryParse(line, out delta))
                        {
                            result += delta;
                        }
                    }                    
                }                
           }          
           System.Console.WriteLine($"Resulting frequency is {result}"); 
        } 
    }
}
