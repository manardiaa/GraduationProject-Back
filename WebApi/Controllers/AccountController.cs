using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using BL.AppServices;
using BL.Dtos;
using Api.HelpClasses;
using System.Security.Claims;
using DAL;
using BL.StaticClasses;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountAppService _accountAppService;
        private RoleAppService _roleAppService;
        IHttpContextAccessor _httpContextAccessor;
        public AccountController(
            AccountAppService accountAppService,
            RoleAppService roleAppService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._accountAppService = accountAppService;

            this._roleAppService = roleAppService;
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _accountAppService.GetAllAccounts();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var res = _accountAppService.GetAccountById(id);
            return Ok(res);
        }

        [HttpGet("current")]
        public IActionResult GetCurrentUser()
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = _accountAppService.GetAccountById(userID);
            return Ok(res);
        }
        [HttpPost("/RegisterAdmin")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterViewodel model)
        {

            return await Register(model, UserRoles.Admin);

        }

        [HttpPost("/Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterViewodel model)
        {

            return await Register(model, UserRoles.User);
           
        }
        private async Task<IActionResult> Register(RegisterViewodel model, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_accountAppService.CheckAccountExistsByData(model))
            {
            var result = await _accountAppService.Register(model);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new Response { Status = "Error", Message = result.Errors.FirstOrDefault().Description });

            ApplicationStudentIdentity identityUser = await _accountAppService.Find(model.UserName, model.PasswordHash);
            await _accountAppService.AssignToRole(identityUser.Id, roleName);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id,RegisterViewodel registerViewodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //registerViewodel.PasswordHash = registerViewodel.ConfirmPassword = null;
            registerViewodel.PasswordHash = null;
            await _accountAppService.Update(registerViewodel);

            return Ok(new Response { Status = "Success", Message = "User updated successfully!" });

        }
        [HttpPut("updatePassword/{id}/{oldPassword}")]
        public async Task<IActionResult> UpdatePassword(string id,RegisterViewodel accountInfo,string oldPassword)
        {
            var user = await _accountAppService.UpdatePassword(id, accountInfo , oldPassword);
            return Ok(user);
        }

        [HttpPut("UpdateUserInfo/{id}")]
        public async Task<IActionResult> UpdateUserInfo(string id,RegisterViewodel accountInfo)
        {
            var user = await _accountAppService.UpdateUserInfo(id, accountInfo);
            return Ok(user);
        }

        
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _accountAppService.Find(model.UserName, model.PasswordHash);
            if (user != null )
            {
                dynamic token = await _accountAppService.CreateToken(user);
               
                return Ok(token);
            }
            return Unauthorized();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _accountAppService.DeleteAccount(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
