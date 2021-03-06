﻿using System;
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
using System.IO;
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
            DataBaseCommands.Updating("original.save");
            /*DirectoryInfo dir = new DirectoryInfo(@"C:\Users\пк\Desktop\Учёба\2 курс\Курсовая\Langelia\Langelia_coursepaper\Langelia");
            var map = new TmxMap(dir.FullName + @"\Properties\Map.tmx");
            var layerGraph = map.Layers[3];
            var layerType = map.Layers[2];
            var layerPassability = map.Layers[1];
            var layerPenalty = map.Layers[0];
            DataBaseCommands.Cleaning();
            using (SqlConnection connection =
                new SqlConnection(@"Data Source=.\SQLSERVEREDU;Initial Catalog=GameLang;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand cmd;
                //SqlCommand command = new SqlCommand("DBCC CHECKIDENT (Cell, RESEED, 0)", connection);
                for (int i = 0; i < map.Layers[0].Tiles.Count; ++i)
                {
                    int pass = layerPassability.Tiles[i].Gid;
                    int pen = layerPenalty.Tiles[i].Gid;
                    int type = layerType.Tiles[i].Gid != 0 ? layerType.Tiles[i].Gid : 3;
                    int picture = layerGraph.Tiles[i].Gid;
                    string sqlExp = string.Format(@"INSERT INTO Cell (Passability, Penalty, Production, Picture) 
                            VALUES ({0}, {1}, {2}, {3}); 
                            UPDATE Cell SET Id_city = CASE Id WHEN 118 THEN 1 WHEN 622 THEN 2 END", pass, pen, type, picture);
                    //sqlExp = string.Format(@"UPDATE Cell SET Passability = {0}, Penalty = {1}, Production = {2}, 
                            //Picture = {3} WHERE Id = {4}", pass, pen, type, picture, i + 1);
                    cmd = new SqlCommand(sqlExp, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            //DataBaseCommands.Cleaning();*/
            OpenGameProcess("");
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "SAVE (*.save) | *.save";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                DataBaseCommands.Updating(opf.FileName);
                OpenGameProcess(opf.FileName);
            }
        }

        private void OpenGameProcess(string path)
        {
            GameProcess form = new GameProcess();
            form.mainMenu = this;
            this.Visible = false;
            form.LoadSave(path);
            form.Show();
            form.Activate();
        }
    }
}
