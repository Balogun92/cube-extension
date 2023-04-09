using CubeExtension.Core.DTOs;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        private IApplicantService _service;

        public CareerController(IApplicantService service)
        {
            _service = service;
        }

        //to add
        [HttpPost]
        public async Task<IActionResult> Add(ApplicantDTO req )
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _service.GetAll();
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
