using System;
using System.Net.Mime;

namespace HomeWork04
{
    public class Quotes : News
    {
        public string Quote { get; set; }
        public string QuoteAutor { get; set; }
        public bool QuoteIsPublished { set; get; }
        public float QuoteRating { get; set; }
        public override void ShowNews()
        {
            Console.WriteLine("Id: " + base.IdNews);
            Console.WriteLine("Date: " + base.PostDate);
            Console.WriteLine("Quote: " + Quote);
            Console.WriteLine("Quote Autor: " + QuoteAutor);
        }
    }
}