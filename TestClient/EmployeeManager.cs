#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using System.Collections.Generic;
using System.Linq;
using TestClient.FileManagementService;

namespace TestClient
{
    /// <summary>
    /// Employee management class
    /// </summary>
    public static class EmployeeManager
    {
        #region Fields

        /// <summary>
        /// Controls the file management service
        /// </summary>
        private static FileManagementServiceClient _serviceController;

        #endregion

        #region Properties

        /// <summary>
        /// Controls the file management service
        /// </summary>
        private static FileManagementServiceClient ServiceController
        {
            get
            {
                if (null == _serviceController)
                {
                    _serviceController = new FileManagementServiceClient();
                }

                return _serviceController;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Login for service
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if successful, False if failed</returns>
        public static bool Login(string username, string password)
        {
            return ServiceController.Login(username, password);
        }

        /// <summary>
        /// Adds employee to service
        /// </summary>
        /// <param name="employee">Employee</param>
        public static void AddEmployee(Employee employee)
        {
            ServiceController.AddEmployee(employee);
        }

        /// <summary>
        /// Gets all employees from service
        /// </summary>
        /// <returns>List of employees</returns>
        public static List<Employee> GetEmployees()
        {
            return ServiceController.GetEmployees().ToList();
        }

        #endregion
    }
}
