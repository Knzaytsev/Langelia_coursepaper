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
            CleanCities();
            CleanPersons();
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
        }

        private static void CleanPersons()
        {
            string sqlExp = "DELETE FROM Person";
            NonQuery(sqlExp, "Person");
            using(SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                sqlExp = $"INSERT INTO Person (Name, Number_move, Health, Attack, Defense, Feature, X, Y, Id_player) " +
                            $"VALUES ('warrior1', 5, 100, 23, 12, 1, 32, 64, 1)";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                sqlExp = $"INSERT INTO Person (Name, Number_move, Health, Attack, Defense, Feature, X, Y, Id_player) " +
                            $"VALUES ('settler1', 6, 100, 0, 0, 2, 64, 64, 1)";
                cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
                sqlExp = $"INSERT INTO Person (Name, Number_move, Health, Attack, Defense, Feature, X, Y, Id_player) " +
                            $"VALUES ('diplomat1', 8, 100, 0, 0, 3, 32, 96, 1)";
                cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
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
