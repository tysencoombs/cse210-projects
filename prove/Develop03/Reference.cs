using System;
using System.Collections.Generic;

// Reference.cs
namespace ScriptureMemorizer
{
    public class Reference
    {
        public string ReferenceText { get; set; }

        public Reference(string referenceText)
        {
            ReferenceText = referenceText;
        }

        public string DisplayReference()
        {
            return ReferenceText;
        }
    }
}
