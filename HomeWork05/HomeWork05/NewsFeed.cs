using System.Collections.Generic;

namespace HomeWork05
{
    public class NewsFeed<TNews>
    {
        private readonly List<TNews> _news = new List<TNews>();

        public void AddNews(TNews newNews)
        {
            _news.Add(newNews);
        }
        public List<TNews> GetAllNews()
        {
            return _news;
        }
    }
}