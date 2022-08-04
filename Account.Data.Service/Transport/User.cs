using MongoDB.Bson.Serialization.Attributes;

namespace Account.Data.Service.Transport
{
    public class User
    {
        /// <summary> 
        /// The User's GUID.
        /// </summary>
        [BsonId]
        public new Guid Id { get; set; }

        /// <summary> 
        /// The User's Username.
        /// </summary>
        public string Name { get; set; }

        /// <summary> 
        /// The User's Email Address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary> 
        /// The User's Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary> 
        /// The User's Default Constructor.
        /// </summary>
        public User() { }

        /// <summary> 
        /// The User's Constructor with Id, User Name, Email Address.
        /// </summary>
        public User(Guid id, string userName, string emailAddress) 
        {
            Id = id;
            Name = userName;
            EmailAddress = emailAddress;
        }
    }
}
