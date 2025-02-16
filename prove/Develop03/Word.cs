using System;
using System.Collections.Generic;

// Word.cs
namespace ScriptureMemorizer
{
    public class Word
    {
        public string Text { get; set; }
        public bool IsHidden { get; set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }
    }
}
