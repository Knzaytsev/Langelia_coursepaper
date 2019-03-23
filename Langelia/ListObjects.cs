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
    public partial class ListObjects : Form
    {
        string _object;
        string cnctStr;
        public ListObjects()
        {
            InitializeComponent();
        }

        public ListObjects(string obj, string connection)
        {
            InitializeComponent();
            _object = obj;
            cnctStr = connection;
            dataGridView1.Enabled = false;
        }

        private void ListObjects_Load(object sender, EventArgs e)
        {
            string sqlExp = "";
            switch (_object)
            {
                case "City":
                    sqlExp = $"SELECT Name_City, Number_citizen, Number_food, Number_product, Number_culture, " +
                        $"Number_military FROM City WHERE Id_player = 1";
                    Show(sqlExp);
                    break;
                case "Player":
                    sqlExp = $"SELECT Name_gov, Number_citizen, Number_culture, Number_military, Number_diplomacy, Name_ruler, " +
                        $"Type_ruler_points, Age, Number_production FROM Player";
                    Show(sqlExp);
                    break;
                case "Person":
                    sqlExp = $"SELECT Name, Number_health, X, Y, Number_defense, Number_attack, Number_movement, Name_type " +
                        $"FROM Person JOIN Type_person ON Person.Id_type_person = Type_person.Id WHERE Id_player = 1";
                    Show(sqlExp);
                    break;
            }
        }

        private void Show(string sqlExp)
        {
            using(SqlConnection connection = new SqlConnection(cnctStr))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExp, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                /*dataGridView1.Width =
                    dataGridView1.Columns.Cast<DataGridViewColumn>().Sum(x => x.Width)
                    + (dataGridView1.RowHeadersVisible ? dataGridView1.RowHeadersWidth : 0) + 3;
                this.Width = dataGridView1.Width;
                this.Height = dataGridView1.Height;*/
            }
        }
    }
}
