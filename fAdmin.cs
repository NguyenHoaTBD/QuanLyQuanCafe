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
using QuanLyQuanCafe.DAO;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
             
        }


        #region Method
        /// <summary>
        /// List Account
        /// </summary>
              
        #endregion
        #region Event Handle 
        #region Account
        private void btnSearchacount_Click(object sender, EventArgs e)
        {
            string query = "";
            string username = txtSearchAccount.Text;
            if (!string.IsNullOrWhiteSpace(username))
            {
                query = "EXEC dbo.USP_GetAccountByUserName @username";
                dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            }
            else
            {
                query = "SELECT * FROM dbo.Account";
                dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
        }
        /// <summary>
        /// Add account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddaccount_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.Account";
            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        #endregion
        #region Category
        #endregion
        #endregion
    }
}
