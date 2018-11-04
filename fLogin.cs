using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to close the app?","Confirm!", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (Login(username, password))
            {
                fHome fHome = new fHome();
                this.Hide();
                fHome.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is invalid!");
            }
           
        }
        private bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
    }
}
