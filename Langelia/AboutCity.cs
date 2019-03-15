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
            nameCity.Text = city.NameCity.ToUpper().Replace("'", "");
            numberCitizen.Text = (city.NumberCitizen * 100).ToString();
            numberFood.Text = city.NumberFood.ToString();
            numberProduction.Text = city.NumberProduct.ToString();
            numberCulture.Text = city.NumberCulture.ToString();
            numberMilitary.Text = city.NumberMilitary.ToString();
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
            _city.CreateBuilding(id, _sqlConnection);
            numberProduction.Text = _city.NumberProduct.ToString();
            numberCulture.Text = _city.NumberCulture.ToString();
            numberMilitary.Text = _city.NumberMilitary.ToString();
            gp.CreateBuilding(_city);
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
                //createLibrary.FlatAppearance.BorderColor = Color.Gold;
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
            gp.DestroyCity(_city);
            Close();
        }
    }
}
