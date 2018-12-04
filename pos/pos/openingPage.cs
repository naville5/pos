using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
    public partial class openingPage : MaterialSkin.Controls.MaterialForm
    {
        dashboard db = new dashboard();
        public openingPage()
        {
            InitializeComponent();
        }
        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            db.Show();
        }
    }
}
