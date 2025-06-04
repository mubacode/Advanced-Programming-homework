using System;

namespace SharedLibrary
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InfoAttribute : Attribute
    {
        public string Author { get; set; }

        public InfoAttribute(string author)
        {
            Author = author;
        }
    }
} 