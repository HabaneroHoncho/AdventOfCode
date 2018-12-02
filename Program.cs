using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1(startingFrequency:0);
            var day2 = new Day2();
            day2.Run();
        }
        
        static void Day1(int startingFrequency)        
        {
            IList<int> frequencies = new List<int>();
            int delta = 0;
            int frequency = 0;

            using (FileStream fileStream = new FileStream("input.txt", FileMode.Open))
            {
                string line;

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while((line = reader.ReadLine())!=null)                        
                    {                        
                        if(int.TryParse(line, out delta))
                        {
                            frequencies.Add(delta);
                        }
                    }                    
                }                
           }
           frequency = ApplyFrequencyChanges(frequencies,startingFrequency); 
           int first  = FindFirstDuplicate(frequencies);

           System.Console.WriteLine($"Day 1: Resulting frequency is {frequency}"); 
           System.Console.WriteLine($"     : {first} is the first frequency to be reached twice"); 
        } 

        static int ApplyFrequencyChanges(IList<int>frequencyChanges,int target)
        {
            int resultingFrequency= 0;

            foreach(int frequencyDelta in frequencyChanges)
            {
                resultingFrequency +=  frequencyDelta;
            }

            return resultingFrequency;
        }

        static int FindFirstDuplicate(IList<int>frequencyChanges)
        {
            int resultingFrequency= 0;
            IList<int> frequencies = new List<int>();
            bool found =false;
            
             while (!found)
             {
                foreach(int frequencyChange in frequencyChanges)
                {

                    resultingFrequency +=  frequencyChange;

                    if(frequencies.Contains(resultingFrequency))
                     {
                         found = true;
                         break;
                     }

                    frequencies.Add(resultingFrequency);
                }   
             }

            return resultingFrequency;

        }
    }
}
