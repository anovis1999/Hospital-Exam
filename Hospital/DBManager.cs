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
            sqlite_conn = new SQLiteConnection(cs);
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GO DBManager.cs and replace the URI to your local path");
                Console.WriteLine();
                Console.WriteLine(ex);
            }
            return sqlite_conn;
        }
    }
}
