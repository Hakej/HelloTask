﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloTask.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler)
            : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("user1@email.com", "admin");

            return Json(token);
        }

        [HttpGet]
        [Authorize(policy: "admin")]
        [Route("auth")]
        public IActionResult GetAuth()
        {
            return Content("Auth");
        }
    }
}
