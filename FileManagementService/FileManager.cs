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
        #region Fields

        /// <summary>
        /// List of employees
        /// </summary>
        private static List<Employee> _Employees;

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
        /// Adds employee to list
        /// </summary>
        /// <param name="employee">Employee information</param>
        public static void AddEmployee(Employee employee)
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

        /// <summary>
        /// Returns list of all employees
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetEmployees()
        {
            return Employees;
        }

        /// <summary>
        /// Finds and returns employee according to username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Employee</returns>
        public static Employee GetEmployee(string username)
        {
            Employee result = null;

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

            return result;
        }

        #endregion
    }
}
