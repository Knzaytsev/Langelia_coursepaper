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
    public partial class SearchResult : Form
    {
        string _cnct;
        string _sqlExp;
        public SearchResult()
        {
            InitializeComponent();
        }

        public SearchResult(string sqlExp, string cnct)
        {
            InitializeComponent();
            _sqlExp = sqlExp;
            _cnct = cnct;
        }

        private void SearchResult_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(_cnct))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(_sqlExp, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
