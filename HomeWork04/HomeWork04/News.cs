namespace HomeWork04
{
    public abstract class News
    {
        public int IdNews { get; set;  }
        public string PostDate { get; set; }
        public abstract void ShowNews();
    }
}