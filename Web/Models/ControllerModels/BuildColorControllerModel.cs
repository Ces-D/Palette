using System.ComponentModel.DataAnnotations;
using Core.Domain.Interfaces;

namespace Web.Models.ControllerModels
{
    public record BuildColorControllerModel : IColor
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public BuildColorTypes ColorType { get; set; }

        [Required]
        public string Color { get; set; }

    }

}