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
        private Person activePerson = new Person();
        private DirectoryInfo dir = new DirectoryInfo(@"C:\Users\пк\Desktop\Учёба\2 курс\Курсовая\Langelia\Langelia_coursepaper\Langelia");
        private string connectionStr = @"Data Source=.\SQLSERVEREDU;Initial Catalog=GameLang;Integrated Security=True";
        private string sqlExp = "";
        bool close = true;
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
            AboutPlayer form = new AboutPlayer();
            form.Show();
            form.Activate();
        }

        private void CitiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListObjects form = new ListObjects();
            form.Show();
            form.Activate();
        }

        private void AllianceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttitudeAlliance form = new AttitudeAlliance();
            form.Show();
            form.Activate();
        }

        private void TradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttitudeTrade form = new AttitudeTrade();
            form.Show();
            form.Activate();
        }

        private void AttitudesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AttitudeAttitudes form = new AttitudeAttitudes();
            form.Show();
            form.Activate();
        }

        private void PersonsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void PlayersToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void EndTurnByButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                sqlExp = $"SELECT Id, Number_move FROM Person";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    people[reader.GetInt32(0)].NumberMove = reader.GetInt32(1);
                }
                reader.Close();
                foreach(var c in cities.Values)
                {
                    sqlExp = $"UPDATE Player SET Number_production = Number_production + {c.NumberProduct} " +
                        $"WHERE Id = (SELECT Id_player FROM City WHERE Id = {c.Id})";
                    (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                }
                //sqlExp = $"SELECT * FROM List_build WHERE ";
            }

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
                int x = e.X / 32;
                int y = e.Y / 32;
                int id = y * 40 + x + 1;
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    sqlExp = $"SELECT * FROM City WHERE Id_player = 1 AND Id = (SELECT Id_city FROM Cell WHERE Cell.Id = {id})";
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
                            activePerson.Active = false;
                        }
                    }
                    else
                    {
                        if (cities.ContainsKey(reader.GetInt32(0))){
                            AboutCity aboutCity = new AboutCity();
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

        public void DestroyCity(int id)
        {
            cities.Remove(id);
        }

        public void CreateBuilding(int id, int numberProduction)
        {
            cities[id].NumberProduct = numberProduction;
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

        private void FormLoad(object sender, EventArgs e)
        {
            pictureBox1.Image =
                new Bitmap(dir.FullName + @"\Pictures\Map.png");
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                sqlExp = "SELECT * FROM Person";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                        reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7),
                        reader.GetInt32(8));
                    people.Add(reader.GetInt32(0), person);
                }
                reader.Close();
                foreach(var p in people.Values)
                {
                    switch (p.Feature)
                    {
                        case 1:
                            sqlExp = $"SELECT Path FROM Picture WHERE Id = {8} ";
                            break;
                        case 2:
                            sqlExp = $"SELECT Path FROM Picture WHERE Id = {6}";
                            break;
                        case 3:
                            sqlExp = $"SELECT Path FROM Picture WHERE Id = {7}";
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
                pictureBox1.Refresh();
                g.Dispose();
                connection.Close();
            }
        }
    }
}
