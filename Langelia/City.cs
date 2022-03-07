using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Langelia
{
    public class City
    {
        private int _id;
        private string _nameCity;
        private int _numberCitizen;
        private int _numberProduct;
        private int _numberFood;
        private int _numberCulture;
        private int _numberMilitary;
        private int _idPlayer;

        public int Id { get { return _id; } }
        public string NameCity
        {
            get { return _nameCity; }
            set { _nameCity = value; }
        }
        public int NumberCitizen
        {
            get { return _numberCitizen; }
            set { _numberCitizen = value; }
        }
        public int NumberProduct
        {
            get { return _numberProduct; }
            set { _numberProduct = value; }
        }
        public int NumberCulture
        {
            get { return _numberCulture; }
            set { _numberCulture = value; }
        }
        public int NumberMilitary
        {
            get { return _numberMilitary; }
            set { _numberMilitary = value; }
        }
        public int NumberFood
        {
            get { return _numberFood; }
            set { _numberFood = value; }
        }
        public int IdPlayer
        {
            get { return _idPlayer; }
            set { _idPlayer = value; }
        }

        public City() { }

        public City(int id, string nameCity, int numberCitizen, int numberProduct, int numberFood, int numberCulture, 
            int numberMilitary, int idPlayer)
        {
            _id = id;
            _nameCity = nameCity.Replace("'", "");
            _numberCitizen = numberCitizen;
            _numberFood = numberFood;
            _numberProduct = numberProduct + 1;
            _numberMilitary = numberMilitary;
            _numberCulture = numberCulture;
            _idPlayer = idPlayer;
        }

        public void CreateBuilding(int id, string sqlCon)
        {
            using (SqlConnection connection = new SqlConnection(sqlCon))
            {
                connection.Open();
                string sqlExp = $"INSERT INTO List_build (Id_building, Id_city) VALUES ({id}, {_id})";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                sqlExp = $"UPDATE Player SET Number_production = Number_production - (SELECT Cost FROM Building WHERE Id = {id}) " +
                    $"WHERE Id = (SELECT Id_player FROM City WHERE Id = {_id})";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                sqlExp = $"SELECT Description FROM Type_production WHERE Id = (SELECT Type_production_fk FROM Type_building WHERE Id = (SELECT Type_points FROM Building WHERE Id = {id}))";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                var type = reader.GetString(0);
                reader.Close();
                sqlExp = $"UPDATE City SET {type} = {type} + " +
                    $"(SELECT Number FROM Type_build_points WHERE Id = (SELECT Type_points FROM Building WHERE Id = {id}))";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                sqlExp = $"SELECT Number_product, Number_culture, Number_military, Number_citizen FROM City WHERE Id = {_id}";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                _numberProduct = reader.GetInt32(0);
                _numberCulture = reader.GetInt32(1);
                _numberMilitary = reader.GetInt32(2);
            }
        }

        public void DestroyCity(string strCon)
        {
            using(SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                string sqlExp = $"DELETE FROM List_build WHERE Id_city = {_id}; " +
                    $"UPDATE Cell SET Id_city = NULL WHERE Id_city = {_id}; " +
                    $"DELETE FROM City WHERE Id = {_id}";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
            }
        }
    }
}
