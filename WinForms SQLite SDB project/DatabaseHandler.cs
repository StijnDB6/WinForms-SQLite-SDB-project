using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WinForms_SQLite_SDB_project
{
    public class DatabaseHandler
    {

        public SQLiteConnection InitiaLizeDatabase()
        {
            SQLiteConnection connectionSQL;

            connectionSQL = new SQLiteConnection("Data Source=person.db;Version=3;New=True;Compress=True;");

            try
            {
                connectionSQL.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database doesn't open.");
            }
            return connectionSQL;
        }
    }
}
