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

        SqlCommand sCommand2;
        SqlDataAdapter sAdapter2;
        SqlCommandBuilder sBuilder2;
        DataSet sDs2;
        DataTable sTable2;

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

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "Procent_Zahar")
            {

                string sql = "SELECT * FROM Sucuri WHERE ProcentZahar < " + textBox9.Text;

                SqlConnection connection = new SqlConnection(connectionString);
                sCommand = new SqlCommand(sql, connection); // se utilizeaza comanda sql si connection

                sAdapter = new SqlDataAdapter(sCommand);
                sBuilder = new SqlCommandBuilder(sAdapter); // adapter
                connection.Open();
                sDs = new DataSet(); //crearea DataSet
                sAdapter.Fill(sDs, "Sucuri"); //Folosirea adapterului asupra tabelului elev
                sTable = sDs.Tables["Sucuri"]; // folosirea table asupra tabelului elev
                connection.Close();

                dataGridView1.DataSource = sDs.Tables["Sucuri"];
                this.dataGridView1.Sort(this.dataGridView1.Columns["Pret"], ListSortDirection.Descending);

            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
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
            dataGridView1.DataSource = sDs.Tables["Sucuri"];
            this.sucuriTableAdapter.Fill(this.database1DataSet.Sucuri);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "ProcentZahar" && textBox11.Text != null &&
                textBox10.Text != "ProcentFructe" && textBox10.Text != null)
            {

                string sql = "SELECT * FROM Sucuri WHERE ProcentFructe > " + textBox10.Text +
                     " AND ProcentZahar = " + textBox11.Text;

                SqlConnection connection = new SqlConnection(connectionString);
                sCommand = new SqlCommand(sql, connection); // se utilizeaza comanda sql si connection

                sAdapter = new SqlDataAdapter(sCommand);
                sBuilder = new SqlCommandBuilder(sAdapter); // adapter
                connection.Open();
                sDs = new DataSet(); //crearea DataSet
                sAdapter.Fill(sDs, "Sucuri"); //Folosirea adapterului asupra tabelului elev
                sTable = sDs.Tables["Sucuri"]; // folosirea table asupra tabelului elev
                connection.Close();

                dataGridView1.DataSource = sDs.Tables["Sucuri"];
                this.dataGridView1.Sort(this.dataGridView1.Columns["Pret"], ListSortDirection.Descending);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "Select MAX(NrDeFolosire) AS MaxFolosire FROM Fructe"; //Comanda sql de select
            SqlConnection connection = new SqlConnection(connectionString); // conectiunea
            connection.Open(); // deschiderea si activarea
            sCommand2 = new SqlCommand(sql, connection); // se utilizeaza comanda sql si connection
            sAdapter2 = new SqlDataAdapter(sCommand2); // utilizarea comenzii command
            sBuilder2 = new SqlCommandBuilder(sAdapter2); // adapter
            sDs2 = new DataSet(); //crearea DataSet
            sAdapter2.Fill(sDs2, "Fructe"); //Folosirea adapterului asupra tabelului elev
            sTable2 = sDs2.Tables["Fructe"]; // folosirea table asupra tabelului elev
            connection.Close(); // inchiderea conectiunii
                                // TODO: This line of code loads data into the 'database1DataSet.Sucuri' table. You can move, or remove it, as needed.
            foreach (DataRow row in this.sTable2.Rows)
            {
                label2.Text = row["MaxFolosire"].ToString();
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string sql = "SELECT Id_produs, NumeSuc, ProcentFructe, ProcentZahar, Natural FROM Sucuri";

            SqlConnection connection = new SqlConnection(connectionString);
            sCommand = new SqlCommand(sql, connection); // se utilizeaza comanda sql si connection

            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter); // adapter
            connection.Open();
            sDs = new DataSet(); //crearea DataSet
            sAdapter.Fill(sDs, "Sucuri"); //Folosirea adapterului asupra tabelului elev
            sTable = sDs.Tables["Sucuri"]; // folosirea table asupra tabelului elev
            connection.Close();

            dataGridView1.DataSource = sDs.Tables["Sucuri"];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "Select AVG(Pret) AS Naturals FROM Sucuri WHERE Natural=1"; //Comanda sql de select
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
            foreach (DataRow row in this.sTable.Rows)
            {
                label3.Text = row["Naturals"].ToString();
            }
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Sucuri WHERE TimpulMediuDeVanzare < 500";

            SqlConnection connection = new SqlConnection(connectionString);
            sCommand = new SqlCommand(sql, connection); // se utilizeaza comanda sql si connection

            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter); // adapter
            connection.Open();
            sDs = new DataSet(); //crearea DataSet
            sAdapter.Fill(sDs, "Sucuri"); //Folosirea adapterului asupra tabelului elev
            sTable = sDs.Tables["Sucuri"]; // folosirea table asupra tabelului elev
            connection.Close();
            Console.WriteLine(this.dataGridView1.Columns["Pret"]);
            Console.WriteLine(this.dataGridView1.Columns["TimpulMediuDeVanzare"]);
            dataGridView1.DataSource = sDs.Tables["Sucuri"];
            this.dataGridView1.Sort(this.dataGridView1.Columns[7], ListSortDirection.Descending);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Sucuri WHERE TimpulMediuDeVanzare <= 24 AND NrDeVanzari >= 350";

            SqlConnection connection = new SqlConnection(connectionString);
            sCommand = new SqlCommand(sql, connection); // se utilizeaza comanda sql si connection

            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter); // adapter
            connection.Open();
            sDs = new DataSet(); //crearea DataSet
            sAdapter.Fill(sDs, "Sucuri"); //Folosirea adapterului asupra tabelului elev
            sTable = sDs.Tables["Sucuri"]; // folosirea table asupra tabelului elev
            connection.Close();
            Console.WriteLine(this.dataGridView1.Columns["Pret"]);
            Console.WriteLine(this.dataGridView1.Columns["TimpulMediuDeVanzare"]);
            dataGridView1.DataSource = sDs.Tables["Sucuri"];

        }
    }
}
