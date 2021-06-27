using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Hospital
{
    class DBManager
    {

        public static SQLiteConnection CreateConn()
        {
            string cs = @"URI=file:C:\Users\user\source\repos\mamas\Hospital\Hospital\database.db";
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(cs);
            // Open the connection:
            try
            {
                sqlite_conn.Open();
                //Console.WriteLine("Connection Created Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return sqlite_conn;
        }
    }
}
