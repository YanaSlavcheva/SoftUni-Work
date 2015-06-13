namespace Bookmarks.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Bookmarks.Common;
    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(200, MinimumLength = 3, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string Title { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [Url(ErrorMessage = GlobalConstants.InvalidValidationMessage)]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

    }
}