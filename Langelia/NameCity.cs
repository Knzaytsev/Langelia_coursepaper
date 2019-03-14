using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Langelia
{
    public partial class NameCity : Form
    {
        public NameCity()
        {
            InitializeComponent();
        }

        private void DoneName_Click(object sender, EventArgs e)
        {
            if (CityName.Text != "")
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
