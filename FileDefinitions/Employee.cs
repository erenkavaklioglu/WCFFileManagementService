#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using System.Runtime.Serialization;

namespace FileDefinitions
{
    /// <summary>
    /// File type for employee information
    /// </summary>
    [DataContract(Name = "Employee")]
    public class Employee
    {
        #region Properties

        /// <summary>
        /// Employee name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Employee Surname
        /// </summary>
        [DataMember]
        public string Surname { get; set; }

        /// <summary>
        /// Employee username
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// Employee e-mail address
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Employee age
        /// </summary>
        [DataMember]
        public int Age { get; set; }

        /// <summary>
        /// Title of the employee
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Annual salary of the employee (in $)
        /// </summary>
        [DataMember]
        public decimal Salary { get; set; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Employee()
        {
            InitializeClass();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="employee">Item to be copied</param>
        public Employee(Employee employee)
        {
            if (null == employee)
            {
                InitializeClass();
            }
            else
            {
                Name = employee.Name;
                Surname = employee.Surname;
                Username = employee.Username;
                Email = employee.Email;
                Age = employee.Age;
                Title = employee.Title;
                Salary = employee.Salary;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the class
        /// </summary>
        private void InitializeClass()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Username = string.Empty;
            Email = string.Empty;
            Age = -1; //No age defined
            Title = string.Empty;
            Salary = -1; //No salary defined
        }

        #endregion
    }
}
