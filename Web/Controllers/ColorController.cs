using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Application.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Web.ViewModels;

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

        // GET api/<ColorController>
        [HttpGet]
        public Color GenerateRandomColor()
        {
            var randomRgbValues = new Random();
            var rgbString = $"rgb({randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)}, {randomRgbValues.Next(0, 255)})";
            return ColorBuilder.BuildFromRgb(rgbString);
        }

        // POST api/<ColorController>
        [HttpPost]
        public Color GenerateCompleteColorFromString([FromBody] GenerateColorModel generateColorModel)
        {
            Color color = generateColorModel.ColorType switch
            {
                ("rgb") => ColorBuilder.BuildFromRgb(generateColorModel.ColorValue, generateColorModel.ColorID),
                ("hsv") => ColorBuilder.BuildFromHsv(generateColorModel.ColorValue, generateColorModel.ColorID),
                ("hex") => ColorBuilder.BuildFromHex(generateColorModel.ColorValue, generateColorModel.ColorID),
                _ => throw new PostBodyException(generateColorModel.ColorValue, null),
            };
            return color;
        }

    }
}

// TODO: When you start working on creating profiles, set Palette api endpoints according to the paletteModel written in ClientApp/src/store/Palette