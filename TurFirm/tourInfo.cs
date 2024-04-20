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
    public partial class tourInfo : Form
    {
        private readonly NpgsqlConnection conn;
        private readonly Form1 mainForm;
        private bool isEditMode = false;
        private int editingTourId;

        public tourInfo(Form1 mainForm, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.conn = conn;
        }

        public void SetEditData(int id, string name, decimal price, string information)
        {
            editingTourId = id;
            textBox1.Text = name;
            textBox2.Text = price.ToString();
            textBox3.Text = information;
            isEditMode = true;
            button2.Text = "Изменить";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (isEditMode)
            {
                sql = @"UPDATE tour_information SET name = @name, price = @price, information = @information 
                        WHERE tour_id = @tour_id";
            }
            else
            {
                sql = @"INSERT INTO tour_information(name, price, information) 
                        VALUES (@name, @price, @information)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox2.Text));
            cmd.Parameters.AddWithValue("@information", textBox3.Text);

            if (isEditMode)
            {
                cmd.Parameters.AddWithValue("@tour_id", editingTourId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            mainForm.loadTours();

            if (isEditMode)
            {
                Close();
            }

            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }



        private void button1_Click_1(object sender, EventArgs e)
        { 
            Close();
        }

        private void tourInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
