
namespace authenticationApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationAppDBSettings : IAuthenticationAppDBSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AuthenticationAppCollectionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DatabaseName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationAppDBSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        string AuthenticationAppCollectionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        string DatabaseName { get; set; }
    }
}