using System;

namespace HomeWork03
{
    public class Article : News
    {
        public string Text { get; set; }
        public string Picture { set; get; }
        public bool IsPublished { set; get; }
        public float Rating { get; set; }
        public string Autor { get; set; }
        public override void ShowNews()
        {
            Console.WriteLine("Id: " + base.IdNews);
            Console.WriteLine("Date: " + base.PostDate);
            Console.WriteLine("Text: " + Text);
            Console.WriteLine("Picture: " + Picture);
            Console.WriteLine("Autor: " + Autor);
        }
    }
}