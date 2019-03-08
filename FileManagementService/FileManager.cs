#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using FileDefinitions;
using System.Collections.Generic;

namespace FileManagementService
{
    /// <summary>
    /// File management class
    /// </summary>
    public static class FileManager
    {
        #region Constants

        /// <summary>
        /// Username for login
        /// </summary>
        private const string USERNAME = "Administrator";

        /// <summary>
        /// Password for login
        /// </summary>
        private const string PASSWORD = "LogMeIn";

        #endregion

        #region Fields

        /// <summary>
        /// List of employees
        /// </summary>
        private static List<Employee> _Employees;

        /// <summary>
        /// System login status
        /// </summary>
        private static bool _loggedIn;

        #endregion

        #region Properties

        /// <summary>
        /// List of employees
        /// </summary>
        private static List<Employee> Employees
        {
            get
            {
                if (null == _Employees)
                {
                    _Employees = new List<Employee>();
                }

                return _Employees;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Login for service usage
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if successful, False if failed</returns>
        public static bool Login(string username, string password)
        {
            _loggedIn = false;

            if (string.Equals(username, USERNAME) &&
                string.Equals(password, PASSWORD))
            {
                _loggedIn = true;
            }

            return _loggedIn;
        }

        /// <summary>
        /// Logoout from service
        /// </summary>
        public static void Logout()
        {
            _loggedIn = false;
        }

        /// <summary>
        /// Adds employee to list
        /// </summary>
        /// <param name="employee">Employee information</param>
        public static void AddEmployee(Employee employee)
        {
            if (_loggedIn)
            {
                if (null != employee)
                {
                    Employee searchedEmployee = GetEmployee(employee.Username);

                    //Don't add item if same username exists
                    if (null == searchedEmployee)
                    {
                        Employees.Add(employee);
                    }
                }
            }
        }

        /// <summary>
        /// Returns list of all employees
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetEmployees()
        {
            List<Employee> result = null;

            if (_loggedIn)
            {
                result = Employees;
            }

            return result;
        }

        /// <summary>
        /// Finds and returns employee according to username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Employee</returns>
        public static Employee GetEmployee(string username)
        {
            Employee result = null;

            if (_loggedIn)
            {
                if (!string.IsNullOrEmpty(username))
                {
                    //Search for the same username
                    foreach (Employee employee in Employees)
                    {
                        if (string.Equals(username, employee.Username))
                        {
                            result = employee;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
