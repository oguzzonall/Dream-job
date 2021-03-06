﻿using CareerPortal.Business.Abstract;
using CareerPortal.Core.Dtos.Concrete.User;
using Microsoft.AspNetCore.Mvc;

namespace CareerPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("getAuth")]
        public string getAuth()
        {
            return "wadawdawwadwa";
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return Ok(userToLogin);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpPost("jobseekerregister")]
        public ActionResult JobSeekerRegister(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return Ok(userExists);
            }

            var registerResult = _authService.JobSeekerRegister(userForRegisterDto);
            if (!registerResult.Success)
            {
                return Ok(registerResult);
            }

            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpPost("jobgiverregister")]
        public ActionResult JobGiverRegister(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return Ok(userExists);
            }

            var registerResult = _authService.JobGiverRegister(userForRegisterDto);
            if (!registerResult.Success)
            {
                return Ok(userExists);
            }

            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}