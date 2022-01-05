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
        /// Usrname ve password bilgilerini DB den sorgular ve getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<AuthenticatedUser> Get()
        {
            return _authenticationService.Get();
        }
    }
}
