using CubeExtension.Core.DTOs;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private IAboutService _service;
        public AboutUsController(IAboutService service)
        {
            _service = service; 
        }

        //Add 
        [HttpPost]
        public async Task<IActionResult> Add(AboutDTO req)
        {
            try
            {
                var res = await _service.Add(req);
                return Ok(new ResponseDTO
                {
                    Data = res,
                    Message = "success",
                    Status = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }

        //to get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _service.Get();
                return Ok(new ResponseDTO
                {
                    Data = res,
                    Message = "success",
                    Status  = true
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }

        //to update
        [HttpPost]
        public async Task<IActionResult> Update(AboutDTO req)
        {
            try
            {
                var res = await _service.Update(req);
                return Ok(new ResponseDTO
                {
                    Data = res,
                    Message = "success",
                    Status = true
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }
    }
}
