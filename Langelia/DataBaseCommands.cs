using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Langelia
{
    class DataBaseCommands
    {
        private static string sqlConnection = @"Data Source=.\SQLSERVEREDU;Initial Catalog=GameLang;Integrated Security=True";

        public static void Cleaning()
        {
            CleanCells();
            CleanListBuild();
            CleanCities();
            CleanPersons();
            CleanPlayer();
        }

        private static void CleanCells()
        {
            string sqlExp = "DELETE FROM Cell";
            NonQuery(sqlExp, "Cell");
        }

        private static void CleanCities()
        {
            string sqlExp = "DELETE FROM City";
            NonQuery(sqlExp, "City");
            using(SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                sqlExp = $"INSERT INTO City " +
                    $"(Name_city, Number_citizen, Number_product, Number_food, Id_player, Number_culture, Number_military) " +
                    $"VALUES ('Таэо', 3, 0, 0, 2, 0, 0), ('Иконох', 5, 0, 0, 3, 0, 0)";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
            }
        }

        private static void CleanPersons()
        {
            string sqlExp = "DELETE FROM Person";
            NonQuery(sqlExp, "Person");
            using(SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                sqlExp = $"INSERT INTO Person (Name, Number_move, Health, Attack, Defense, Feature, X, Y, Id_player) " +
                            $"VALUES ('warrior1', 5, 100, 23, 12, 1, 32, 64, 1), " +
                            $"('settler1', 6, 100, 0, 0, 2, 64, 64, 1), " +
                            $"('diplomat1', 8, 100, 0, 0, 3, 32, 96, 1), " +
                            $"('warrior2', 5, 100, 23, 12, 1, 1152, 64, 2), " +
                            $"('diplomat2', 8, 100, 0, 0, 3, 1184, 96, 2), " +
                            $"('warrior3', 5, 100, 23, 12, 1, 672, 448, 3), " +
                            $"('diplomat3', 8, 100, 0, 0, 3, 640, 480, 3)";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                /*sqlExp = $"INSERT INTO Person (Name, Number_move, Health, Attack, Defense, Feature, X, Y, Id_player) " +
                            $"VALUES ('settler1', 6, 100, 0, 0, 2, 64, 64, 1)";
                cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                sqlExp = $"INSERT INTO Person (Name, Number_move, Health, Attack, Defense, Feature, X, Y, Id_player) " +
                            $"VALUES ('diplomat1', 8, 100, 0, 0, 3, 32, 96, 1)";
                cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();*/
            }
        }

        private static void CleanListBuild()
        {
            string sqlExp = "DELETE FROM List_build";
            NonQuery(sqlExp, "List_build");
        }

        private static void CleanPlayer()
        {
            string sqlExp = "UPDATE Player SET Number_citizen = 0, Number_culture = 0, Number_military = 0, " +
                "Number_diplomacy = 0, Attitude = NULL, Alliance = NULL, Trade = NULL, War = NULL, Development = NULL, " +
                "Name_ruler = 'Каэлисто', Type_ruler_points = 1, Age = 0, Dip_act = NULL, Number_production = 0 WHERE Id = 1; " +
                "UPDATE Player SET Number_citizen = 0, Number_culture = 0, Number_military = 0, " +
                "Number_diplomacy = 0, Attitude = NULL, Alliance = NULL, Trade = NULL, War = NULL, Development = NULL, " +
                "Name_ruler = 'Лиом', Type_ruler_points = 2, Age = 0, Dip_act = NULL, Number_production = 0 WHERE Id = 2; " +
                "UPDATE Player SET Number_citizen = 0, Number_culture = 0, Number_military = 0, " +
                "Number_diplomacy = 0, Attitude = NULL, Alliance = NULL, Trade = NULL, War = NULL, Development = NULL, " +
                "Name_ruler = 'Уони', Type_ruler_points = 3, Age = 0, Dip_act = NULL, Number_production = 0 WHERE Id = 3";
            using(SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
            }
        }

        private static void NonQuery(string sqlExp, string type)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                sqlExp = $"DBCC CHECKIDENT ({type} , RESEED, 0)";
                cmd = new SqlCommand(sqlExp, connection);
                int ex = cmd.ExecuteNonQuery();
            }
        }
    }
}
