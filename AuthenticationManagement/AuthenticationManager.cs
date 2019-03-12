#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using System;
using System.Collections.Generic;
using SysTimers = System.Timers;

namespace AuthenticationManagement
{
    /// <summary>
    /// Authentication management class
    /// </summary>
    public class AuthenticationManager
    {
        #region Constants

        /// <summary>
        /// Timeout timer interval (in ms)
        /// </summary>
        private const int TIMEOUT_TIMER_INTERVAL = 60000; //60 seconds

        #endregion

        #region Fields

        /// <summary>
        /// List of users
        /// </summary>
        private List<User> _Users;

        /// <summary>
        /// List of authenticated users
        /// </summary>
        private List<UserToken> _AuthenticatedUsers;

        /// <summary>
        /// Timer for timeout operations
        /// </summary>
        private SysTimers.Timer _TimeoutTimer;

        #endregion

        #region Properties

        /// <summary>
        /// List of users
        /// </summary>
        private List<User> Users
        {
            get
            {
                if (null == _Users)
                {
                    _Users = new List<User>();
                }

                return _Users;
            }
        }

        /// <summary>
        /// List of authenticated users
        /// </summary>
        private List<UserToken> AuthenticatedUsers
        {
            get
            {
                if (null == _AuthenticatedUsers)
                {
                    _AuthenticatedUsers = new List<UserToken>();
                }

                return _AuthenticatedUsers;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticationManager()
        {
            //No need for timeout operation !!
            //_TimeoutTimer = new SysTimers.Timer();
            //_TimeoutTimer.Elapsed += _TimeoutTimer_Elapsed;
            //_TimeoutTimer.Interval = TIMEOUT_TIMER_INTERVAL;
            //_TimeoutTimer.Start();
        }

        #endregion

        #region Eventhandlers

        /// <summary>
        /// Timer tick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _TimeoutTimer_Elapsed(object sender, SysTimers.ElapsedEventArgs e)
        {
            try
            {
                foreach (var authUser in AuthenticatedUsers)
                {
                    //Add Interval to loginTime
                    DateTime finishTime = authUser.LoginTime.AddMinutes(authUser.TimeoutInterval);

                    //Compare it with the current date time
                    if (finishTime >= DateTime.Now)
                    {
                        EndAuthentication(authUser);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds user to user list
        /// </summary>
        /// <param name="user">User information</param>
        public void AddUser(User user)
        {
            if (null != user)
            {
                Users.Add(user);
            }
        }

        /// <summary>
        /// Deletes user from list
        /// </summary>
        /// <param name="user">User information</param>
        public void DeleteUser(User user)
        {
            if (null != user)
            {
                foreach (User usr in Users)
                {
                    if (user.Equals(usr))
                    {
                        Users.Remove(usr);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Authentication for user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>UserToken returns if authentication is successful, otherwise returns null</returns>
        public UserToken Authenticate(string username, string password)
        {
            UserToken result = null;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                //Can't authenticate an already authenticated user
                if (!IsUserAuthenticated(username, password))
                {
                    //Iterate users for comparison
                    foreach (var usr in Users)
                    {
                        if (string.Equals(usr.Username, username) &&
                            string.Equals(usr.Password, password))
                        {
                            result = new UserToken(usr);
                            AuthenticatedUsers.Add(result);

                            break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Finishes the authentication for given user
        /// </summary>
        /// <param name="token">User token</param>
        public void EndAuthentication(UserToken token)
        {
            if (null != token)
            {
                AuthenticatedUsers.Remove(token);
            }
        }

        /// <summary>
        /// Checks for the authentication of given token
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        /// <returns>True if token is active, False if token is inactive</returns>
        public bool CheckAuthentication(UserToken token)
        {
            bool result = false;

            if (null != token)
            {
                foreach (var authUser in AuthenticatedUsers)
                {
                    if(token.Equals(authUser))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Finds and returns if a user is already authenticated
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if already authenticated, false otherwise</returns>
        private bool IsUserAuthenticated(string username, string password)
        {
            bool result = false;

            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                //Iterater all authenticated users
                foreach (var authUser in AuthenticatedUsers)
                {
                    if (string.Equals(authUser.Username, username) &&
                        string.Equals(authUser.Password, password))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
