using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FileDefinitions;

namespace FileManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class FileManagementService : IFileManagementService
    {


        #region Fields

        

        #endregion

        #region Methods - IFileManagementService Implementation

        /// <summary>
        /// Adds employee to list
        /// </summary>
        /// <param name="employee">Employee information</param>
        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get employee according to username
        /// </summary>
        /// <param name="username">Employee username</param>
        /// <returns>Employee information, null if username not exists</returns>
        public Employee GetEmployee(string username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of employees</returns>
        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Login for service usage
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if successful, False if failed</returns>
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
