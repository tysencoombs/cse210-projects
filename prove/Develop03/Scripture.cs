using System;
using System.Collections.Generic;

// Scripture.cs
using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        public Reference Reference { get; set; }
        public List<Word> Words { get; set; }

        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = new List<Word>();
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                Words.Add(new Word(word));
            }
        }

        public void DisplayScripture()
        {
            Console.WriteLine($"{Reference.DisplayReference()}");
            foreach (Word word in Words)
            {
                if (word.IsHidden)
                    Console.Write("_____ ");
                else
                    Console.Write($"{word.Text} ");
            }
            Console.WriteLine();
        }

        public void HideRandomWord()
        {
            Random random = new Random();
            int index = random.Next(0, Words.Count);
            if (!Words[index].IsHidden)
            {
                Words[index].IsHidden = true;
            }
        }

        public bool AllWordsHidden()
        {
            foreach (Word word in Words)
            {
                if (!word.IsHidden)
                    return false;
            }
            return true;
        }
    }
}
