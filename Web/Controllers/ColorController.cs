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

        // POST api/<ColorController>
        [HttpPost]
        public Color GenerateColor([FromBody] GenerateColorModel generateColorModel)
        {
            Color color = generateColorModel.ColorType switch
            {
                ("rgb") => ColorBuilder.BuildFromRgb(generateColorModel.ColorValue),
                ("hsv") => ColorBuilder.BuildFromHsv(generateColorModel.ColorValue),
                ("hex") => ColorBuilder.BuildFromHex(generateColorModel.ColorValue),
                _ => throw new PostBodyException(generateColorModel.ColorValue, null),
            };
            return color;
        }

    }
}

