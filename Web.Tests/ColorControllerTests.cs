using System;
using System.Net;
using System.Text;
using Xunit;
using Web.Controllers;
using Web.Models.ViewModels;
using Web.Models.ControllerModels;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using FluentAssertions;
using System.Threading.Tasks;

namespace Web.Tests
{
    public class ColorControllerTests : IntegrationTest
    {
        public ColorControllerTests(ApiWebApplicationFactory fixture) : base(fixture) { }

        [Fact]
        public async Task GET_build_random_color_controller_returns_model()
        {
            var response = await _client.GetAsync("/api/Color/Random");
            Console.WriteLine(response.StatusCode);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var randomColor = JsonSerializer.Deserialize<ColorViewModel>(await response.Content.ReadAsStringAsync());
            randomColor.Id.Should().NotBeNullOrEmpty();
            randomColor.Rgb.Should().Be(typeof(RgbViewModel));
        }


        [Fact]
        public async Task POST_build_color_from_just_string_value_returns_model()
        {

            var colorModel = new BuildColorControllerModel()
            {
                ColorType = ColorTypeControllerEnum.rgb,
                ColorString = "rgb(234, 1, 201)"
            };

            var content = new StringContent(JsonSerializer.Serialize<BuildColorControllerModel>(colorModel), Encoding.UTF8);
            var response = await _client.PostAsync("api/Color/Build", content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var builtColor = JsonSerializer.Deserialize<ColorViewModel>(await response.Content.ReadAsStringAsync());
            builtColor.Id.Should().NotBeNullOrEmpty();
            builtColor.Rgb.Should().Be(typeof(RgbViewModel));
        }
    }
}

// TODO: figure out why the tests fail