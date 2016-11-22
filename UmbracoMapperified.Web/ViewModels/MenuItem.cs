namespace UmbracoMapperified.Web.ViewModels
{
    using Zone.UmbracoMapper;

    public class MenuItem : BaseNodeViewModel
    {
        private string _title;

        public string Title
        {
            get
            {
                return string.IsNullOrEmpty(_title) ? Name : _title;
            }

            set
            {
                _title = value;
            }
        }

        public bool IsActive { get; set; }
    }
}
