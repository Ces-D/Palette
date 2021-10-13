using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Palette.Core.Infrastructure.Models.Colors;
using Palette.Core.Infrastructure.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Palette.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        // GET: api/<ColorController>
        [HttpGet("/complimentary")]
        public IEnumerable<Color> Get()
        {
            var rgb = new Rgb(123, 20, 200);
            var color = new Color(rgb);
            var harmonies = new ColorHarmonies(color);
            return harmonies.Complimentary();
        }

        // POST api/<ColorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
