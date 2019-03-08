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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFileManagementService
    {
        /// <summary>
        /// Login for service usage
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if successful, False if failed</returns>
        [OperationContract]
        bool Login(string username, string password);

        /// <summary>
        /// Adds employee to list
        /// </summary>
        /// <param name="employee">Employee information</param>
        [OperationContract]
        void AddEmployee(Employee employee);

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of employees</returns>
        [OperationContract]
        List<Employee> GetEmployees();

        /// <summary>
        /// Get employee according to username
        /// </summary>
        /// <param name="username">Employee username</param>
        /// <returns>Employee information, null if username not exists</returns>
        [OperationContract]
        Employee GetEmployee(string username);
    }
}
