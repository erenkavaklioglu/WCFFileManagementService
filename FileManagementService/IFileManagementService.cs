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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Name = "FileManagementService", 
                     Namespace ="http://erenkavaklioglu/WCFService")]
    public interface IFileManagementService
    {
        /// <summary>
        /// Login for service usage
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if successful, False if failed</returns>
        [OperationContract]
        UserToken Login(string username, string password);

        /// <summary>
        /// Logout from service
        /// </summary>
        /// <param name="token">User token to logout</param>
        [OperationContract]
        void Logout(UserToken token);

        /// <summary>
        /// Adds employee to list
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        /// <param name="employee">Employee information</param>
        [OperationContract]
        void AddEmployee(UserToken token, Employee employee);

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        /// <returns>List of employees</returns>
        [OperationContract]
        List<Employee> GetEmployees(UserToken token);

        /// <summary>
        /// Get employee according to username
        /// </summary>
        /// <param name="token">Token for authentication control</param>
        /// <param name="username">Employee username</param>
        /// <returns>Employee information, null if username not exists</returns>
        [OperationContract]
        Employee GetEmployee(UserToken token, string username);
    }
}
