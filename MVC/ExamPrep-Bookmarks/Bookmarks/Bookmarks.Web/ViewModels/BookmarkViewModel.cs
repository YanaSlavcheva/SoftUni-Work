namespace Bookmarks.Web.ViewModels
{
    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class BookmarkViewModel : IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}