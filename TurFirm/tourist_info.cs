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

namespace TurFirm
{
    public partial class tourist_info : Form
    {
        public NpgsqlConnection conn;
        public Form1 form1;
        public bool IsEditMode = false;
        public int EditingTouristId;
        public tourist_info(Form1 f, NpgsqlConnection con)
        {
            InitializeComponent();

            form1 = f;
            conn = con;
        }

        private void TouristForm_Load(object sender, EventArgs e)
        {

        }
        public void SetEditData(int id, string passportSeries, string city, string country, string phoneNumber, string indexNumber)
        {
            EditingTouristId = id;
            textBox1.Text = passportSeries;
            textBox2.Text = city;
            textBox3.Text = country;
           textBox4.Text = phoneNumber;
            textBox5.Text = indexNumber;
            textBox6.Text = id.ToString();
            IsEditMode = true;
            button2.Text = "Изменить";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
                // SQL-запрос для обновления данных
                sql = @"UPDATE tourist_information SET tourist_information_id=@tourist_information_id, passport_series = @passport_series, city = @city, 
                country = @country, phone_number = @phone_number, index_number = @index_number 
                WHERE tourist_information_id = @tourist_information_id";
            }
            else
            {

                sql = @"INSERT INTO tourist_information(tourist_information_id,passport_series, city, country, phone_number, index_number) 
                VALUES (@tourist_information_id,@passport_series, @city, @country, @phone_number, @index_number)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@tourist_information_id", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@passport_series", textBox1.Text);
            cmd.Parameters.AddWithValue("@city", textBox2.Text);
            cmd.Parameters.AddWithValue("@country", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone_number", textBox4.Text);
            cmd.Parameters.AddWithValue("@index_number", textBox5.Text);

            if (IsEditMode)
            {

                cmd.Parameters.AddWithValue("@tourist_information_id", EditingTouristId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();



            form1.loadTouristsInformation();


            if (IsEditMode)
            {
                Close();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }







        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void tourist_info_Load(object sender, EventArgs e)
        {

        }

        private void tourist_info_Load_1(object sender, EventArgs e)
        {

        }
    }
}

