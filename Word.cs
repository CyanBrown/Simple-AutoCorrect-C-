using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAutoCorrect
{
    class Word
    {
        public string alphabet = "abcdefghijklmnopqrstuvwxyz";

        private int length;
        private int[] condense = new int[26];
        private List<String> sections = new List<String>();
        private string word;

        public int Length { get { return length; } }
        public int[] Condense { get { return condense; } }
        public List<String> Sections { get { return sections; } }
        public string GetWord { get { return word; } }

        public Word(String word)
        {
            this.word = word;
            CondenseWord();
            SectionWord();
        }

        private void CondenseWord()
        {
            foreach(char c in word)
            {
                try {
                    condense[alphabet.IndexOf(c)]++;
                } 
                catch
                {
                  
                }
                
            }
        }

        private void SectionWord()
        {
            for(int i = 0; i<word.Length; i++)
            {
                sections.Add(word.Substring(i));
                sections.Add(word.Substring(0, word.Length - i));
            }

            sections.Remove("");
            sections.Remove(word);
        }

        public override string ToString()
        {
            return word;
        }
    }
}
