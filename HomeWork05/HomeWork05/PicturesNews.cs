using System;

namespace HomeWork05
{
    public class PicturesNews : News
    {
        public string PictureUrl { get; set; }
        public bool PictureIsPublished { set; get; }
        public float PictureRating { get; set; }
        public override void ShowNews()
        {
            Console.WriteLine("Id: " + base.IdNews);
            Console.WriteLine("Date: " + base.PostDate);
            Console.WriteLine("Picture: " + PictureUrl);
        }
    }
}