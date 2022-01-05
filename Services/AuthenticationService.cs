using authenticationApp.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace authenticationApp.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationService
    {
        private readonly IMongoCollection<AuthenticatedUser> _authenticatedUsers;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public AuthenticationService(IAuthenticationAppDBSetings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _authenticatedUsers = database.GetCollection<AuthenticatedUser>(settings.AuthenticationAppCollectionName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AuthenticatedUser> Get() => _authenticatedUsers.Find(user => true).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticatedUser Get(string id) => _authenticatedUsers.Find(user => user.Id == id).FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public AuthenticatedUser Create(AuthenticatedUser user)
        {
            _authenticatedUsers.InsertOne(user);
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedUser"></param>
        public void Update(string id, AuthenticatedUser updatedUser) => _authenticatedUsers.ReplaceOne(game => game.Id == id, updatedUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userForDeletion"></param>
        public void Delete(AuthenticatedUser userForDeletion) => _authenticatedUsers.DeleteOne(game => game.Id == userForDeletion.Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id) => _authenticatedUsers.DeleteOne(user => user.Id == id);
    }
}