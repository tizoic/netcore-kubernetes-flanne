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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        protected readonly HashConfiguration _hash;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;

            var coniguration = new MapperConfiguration(cfg=> {
                cfg.AddProfile<OrganizationProfile>();
            });

            _mapper = coniguration.CreateMapper();

            _hash = new HashConfiguration();

        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<UserModel>>(_userService.GetAll()));
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        [HttpDelete("{id}")]
        public IActionResult DeteleById(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        [HttpPut()]
        public IActionResult Put([FromBody] UserModel userModel)
        {
            var coniguration = new MapperConfiguration(cfg=> {
                cfg.CreateMap<UserModel, User>();
            });
            var user = _mapper.Map<User>(userModel);
            return Ok(_mapper.Map<UserModel>(_userService.Update(user)));
        }
        
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [HttpPost()]
        public IActionResult Post([FromBody] UserCreateModel userCreateModel)
        {
            
            var user = _mapper.Map<User>(userCreateModel);
            return Ok(_mapper.Map<UserModel>(_userService.Add(user)));
        }

        // [HttpGet("password/encrypt")]
        // public IActionResult Encrypt (string password)
        // {
        //     return Ok(_hash.Encrypt(password));
        // }

        // [HttpGet("password/validade")]
        // public IActionResult Compare (string password, string hash)
        // {
        //     return Ok(_hash.ValidatePassword(password, hash));
        // }
    }
}
