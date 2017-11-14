using System;

namespace HomeWork03
{
    public class PicturesNews : News
    {
        public string PictureUrl { get; set; }
        public bool IsPublished { set; get; }
        public float Rating { get; set; }
        public override void ShowNews()
        {
            Console.WriteLine("Id: " + base.IdNews);
            Console.WriteLine("Date: " + base.PostDate);
            Console.WriteLine("Picture: " + PictureUrl);
        }
    }
}