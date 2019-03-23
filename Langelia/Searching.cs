using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Langelia
{
    public partial class Searching : Form
    {
        private string sqlCnct;
        public Searching()
        {
            InitializeComponent();
            listView1.Scrollable = true;
        }

        public Searching(string cnct)
        {
            InitializeComponent();
            sqlCnct = cnct;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(sqlCnct))
            {
                connection.Open();
                string sqlExp = "";
                string nameTable = "";
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Игрок":
                        nameTable = "Player";
                        sqlExp = $"SELECT Id, Name_gov, Number_citizen, Number_culture, Number_military, Number_diplomacy, " +
                            $"Name_ruler, Type_ruler_points, Age, Number_production FROM Player";
                        break;
                    case "Город":
                        nameTable = "City";
                        sqlExp = "SELECT * FROM City";
                        break;
                    case "Список построек":
                        nameTable = "List_build";
                        sqlExp = "SELECT * FROM List_build";
                        break;
                }
                SqlDataReader reader = (new SqlCommand(sqlExp, connection)).ExecuteReader();
                TreeNode node = new TreeNode(nameTable);
                node.Name = nameTable;
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    node.Nodes.Add(reader.GetName(i));
                }
                treeView1.Nodes.Add(node);
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
        }

        private void rightOne_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            RightOne(node);
        }

        private void AddingObjects(string parent, string tableAttr)
        {
            FlowLayoutPanel panelWithObj = new FlowLayoutPanel();
            panelWithObj.Name = tableAttr;
            panelWithObj.Size = new Size(flowLayoutPanel1.Width, 25);
            ListViewItem item = new ListViewItem(tableAttr);
            listView1.Items.Add(item);
            Label table = new Label();
            table.Text = parent;
            table.Location = new Point(0, 4);
            table.AutoSize = true;
            panelWithObj.Controls.Add(table);
            //flowLayoutPanel1.Controls.Add(table);
            Label attribute = new Label();
            attribute.Text = tableAttr;
            attribute.AutoSize = true;
            attribute.Location = new Point(table.Width + 2, 4);
            panelWithObj.Controls.Add(attribute);
            //flowLayoutPanel1.Controls.Add(attribute);
            ComboBox condition = new ComboBox();
            condition.Items.Add(">");
            condition.Items.Add(">=");
            condition.Items.Add("<");
            condition.Items.Add("<=");
            condition.Items.Add("=");
            condition.Location = new Point(attribute.Width + 2, 0);
            condition.Size = new Size(40, condition.Size.Height);
            panelWithObj.Controls.Add(condition);
            //flowLayoutPanel1.Controls.Add(condition);
            TextBox condName = new TextBox();
            condName.Location = new Point(attribute.Width + 2, 2);
            int width = panelWithObj.Width - 40 - condition.Location.X - 40;
            condName.Size = new Size(width, attribute.Height);
            panelWithObj.Controls.Add(condName);
            //flowLayoutPanel1.Controls.Add(condName);
            flowLayoutPanel1.Controls.Add(panelWithObj);
        }

        private void startSearching_Click(object sender, EventArgs e)
        {
            string sqlExp = "";
            using(SqlConnection connection = new SqlConnection(sqlCnct))
            {
                connection.Open();
                string tn = "";
                string att = "";
                string cond = "";
                string condName = "";
                foreach (FlowLayoutPanel flp in flowLayoutPanel1.Controls)
                {
                    if (sqlExp != "")
                    {
                        sqlExp += "UNION \n";
                    }
                    tn = flp.Controls[0].Text;
                    att = flp.Controls[1].Text;
                    cond = ((ComboBox)flp.Controls[2]).SelectedItem != null ? 
                        ((ComboBox)flp.Controls[2]).SelectedItem.ToString() : "";
                    condName = flp.Controls[3].Text;
                    sqlExp += $"SELECT {att} FROM {tn} ";
                    if (cond != "")
                    {
                        sqlExp += $"WHERE {att} {cond} {condName} \n";
                    }
                }
            }
            SearchResult result = new SearchResult(sqlExp, sqlCnct);
            result.Show();
        }

        private void leftOne_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            LeftOne(item);
        }

        private void RightOne(TreeNode node)
        {
            string child = node.Text;
            string parent = node.Parent.Text;
            string tableAttr = parent + "." + child;
            //treeView1.Nodes[parent].Nodes.Remove(node);
            treeView1.SelectedNode.Remove();
            AddingObjects(parent, tableAttr);
        }

        private void rightAll_Click(object sender, EventArgs e)
        {
            TreeView tv = treeView1;
            foreach (TreeNode i in treeView1.Nodes)
            {
                foreach (TreeNode n in i.Nodes)
                {
                    RightOne(n);
                }
                foreach (TreeNode n in i.Nodes)
                {
                    if (n != null)
                    {
                        treeView1.Nodes.Remove(n);
                    }
                }
            }

        }

        private void LeftOne(ListViewItem item)
        {
            string parent = item.Text.Substring(0, item.Text.IndexOf('.'));
            string child = item.Text.Substring(item.Text.IndexOf('.') + 1, item.Text.Length - item.Text.IndexOf('.') - 1);
            //listView1.SelectedItems[0].Remove();
            listView1.Items.Remove(item);
            treeView1.Nodes[parent].Nodes.Add(child);
            flowLayoutPanel1.Controls.RemoveByKey(item.Text);
        }

        private void leftAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem i in listView1.Items)
            {
                LeftOne(i);
            }
        }
    }
}
