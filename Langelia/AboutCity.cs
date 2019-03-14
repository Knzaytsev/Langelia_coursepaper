using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Langelia
{
    public partial class AboutCity : Form
    {
        private City _city;
        private string _sqlConnection = "";
        private GameProcess gp;
        public AboutCity()
        {
            InitializeComponent();
        }

        public void About(City city, string sqlConnection, GameProcess process)
        {
            nameCity.Text = city.NameCity.ToUpper();
            numberCitizen.Text = (city.NumberCitizen * 100).ToString();
            numberFood.Text = city.NumberFood.ToString();
            numberProduction.Text = city.NumberProduct.ToString();
            _city = city;
            _sqlConnection = sqlConnection;
            gp = process;
        }

        private void createLibrary_Click(object sender, EventArgs e)
        {
            Creating(1);
            CheckAll();
            //createLibrary.Enabled = false;
        }

        private void createTheatre_Click(object sender, EventArgs e)
        {
            Creating(2);
            CheckAll();
            //createTheatre.Enabled = false;
        }

        private void createArtWorkshop_Click(object sender, EventArgs e)
        {
            Creating(3);
            CheckAll();
            //createArtWorkshop.Enabled = false;
        }

        private void createBarracks_Click(object sender, EventArgs e)
        {
            Creating(4);
            CheckAll();
            //createBarracks.Enabled = false;
        }

        private void createCamp_Click(object sender, EventArgs e)
        {
            Creating(5);
            CheckAll();
            //createCamp.Enabled = false;
        }

        private void createForge_Click(object sender, EventArgs e)
        {
            Creating(6);
            CheckAll();
            //createForge.Enabled = false;
        }

        private void createWorkshop_Click(object sender, EventArgs e)
        {
            Creating(7);
            CheckAll();
            //createWorkshop.Enabled = false;
        }

        private void Creating(int id)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                connection.Open();
                string sqlExp = $"SELECT Time FROM Building WHERE Id = {id}";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                sqlExp = $"INSERT INTO List_build (Time_build, Id_building, Id_city) VALUES ({reader.GetInt32(0)}, {id}, {_city.Id})";
                reader.Close();
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                sqlExp = $"UPDATE Player SET Number_production = Number_production - (SELECT Cost FROM Building WHERE Id = {id}) " +
                    $"WHERE Id = (SELECT Id_player FROM City WHERE Id = {_city.Id})";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                sqlExp = $"UPDATE City SET Number_product = Number_product + " +
                    $"(SELECT Number FROM Type_build_points WHERE Id = (SELECT Type_points FROM Building WHERE Id = {id}))";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                sqlExp = $"SELECT Number_product FROM City WHERE Id = {_city.Id}";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                numberProduction.Text = reader.GetInt32(0).ToString();
                _city.NumberProduct = reader.GetInt32(0);
                gp.CreateBuilding(_city.Id, _city.NumberProduct);
            }
        }

        private bool CheckProduction(int id)
        {
            bool ok;
            using(SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                connection.Open();
                string sqlExp = $"SELECT Number_production FROM Player WHERE Id = 1";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                sqlExp = $"SELECT * FROM Building WHERE Id = {id} AND {reader.GetInt32(0)} >= Cost";
                reader.Close();
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                ok = reader.Read();
            }
            return ok;
        }

        private bool CheckBuilding(int id)
        {
            bool ok;
            using(SqlConnection connection = new SqlConnection(_sqlConnection))
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM List_build WHERE Id_city = {_city.Id} AND Id_building = {id}";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                ok = reader.Read();
            }
            return ok;
        }

        private void CheckAll()
        {
            if (!CheckProduction(1))
            {
                createLibrary.Enabled = false;
            }
            else if (CheckBuilding(1))
            {
                createLibrary.Enabled = false;
                createLibrary.FlatAppearance.BorderColor = Color.Gold;
            }
            if (!CheckProduction(2))
            {
                createTheatre.Enabled = false;
            }
            else if (CheckBuilding(2))
            {
                createTheatre.Enabled = false;
            }
            if (!CheckProduction(3))
            {
                createArtWorkshop.Enabled = false;
            }
            else if (CheckBuilding(3))
            {
                createArtWorkshop.Enabled = false;
            }
            if (!CheckProduction(4))
            {
                createBarracks.Enabled = false;
            }
            else if (CheckBuilding(4))
            {
                createBarracks.Enabled = false;
            }
            if (!CheckProduction(5))
            {
                createCamp.Enabled = false;
            }
            else if (CheckBuilding(5))
            {
                createCamp.Enabled = false;
            }
            if (!CheckProduction(6))
            {
                createForge.Enabled = false;
            }
            else if (CheckBuilding(6))
            {
                createForge.Enabled = false;
            }
            if (!CheckProduction(7))
            {
                createWorkshop.Enabled = false;
            }
            else if (CheckBuilding(7))
            {
                createWorkshop.Enabled = false;
            }
        }

        private void LoadCity(object sender, EventArgs e)
        {
            CheckAll();   
        }

        private void destroyCity_Click(object sender, EventArgs e)
        {
            string sqlExp = $"DELETE FROM List_build WHERE Id_city = {_city.Id}";
            gp.DestroyCity(_city.Id);
            Close();
        }
    }
}
