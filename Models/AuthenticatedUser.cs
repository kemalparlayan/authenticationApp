using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace authenticationApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticatedUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [BsonRepresentation(BsonType.String)]
        public string username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [BsonRepresentation(BsonType.String)]
        public string password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [BsonRepresentation(BsonType.String)]
        public string email { get; set; }

    }
}