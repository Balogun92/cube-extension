using CubeExtension.Core.DTOs;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompetenciesController : ControllerBase
    {
        private ICompService _service;
        public CompetenciesController(ICompService service)
        {
            _service = service;
        }

        //Add List
        [HttpPost]
        public async Task<IActionResult> AddList(CompListDTO req)
        {
            try
            {
                var res = await _service.AddCompList(req);
                return Ok(new ResponseDTO
                {
                    Data = res,
                    Message = "success",
                    Status = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException.Message);
            }
        }

        //Add List
        [HttpPost]
        public async Task<IActionResult> AddWhy(CompWhyDTO req)
        {
            try
            {
                var res = await _service.AddCompWhy(req);
                return Ok(new ResponseDTO
                {
                    Data = res,
                    Message = "success",
                    Status = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException.Message);
            }
        }

        //to get
        [HttpGet]
        public async Task<IActionResult> GetCompList()
        {
            try
            {
                var res = await _service.GetCompList();
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

        [HttpGet]
        public async Task<IActionResult> GetCompWhyList()
        {
            try
            {
                var res = await _service.GetCompWhyList();
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
        public async Task<IActionResult> DeleteCompList(string id)
        {
            try
            {
                var res = await _service.DeleteCompList(id);
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
        public async Task<IActionResult> DeleteCompWhyList(string id)
        {
            try
            {
                var res = await _service.DeleteWhyCompList(id);
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

    }
}
