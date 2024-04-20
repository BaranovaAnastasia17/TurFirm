using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Npgsql;



namespace TurFirm
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection con;
        private string connString = "Host=127.0.0.1;Username=postgres;Password=123;Database=superherodb";


        public Form1()
        {
            InitializeComponent();
            con = new NpgsqlConnection(connString);
            con.Open();
            loadTourists();
            loadTouristsInformation();
            loadTours();
            loadSeasons();
            loadPayment();
            loadTrips();
        }
        public void loadTourists()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tourists", con);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void loadTouristsInformation()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tourist_information", con);
            adap.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        public void loadTours()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tour_information", con);
            adap.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        public void loadSeasons()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM seasons", con);
            adap.Fill(dt);
            dataGridView4.DataSource = dt;
        }
        public void loadPayment()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM payments", con);
            adap.Fill(dt);
            dataGridView5.DataSource = dt;
        }

        public void loadTrips()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM trips", con);
            adap.Fill(dt);
            dataGridView7.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        TouristForm tf = new TouristForm(this, con);
                        tf.Show();

                        break;
                    }
                case 1:
                    {
                        tourist_info tf = new tourist_info(this, con);
                        tf.Show();

                        break;
                    }
                case 2:
                    {
                        tourInfo tf = new tourInfo(this, con);
                        tf.Show();

                        break;
                    }
                case 3:
                    {
                        seasonsForm tf = new seasonsForm(this, con);
                        tf.Show();

                        break;
                    }
                case 4:
                    {


                        PaymentForm tf = new PaymentForm(this, con);
                        tf.Show();

                        break;
                    }
                case 5:
                    {
                        TripsForm tf = new TripsForm(this, con);
                        tf.Show();

                        break;
                    }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        if (dataGridView1.CurrentRow != null)
                        {

                            TouristForm tf = new TouristForm(this, con);


                            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            string firstName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            string lastName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                            string patronymic = dataGridView1.CurrentRow.Cells[3].Value.ToString();



                            tf.SetEditData(id, firstName, lastName, patronymic);


                            tf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (dataGridView2.CurrentRow != null)
                        {

                            tourist_info tf = new tourist_info(this, con);


                            int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                            string passportSeries = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                            string city = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                            string country = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                            string phoneNumber = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                            string indexNumber = dataGridView2.CurrentRow.Cells[5].Value.ToString();



                            tf.SetEditData(id, passportSeries, city, country, phoneNumber, indexNumber);


                            tf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 2:
                    {
                        if (dataGridView3.CurrentRow != null)
                        {

                            tourInfo tf = new tourInfo(this, con);


                            int id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                            string name = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                            decimal price = (decimal)dataGridView3.CurrentRow.Cells[2].Value;
                            string information = dataGridView3.CurrentRow.Cells[3].Value.ToString();




                            tf.SetEditData(id, name, price, information);


                            tf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 3:
                    {
                        if (dataGridView4.CurrentRow != null)
                        {

                            seasonsForm tf = new seasonsForm(this, con);


                            int id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                            int tour_id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[1].Value);
                            DateTime datestart = (DateTime)dataGridView4.CurrentRow.Cells[2].Value;
                            DateTime dateend = (DateTime)dataGridView4.CurrentRow.Cells[3].Value;
                            bool isSeasonOpen = (bool)dataGridView4.CurrentRow.Cells[4].Value;
                            int numseats = (int)dataGridView4.CurrentRow.Cells[5].Value;




                            tf.SetEditData(id, tour_id, datestart, dateend, isSeasonOpen, numseats);


                            tf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 4:
                    {
                        if (dataGridView5.CurrentRow != null)
                        {

                            PaymentForm tf = new PaymentForm(this, con);


                            int id = Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value);
                            int trip_id = Convert.ToInt32(dataGridView5.CurrentRow.Cells[1].Value);
                            DateTime paymentdate = (DateTime)dataGridView5.CurrentRow.Cells[2].Value;

                            decimal amount = (decimal)dataGridView5.CurrentRow.Cells[3].Value;




                            tf.SetEditData(id, trip_id, paymentdate, amount);


                            tf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }

                case 5:
                    {
                        if (dataGridView7.CurrentRow != null)
                        {

                            TripsForm tf = new TripsForm(this, con);


                            int id = Convert.ToInt32(dataGridView7.CurrentRow.Cells[0].Value);

                            int seasId = Convert.ToInt32(dataGridView7.CurrentRow.Cells[1].Value);

                            int tourist_id = Convert.ToInt32(dataGridView7.CurrentRow.Cells[2].Value);




                            tf.SetEditData(id, seasId, tourist_id);


                            tf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        if (dataGridView1.CurrentRow != null)
                        {




                            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                            string sql = "DELETE FROM tourists WHERE tourist_id = @tourist_id";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                            {

                                cmd.Parameters.AddWithValue("tourist_id", id);

                                try
                                {

                                    cmd.ExecuteNonQuery();


                                    loadTourists();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 1:
                    {
                        if (dataGridView2.CurrentRow != null)
                        {




                            int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);

                            string sql = "DELETE FROM tourist_information WHERE tourist_information_id = @tourist_information_id";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                            {

                                cmd.Parameters.AddWithValue("tourist_information_id", id);

                                try
                                {

                                    cmd.ExecuteNonQuery();


                                    loadTouristsInformation();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 2:
                    {
                        if (dataGridView3.CurrentRow != null)
                        {




                            int id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);

                            string sql = "DELETE FROM tour_information WHERE tour_id = @tour_id";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                            {

                                cmd.Parameters.AddWithValue("tour_id", id);

                                try
                                {

                                    cmd.ExecuteNonQuery();


                                    loadTours();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 3:
                    {
                        if (dataGridView4.CurrentRow != null)
                        {




                            int id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);

                            string sql = "DELETE FROM seasons WHERE season_id = @season_id";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                            {

                                cmd.Parameters.AddWithValue("season_id", id);

                                try
                                {

                                    cmd.ExecuteNonQuery();


                                    loadSeasons();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 4:
                    {
                        if (dataGridView5.CurrentRow != null)
                        {




                            int id = Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value);

                            string sql = "DELETE FROM payments WHERE payment_id = @payment_id";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                            {

                                cmd.Parameters.AddWithValue("payment_id", id);

                                try
                                {

                                    cmd.ExecuteNonQuery();


                                    loadPayment();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
                case 5:
                    {
                        if (dataGridView7.CurrentRow != null)
                        {




                            int id = Convert.ToInt32(dataGridView7.CurrentRow.Cells[0].Value);

                            string sql = "DELETE FROM trips WHERE trip_id = @trip_id";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                            {

                                cmd.Parameters.AddWithValue("trip_id", id);

                                try
                                {

                                    cmd.ExecuteNonQuery();


                                    loadTrips();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                        }
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExecuteSimpleQuery();
        }
        private void ExecuteSimpleQuery()
        {
            string userInput = textBox1.Text;
            // Example: SELECT * FROM tourists WHERE name LIKE '%John%'
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(userInput, con);
            try
            {
                adap.Fill(dt);

                dataGridView6.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
        private void ExecuteComplexQuery()
        {
            // Предполагается, что пользовательский ввод разделяется на две части:
            // 1. SQL запрос до первого символа '|'
            // 2. Параметры запроса, разделенные запятыми, после символа '|'
            string userInput = richTextBox1.Text;
            string[] parts = userInput.Split(new char[] { '|' }, 2);

            if (parts.Length < 2)
            {
                MessageBox.Show("Некорректный ввод. Требуется SQL запрос и параметры, разделенные '|'.");
                return;
            }

            string query = parts[0];
            string[] parameters = parts[1].Split(',');

            DataTable dt = new DataTable();

            // Используем NpgsqlCommand для безопасного выполнения запроса
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
            {
                // Добавляем параметры в запрос
                for (int i = 0; i < parameters.Length; i++)
                {
                    // Предполагается, что параметры вводятся в формате: @paramName=paramValue
                    string[] paramParts = parameters[i].Trim().Split('=');
                    if (paramParts.Length != 2)
                    {
                        MessageBox.Show($"Некорректный параметр: {parameters[i]}");
                        return;
                    }
                    int test = int.Parse(paramParts[1]);
                    if (test != null)
                    {
                        cmd.Parameters.AddWithValue(paramParts[0], test);
                    }
                    else { cmd.Parameters.AddWithValue(paramParts[0], paramParts[1]); }

                }

                try
                {
                    // Открываем соединение, если оно уже не открыто
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    // Используем NpgsqlDataAdapter для заполнения DataTable
                    using (NpgsqlDataAdapter adap = new NpgsqlDataAdapter(cmd))
                    {
                        adap.Fill(dt);
                    }

                    // Отображаем результаты
                    dataGridView6.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении сложного запроса: " + ex.Message);
                }
                finally
                {
                    // Закрываем соединение
                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }




        private void button5_Click(object sender, EventArgs e)
        {
            ExecuteComplexQuery();
        }

        private void ExportUsingXmlWriter()
        {
            using (XmlWriter writer = XmlWriter.Create("ComplexQueryResults.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Results");

                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    if (row.IsNewRow) continue; // Пропускаем пустую строку в конце

                    writer.WriteStartElement("Row");

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        writer.WriteElementString(dataGridView6.Columns[i].Name, row.Cells[i].Value?.ToString() ?? "");
                    }

                    writer.WriteEndElement(); // Row
                }

                writer.WriteEndElement(); // Results
                writer.WriteEndDocument();
            }
        }
        private void ExportUsingXmlDocument()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("Results");
            xmlDoc.AppendChild(rootElement);

            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                if (row.IsNewRow) continue; // Пропускаем пустую строку в конце

                XmlElement rowElement = xmlDoc.CreateElement("Row");
                rootElement.AppendChild(rowElement);

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    XmlElement cellElement = xmlDoc.CreateElement(dataGridView6.Columns[i].Name);
                    cellElement.InnerText = row.Cells[i].Value?.ToString() ?? "";
                    rowElement.AppendChild(cellElement);
                }
            }

            xmlDoc.Save("ComplexQueryResultsDoc.xml");
        }

        private void LoadXmlIntoDataGridView6WithXmlDocument()
        {
            DataTable dataTable = new DataTable();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("ComplexQueryResultsDoc.xml"); // Load your XML file

            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/Results/Row"); // Adjust the XPath according to your XML structure

            if (xmlNodeList.Count > 0)
            {
                // Assuming that your DataGridView columns match the XML element names
                foreach (XmlNode node in xmlNodeList[0].ChildNodes)
                {
                    dataTable.Columns.Add(node.Name);
                }

                foreach (XmlNode node in xmlNodeList)
                {
                    DataRow dataRow = dataTable.NewRow();

                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        dataRow[childNode.Name] = childNode.InnerText;
                    }

                    dataTable.Rows.Add(dataRow);
                }

                dataGridView6.DataSource = dataTable;
            }
        }
        private void LoadXmlIntoDataGridView6WithXmlReader()
        {
            string xmlFilePath = "ComplexQueryResultsDoc.xml"; // Укажите путь к вашему XML файлу
            DataTable dataTable = new DataTable();
            using (XmlReader reader = XmlReader.Create(xmlFilePath))
            {
                while (reader.Read())
                {
                    // Ищем начало элемента Row
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Row")
                    {
                        DataRow dataRow = dataTable.NewRow();

                        // Читаем внутренние элементы Row (колонки)
                        while (reader.Read() && !(reader.NodeType == XmlNodeType.EndElement && reader.Name == "Row"))
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                string columnName = reader.Name;
                                string cellValue = reader.ReadElementContentAsString();

                                // Добавляем колонку, если она еще не добавлена
                                if (!dataTable.Columns.Contains(columnName))
                                {
                                    dataTable.Columns.Add(columnName);
                                }

                                dataRow[columnName] = cellValue;

                                // После ReadElementContentAsString() курсор уже на следующем элементе, поэтому дополнительный Read() в этой точке может пропустить элементы
                            }
                        }

                        dataTable.Rows.Add(dataRow);
                    }
                }
            }

            dataGridView6.DataSource = dataTable; // Привязываем DataTable к вашему DataGridView
        }






        private void button6_Click(object sender, EventArgs e)
        {
            ExportUsingXmlWriter();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExportUsingXmlDocument();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadXmlIntoDataGridView6WithXmlReader();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadXmlIntoDataGridView6WithXmlDocument();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadTrips();
            tabControl1.SelectedIndex = 5;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
             string query = @"
        SELECT ti.name, COUNT(*) AS TourCount
        FROM trips t
        JOIN seasons s ON t.season_id = s.season_id
        JOIN tour_information ti ON s.tour_id = ti.tour_id
        GROUP BY ti.name order by TourCount desc;
    ";
          
            NpgsqlCommand command = new NpgsqlCommand(query, con);
            NpgsqlDataReader reader = command.ExecuteReader();

            Series series = chart1.Series.Add("Tours");
            series.ChartType = SeriesChartType.Pie;

            // Настраиваем отображение процентов
            series.Label = "#PERCENT{P2}"; // Отображает проценты с двумя знаками после запятой
            series.LegendText = "#VALX (#PERCENT{P2})"; // Отображает название сегмента и его процентное значение в легенде

            while (reader.Read())
            {
                series.Points.AddXY(reader["name"].ToString(), reader["TourCount"]);
            }

            // Включаем отображение легенды, если она ещё не включена
            chart1.Legends[0].Enabled = true;

            reader.Close();



            query = @"
    SELECT tu.first_name || ' ' || tu.patronymic || ' ' || tu.last_name AS FullName, SUM(p.amount) AS TotalSpent
    FROM payments p
    JOIN trips t ON p.trip_id = t.trip_id
    JOIN tourists tu ON t.tourist_id = tu.tourist_id
    GROUP BY tu.first_name, tu.patronymic, tu.last_name ORDER BY TotalSpent desc;
";

            command = new NpgsqlCommand(query, con);
            reader = command.ExecuteReader();

            Series series2 = chart2.Series.Add("TotalSpent");
            series2.ChartType = SeriesChartType.Column;

            // Добавляем точки и устанавливаем для каждой из них индивидуальный цвет
            int colorIndex = 0;
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Cyan, Color.Magenta };
            while (reader.Read())
            {
                int pointIndex = series2.Points.AddXY(reader["FullName"].ToString(), reader["TotalSpent"]);
                series2.Points[pointIndex].Color = colors[colorIndex % colors.Length];
                colorIndex++;
            }

            reader.Close();


        }

        private void button11_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            string query = @"
        SELECT ti.name, COUNT(*) AS TourCount
        FROM trips t
        JOIN seasons s ON t.season_id = s.season_id
        JOIN tour_information ti ON s.tour_id = ti.tour_id
        GROUP BY ti.name order by TourCount desc;
    ";

            NpgsqlCommand command = new NpgsqlCommand(query, con);
            NpgsqlDataReader reader = command.ExecuteReader();

            Series series = chart1.Series.Add("Tours");
            series.ChartType = SeriesChartType.Pie;

            // Настраиваем отображение процентов
            series.Label = "#PERCENT{P2}"; // Отображает проценты с двумя знаками после запятой
            series.LegendText = "#VALX (#PERCENT{P2})"; // Отображает название сегмента и его процентное значение в легенде

            while (reader.Read())
            {
                series.Points.AddXY(reader["name"].ToString(), reader["TourCount"]);
            }

            // Включаем отображение легенды, если она ещё не включена
            chart1.Legends[0].Enabled = true;

            reader.Close();



            query = @"
    SELECT tu.first_name || ' ' || tu.patronymic || ' ' || tu.last_name AS FullName, SUM(p.amount) AS TotalSpent
    FROM payments p
    JOIN trips t ON p.trip_id = t.trip_id
    JOIN tourists tu ON t.tourist_id = tu.tourist_id
    GROUP BY tu.first_name, tu.patronymic, tu.last_name ORDER BY TotalSpent desc;
";

            command = new NpgsqlCommand(query, con);
            reader = command.ExecuteReader();

            Series series2 = chart2.Series.Add("TotalSpent");
            series2.ChartType = SeriesChartType.Column;

            // Добавляем точки и устанавливаем для каждой из них индивидуальный цвет
            int colorIndex = 0;
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Cyan, Color.Magenta };
            while (reader.Read())
            {
                int pointIndex = series2.Points.AddXY(reader["FullName"].ToString(), reader["TotalSpent"]);
                series2.Points[pointIndex].Color = colors[colorIndex % colors.Length];
                colorIndex++;
            }

            reader.Close();


        }
    }
}
    
