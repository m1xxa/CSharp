using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 В попередній домашній роботі потрібно замінити масив на свій дженерік клас. Тобто потрібно наступне:
- створити свій дженерік клас
- створити в ньому методи для додавання і вичитки даних
- замінити свій основний масив новоствореним дженеріком
*/

namespace HomeWork05
{
    class Program
    {
        static void Main(string[] args)
        {
            NewsFeed<News> newsFeed = new NewsFeed<News>();
            
            AddNews(newsFeed);
        }
        static void AddNews(NewsFeed<News> newsFeed)
        {
            bool isExit = false;
            while(!isExit)
            {
                Console.Write("Please, input the type of news (Article, Quote or Picture), Show to show all news, or Exit to exit : ");
                string type = Console.ReadLine();

                switch (type)
                {
                    case "Article":
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
                        newsFeed.AddNews(article);
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
                        newsFeed.AddNews(quote);
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
                        newsFeed.AddNews(pictureNews);
                        break;

                    case "Show":
                        foreach (var item in newsFeed.GetAllNews())
                        {
                            if (item is Article isArticle)
                            {
                                Console.WriteLine($"{isArticle.IdNews}, {isArticle.PostDate}, {isArticle.ArticleText}, " +
                                                  $"{isArticle.ArticlePicture}, {isArticle.ArticleAutor}, " +
                                                  $"{isArticle.ArticleRating}, {isArticle.ArticleIsPublished}");
                            }
                            if (item is PicturesNews isPictureNews)
                            {
                                Console.WriteLine($"{isPictureNews.IdNews}, {isPictureNews.PostDate}, {isPictureNews.PictureUrl}, " +
                                                  $"{isPictureNews.PictureRating}, {isPictureNews.PictureIsPublished}");
                            }
                            if (item is Quotes isQuote)
                            {
                                Console.WriteLine($"{isQuote.IdNews}, {isQuote.PostDate}, {isQuote.Quote}, {isQuote.QuoteAutor}, " +
                                                  $"{isQuote.QuoteRating}, {isQuote.QuoteIsPublished}");
                            }
                        }
                        break;
                    case "Exit":
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again");
                        break;
                }
            }
        }

    }
}

