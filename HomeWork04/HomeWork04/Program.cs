using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/* TASK
- Доопрацювати попереднє завдання:
    1. Створити базовий абстрактний клас. Мінімум 2 властивості
    2. Створити два дочірніх класи. Мінімум 3 властивості і всі різних типів
    3. Створити масив (кількість єлементів вказує користувач)
    4. Дати користувачеві заповнити масив. Користувач має сам обрати який саме тип (з двох    дочірніх) він зараз хоче створити. 
    5. Користувач у будь-який момент заповнення масива може переглянути уже заповнені  елементи

- При цьому дотримуватися наступних правил:
     1. Користувач повинен самостійно задати значення для кожної властивості об'єкта, що створюється
      2. Назви властивостей не повинні співпадати у дочірніх класах
      3. При виведенні на екран повинні виводитися усі властивості зазначені у створеному екземплярі
       4. Не використовувати метод ToString для дочірніх класів

Ріхтер: 124-128, 485-495
 */


namespace HomeWork04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter the number of news that you want to publish: ");
            int numberOfNews = 0;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out numberOfNews);
                if (numberOfNews > 0) break;
                else Console.WriteLine("Incorrect number, try again: ");
            }

            News[] allNews = new News[numberOfNews];

            AddNews(allNews, numberOfNews);
        }
        static void AddNews(News[] news, int numberOfNews)
        {
            for (int i = 0; i < numberOfNews; i++)
            {
                Console.Write("Please, input the type of news (Article, Quote or Picture): ");
                string type = Console.ReadLine();

                switch (type)
                {
                    case "Article" :
                        Article article = new Article();
                        Console.Write("Please, input the Id of Article: ");
                        while (true)
                        {
                            int.TryParse(Console.ReadLine(), out int idNews);
                            if (idNews > 0)
                            {
                                article.IdNews = idNews;
                                break;
                            }
                            else Console.WriteLine("Incorrect number, try again: ");
                        }
                        article.PostDate = DateTime.Today.ToString();
                        Console.Write("Please, input the text: ");
                        article.ArticleText = Console.ReadLine();
                        Console.Write("Please, input the url of picture: ");
                        article.ArticlePicture = Console.ReadLine();
                        Console.Write("Please, input the Autor's name: ");
                        article.ArticleAutor = Console.ReadLine();
                        Console.Write("Publish now? (true or false): ");
                        article.ArticleIsPublished = bool.Parse(Console.ReadLine());
                        news[i] = article;
                        break;

                    case "Quote":
                        Quotes quote = new Quotes();
                        Console.Write("Please, input the Id of Quote: ");
                        while (true)
                        {
                            int.TryParse(Console.ReadLine(), out int idNews);
                            if (idNews > 0)
                            {
                                quote.IdNews = idNews;
                                break;
                            }
                            else Console.WriteLine("Incorrect number, try again: ");
                        }
                        quote.PostDate = DateTime.Today.ToString();
                        Console.Write("Please, input the text: ");
                        quote.Quote = Console.ReadLine();
                        Console.Write("Please, input the Autor's name: ");
                        quote.QuoteAutor = Console.ReadLine();
                        Console.Write("Publish now? (true or false): ");
                        quote.QuoteIsPublished = bool.Parse(Console.ReadLine());
                        news[i] = quote;
                        break;
                    case "Picture":
                        PicturesNews pictureNews = new PicturesNews();
                        Console.Write("Please, input the Id of Picture News: ");
                        while (true)
                        {
                            int.TryParse(Console.ReadLine(), out int idNews);
                            if (idNews > 0)
                            {
                                pictureNews.IdNews = idNews;
                                break;
                            }
                            else Console.WriteLine("Incorrect number, try again: ");
                        }
                        pictureNews.PostDate = DateTime.Today.ToString();
                        Console.Write("Please, input the url of picture: ");
                        pictureNews.PictureUrl = Console.ReadLine();
                        Console.Write("Publish now? (true or false): ");
                        pictureNews.PictureIsPublished = bool.Parse(Console.ReadLine());
                        news[i] = pictureNews;
                        break;

                    case "Show":
                        for (int j = 0; j < i; j++)
                        {
                            News currentNews = news[j] as Article;
                            if (currentNews != null)
                            {
                                Console.WriteLine("its Article");
                            }
                            currentNews = news[j] as PicturesNews;
                            if (currentNews != null)
                            {
                                Console.WriteLine("its PictureNews");
                            }
                            currentNews = news[j] as Quotes;
                            if (currentNews != null)
                            {
                                Console.WriteLine("its Quote");
                            }
                        }
                        if (i != 0) i--;
                        break;

                    default:
                        if (i != 0) i--;
                        Console.WriteLine("Invalid input, try again");
                        break;
                } 
            }
        }
    }
}
