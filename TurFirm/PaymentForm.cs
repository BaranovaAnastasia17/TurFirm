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
    public partial class PaymentForm : Form
    {
        public NpgsqlConnection conn;
        public Form1 form1; // Assuming this is your main form where you'll refresh the data grid or list.
        public bool IsEditMode = false;
        public int EditingPaymentId;

        public PaymentForm(Form1 f, NpgsqlConnection con)
        {
            InitializeComponent();
            form1 = f;
            conn = con;
        }

        // Initialize UI components and load form data here if needed
        private void PaymentsForm_Load(object sender, EventArgs e)
        {

        }

        public void SetEditData(int paymentId, int tripId, DateTime paymentDate, decimal amount)
        {
            textBox1.Text = tripId.ToString();
            dateTimePicker1.Value = paymentDate;
            textBox2.Text = amount.ToString("F2");

            EditingPaymentId = paymentId;
            IsEditMode = true;
            button1.Text = "Изменить";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
    
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
                sql = @"UPDATE payments SET trip_id=@trip_id, payment_date=@payment_date, amount=@amount 
                        WHERE payment_id=@payment_id";
            }
            else
            {
                sql = @"INSERT INTO payments(trip_id, payment_date, amount) 
                        VALUES (@trip_id, @payment_date, @amount)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@trip_id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@payment_date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@amount", decimal.Parse(textBox2.Text));

            if (IsEditMode)
            {
                cmd.Parameters.AddWithValue("@payment_id", EditingPaymentId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            form1.loadPayment();

            if (IsEditMode)
            {
                Close();
            }
            else
            {

                textBox1.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
