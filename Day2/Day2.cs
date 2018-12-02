using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Util;

namespace AdventOfCode
{
    public class Day2
    {
        private FileReader _fileReader;
        public Day2()
        {
            _fileReader = new FileReader();
        }

        public void Run()
        {
            IList<string> list = _fileReader.Read("Day2Input.txt");
           // Part1(list);
            Part2(list);
        }

        void Part1(IList<string> list)
        {
            int twoCount= 0;
            int threeCount= 0;
              
            foreach (string line in list)
            {

                Dictionary<char,int> occurrence = new Dictionary<char, int>();
                
                int count;

                char[] letters = line.ToCharArray();
                foreach (char ch in letters)
                {
                    if(occurrence.TryGetValue(ch,out count))
                    {
                        occurrence[ch]++;
                    }else
                    {
                        occurrence.Add(ch,1);
                    }
                }
                
                var twos = occurrence
                            .Values
                            .Distinct()
                            .Count(x=>x==2);

                var threes = occurrence
                .Values
                .Distinct()
                .Count(x=> x==3);

                twoCount+=twos;
                threeCount+=threes;
            }

            System.Console.WriteLine($"Day2   : The checksum is {twoCount*threeCount}");

        }
        
        //What letters are common between the two correct box IDs?
        void Part2(IList<string> list)
        {
            string currentLine;

            for( int i = 0; i<list.Count;i++)
            {
                currentLine = list[i];
                char[] source = currentLine.ToCharArray();

                System.Console.WriteLine($"{i} - CurrentLine {currentLine}");
             
                for( int j = i+1; j <list.Count;j++)
                {
                    char[] target = list[j].ToCharArray();
                   
                    if (DiffersByOne(source,target,out string commoncharacters))
                    {
                        System.Console.WriteLine($"{i}{j}:---{commoncharacters}");
                        break;
                    }
                }
            }
        }

        bool DiffersByOne(char[] source,char[] target,out string answer)
        {
            string common = string.Empty;
            int diff=0;
            
            for (int i = 0; i < source.Length; i++)            
            {
                if(source[i]==target[i])
                {
                    common+=source[i];
                }
                else
                {
                    diff+=1;
                }
                
                if(diff>1) 
                {
                    common = string.Empty; 
                    break;
                }
            }
            
            answer = common;
                       
            return diff == 1;
        }
    }
}