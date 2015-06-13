namespace Bookmarks.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class BookmarkDetailsViewModel : IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        //public virtual IEnumerable<CommentViewModel> Comments { get; set; }

        public int Votes { get; set; }
    }
}