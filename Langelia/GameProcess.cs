using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Langelia
{
    public partial class GameProcess : Form
    {
        public MainMenu mainMenu = new MainMenu();
        private Dictionary<int, Person> people = new Dictionary<int, Person>();
        private Dictionary<int, City> cities = new Dictionary<int, City>();
        private AboutPerson aboutPerson;
        private AboutCity aboutCity;
        private Person activePerson = new Person();
        private DirectoryInfo dir = new DirectoryInfo(@"C:\Users\пк\Desktop\Учёба\2 курс\Курсовая\Langelia\Langelia_coursepaper\Langelia");
        private string connectionStr = @"Data Source=.\SQLSERVEREDU;Initial Catalog=GameLang;Integrated Security=True";
        private string sqlExp = "";
        private bool close = true;
        private string path = "";
        public GameProcess()
        {
            InitializeComponent();
        }

        private void ExitToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu.Visible = true;
            close = false;
            mainMenu.Activate();
            this.Close();
        }

        private void FormClosingThis(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                mainMenu.Close();
            }
        }

        private void AboutPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutPlayer form = new AboutPlayer(connectionStr);
            form.Show();
            form.Activate();
        }

        private void CitiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListObjects form = new ListObjects("City", connectionStr);
            form.Show();
            form.Activate();
        }

        private void PersonsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListObjects form = new ListObjects("Person", connectionStr);
            form.Show();
            form.Activate();
        }

        private void PlayersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListObjects form = new ListObjects("Player", connectionStr);
            form.Show();
            form.Activate();
        }

        private void EndTurnByButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                sqlExp = $"SELECT Person.Id, Number_movement FROM Person JOIN Type_person ON Person.Id_type_person = Type_person.Id";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    people[reader.GetInt32(0)].NumberMove = reader.GetInt32(1);
                }
                reader.Close();
                foreach(var c in cities.Values)
                {
                    sqlExp = $"UPDATE Player SET Number_production = Number_production + {c.NumberProduct}, " +
                        $" Number_culture = Number_culture + {c.NumberCulture}, " +
                        $"Number_military = Number_military + {c.NumberMilitary} " +
                        $"WHERE Id = (SELECT Id_player FROM City WHERE Id = {c.Id})";
                    (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                }
                sqlExp = $"UPDATE PLAYER SET Number_production = Number_production + CASE Type_ruler_points " +
                    $"WHEN 1 THEN(SELECT Number FROM Type_ruler_points WHERE Id = 1) ELSE 0 " +
                    $"END, " +
                    $"Number_culture = Number_culture + CASE Type_ruler_points " +
                    $"WHEN 2 THEN(SELECT Number FROM Type_ruler_points WHERE Id = 2) ELSE 0 " +
                    $"END, " +
                    $"Number_military = Number_military + CASE Type_ruler_points " +
                    $"WHEN 3 THEN(SELECT Number FROM Type_ruler_points WHERE Id = 3) ELSE 0 " +
                    $"END";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
            }
            aboutCity?.Close();
            aboutPerson?.Close();

        }

        private void EndTurnByKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                EndTurnByButton_Click(sender, e);
            }
        }

        private void ManagePers(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int x = e.X / 32;                   //Корректировка x
                int y = e.Y / 32;                   //Корректировка у
                int id = y * 40 + x + 1;            //Вычисление идентификатора клетки
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    sqlExp = $"SELECT * FROM City WHERE Id_player = 1 AND " +
                        $"Id = (SELECT Id_city FROM Cell WHERE Cell.Id = {id})";
                    SqlCommand cmd = new SqlCommand(sqlExp, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(!reader.Read())
                    {
                        reader.Close();
                        x *= 32;
                        y *= 32;
                        sqlExp = $"SELECT Id FROM Person WHERE Id_player = 1 AND X = {x} AND Y = {y}";
                        cmd = new SqlCommand(sqlExp, connection);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            activePerson.Active = false;
                            aboutPerson?.Close();
                            activePerson = people[reader.GetInt32(0)];
                            reader.Close();
                            aboutPerson = new AboutPerson();
                            aboutPerson.About(activePerson, this);
                            aboutPerson.Show();
                            activePerson.Active = true;
                        }
                        else
                        {
                            aboutPerson?.Close();
                            aboutCity?.Close();
                            activePerson.Active = false;
                        }
                    }
                    else
                    {
                        if (cities.ContainsKey(reader.GetInt32(0))){
                            aboutCity?.Close();
                            aboutCity = new AboutCity();
                            aboutCity.About(cities[reader.GetInt32(0)], connectionStr, this);
                            aboutCity.Show();
                        }
                    }
                    connection.Close();
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                if(activePerson.Active)
                {
                    int oldX = activePerson.X;
                    int oldY = activePerson.Y;
                    string moveDone = activePerson.Movement(e.X / 32, e.Y / 32, connectionStr);
                    if (moveDone == "")
                    {
                        people[activePerson.Id] = activePerson;
                        aboutPerson.ChangingMove(activePerson.NumberMove);
                        DrawMovement(oldX / 32, oldY / 32);
                    }
                    else if(moveDone != "0")
                    {
                        MessageBox.Show(moveDone);
                    }
                }
            }
        }

        public void CreateCity()
        {
            NameCity nc = new NameCity();
            string nameCity = "";
            if(nc.ShowDialog(this) == DialogResult.OK)
            {
                nameCity = nc.CityName.Text;
            }
            else
            {
                nc.Dispose();
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                City city = activePerson.CreateCity(connectionStr, nameCity);
                int x = activePerson.X;
                int y = activePerson.Y;
                people.Remove(activePerson.Id);
                sqlExp = $"SELECT Path FROM Picture WHERE Id = 9";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                Bitmap bmp = new Bitmap(reader.GetString(0));
                g.DrawImage(bmp, x - 2, y);
                pictureBox1.Refresh();
                cities.Add(city.Id, city);
            }
        }

        public void DestroyCity(City city)
        {
            cities.Remove(city.Id);
            DrawCell(city.Id);
            city.DestroyCity(connectionStr);
        }

        public void CreateBuilding(City city)
        {
            cities[city.Id] = city;
        }

        private void DrawCell(int id)
        {
            using(SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                sqlExp = $"SELECT Id FROM Cell WHERE Id_city = {id}";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                int idCell = reader.GetInt32(0);
                reader.Close();
                sqlExp = $"SELECT Path FROM Picture WHERE Id = (SELECT Picture FROM Cell WHERE Id = {idCell})";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                int x = idCell % 40 - 1;
                int y = idCell / 40;
                g.DrawImage(new Bitmap(reader.GetString(0)), x * 32 - 2, y * 32);
                pictureBox1.Refresh();
            }
        }

        private void DrawMovement(int x, int y)
        {
            using(SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                int id = y * 40 + x + 1;
                sqlExp = $"SELECT Path FROM Picture WHERE Id = (SELECT Picture FROM Cell WHERE Id = {id})";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                Bitmap bmp = new Bitmap(reader.GetString(0));
                g.DrawImage(bmp, x * 32 - 2, y * 32);
                bmp = new Bitmap(activePerson.PathColor);
                g.DrawImage(bmp, activePerson.X - 2, activePerson.Y);
                pictureBox1.Refresh();
            }
        }

        private void DrawCity(int id, int player)
        {
            using(SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string sqlExp = "";
                switch (player)
                {
                    case 1:
                        sqlExp = $"SELECT Path FROM Picture WHERE Id = 9";
                        break;
                    case 2:
                        sqlExp = "SELECT Path FROM Picture WHERE Id = 14";
                        break;
                    case 3:
                        sqlExp = "SELECT Path FROM Picture WHERE Id = 19";
                        break;
                }
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                string path = reader.GetString(0);
                reader.Close();
                sqlExp = $"SELECT Id FROM Cell WHERE Id_city = {id}";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                if (reader.Read())
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    int x = reader.GetInt32(0) % 40 - 1;
                    int y = reader.GetInt32(0) / 40;
                    g.DrawImage(new Bitmap(path), x * 32 - 2, y * 32);
                }
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            pictureBox1.Image =
                new Bitmap(dir.FullName + @"\Pictures\Map.png");
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                //sqlExp = "SELECT * FROM Person";
                sqlExp = $"SELECT Person.Id, Name, Number_movement, Number_health, Number_attack, Number_defense, Id_type_person, " +
                    $"X, Y, Id_player " +
                    $"FROM Person JOIN Type_person ON Person.Id_type_person = Type_person.Id";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                        reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7),
                        reader.GetInt32(8), reader.GetInt32(9));
                    people.Add(reader.GetInt32(0), person);
                }
                reader.Close();
                foreach(var p in people.Values)
                {
                    switch (p.Feature)
                    {
                        case 1:
                            sqlExp = $"SELECT Path FROM Picture WHERE Id = {(p.Player - 1) * 5 + 8}";
                            break;
                        case 2:
                            sqlExp = $"SELECT Path FROM Picture WHERE Id = {(p.Player - 1) * 5 + 6}";
                            break;
                        case 3:
                            sqlExp = $"SELECT Path FROM Picture WHERE Id = {(p.Player - 1) * 5 + 7}";
                            break;
                    }
                    cmd = new SqlCommand(sqlExp, connection);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    Bitmap bmp = new Bitmap(reader.GetString(0));
                    p.PathColor = reader.GetString(0);
                    g.DrawImage(bmp, p.X - 2, p.Y);
                    reader.Close();
                }
                sqlExp = $"SELECT * FROM City";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(reader.GetInt32(0), new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(3), 
                        reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(6)));
                    DrawCity(reader.GetInt32(0), reader.GetInt32(6));
                }
                pictureBox1.Refresh();
                g.Dispose();
                connection.Close();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if(path == "")
            {
                ok = Saving();
            }
            if (ok == true)
            {
                SaveGame sg = new SaveGame(path, connectionStr, people, cities);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Saving())
            {
                SaveGame sg = new SaveGame(path, connectionStr, people, cities);
            }
        }

        public void LoadSave(string loadPath)
        {
            path = loadPath;
        }

        private bool Saving()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SAVE|*.save";
            sfd.ShowDialog();
            if(sfd.FileName != "")
            {
                path = sfd.FileName;
                return true;
            }
            return false;
        }

        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputCities = (from c in cities.Values where c.IdPlayer == 1 select c).ToArray();
            if (inputCities.Length == 0)
            {
                MessageBox.Show("У Вас ещё нет ни одного города, чтобы проводить статистику!");
                return;
            }
            ChartCities cs = new ChartCities(inputCities);
            cs.Show();
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Searching form = new Searching(connectionStr);
            form.Show();
            form.Activate();
        }
    }
}
