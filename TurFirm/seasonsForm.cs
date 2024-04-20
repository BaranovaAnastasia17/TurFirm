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
    public partial class seasonsForm : Form
    {
        public NpgsqlConnection conn;
        public Form1 form1; // Assuming this is your main form where you'll refresh the data grid or list.
        public bool IsEditMode = false;
        public int EditingSeasonId;

        public seasonsForm(Form1 f, NpgsqlConnection con)
        {
            InitializeComponent();
            form1 = f;
            conn = con;
        }

        // Initialize UI components and load form data here if needed
        private void SeasonForm_Load(object sender, EventArgs e)
        {

        }

        public void SetEditData(int id, int tour_id, DateTime startDate, DateTime endDate, bool isSeasonOpen, int numSeats)
        {
            textBox2.Text = tour_id.ToString();
            EditingSeasonId = id;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = endDate;
            checkBox1.Checked = isSeasonOpen;
            textBox1.Text = numSeats.ToString();

            IsEditMode = true;
            button1.Text = "Изменить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
                sql = @"UPDATE seasons SET tour_id=@tour_id, start_date = @start_date, end_date = @end_date, 
                        is_season_open = @is_season_open, num_seats = @num_seats 
                        WHERE season_id = @season_id";
            }
            else
            {
                sql = @"INSERT INTO seasons(tour_id,start_date, end_date, is_season_open, num_seats) 
                        VALUES (@tour_id,@start_date, @end_date, @is_season_open, @num_seats)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tour_id", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@start_date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@end_date", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@is_season_open", checkBox1.Checked);
            cmd.Parameters.AddWithValue("@num_seats", int.Parse(textBox1.Text));

            if (IsEditMode)
            {
                cmd.Parameters.AddWithValue("@season_id", EditingSeasonId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            form1.loadSeasons();

            if (IsEditMode)
            {
                Close();
            }
            else
            {
                textBox2.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                checkBox1.Checked = false;
                textBox1.Text = "";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void seasonsForm_Load(object sender, EventArgs e)
        {

        }
    }
}