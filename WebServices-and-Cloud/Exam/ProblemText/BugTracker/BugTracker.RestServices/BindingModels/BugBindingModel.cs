namespace BugTracker.RestServices.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class BugBindingModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}