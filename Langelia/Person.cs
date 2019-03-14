using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Langelia
{
    public class Person
    {
        private int _id;
        private string _name;
        private int _numberMove;
        private int _health;
        private int _attack;
        private int _defense;
        private enum feature { warrior = 1, settler = 2, diplomat = 3};
        private int _feature;
        private int _x;
        private int _y;
        private bool active = false;
        private string pathColor;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public int NumberMove
        {
            get { return _numberMove; }
            set { _numberMove = value; }
        }
        public int Id
        {
            get { return _id; }
        }
        public string PathColor
        {
            get { return pathColor; }
            set { pathColor = value; }
        }
        public int Feature { get { return _feature; } }
        public string Name { get { return _name; } }
        public int Health { get { return _health; } }
        public int Defense { get { return _defense; } }
        public int Attack { get { return _attack; } }

        public Person() { }

        public Person(int id, string name, int numberMove, int health, int attack, int defense, int feature, int x, int y)
        {
            _id = id;
            _name = name;
            _numberMove = numberMove;
            _health = health;
            _attack = attack;
            _defense = defense;
            _feature = feature;
            _x = x;
            _y = y;
        }

        public City CreateCity(string sqlConnection, string nameCity)
        {
            string name = "'" + nameCity + "'";
            int profit = 0;
            int numberCitizen = 1;
            int numberProduct = 0;
            int numberFood = 0;
            int idPlayer = 0;
            int idCity = 0;
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                int x = _x / 32;
                int y = _y / 32;
                int id = y * 40 + x + 1;
                string sqlExp = $"SELECT Id_player FROM Person WHERE Id = {_id}";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                idPlayer = reader.GetInt32(0);
                reader.Close();
                sqlExp = $"INSERT INTO City (Name_city, Profit, Number_citizen, Number_product, Number_food, Id_player) " +
                    $"VALUES ({name}, {profit}, {numberCitizen}, {numberProduct}, {numberFood}, {idPlayer})";
                cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                sqlExp = $"SELECT Id FROM City";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                while (reader.Read())
                {
                    idCity = reader.GetInt32(0);
                }
                reader.Close();
                sqlExp = $"UPDATE Cell SET Id_city = {idCity} WHERE Id = {id}";
                cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                sqlExp = $"UPDATE City SET Number_product = CASE (SELECT Production FROM Cell WHERE Id_city = {idCity}) " +
                    $"WHEN 1 THEN 0 " +
                    $"WHEN 2 THEN(SELECT Number FROM Production WHERE Id = (SELECT Production FROM Cell WHERE Id_city = {idCity})) " +
                    $"END, " +
                    $"Number_food = CASE(SELECT Production FROM Cell WHERE Id_city = {idCity}) " +
                    $"WHEN 1 THEN (SELECT Number FROM Production WHERE Id = (SELECT Production FROM Cell WHERE Id_city = {idCity})) " +
                    $"WHEN 2 THEN 0 " +
                    $"END";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                sqlExp = $"DELETE FROM Person WHERE Id = {_id}";
                cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                sqlExp = $"SELECT Number_product, Number_food FROM City WHERE Id = {idCity}";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                reader.Read();
                numberProduct = reader.GetInt32(0);
                numberFood = reader.GetInt32(1);
            }
            return new City(idCity, name, numberCitizen, numberProduct, numberFood);
        }

        public string Movement(int x, int y, string connectionStr)
        {
            int id = y * 40 + x + 1;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string sqlExp = $"SELECT Passability, Penalty FROM Cell WHERE Id = {id}";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int pass = reader.GetInt32(0);
                x *= 32;
                y *= 32;
                if (pass != 1 && ((x == _x + 32 && y == _y) || (x == _x - 32 && y == _y) || (x == _x && y == _y + 32) ||
                            (x == _x && y == _y - 32)) && !(x == _x && y == _y))
                {
                    int penalty = reader.GetInt32(1);
                    reader.Close();
                    if (_numberMove - penalty >= 0)
                    {
                        _numberMove -= penalty;
                        _x = x;
                        _y = y;
                        sqlExp = $"UPDATE Person SET X = {_x}, Y = {_y} WHERE Id = {_id}";
                        cmd = new SqlCommand(sqlExp, connection);
                        cmd.ExecuteNonQuery();
                        return "";
                    }
                    else
                    {
                        return "Превышен лимит ходов!";
                    }
                }
            }
            return "0";
        }
    }
}
