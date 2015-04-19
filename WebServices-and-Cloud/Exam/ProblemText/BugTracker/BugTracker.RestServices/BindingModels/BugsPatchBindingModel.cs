namespace BugTracker.RestServices.BindingModels
{
    using BugTracker.Data.Models;

    public class BugsPatchBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }
    }
}