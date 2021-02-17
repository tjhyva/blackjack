using System;
using System.Windows;

namespace WpfBlackJack
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void btnRegisterRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string register = WpfBlackJack.DB.AddToSQLite(txbUsernameRegister.Text, txbEmailRegister.Text, pwbPasswordRegister.Password);
                MainWindow mainWindow = new MainWindow();                
                this.Close();
                mainWindow.lblMessages.Text = register;
                mainWindow.ShowDialog();
            }
            catch (Exception)
            {
                lblMessagesRegister.Text = "Email allrdy use.";                
            }
        }        

        private void txbUsernameRegister_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbUsernameRegister.Text == "Username")
            {
                txbUsernameRegister.Text = "";
            }
        }

        private void txbEmailRegister_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbEmailRegister.Text == "Email")
            {
                txbEmailRegister.Text = "";
            }
        }
    }
}
