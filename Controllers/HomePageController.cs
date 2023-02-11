using CubeExtension.Core.DTOs;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private IHomePageService _service;

        public HomePageController(IHomePageService service)
        {
            _service = service;
        }

        //
        [HttpPost]
        public async Task<IActionResult> Add(HomePageDTO req)
        {
            try
            {
                var res = await _service.Add(req);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
