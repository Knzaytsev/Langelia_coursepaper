using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiledSharp;

namespace Langelia
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            var map = new TmxMap(@"C:\Users\пк\Desktop\Учёба\2 курс\Курсовая\Langelia\Langelia\Properties\Map.tmx");
            var layerGraph = map.Layers[3];
            var layerType = map.Layers[2];
            var layerPassability = map.Layers[1];
            var layerPenalty = map.Layers[0];
            /*using (SqlConnection connection =
                new SqlConnection(@"Data Source=.\SQLSERVEREDU;Initial Catalog=GameLang;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand cmd;
                string sqlExp;
                //SqlCommand command = new SqlCommand("DBCC CHECKIDENT (Cell, RESEED, 0)", connection);
                for (int i = 0; i < map.Layers[0].Tiles.Count; ++i)
                {
                    int pass = layerPassability.Tiles[i].Gid;
                    int pen = layerPenalty.Tiles[i].Gid;
                    int type = layerType.Tiles[i].Gid != 0 ? layerType.Tiles[i].Gid : 3;
                    int picture = layerGraph.Tiles[i].Gid;
                    //string sqlExp = string.Format(@"INSERT INTO Cell (Passability, Penalty, Production, Picture) 
                            //VALUES ({0}, {1}, {2}, {3})", pass, pen, type, picture);
                    sqlExp = string.Format(@"UPDATE Cell SET Passability = {0}, Penalty = {1}, Production = {2}, 
                            Picture = {3} WHERE Id = {4}", pass, pen, type, picture, i + 1);
                    cmd = new SqlCommand(sqlExp, connection);
                    cmd.ExecuteNonQuery();
                }
            }*/
            GameProcess form = new GameProcess();
            form.mainMenu = this;
            this.Visible = false;
            form.Show();
            form.Activate();
        }

        private void ReadingAndAdding(string path)
        {

        }
    }
}
