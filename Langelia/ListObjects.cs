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
                    sqlExp = $"SELECT Name_city as \"Название города\", [1] as \"Культура\", [2] as \"Война\", [3] as \"Производство\" " +
                        $"FROM " +
                        $"(SELECT Name_City, Type_build_points.Number, Type_building.Id as \"tbp_id\" " +
                        $"FROM City " +
                        $"join List_build " +
                        $"on City.Id = List_build.Id_city " +
                        $"join Building " +
                        $"on Building.Id = List_build.Id " +
                        $"join Type_building " +
                        $"on Building.Type_points = Type_building.Id " +
                        $"join Type_build_points " +
                        $"on Building.Type_build_points = Type_build_points.Id " +
                        $"WHERE Id_player = 1) src " +
                        $"PIVOT " +
                        $"( " +
                        $"SUM(Number) " +
                        $"FOR \"tbp_id\" IN([1], [2], [3])" +
                        $") piv";
                    Show(sqlExp);
                    break;
                case "Player":
                    sqlExp = $"SELECT Name_gov as \"Государство\", Number_citizen as \"Жители\", Number_culture as \"Культура\", " +
                        $"Number_military as \"Война\", Number_production as \"Производство\", " +
                        $"Number_diplomacy as \"Дипломатия\", Name_ruler as \"Правитель\", " +
                        $"Age as \"Возраст\" FROM Player";
                    Show(sqlExp);
                    break;
                case "Person":
                    sqlExp = $"SELECT Name as \"Наименование\", Number_health as \"Количество здоровья\", Number_defense as \"Защита\", " +
                        $"Number_attack as \"Атака\", Number_movement as \"Очков движения\", Name_type as \"Класс персонажа\" " +
                        $"FROM Person JOIN Type_person ON Person.Id_type_person = Type_person.Id WHERE Id_player = 1";
                    Show(sqlExp);
                    break;
                case "Buildings":
                    sqlExp = $"select Player.Name_ruler as \"Правитель\", City.Name_city as \"Город\", count(*) as \"Количество построек\" from Player " +
                        $"join city on Player.id = city.Id_player " +
                        $"join List_build on city.id = List_build.Id_city where Player.Id = 1 " +
                        $"group by Player.Name_ruler, City.Name_city";
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
