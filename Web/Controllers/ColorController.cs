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
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly ILogger<ColorController> _logger;
        public ColorController(ILogger<ColorController> logger)
        {
            _logger = logger;
        }

        // GET api/<ColorController>/random
        [HttpGet]
        [ActionName("random")]
        public ColorViewModel GenerateRandomColor()
        {
            var randomRgbValues = new Random();
            var rgbString = $"rgb({randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)})";
            return ColorBuilder.BuildFromRgb(rgbString);
        }

        // POST api/<ColorController>/stringBuild
        [HttpPost]
        [ActionName("stringBuild")]
        public ColorViewModel BuildColorFromString([FromBody] BuildColorFromStringControllerModel buildColor)
        {
            ColorViewModel colorViewModel = buildColor.ColorType switch
            {
                ("rgb") => ColorBuilder.BuildFromRgb(buildColor.ColorValue, buildColor.ColorID),
                ("hsv") => ColorBuilder.BuildFromHsv(buildColor.ColorValue, buildColor.ColorID),
                ("hex") => ColorBuilder.BuildFromHex(buildColor.ColorValue, buildColor.ColorID),
                _ => throw new PostBodyException(buildColor.ColorValue, null),
            };
            return colorViewModel;
        }


    }
}
// TODO: test the endpoints
// TODO: update the endpoints called by the client reducers

// TODO: When you start working on creating profiles, set Palette api endpoints according to the paletteModel written in ClientApp/src/store/Palette