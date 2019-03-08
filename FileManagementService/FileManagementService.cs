#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

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
        /// <param name="employee">Employee information</param>
        public void AddEmployee(Employee employee)
        {
            FileManager.AddEmployee(employee);
        }

        /// <summary>
        /// Get employee according to username
        /// </summary>
        /// <param name="username">Employee username</param>
        /// <returns>Employee information, null if username not exists</returns>
        public Employee GetEmployee(string username)
        {
            return FileManager.GetEmployee(username);
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of employees</returns>
        public List<Employee> GetEmployees()
        {
            return FileManager.GetEmployees();
        }

        /// <summary>
        /// Login for service usage
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if successful, False if failed</returns>
        public bool Login(string username, string password)
        {
            return FileManager.Login(username, password);
        }

        /// <summary>
        /// Logout from service
        /// </summary>
        public void Logout()
        {
            FileManager.Logout();
        }

        #endregion
    }
}
