using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace Langelia
{
    [Serializable]
    public class PersonSave
    {
        public int number_health;
        public int x;
        public int y;
        public string name;
        public int player;
        public int idType;
        public PersonSave() { }
        public PersonSave(Person person)
        {
            number_health = person.Health;
            x = person.X;
            y = person.Y;
            name = person.Name;
            player = person.Player;
            idType = person.Feature;
        }
    }
    [Serializable]
    public class Cell
    {
        public int numberCells = 680;
        public int[] cellsPass = new int[680];
        public int[] cellPenalty = new int[680];
        public int[] cellProduction = new int[680];
        public int[] cellPicture = new int[680];
        public int[] cellCity = new int[680];
        public Cell() { }

        public Cell(string cnctStr)
        {
            using (SqlConnection connection = new SqlConnection(cnctStr))
            {
                connection.Open();
                string sqlExp = "SELECT * FROM Cell";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0) - 1;
                    cellsPass[id] = reader.GetInt32(1);
                    cellPenalty[id] = reader.GetInt32(2);
                    cellProduction[id] = reader.GetInt32(3);
                    cellPicture[id] = reader.GetInt32(4);
                }
                reader.Close();
                sqlExp = "SELECT Id, Id_city FROM Cell WHERE Id_city <> NULL";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                while (reader.Read())
                {
                    cellCity[reader.GetInt32(0)] = reader.GetInt32(1);
                }
            }
        }
    }
    [Serializable]
    public class ListBuildings
    {
        public int IdBuilding;
        public int IdCity;
        public ListBuildings() { }

        public ListBuildings(int city, int buiding)
        {
            IdBuilding = buiding;
            IdCity = city;
        }
        
        public static ListBuildings[] GiveIds(string cnctSql, ListBuildings[] lb)
        {
            using(SqlConnection connection = new SqlConnection(cnctSql))
            {
                connection.Open();
                string sqlExp = "SELECT COUNT(*) FROM List_build";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                int i = 0;
                reader.Read();
                lb = new ListBuildings[reader.GetInt32(0)];
                reader.Close();
                sqlExp = "SELECT * FROM List_build";
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                while (reader.Read())
                {
                    lb[i] = new ListBuildings(reader.GetInt32(2), reader.GetInt32(1));
                    ++i;
                }
            }
            return lb;
        }
    }

    [Serializable]
    public class Player
    {
        public string nameGov;
        public int numberCitizen;
        public int numberCulture;
        public int numberMilitary;
        public int numberDiplomacy;
        public int numberProduction;
        public string nameRuler;
        public int typeRuler;
        public int age;

        public Player() { }

        public Player(string nameGovern, int nmbCitizen, int nmbCilture, int nmbMilitary, int nmbDip, int nmbProd,
            string nameRul, int typeRul, int ageRuler)
        {
            nameGov = nameGovern;
            numberCitizen = nmbCitizen;
            numberCulture = nmbCilture;
            numberMilitary = nmbMilitary;
            numberDiplomacy = nmbDip;
            numberProduction = nmbProd;
            nameRuler = nameRul;
            typeRuler = typeRul;
            age = ageRuler;
        }

        public static Player[] GiveIds(string cnctSql, Player[] player)
        {
            using (SqlConnection connection = new SqlConnection(cnctSql))
            {
                connection.Open();
                string sqlExp = "SELECT * FROM Player";
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                int i = 0;
                player = new Player[3];
                reader.Close();
                reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                while (reader.Read())
                {
                    player[i] = new Player(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(15), reader.GetString(11), reader.GetInt32(12), reader.GetInt32(13));
                    ++i;
                }
            }
            return player;
        }
    }

    public class SaveGame
    {
        public Cell cell;
        public City[] cities;
        public PersonSave[] personSave;
        public ListBuildings[] listBuildings;
        public Player[] player;
        public SaveGame() { }
        public SaveGame(string path, string cnctStr, Dictionary<int, Person> person, Dictionary<int, City> city)
        {
            personSave = new PersonSave[person.Count];
            int i = 0;
            foreach(var p in person.Values)
            {
                personSave[i] = new PersonSave(p);
                ++i;
            }
            i = 0;
            cities = new City[city.Count];
            foreach(var c in city.Values)
            {
                cities[i] = c;
                ++i;
            }
            cell = new Cell(cnctStr);
            player = Player.GiveIds(cnctStr, player);
            listBuildings = ListBuildings.GiveIds(cnctStr, listBuildings);
            XmlSerializer xml = new XmlSerializer(typeof(SaveGame));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(fs, this);
            }
        }
    }
}
