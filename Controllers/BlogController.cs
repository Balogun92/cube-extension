using CubeExtension.Core.DTOs;
using CubeExtension.Core.Interfaces;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogService _service;
        public BlogController(IBlogService service)
        {
            _service = service;   
        }

        //create blog
        [HttpPost]
        public async Task<IActionResult> Create(BlogDTO req)
        {
            try
            {
                var res = await _service.Create(req);
                if (res)
                    return Ok(new ResponseDTO
                    {
                        Data = res,
                        Message = "success",
                        Status = true
                    });
                return BadRequest(new ResponseDTO
                {
                    Data = res,
                    Message = "Error Occured",
                    Status = false
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByCategory(string category)
        {
            try
            {
                var res = await _service.GetBlogByCategory(category);
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
        public async Task<IActionResult> GetSingle(string id)
        {
            try
            {
                var res = await _service.GetOne(id);
                return Ok(new ResponseDTO
                {
                    Data = res.Item1,
                    Data2 = res.Item2,
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
        public async Task<IActionResult> DeleteOne(string id)
        {
            try
            {
                var res = await _service.Delete(id);
                if(res)
                return Ok(new ResponseDTO
                {
                    Data = res,
                    Message = "success",
                    Status = true
                });
                return BadRequest(new ResponseDTO
                {
                    Data = res,
                    Message = "Error Occured",
                    Status = false
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }
    }
}
