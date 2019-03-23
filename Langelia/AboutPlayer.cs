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
    public partial class AboutPlayer : Form
    {
        string cnctStr = "";
        public AboutPlayer()
        {
            InitializeComponent();
        }

        public AboutPlayer(string conn)
        {
            InitializeComponent();
            cnctStr = conn;
        }

        private void AboutPlayer_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(cnctStr))
            {
                connection.Open();
                string sqlExp = $"SELECT Name_gov, Number_citizen, Number_culture, Number_diplomacy, Number_military, " +
                    $"Number_production, Name_ruler, " +
                        $"Type_ruler_points, Age FROM Player WHERE Id = 1";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                NameGov.Text = reader.GetString(0);
                NumberCitizen.Text = reader.GetInt32(1).ToString();
                NumberCulture.Text = reader.GetInt32(2).ToString();
                NumberDiplomacy.Text = reader.GetInt32(3).ToString();
                NumberMilitary.Text = reader.GetInt32(4).ToString();
                NumberProduction.Text = reader.GetInt32(5).ToString();
                NameRuler.Text = reader.GetString(6);
                Description.Text = "sample text";
                AgeRuler.Text = reader.GetInt32(8).ToString();
            }
        }
    }
}
