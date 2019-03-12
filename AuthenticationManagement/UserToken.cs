#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using System;
using System.Runtime.Serialization;

namespace AuthenticationManagement
{
    /// <summary>
    /// Token for user login
    /// </summary>
    [DataContract(Name = "UserToken")]
    public class UserToken : User
    {
        #region Constants

        /// <summary>
        /// Default timeout interval (in minutes)
        /// </summary>
        private const int DEFAULT_TIMEOUT_INTERVAL = 30;

        #endregion

        #region Properties

        /// <summary>
        /// Time of login
        /// </summary>
        [DataMember]
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// Timeout interval (in minutes)
        /// </summary>
        [DataMember]
        public int TimeoutInterval { get; set; }

        /// <summary>
        /// Guid for temporary login operation.
        /// This Guid generated at login operation and erased at timeout or logout
        /// </summary>
        [DataMember]
        public Guid TemporaryLoginID { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">User information</param>
        public UserToken(User user)
            : base(user)
        {
            LoginTime = DateTime.Now;
            TimeoutInterval = DEFAULT_TIMEOUT_INTERVAL;
            TemporaryLoginID = Guid.NewGuid();
        }

        #endregion
    }
}
