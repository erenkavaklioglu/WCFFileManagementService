#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using AuthenticationManagement;

namespace FileManagementService
{
    /// <summary>
    /// Controls authentication operations for the service
    /// </summary>
    public static class ServiceAuthenticator
    {
        #region Fields

        /// <summary>
        /// Controls authentication operations
        /// </summary>
        private static AuthenticationManager _AuthManager;

        #endregion

        #region Properties

        /// <summary>
        /// Controls authentication operations
        /// </summary>
        public static AuthenticationManager AuthManager
        {
            get
            {
                if (null == _AuthManager)
                {
                    _AuthManager = new AuthenticationManager();

                    //Generates users for test!!
                    TEST_GenerateUsers();
                }

                return _AuthManager;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Generate users for test
        /// </summary>
        private static void TEST_GenerateUsers()
        {
            User user1 = new User();
            User user2 = new User();

            user1.Name = "Walter";
            user1.Surname = "Bishop";
            user1.Username = "WBishop";
            user1.Password = "PeterBishop";

            user2.Name = "Astrid";
            user2.Surname = "Farnsworth";
            user2.Username = "Asprin";
            user2.Password = "OliviaDunham";

            AuthManager.AddUser(user1);
            AuthManager.AddUser(user2);
        }

        #endregion
    }
}
