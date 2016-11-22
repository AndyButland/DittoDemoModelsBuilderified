namespace TxtStarter.ViewModels
{
    public class PagingDetail
    {
        public PagingDetail(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}