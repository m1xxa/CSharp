namespace QuerryExample
{
    internal class Buyer
    {
        public Buyer(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }
        public bool IsBuyFirst { get; set; } = false;
        public bool IsBuySecond { get; set; } = false;
        public bool IsBuyThird { get; set; } = false;
    }
}
