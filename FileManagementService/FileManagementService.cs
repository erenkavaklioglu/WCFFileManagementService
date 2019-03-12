#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using AuthenticationManagement;
using FileDefinitions;
using System.Collections.Generic;
using System.ServiceModel;

namespace FileManagementService
{
    public class FileManagementService : IFileManagementService
    {
        #region Methods - IFileManagementService Implementation

        /// <summary>
        /// Adds employee to list
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        /// <param name="employee">Employee information</param>
        public void AddEmployee(UserToken token, Employee employee)
        {
            if (ServiceAuthenticator.AuthManager.CheckAuthentication(token))
            {
                FileManager.AddEmployee(employee);
            }
        }

        /// <summary>
        /// Get employee according to username
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        /// <param name="username">Employee username</param>
        /// <returns>Employee information, null if username not exists</returns>
        public Employee GetEmployee(UserToken token, string username)
        {
            Employee result = null;

            if (ServiceAuthenticator.AuthManager.CheckAuthentication(token))
            {
                result = FileManager.GetEmployee(username);
            }

            return result;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        /// <returns>List of employees</returns>
        public List<Employee> GetEmployees(UserToken token)
        {
            List<Employee> result = null;

            if (ServiceAuthenticator.AuthManager.CheckAuthentication(token))
            {
                result = FileManager.GetEmployees();
            }

            return result;
        }

        /// <summary>
        /// Login for service usage
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Token for the user</returns>
        public UserToken Login(string username, string password)
        {
            return ServiceAuthenticator.AuthManager.Authenticate(username, password);
        }

        /// <summary>
        /// Logout from service
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        public void Logout(UserToken token)
        {
            ServiceAuthenticator.AuthManager.EndAuthentication(token);
        }

        #endregion
    }
}
