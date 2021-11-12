using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Web.Models.ControllerModels;
using Web.Models.ViewModels;
using Core.Domain.Exceptions;
using Core.Application.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ColorController : ControllerBase
    {

        // GET api/<ColorController>/random
        [HttpGet]
        [ActionName("Random")]
        public ColorViewModel BuildRandomColor()
        {
            var randomRgbValues = new Random();
            var rgbString = $"rgb({randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)})";
            return (ColorViewModel)ColorBuilder.BuildFromRgb(rgbString);
        }

        // POST api/<ColorController>/Build
        [HttpPost, ActionName("Build")]
        public ActionResult<ColorViewModel> BuildColorFromModel([FromBody] BuildColorControllerModel buildColorModel)
        {
            try
            {
            var colorViewModel = buildColorModel.ColorType switch
            {
                BuildColorTypes.rgb => ColorBuilder.BuildFromRgb(buildColorModel.Color, buildColorModel.Id),
                BuildColorTypes.hsl => ColorBuilder.BuildFromHsl(buildColorModel.Color, buildColorModel.Id),
                _ => throw new PostBodyException(buildColorModel, "Error with accepting these values"),
            };
            return (ColorViewModel)colorViewModel;
            }
            catch (Exception ex)
            {
                throw new PostBodyException(ex);
            }
        }
    }
}

// TODO: controllers are not throwing any errors when inputs incorrect
// TODO: update the endpoints called by the client reducers

// TODO: When you start working on creating profiles, set Palette api endpoints according to the paletteModel written in ClientApp/src/store/Palette