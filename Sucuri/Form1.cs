using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Sucuri
{
    public partial class Form1 : Form
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
        SqlCommand sCommand;
        SqlDataAdapter sAdapter;
        SqlCommandBuilder sBuilder;
        DataSet sDs;
        DataTable sTable;

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "Select * FROM Sucuri"; //Comanda sql de select
            SqlConnection connection = new SqlConnection(connectionString); // conectiunea
            connection.Open(); // deschiderea si activarea
            sCommand = new SqlCommand(sql, connection); // se utilizeaza comanda sql si connection
            sAdapter = new SqlDataAdapter(sCommand); // utilizarea comenzii command
            sBuilder = new SqlCommandBuilder(sAdapter); // adapter
            sDs = new DataSet(); //crearea DataSet
            sAdapter.Fill(sDs, "Sucuri"); //Folosirea adapterului asupra tabelului elev
            sTable = sDs.Tables["Sucuri"]; // folosirea table asupra tabelului elev
            connection.Close(); // inchiderea conectiunii
            // TODO: This line of code loads data into the 'database1DataSet.Sucuri' table. You can move, or remove it, as needed.
            this.sucuriTableAdapter.Fill(this.database1DataSet.Sucuri);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //            DataRow newline = this.database1DataSet.Tables["Sucuri"].NewRow();

            if (!( (textBox1.Text == null || textBox1.Text == "Id_produs")
                && (textBox2.Text == null || textBox2.Text == "NumeSuc")
                && (textBox3.Text == null || textBox3.Text == "Pret")
                && (textBox4.Text == null || textBox4.Text == "ProcentZahar")
                && (textBox5.Text == null || textBox5.Text == "ProcentFructe")
                && (textBox6.Text == null || textBox6.Text == "NrDeVanzari")
                && (textBox7.Text == null || textBox7.Text == "TimpulMediuDeVanzari")
                ))
            {
                /*
                newline["Id_produs"] = Int32.Parse(textBox1.Text); 
                newline["NumeSuc"] = textBox2.Text; ;
                newline["Pret"] = Int32.Parse(textBox3.Text); ;
                newline["ProcentZahar"] = Int32.Parse(textBox4.Text); ;
                newline["ProcentFructe"] = Int32.Parse(textBox5.Text); ;
                newline["Natural"] = checkBox1.Checked; ;
                newline["NrDeVanzari"] = Int32.Parse(textBox6.Text); ;
                newline["TimpulMediuDeVanzare"] = Int32.Parse(textBox7.Text); ;
                */
                /*
                int tmp_check = 0;
                if (checkBox1.Checked == true)
                    tmp_check = 1;

                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
                          System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("INSERT INTO dbo.Sucuri(Id_produs,  NumeSuc, Pret, Natural, ProcentZahar, ProcentFructe, NrDeVanzari, TimpulMediuDeVanzare) VALUES({0}, N'{1}', {2}, {3}, {4}, {5}, {6}, {7})",
                    Int32.Parse(textBox1.Text), textBox2.Text, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), tmp_check, Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text));
                cmd.Connection = sqlConnection1;
                Console.WriteLine(cmd.CommandText);

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                */
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
                string sql = "SELECT * FROM Sucuri";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                foreach (DataGridViewColumn col in this.dataGridView1.Columns)
                { 
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                int tmp_check = 0;
                if (checkBox1.Checked == true)
                    tmp_check = 1;

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("INSERT INTO dbo.Sucuri(Id_produs,  NumeSuc, Pret, Natural, ProcentZahar, ProcentFructe, NrDeVanzari, TimpulMediuDeVanzare) VALUES({0}, N'{1}', {2}, {3}, {4}, {5}, {6}, {7})",
                    Int32.Parse(textBox1.Text), textBox2.Text, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), tmp_check, Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text));
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.sCommand = new SqlCommand(sql, connection);
                this.sAdapter = new SqlDataAdapter(sCommand);
                this.sBuilder = new SqlCommandBuilder(sAdapter);
                this.sDs = new DataSet();
                this.sAdapter.Fill(sDs, "Sucuri");
                this.sTable = sDs.Tables["Sucuri"];
                this.sAdapter.Update(sTable);
                connection.Close();
                dataGridView1.DataSource = sDs.Tables["Sucuri"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                /*
                Database1DataSet.SucuriRow newSucuriRow;
                newSucuriRow = this.database1DataSet.Sucuri.NewSucuriRow();
                newSucuriRow.Id_produs = Int32.Parse(textBox1.Text);
                newSucuriRow.NumeSuc = textBox2.Text; 
                newSucuriRow.Pret = Int32.Parse(textBox3.Text);
                newSucuriRow.ProcentZahar = Int32.Parse(textBox4.Text);
                newSucuriRow.ProcentFructe = Int32.Parse(textBox5.Text);
                newSucuriRow.Natural = checkBox1.Checked;
                newSucuriRow.NrDeVanzari = Int32.Parse(textBox6.Text);
                newSucuriRow.TimpulMediuDeVanzare = Int32.Parse(textBox7.Text);
                try
                {
                    //TODO: add if if index in not good, show 
                    // Add the row to the Region table
                    this.database1DataSet.Sucuri.Rows.Add(newSucuriRow);
                    //this.database1DataSet.Tables["Sucuri"].Rows.Add(newline);
                    // Save the new row to the database
                    this.sucuriTableAdapter.Update(this.database1DataSet.Sucuri);

                    this.dataGridView1.Update();
                }
                catch
                {
                    Console.Write("oh noe!");
                }
             */ 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(textBox8.Text == null || textBox8.Text == "Codul Produsului"))
            {
                database1DataSet.Sucuri.Rows[Int32.Parse(textBox8.Text) - 1].Delete();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int min = 500000;
            foreach (DataRow row in this.sTable.Rows)
            {
                if (Int32.Parse(row["Pret"].ToString()) < min)
                    min = Int32.Parse(row["Pret"].ToString());
                
            }
            label1.Text = min.ToString();
        }

    }
}
