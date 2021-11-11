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
            return ColorBuilder.BuildFromRgb(rgbString);
        }

        // POST api/<ColorController>/build
        [HttpPost, ActionName("Build")]
        public ColorViewModel BuildColorFromValues([FromBody] BuildColorControllerModel buildColor)
        {
            ColorViewModel colorViewModel = buildColor.ColorType switch
            {
                (ColorTypeControllerEnum.rgb) => ColorBuilder.BuildFromRgb(buildColor.ColorString, buildColor.ColorValues.Cast<Byte>().ToArray(), buildColor.ColorId),
                (ColorTypeControllerEnum.hsl) => ColorBuilder.BuildFromHsl(buildColor.ColorString, buildColor.ColorValues.Cast<Double>().ToArray(), buildColor.ColorId),
                (ColorTypeControllerEnum.hex) => ColorBuilder.BuildFromHex(buildColor.ColorString, buildColor.ColorId),
                _ => throw new PostBodyException(buildColor.ColorString, null),
            };
            return colorViewModel;
        }

    }
}

// TODO: test the endpoints
// TODO: update the endpoints called by the client reducers

// TODO: When you start working on creating profiles, set Palette api endpoints according to the paletteModel written in ClientApp/src/store/Palette