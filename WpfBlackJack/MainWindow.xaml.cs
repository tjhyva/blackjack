using System;
using System.Data.SQLite;
using System.Windows;

namespace WpfBlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string filename = "PlayerDB.sqlite";
        private static string tablename = "players";
        public MainWindow()
        {           
            InitializeComponent();
            CreateDataBase();
        }

        private void CreateDataBase()
        {
            if (!System.IO.File.Exists(filename))
            {
                SQLiteConnection.CreateFile(filename);

                SQLiteConnection conn = new SQLiteConnection($"Data Source={filename};Version=3;");
                conn.Open();

                string sql = $"create table {tablename} (player_id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, email  TEXT NOT NULL UNIQUE, password TEXT NOT NULL, balance DECIMAL(28, 2), win int, lose int)";

                SQLiteCommand command = new SQLiteCommand(sql, conn);

                command.ExecuteNonQuery();
                conn.Close();
                lblMessages.Text = "new database created";
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {            
            RegisterWindow registerWindow = new RegisterWindow();
            this.Close();
            registerWindow.ShowDialog();            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                WpfBlackJack.DB.Login(txbUsername.Text, pwbPassword.Password);
                PlayWindow playWindow = new PlayWindow();
                playWindow.txbPlayer.Text = "Tomi";
                playWindow.txbBalance.Text = "27";
                this.Close();
                playWindow.ShowDialog();
                
            }
            catch (Exception)
            {
                lblMessages.Text = "Username or password not mach";                
            }
        }
    }
}
