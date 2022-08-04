namespace Account.Data.Service.Transport
{
    /// <summary>
    /// The Contact Model.
    /// </summary>
    public class Person : User
    {

        /// <summary> 
        /// The Person's First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary> 
        /// The Person's Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary> 
        /// The Person's Birth Date.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary> 
        /// The Person's Default Constructor.
        /// </summary>
        public Person() { }

        /// <summary> 
        /// Constructor to take in and assign First Name, Last Name, User Name, and Email Address.
        /// </summary>
        public Person(string firstName, string lastName, DateTime dateofbirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateofbirth;
        }

        /// <summary> 
        /// Constructor to take in and assign inherited properties with First Name, Last Name, User Name, and Email Address.
        /// </summary>
        public Person(Guid id, string userName, string emailAddress, 
            string firstName, string lastName, DateTime dateofbirth)
        {
            this.Id = id;
            this.Name = userName;
            this.EmailAddress = emailAddress;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateofbirth;
        }
    }
}
