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
        private AboutPerson aboutPerson;
        //private List<Person> actPeople = new List<Person>();
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
                foreach (var p in people.Values)
                {
                    sqlExp = $"UPDATE Person SET X = {p.X}, Y = {p.Y} WHERE Id = {p.Id}";
                    SqlCommand cmd = new SqlCommand(sqlExp, connection);
                    cmd.ExecuteNonQuery();
                }
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
                    /*sqlExp =
                        string.Format("SELECT City FROM Player WHERE Id = 1 AND City = (SELECT Id FROM City WHERE Cell = {0})", id);*/
                    sqlExp = string.Format(@"SELECT * FROM City WHERE Id = (SELECT Id FROM Player WHERE City.Id = Id) 
                                                AND Cell = {0}", id);
                    SqlCommand cmd = new SqlCommand(sqlExp, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    //int exmp = cmd.ExecuteNonQuery();
                    if(!reader.Read())
                    {
                        reader.Close();
                        x *= 32;
                        y *= 32;
                        /*sqlExp = string.Format(@"SELECT * FROM Person WHERE Id = (SELECT Id FROM Player 
                                    WHERE Person.Id = Id) AND X = {0} AND Y = {1}", x, y);
                        cmd = new SqlCommand(sqlExp, connection);
                        //int exmp = cmd.ExecuteNonQuery();
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            activePerson = new Person(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), 
                                reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), 
                                reader.GetInt32(7), reader.GetInt32(8));
                            activePerson.Active = true;
                        }*/
                        sqlExp = string.Format(@"SELECT Id FROM Person WHERE Id = (SELECT Id FROM Player 
                                    WHERE Person.Id = Id) AND X = {0} AND Y = {1}", x, y);
                        cmd = new SqlCommand(sqlExp, connection);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            aboutPerson?.Close();
                            activePerson = people[reader.GetInt32(0)];
                            reader.Close();
                            sqlExp = $"SELECT Name FROM Feature WHERE Id = {activePerson.Feature}";
                            cmd = new SqlCommand(sqlExp, connection);
                            reader = cmd.ExecuteReader();
                            reader.Read();
                            activePerson.Active = false;
                            aboutPerson = new AboutPerson();
                            aboutPerson.About(activePerson.Name, reader.GetString(0), activePerson.NumberMove, 
                                activePerson.Health, activePerson.Defense, activePerson.Attack);
                            aboutPerson.Show();
                            activePerson.Active = true;
                        }
                    }
                    else
                    {
                        aboutPerson.Close();
                        activePerson.Active = false;
                    }
                    connection.Close();
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                if(activePerson.Active)
                {
                    int x = e.X / 32;
                    int y = e.Y / 32;
                    int id = y * 40 + x + 1;
                    using(SqlConnection connection = new SqlConnection(connectionStr))
                    {
                        connection.Open();
                        sqlExp = string.Format("SELECT Passability, Penalty FROM Cell WHERE Id = {0}", id);
                        SqlCommand cmd = new SqlCommand(sqlExp, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        int pass = reader.GetInt32(0);
                        x *= 32;
                        y *= 32;
                        if (pass != 1 && ((x == activePerson.X + 32 && y == activePerson.Y) ||
                            (x == activePerson.X - 32 && y == activePerson.Y) || 
                            (x == activePerson.X && y == activePerson.Y + 32) ||
                            (x == activePerson.X && y == activePerson.Y - 32)) && !(x == activePerson.X && y == activePerson.Y))
                        {
                            int penalty = reader.GetInt32(1);
                            reader.Close();
                            if (activePerson.NumberMove - penalty >= 0)
                            {
                                Graphics g = Graphics.FromImage(pictureBox1.Image);
                                x = activePerson.X / 32;
                                y = activePerson.Y / 32;
                                id = y * 40 + x + 1;
                                sqlExp = $"SELECT Path FROM Picture WHERE Id = (SELECT Picture FROM Cell WHERE Id = {id})";
                                cmd = new SqlCommand(sqlExp, connection);
                                reader = cmd.ExecuteReader();
                                reader.Read();
                                Bitmap bmp = new Bitmap(reader.GetString(0));
                                g.DrawImage(bmp, activePerson.X - 2, activePerson.Y);
                                activePerson.Movement(e.X, e.Y);
                                activePerson.NumberMove -= penalty;
                                //SolidBrush brush = new SolidBrush(Color.Black);
                                //g.FillRectangle(brush, activePerson.X - 2, activePerson.Y, 32, 32);
                                bmp = new Bitmap(activePerson.PathColor);
                                people[activePerson.Id] = activePerson;
                                g.DrawImage(bmp, activePerson.X - 2, activePerson.Y);
                                pictureBox1.Refresh();
                                g.Dispose();
                                //actPeople.Add(activePerson);
                            }
                            else
                            {
                                MessageBox.Show("Превышен лимит!");
                            }
                        }
                    }
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
                sqlExp = "SELECT * FROM Person";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                        reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7),
                        reader.GetInt32(8));
                    people.Add(reader.GetInt32(0), person);
                    //Bitmap bmp = new Bitmap
                    //SolidBrush brush = new SolidBrush(Color.Black);
                    //g.FillRectangle(brush, reader.GetInt32(0) - 2, reader.GetInt32(1), 32, 32);
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

        private int ComputeId(int x, int y)
        {
            x /= 32;
            y /= 32;
            x *= 32;
            y *= 32;
            return y * 40 + x + 1;
        }
    }
}
