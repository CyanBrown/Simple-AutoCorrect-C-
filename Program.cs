using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Diagnostics;

namespace SimpleAutoCorrect
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine("Reading words...");
            string[] words = File.ReadAllLines(@"C:\Users\cyanb\source\repos\SimpleAutoCorrect\words.txt");
            for(int i = 0; i<words.Length; i++)
            {
                words[i] = words[i].Replace("\n", "").Replace("\r", "");
            }

            Console.Write("Type the word you want to check: ");
            string w = Console.ReadLine();
            Word incorrectWord = new Word(w);

            string bestWord = "";
            double bestScore = 0;

            foreach(string word in words)
            {
                SearchingAlg compare = new SearchingAlg(incorrectWord, word);
                double points = compare.GetPoints();
                //Console.WriteLine(word+" "+points.ToString());
                if (points > bestScore)
                {
                    bestWord = word;
                    bestScore = points;
                }
            }

            Console.WriteLine("The most likely word is: " + bestWord);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds);
        }
    }
}
