using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
    public partial class login : MaterialSkin.Controls.MaterialForm
    {

        MySqlConnection con = null;
        MySqlCommand cmd;
        MySqlDataReader mdr;
        DataTable dt;

        mySqlConnect conn = new mySqlConnect();
        openingPage op = new openingPage();

        public login()
        {
            InitializeComponent();
            con = conn.connect();
        }

        private void btnlogin_Click(object sende, EventArgs e)
        {
            if (ISvalidated())
            {
                try
                {
                    IsLoginCorrect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        //usable methods
        public void IsLoginCorrect()
        {

            dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("IsLoginCorrect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("users", textadmin.Text);
                cmd.Parameters.AddWithValue("passwords", textpass.Text);
                mdr = cmd.ExecuteReader();
                dt.Load(mdr);

                if (dt.Rows.Count.ToString() == "1")
                {
                    MessageBox.Show("Login Success!");
                    this.Hide();
                    op.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect UserName or Password!!!", "ERROr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textadmin.Clear();
                    textpass.Clear();
                    textadmin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private bool ISvalidated()
        {
            if (textadmin.Text.Trim() == string.Empty)
            {
                MessageBox.Show("user name is requried", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textadmin.Clear();
                textpass.Clear();
                textadmin.Focus();
                return false;
            }

            else if (textpass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textpass.Clear();
                textpass.Focus();
                return false;
            }
            return true;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
