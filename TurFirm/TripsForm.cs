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
    public partial class TripsForm : Form
    {
        public NpgsqlConnection conn;
        public Form1 form1; // Assuming this is your main form where you'll refresh the data grid or list.
        public bool IsEditMode = false;
        public int EditingTripId;

        public TripsForm(Form1 f, NpgsqlConnection con)
        {
            InitializeComponent();
            form1 = f;
            conn = con;
        }

        // Initialize UI components and load form data here if needed
        private void TripsForm_Load(object sender, EventArgs e)
        {

        }

        public void SetEditData(int tripId, int seasonId, int touristId)
        {
            textBox1.Text = seasonId.ToString();
            textBox2.Text = touristId.ToString();
            EditingTripId = tripId;
            IsEditMode = true;
            button1.Text = "Изменить";
        }

    

  

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (IsEditMode)
            {
                sql = @"UPDATE trips SET season_id=@season_id, tourist_id=@tourist_id 
                        WHERE trip_id=@trip_id";
            }
            else
            {
                sql = @"INSERT INTO trips(season_id, tourist_id) 
                        VALUES (@season_id, @tourist_id)";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@season_id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@tourist_id", int.Parse(textBox2.Text));

            if (IsEditMode)
            {
                cmd.Parameters.AddWithValue("@trip_id", EditingTripId);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            form1.loadTrips();

            if (IsEditMode)
            {
                Close();
            }
            else
            {
       
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
