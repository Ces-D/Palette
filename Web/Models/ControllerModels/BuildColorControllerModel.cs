using System.ComponentModel.DataAnnotations;

namespace Web.Models.ControllerModels
{
    public class BuildColorControllerModel
    {
        [Required]
        public ColorTypeControllerEnum ColorType { get; set; }
        public string ColorString { get; set; }
        public string[] ColorValues { get; set; }
        public string ColorId { get; set; }
    }

}
