using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Web.Models.ControllerModels;
using Web.Models.ViewModels;
using Core.Domain.Exceptions;
using Core.Application.Logic;
using Web.Exceptions.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ColorBuildExceptionFilter]
    public class ColorController : ControllerBase
    {

        // GET api/<ColorController>/random
        [HttpGet, ActionName("Random")]
        public ActionResult<ColorViewModel> BuildRandomColor()
        {
            var randomRgbValues = new Random();
            var rgbString = $"rgb({randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)})";
            var colorEntity = ColorBuilder.BuildFromRgb(rgbString);

            return (ColorViewModel)colorEntity;
            
        }

        // POST api/<ColorController>/Build
        [HttpPost, ActionName("Build")]
        public ActionResult<ColorViewModel> BuildColorFromModel([FromBody] BuildColorControllerModel buildColorModel)
        {
            var colorEntity = buildColorModel.ColorType switch
            {
                BuildColorTypes.rgb => ColorBuilder.BuildFromRgb(buildColorModel.Color, buildColorModel.Id),
                BuildColorTypes.hsl => ColorBuilder.BuildFromHsl(buildColorModel.Color, buildColorModel.Id),
                _ => throw new PostBodyException(buildColorModel, "Error with accepting these values"),
            };
            return (ColorViewModel)colorEntity;

        }
    }
}
// TODO: When you start working on creating profiles, set Palette api endpoints according to the paletteModel written in ClientApp/src/store/Palette