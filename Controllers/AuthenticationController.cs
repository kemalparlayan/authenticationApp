using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using authenticationApp.Services;
using authenticationApp.Models;

namespace authenticationApp.Controllers
{

    /// <summary>
    /// Authenticaiton ile iligli metotları içerir.
    /// </summary>
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
        /// Kullanıcı doğrulanırsa JWT dönecek
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post([FromBody] AuthenticatedUser user)
        {
            return _authenticationService.ValidateUser(user.username, user.password);
        }
    }
}
