namespace TxtStarter.ViewModels
{
    using System.Collections.Generic;

    public class PagedCollection
    {
        public int TotalItems { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public bool IsFirstPage => PageNumber <= 1;

        public bool IsLastPage => PageNumber >= TotalPages;
    }

    public class PagedCollection<T> : PagedCollection
    {
        public PagedCollection()
        {
            Items = new List<T>();
        }

        public IList<T> Items { get; set; }
    }
}