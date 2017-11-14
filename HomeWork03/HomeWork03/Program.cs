using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/* TASK
 * 1. Створити базовий абстрактний клас. Мінімум 2 властивості
 * 2. Створити два дочірніх класи. Мінімум 3 властивості і всі різних типів
 * 3. Створити масив (кількість єлементів вказує користувач)
 * 4. Дати користувачеві заповнити масив. Користувач має сам обрати який саме клас (з двох дочірніх) він зараз хоче створити. 
 * 5. Користувач у будь-який момент заповнення масива може переглянути уже заповнені елементи
 */


namespace HomeWork03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter the number of news that you want to publish: ");
            int numberOfNews = Int32.Parse(Console.ReadLine());
            News[] news = new News[numberOfNews];
            for (int i = 0; i < numberOfNews; i++)
            {
                Console.Write("Please, input the type of news (Article, Quote or Picture): ");
                string type = Console.ReadLine();

                if (type == "Article")
                {
                    Article article = new Article();
                    Console.Write("Please, input the Id of Article: ");
                    article.IdNews = Int32.Parse(Console.ReadLine());
                    article.PostDate = DateTime.Today.ToString();
                    Console.Write("Please, input the text: ");
                    article.Text = Console.ReadLine();
                    Console.Write("Please, input the url of picture: ");
                    article.Picture = Console.ReadLine();
                    Console.Write("Please, input the Autor's name: ");
                    article.Autor = Console.ReadLine();
                    Console.Write("Publish now? (true or false): ");
                    article.IsPublished = bool.Parse(Console.ReadLine());
                    news[i] = article;
                }
                else if (type == "Quote")
                {
                    Quotes quote = new Quotes();
                    Console.Write("Please, input the Id of Quote: ");
                    quote.IdNews = Int32.Parse(Console.ReadLine());
                    quote.PostDate = DateTime.Today.ToString();
                    Console.Write("Please, input the text: ");
                    quote.Quote = Console.ReadLine();
                    Console.Write("Please, input the Autor's name: ");
                    quote.QuoteAutor = Console.ReadLine();
                    Console.Write("Publish now? (true or false): ");
                    quote.IsPublished = bool.Parse(Console.ReadLine());
                    news[i] = quote;
                }
                else if (type == "Picture")
                {
                    PicturesNews pictureNews = new PicturesNews();
                    Console.Write("Please, input the Id of Picture News: ");
                    pictureNews.IdNews = Int32.Parse(Console.ReadLine());
                    pictureNews.PostDate = DateTime.Today.ToString();
                    Console.Write("Please, input the url of picture: ");
                    pictureNews.PictureUrl = Console.ReadLine();
                    Console.Write("Publish now? (true or false): ");
                    pictureNews.IsPublished = bool.Parse(Console.ReadLine());
                    news[i] = pictureNews;
                }
                else if (type == "Show")
                {
                    for (int j = 0; j < i; j++)
                    {
                        news[0].ShowNews();
                    }
                }
            }
        }
        
    }
}
