#region Signature
/*
Author : Eren Kavaklıoğlu
Year   : 2019
*/
#endregion

using System.Windows;

namespace TestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region Constructors

        public LoginWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventhandlers

        /// <summary>
        /// Login button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            bool result = EmployeeManager.Login(textBoxUsername.Text, passwordBoxPassword.Password);

            MessageBox.Show("Result: " + result);
        }

        #endregion
    }
}
