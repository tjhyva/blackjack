using System;
using System.Data;
using System.Data.SQLite;

namespace WpfBlackJack
{
    public class DB
    {        
        private static string filename = "PlayerDB.sqlite";
        private static string tablename = "players";
        public DB()
        {            
        }

        public static string AddToSQLite(string name, string email, string pwd)
        {               
            try
            {
                if(System.IO.File.Exists(filename))
                {
                    SQLiteConnection conn = new SQLiteConnection($"Data source={filename}");
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"INSERT INTO {tablename} (name, email, password, balance, win, lose) VALUES ('{name}','{email}','{pwd}',0,0,0)";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return $"Welcome new user {name}!!  ";
                }
                else
                {                       
                    throw new System.IO.FileNotFoundException("File not be found");
                }

            }
            catch (Exception)
            {

                throw;
            }            
        }

        public static DataTable Login(string name, string pwd)
        {
            try
            {
                if (System.IO.File.Exists(filename))
                {
                    SQLiteConnection conn = new SQLiteConnection($"Data source={filename}; Version=3;New=False;Compress=True");
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM {tablename} WHERE name LIKE '{name}'";                    
                    SQLiteDataReader rdr = cmd.ExecuteReader();                    
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    rdr.Close();
                    conn.Close();                    

                    if(dt.Rows.Count != 0)
                    {
                        Object balance = dt.Rows[0]["balance"];                        
                        return dt;
                    }
                    throw new System.IO.FileNotFoundException("Login fail");
                }
                else
                {
                    throw new System.IO.FileNotFoundException("Login fail");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
