using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sucuri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Sucuri' table. You can move, or remove it, as needed.
            this.sucuriTableAdapter.Fill(this.database1DataSet.Sucuri);
            //hjkhk
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database1DataSet.SucuriRow newSucuriRow;
//            DataRow newline = this.database1DataSet.Tables["Sucuri"].NewRow();

            if (!( (textBox1.Text == null || textBox1.Text == "Id_produs")
                && (textBox2.Text == null || textBox1.Text == "NumeSuc")
                && (textBox3.Text == null || textBox1.Text == "Pret")
                && (textBox4.Text == null || textBox1.Text == "ProcentZahar")
                && (textBox5.Text == null || textBox1.Text == "ProcentFructe")
                && (textBox6.Text == null || textBox1.Text == "NrDeVanzari")
                && (textBox7.Text == null || textBox1.Text == "TimpulMediuDeVanzari")
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

                newSucuriRow = this.database1DataSet.Sucuri.NewSucuriRow();
                newSucuriRow.Id_produs = Int32.Parse(textBox1.Text);
                newSucuriRow.NumeSuc = textBox2.Text;
                newSucuriRow.Pret = Int32.Parse(textBox3.Text);
                newSucuriRow.ProcentZahar = Int32.Parse(textBox4.Text);
                newSucuriRow.ProcentFructe = Int32.Parse(textBox5.Text);
                newSucuriRow.Natural = checkBox1.Checked;
                newSucuriRow.NrDeVanzari = Int32.Parse(textBox6.Text);
                newSucuriRow.TimpulMediuDeVanzare = Int32.Parse(textBox7.Text);

                // Add the row to the Region table
                this.database1DataSet.Sucuri.Rows.Add(newSucuriRow);
                //this.database1DataSet.Tables["Sucuri"].Rows.Add(newline);
                // Save the new row to the database
                this.sucuriTableAdapter.Update(this.database1DataSet.Sucuri);
                this.dataGridView1.Update();
            }
        }
    }
}
