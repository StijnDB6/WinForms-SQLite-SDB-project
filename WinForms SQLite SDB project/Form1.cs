using System.Data.SQLite;
using System.Text;

namespace WinForms_SQLite_SDB_project
{
    public partial class Form1 : Form
    {
        private DatabaseHandler databaseHandler;
        public Form1()
        {
            InitializeComponent();
            databaseHandler = new DatabaseHandler(); // instance van DatabaseHandler

        }

        protected void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand cmdPerson = conn.CreateCommand();
            cmdPerson.CommandText = "CREATE TABLE IF NOT EXISTS Person (id INTEGER PRIMARY KEY AUTOINCREMENT, firstname VARCHAR(50), lastname VARCHAR(50), medicalcondition VARCHAR(50))";
            cmdPerson.ExecuteNonQuery();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Sicknesses (sickness VARCHAR(50), flu VARCHAR(50), cold VARCHAR(50), infection VARCHAR(50), wound VARCHAR(50));";
            cmd.ExecuteNonQuery();

            // aanmaken van tabel Person en tabel Sicknesses met velden

        }

        protected void InsertData(SQLiteConnection conn, string firstname, string lastname, string medicalcondition)
        {
            SQLiteCommand cmdInsert = conn.CreateCommand();
            cmdInsert.CommandText = $"INSERT INTO Person (firstname, lastname, medicalcondition) VALUES ('{firstname}', '{lastname}', '{medicalcondition}')";
            cmdInsert.ExecuteNonQuery();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Sicknesses (sickness, flu, cold, infection, wound) VALUES ('common cold', 'flu', 'rhinovirus', 'arm infection', 'open wound')";
            cmd.ExecuteNonQuery();

            // toevoegen van data in tabel Person en tabel Sicknesses
        }

        protected void ReadData(SQLiteConnection conn)
        {

            SQLiteDataReader reader;
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Person"; // neemt alles van deze tabel om later te lezen
            reader = cmd.ExecuteReader();

            StringBuilder resultText = new StringBuilder();

            while (reader.Read())
            {


                string firstName = reader["firstname"].ToString();
                string lastName = reader["lastname"].ToString();
                string medicalCondition = reader["medicalcondition"].ToString();
                

                resultText.AppendLine($"Name: {firstName} {lastName}, with medical condition: {medicalCondition}");
                // display al deze gelezen data in een bepaalde vorm 
            }

            greetingLabel.Text = resultText.ToString();
            // toon deze data in een label op de form
        }

        protected void ClearTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DROP TABLE IF EXISTS Person";
            cmd.ExecuteNonQuery();
            // ClearTable functie om de tabel leeg te maken (of helemaal te verwijderen aangezien deze toch
            // opnieuw aangemaakt wordt)
        }


        private void addPatient_Click(object sender, EventArgs e)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            SQLiteConnection connectionSQL = databaseHandler.InitiaLizeDatabase();
            CreateTable(connectionSQL);

            // als op knop 'Add patient' geklikt wordt maken we de tabellen aan



            if (DataExists(connectionSQL, textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("A person with the same credentials already exists.", "Duplicate data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.BackColor = Color.Yellow;
                textBox2.BackColor = Color.Yellow;

                // als de credentials bestaan met behulp van functie 'DataExists' dan toon een warning messagebox en kleur textboxes geel
            }
            else
            {
                InsertData(connectionSQL, textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.BackColor = SystemColors.Window;
                textBox2.BackColor = SystemColors.Window;

                // als credentials nog niet bestaan dan een textbox om success te tonen

                if (SicknessExists(connectionSQL, textBox3.Text))
                {
                    MessageBox.Show("Sickness exists.");

                    // als ziekte die ingevuld is bestaat dan toon een messagebox dat dit een gekende ziekte is

                }
                else
                {
                    MessageBox.Show("Not a known sickness");

                    // als ziekte niet gekend is in de database, toon dan messagebox dat deze niet gekend is
                }
            }



            ReadData(connectionSQL); // read data functie, en display deze dan in de label

            connectionSQL.Close();
        }

        private bool DataExists(SQLiteConnection connection, string firstname, string lastname) // functie om na te kijken of credentials al bestaan
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Person WHERE firstname = @firstname AND lastname = @lastname", connection))
            {
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                // als firstname en of lastname al in database zit dan count is hoger dan 0 en return true (credentials bestaan al)

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        private bool SicknessExists(SQLiteConnection connection, string sickness)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Sicknesses WHERE sickness = @Sickness", connection))
            {
                cmd.Parameters.AddWithValue("@Sickness", sickness);

                // kijk of een bepaalde ziekte al in database is, bijna zelfde functie als DataExists

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        private void clearDatabase_Click(object sender, EventArgs e)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            SQLiteConnection connectionSQL = databaseHandler.InitiaLizeDatabase();

            ClearTable(connectionSQL);
            greetingLabel.Text = "";
            connectionSQL.Close();

            // als op knop Clear database geklikt wordt dan gaat deze leeg met ClearTable functie en is het label ook leeg
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}