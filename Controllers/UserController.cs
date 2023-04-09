using CubeExtension.Core.DTOs;
using CubeExtension.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubeExtension.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService _service)
        {
            this._service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterUserDTO req)
        {
            try
            {
                var res = await _service.Login(req);
                if (res.Item1)
                {
                    var mod = new LoginResDTO
                    {
                        Email = res.Item3.Email,
                        Username = res.Item3.Username,
                    };
                    return Ok(new ResponseDTO
                    {
                        Data = mod,
                        Message = res.Item2,
                        Status = res.Item1
                    });
                }

                  
                return BadRequest(new ResponseDTO
                {
                    Data = res.Item3,
                    Message = res.Item2,
                    Status = res.Item1
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }


        //to create user, initial adminuser would be created
        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserDTO req)
        {
            try
            {
                var res = await _service.CreateUser(req);
                if (res.Item1)
                {
                 
                    return Ok(new ResponseDTO
                    {
                        Data = res.Item1,
                        Message = res.Item2,
                        Status = res.Item1
                    });
                }


                return BadRequest(new ResponseDTO
                {
                    Data = res.Item1,
                    Message = res.Item2,
                    Status = res.Item1
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message ?? ex.InnerException?.Message);
            }
        }



    }
}
