using System;

namespace HomeWork04
{
    public class Article : News
    {
        public string ArticleText { get; set; }
        public string ArticlePicture { set; get; }
        public bool ArticleIsPublished { set; get; }
        public float ArticleRating { get; set; }
        public string ArticleAutor { get; set; }
        public override void ShowNews()
        {
            Console.WriteLine("Id: " + base.IdNews);
            Console.WriteLine("Date: " + base.PostDate);
            Console.WriteLine("Text: " + ArticleText);
            Console.WriteLine("Picture: " + ArticlePicture);
            Console.WriteLine("Autor: " + ArticleAutor);
        }
    }
}