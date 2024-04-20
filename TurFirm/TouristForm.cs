using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace TurFirm
{
    public partial class TouristForm : Form
    {

        public NpgsqlConnection conn;
        public Form1 form1;
        public bool IsEditMode = false;
        public int EditingTouristId;
        public TouristForm(Form1 f, NpgsqlConnection con)
        {
            InitializeComponent();

            form1 = f;
            conn = con;
        }

        private void TouristForm_Load(object sender, EventArgs e)
        {

        }
        public void SetEditData(int id, string firstName, string lastName, string patronymic)
        {
            EditingTouristId = id;
            textBox1.Text = firstName;
            textBox2.Text = lastName;
            textBox3.Text = patronymic;
            IsEditMode = true;
            button2.Text = "Изменить";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
       
                sql = "UPDATE tourists SET first_name = @first_name, last_name = @last_name, patronymic = @patronymic WHERE tourist_id = @tourist_id";
            }
            else
            {

                sql = "INSERT INTO tourists(first_name, last_name, patronymic) VALUES (@first_name, @last_name, @patronymic)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("first_name", textBox1.Text);
            cmd.Parameters.AddWithValue("last_name", textBox2.Text);
            cmd.Parameters.AddWithValue("patronymic", textBox3.Text);

            if (IsEditMode)
            {
                cmd.Parameters.AddWithValue("@tourist_id", EditingTouristId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            form1.loadTourists();

       
            if (IsEditMode)
            {
                Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
    
            
        }
    }
}
