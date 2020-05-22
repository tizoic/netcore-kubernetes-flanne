using System;
using System.Collections.Generic;
using AutoMapper;
using backend.Api.Configurations;
using backend.Api.Models;
using backend.Api.Profiles;
using backend.Domain.Entities;
using backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        protected readonly HashConfiguration _hash;

        public LoginController(ILogger<LoginController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;

            var coniguration = new MapperConfiguration(cfg=> {
                cfg.AddProfile<OrganizationProfile>();
            });

            _mapper = coniguration.CreateMapper();

            _hash = new HashConfiguration();

        }
     
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost("authenticated")]
        public IActionResult Post([FromBody] LoginModel loginModel)
        {
            var user = _userService.GetbyLogin(loginModel.username);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(_hash.ValidatePassword(loginModel.password, user.Password));
        }
    }
}
