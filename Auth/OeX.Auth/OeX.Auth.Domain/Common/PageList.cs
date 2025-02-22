namespace OeX.Auth.Domain.Common
{
    public abstract class PageList
    {
        public int PageSize { get; set; } = 5;

        private int _pageNumber = 1;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value > 0 ? ++value : 1;
        }
    }
}
