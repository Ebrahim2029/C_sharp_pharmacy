using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pharmacy
{
    public partial class Form2 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Xhemo\source\repos\pharmacy\database\DB_pharmacy.mdf;Integrated Security=True;Connect Timeout=30");


        public int sum = 0;
        public Form2()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "العلاج";
            dataGridView1.Columns[1].Name = "السعر";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

                SqlCommand cmd1 = new SqlCommand("SELECT  [Name Treatment],[Name company], [Made in] ,price  FROM [Table] ");

                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connect;
                connect.Open();
                SqlDataReader sdr = cmd1.ExecuteReader();

                while (sdr.Read())
                {

                    if (sdr["Name Treatment"].ToString() == comboBox1.Text)
                    {
                        textBox3.Text = sdr["Name company"].ToString();
                        textBox4.Text = sdr["Made in"].ToString();
                        textBox1.Text = sdr["price"].ToString();
                    }

                }
                connect.Close();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("SELECT  [Name Treatment]  FROM [Table] ");

            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connect;
            connect.Open();
            SqlDataReader sdr = cmd1.ExecuteReader();

            while (sdr.Read())
            {

                comboBox1.Items.Add(sdr["Name Treatment"].ToString());
            }
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main fr1 = new Main();
            fr1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") return;
                String[] row = { comboBox1.Text, textBox1.Text };
           
           
            dataGridView1.Rows.Add(row);
            sum += Convert.ToInt32(textBox1.Text);
            textBox2.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number = dataGridView1.Rows.Count;

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }

           
            if (dataGridView1.Rows.Count < number)
            {
                comboBox1.Text = "";
                textBox2.Text = "0";
                textBox1.Text = "0";
                textBox4.Text = "";
                
                textBox3.Text = "";

            }
            
            
        }

       
    }
}
