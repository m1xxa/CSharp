using System;
using System.Net.Mime;

namespace HomeWork03
{
    public class Quotes : News
    {
        public string Quote { get; set; }
        public string QuoteAutor { get; set; }
        public bool IsPublished { set; get; }
        public float Rating { get; set; }
        public override void ShowNews()
        {
            Console.WriteLine("Id: " + base.IdNews);
            Console.WriteLine("Date: " + base.PostDate);
            Console.WriteLine("Quote: " + Quote);
            Console.WriteLine("Quote Autor: " + QuoteAutor);
        }
    }
}