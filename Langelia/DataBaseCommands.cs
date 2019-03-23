using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledSharp;
using System.IO;
using System.Xml.Serialization;
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

        public static void Updating(string path)
        {
            SaveGame sg = new SaveGame();
            XmlSerializer xml = new XmlSerializer(typeof(SaveGame));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                sg = (SaveGame)xml.Deserialize(fs);
            }
            CleanCells();
            CleanListBuild();
            CleanCities();
            CleanPersons();
            UpdateCities(sg.cities);
            UpdateCells(sg.cell);
            UpdateListBuild(sg.listBuildings);
            UpdatePlayer(sg.player);
            UpdatePerson(sg.personSave);
        }

        private static void UpdatePerson(PersonSave[] people)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                for (int i = 0; i < people.Length; ++i)
                {
                    string sqlExp = $"INSERT INTO Person (Name, Number_health, X, Y, Id_player, Id_type_person) " +
                        $"VALUES ('{people[i].name}', {people[i].number_health}, {people[i].x}, {people[i].y}, {people[i].player}, {people[i].idType})";
                    (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                }
            }
        }

        private static void UpdatePlayer(Player[] players)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                for (int i = 0; i < players.Length; ++i)
                {
                    string sqlExp = $"UPDATE Player SET Name_gov = '{players[i].nameGov}', " +
                        $"Number_citizen = {players[i].numberCitizen}, Number_culture = {players[i].numberCulture}, " +
                        $"Number_military = {players[i].numberMilitary}, Number_diplomacy = {players[i].numberDiplomacy}, " +
                        $"Name_ruler = '{players[i].nameRuler}', Type_ruler_points = {players[i].typeRuler}, Age = {players[i].age}, " +
                        $"Number_production = {players[i].numberProduction} WHERE Id = {i + 1}";
                    (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                }
            }
        }

        private static void UpdateListBuild(ListBuildings[] lb)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                for (int i = 0; i < lb.Length; ++i)
                {
                    string sqlExp = $"INSERT INTO List_build (Id_building, Id_city) " +
                        $"VALUES ({lb[i].IdBuilding}, {lb[i].IdCity})";
                    (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                }
            }
        }

        private static void UpdateCities(City[] city)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                for (int i = 0; i < city.Length; ++i)
                {
                    string sqlExp = $"INSERT INTO City (Name_city, Number_citizen, " +
                        $"Number_product, Number_food, Number_culture, Number_military, Id_player) " +
                        $"VALUES ('{city[i].NameCity}', {city[i].NumberCitizen}, {city[i].NumberProduct}, " +
                        $"{city[i].NumberFood}, {city[i].NumberCulture}, {city[i].NumberMilitary}, {city[i].IdPlayer})";
                    (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                }
            }
        }

        private static void UpdateCells(Cell cell)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                for (int i = 0; i < cell.numberCells; ++i)
                {
                    string idCity = cell.cellCity[i] == 0 ? "NULL" : $"{cell.cellCity[i]}";
                    string sqlExp = $"UPDATE Cell SET Id_city = {idCity} WHERE Id = {i + 1}";
                    (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
                }
            }
        }

        private static void CleanCells()
        {
            /*string sqlExp = "DELETE FROM Cell";
            NonQuery(sqlExp, "Cell");*/
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                string sqlExp = "UPDATE Cell SET Id_city = NULL";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
            }
        }

        private static void CleanCities()
        {
            string sqlExp = "DELETE FROM City";
            NonQuery(sqlExp, "City");
            /*using(SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                sqlExp = $"INSERT INTO City " +
                    $"(Name_city, Number_citizen, Number_product, Number_food, Id_player, Number_culture, Number_military) " +
                    $"VALUES ('Таэо', 3, 0, 0, 2, 0, 0), ('Иконох', 5, 0, 0, 3, 0, 0)";
                (new SqlCommand(sqlExp, connection)).ExecuteNonQuery();
            }*/
        }

        private static void CleanPersons()
        {
            string sqlExp = "DELETE FROM Person";
            NonQuery(sqlExp, "Person");
            /*using(SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                sqlExp = $"INSERT INTO Person (Name, Number_health, X, Y, Id_player, Id_type_person) " +
                            $"VALUES ('warrior1', 100, 32, 64, 1, 1), " +
                            $"('settler1', 100, 64, 64, 1, 2), " +
                            $"('diplomat1', 100, 32, 96, 1, 3), " +
                            $"('warrior2', 100, 1152, 64, 2, 1), " +
                            $"('diplomat2', 100, 1184, 96, 2, 3), " +
                            $"('warrior3', 100, 672, 448, 3, 1), " +
                            $"('diplomat3', 100, 640, 480, 3, 3)";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                cmd.ExecuteNonQuery();
            }*/
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
