﻿#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using System.Runtime.Serialization;

namespace AuthenticationManagement
{
    /// <summary>
    /// User information
    /// </summary>
    [DataContract(Name = "User")]
    public class User
    {
        #region Properties

        /// <summary>
        /// Name of the user
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Surname of the user
        /// </summary>
        [DataMember]
        public string Surname { get; set; }

        /// <summary>
        /// Username for login
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public User()
        {
            InitializeClass();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="user">User information</param>
        public User(User user)
        {
            if (null == user)
            {
                InitializeClass();
            }
            else
            {
                Name = user.Name;
                Surname = user.Surname;
                Username = user.Username;
                Password = user.Password;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the properties
        /// </summary>
        private void InitializeClass()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }

        #endregion

        #region Methods - Overrides

        /// <summary>
        /// Compares current object with another one
        /// </summary>
        /// <param name="obj">Object for comparison</param>
        /// <returns>True if equals, False if not</returns>
        public override bool Equals(object obj)
        {
            bool result = false;

            if (null != obj)
            {
                User comparisonElement = (User)obj;

                //Value is equal if all properties are equal
                if (string.Equals(comparisonElement.Name, this.Name) &&
                    string.Equals(comparisonElement.Surname, this.Surname) &&
                    string.Equals(comparisonElement.Username, this.Username) &&
                    string.Equals(comparisonElement.Password, this.Password))
                {
                    result = true;
                }
            }

            return result;
        }

        #endregion
    }
}
