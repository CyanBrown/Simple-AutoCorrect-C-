using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAutoCorrect
{
    class SearchingAlg
    {
        private int lengthDiff;
        private double points = 0;
        private Word incorrectWord;
        private Word guessWord;

        public SearchingAlg(Word incorrectWord, String guessWord)
        {
            this.incorrectWord = incorrectWord;
            this.guessWord = new Word(guessWord);
            lengthDiff = Math.Abs(this.guessWord.Length - this.incorrectWord.Length);

        }

        public double GetPoints()
        {
            points += CompareLetters();
            points += CompareSections();
            return points;
        }

        private double CompareSections()
        {
            double total = 0;

            foreach(string section in incorrectWord.Sections)
            {
                if (guessWord.Sections.Contains(section))
                {
                   total += section.Length * 1.8;
                }
            }

            return total;
        }

        private double CompareLetters()
        {
            double total = 0;

            for(int i = 0; i < 26; i++)
            {
                int incorrectCount = incorrectWord.Condense[i];
                int guessCount = guessWord.Condense[i];
                int diff = Math.Abs(incorrectCount - guessCount);

                if(incorrectCount == 0 || guessCount == 0)
                {
                    continue;
                }

                if (diff == 0)
                {
                    total += 5;
                } 
                else if (diff == 1)
                {
                    total += 3;
                }
                else if (diff <= 3)
                {
                    total++;
                }
            }

            if (lengthDiff <= 3)
            {
                return total/Math.Max(lengthDiff, 2);
            }

            return 0;
        }
    }
}
