using CMSAPI.JWT.Interfaces;
using CMSAPI.Models.Request;
using CMSAPI.Models.Response;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CMSAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IJwtAuthManager jwtAuthManager;

        public AccountController(IUserService pUserService, IJwtAuthManager pJwtAuthManager)
        {
            userService = pUserService;
            jwtAuthManager = pJwtAuthManager;
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = userService.GetUserAccountByAccount(request.Account);

            if (user == null)
                return Unauthorized("account not exist");

            if (!userService.IsValidUserCredentials(request.Account, request.Password))
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Account)
            };

            var jwtResult = jwtAuthManager.GenerateTokens(request.Account, claims, DateTime.Now);

            // 新增 jwt Token to Header
            HttpContext.Response.Headers.Add("accessToken", jwtResult.AccessToken);

            var result = new ResponseTemplate<LoginResponse>
            {
                Data = new LoginResponse(user)
            };

            return Ok(result);

        }


        [Authorize]
        [HttpGet]
        public ActionResult GetCurrentUser()
        {

            string account = User.Identity?.Name;

            if (string.IsNullOrEmpty("account"))
                return Unauthorized();

            var user = userService.GetUserAccountByAccount(account);

            if (user == null)
                return Unauthorized("account not exist");


            var resp = new ResponseTemplate<LoginResponse>
            {
                Data = new LoginResponse(user)
            };

            return Ok(resp);
        }


        [HttpGet]
        public ActionResult ExceptionTest()
        {
            throw new Exception("exception test");
        }

    }
}
