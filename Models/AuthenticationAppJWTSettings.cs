
namespace authenticationApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationAppJWTSettings : IAuthenticationAppJWTSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Secret { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationAppJWTSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        string Secret { get; set; }
    }
}