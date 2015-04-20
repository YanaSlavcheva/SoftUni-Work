namespace MessagesRestService.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ChannelBindingModel
    {
        [Required(ErrorMessage = "The name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 100")]
        public string Name { get; set; }
    }
}