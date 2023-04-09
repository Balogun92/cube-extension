using CubeExtension.Core.DTOs;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandDTO req)
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


        //to delete
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var res = await _service.Delete(id);
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
                    Message = "Success",
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
