using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using authenticationApp.Services;
using authenticationApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace authenticationApp.Controllers
{

    /// <summary>
    /// Authenticaiton ile iligli metotları içerir.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;

        private readonly AuthenticationService _authenticationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="authenticationService"></param>
        public AuthenticationController(ILogger<AuthenticationController> logger, AuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }


        /// <summary>
        /// Returns JWT if username password verify.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public string Post([FromBody] AuthenticatedUser user)
        {
            return _authenticationService.ValidateUser(user.username, user.password);
        }
    }
}
