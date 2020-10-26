using System;
using CrecheApp.Domain.Model;
using CrecheApp.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace CrecheApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequestModel model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(UserModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.Add(account);
            return Ok();
        }

        [HttpPut]
        [Route("{globalId:guid}")]
        public IActionResult Update(Guid? globalId, [FromBody] UserModel account)
        {
            if (globalId == null)
            {
                return BadRequest("GlobalId is empty");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.Update(account);
            return Ok();
        }

        [HttpDelete]
        [Route("{globalId:guid}")]
        public IActionResult Delete(Guid? globalId)
        {
            if (globalId == null)
            {
                return BadRequest("GlobalId is empty");
            }
            _userService.Delete(globalId.Value);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet]
        [Route("{globalId:guid}")]
        public IActionResult GetByGlobalId(Guid? globalId)
        {
            if (globalId == null)
            {
                return BadRequest("GlobalId empty");
            }
            return Ok(_userService.GetByGlobalId(globalId.Value));
        }
    }
}
