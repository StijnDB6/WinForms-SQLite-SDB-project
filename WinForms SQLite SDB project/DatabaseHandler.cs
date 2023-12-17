using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite; // gebruik SQLite dependency

namespace WinForms_SQLite_SDB_project
{
    public class DatabaseHandler
    {

        public SQLiteConnection InitiaLizeDatabase() // functie om connectie op te roepen
        {
            SQLiteConnection connectionSQL;

            connectionSQL = new SQLiteConnection("Data Source=person.db;Version=3;New=True;Compress=True;");
            // met welke database je verbind

            try
            {
                connectionSQL.Open();
                // connectie is open
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database doesn't open.");
                // als connectie niet werkt dan deze messagebox
            }
            return connectionSQL;
        }
    }
}
