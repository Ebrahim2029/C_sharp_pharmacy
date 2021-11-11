using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pharmacy
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Xhemo\source\repos\pharmacy\database\DB_pharmacy.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Table] " +
           "(ID ,[Name Treatment],[Name company], [Made in ] ,price )  values ('" + ID.Text + "' , '" + Name_com.Text + "' , '" + company.Text + "' , '" + madein.Text + "' , '" + price.Text + "')";
            cmd.ExecuteNonQuery();
            connect.Close();
            ID.Text = "";
            Name_com.Text = "";
            company.Text = "";
            madein.Text = "";
            price.Text = "";
            MessageBox.Show("تم  ادخال البيانات ");
            display_Data();

        }

        public void display_Data()
        {
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select * from [Table]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter datadp = new SqlDataAdapter(cmd);
            datadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connect.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            display_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
           
            cmd.CommandText = "update [Table] set [Name Treatment] = '" + Name_com.Text + "' , [Name company] = '" + company.Text + "' , " +
            "[Made in ] = '" + madein.Text + "' , price =  '" + price.Text + "'  where ID= '" + ID.Text + "'  ";
                cmd.ExecuteNonQuery();
            connect.Close();
            ID.Text = "";
            Name_com.Text = "";
            company.Text = "";
            madein.Text = "";
            price.Text = "";
            display_Data();
            MessageBox.Show("تم  تعديل البيانات ");
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
            cmd.CommandText = "delete from  [Table] where ID= '" + ID.Text + "' ";
            cmd.ExecuteNonQuery();
            connect.Close();
            ID.Text = "";
            Name_com.Text = "";
            company.Text = "";
            madein.Text = "";
            price.Text = "";
            display_Data();
            MessageBox.Show("تم  مسح البيانات البيانات ");
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main fr4 = new Main();
            fr4.Show();
            this.Hide();
        }
    }
}
