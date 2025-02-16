// ScriptureLibrary.cs
using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class ScriptureLibrary
    {
        private List<Scripture> scriptures;

        public ScriptureLibrary()
        {
            scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John 3:16"), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                new Scripture(new Reference("Proverbs 3:5-6"), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("Romans 8:28"), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."),
                new Scripture(new Reference("Philippians 4:13"), "I can do all things through Christ which strengtheneth me."),
                new Scripture(new Reference("Alma 37:6"), "By small and simple things are great things brought to pass.")
            };
        }

        public Scripture GetRandomScripture()
        {
            Random rand = new Random();
            return scriptures[rand.Next(scriptures.Count)];
        }
    }
}
