using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fProfile : Form
    {
        private Account account;
        public Account Account
        {
            get => account;
            set { account = value; SetDataAccount(account); }

        }
        public fProfile(Account account)
        {
            InitializeComponent();
            this.Account = account;
        }
        #region METHOD
        public void UpdateAccount()
        {
            string newpass = txtNewpass.Text;
            if (!newpass.Equals(txtConfirmpass.Text))
                MessageBox.Show("New Password is not match!");
            else
            {
                Account upDateAccount = new Account();
                upDateAccount.UserName = account.UserName;
                upDateAccount.PassWord = txtPassword.Text;
                upDateAccount.Displayname = txtDisplayname.Text;
                if(AccountDAO.Instance.UpdateAccount(upDateAccount, newpass))
                {
                    MessageBox.Show("Change Account is successful!");
                }
                else
                {
                    MessageBox.Show("Change Account is failed!");
                }
            }
        }

        public void SetDataAccount(Account account)
        {
            txtUsername.Text = account.UserName;
            txtDisplayname.Text = account.Displayname;

        }
        #endregion
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            UpdateAccount();
        }
    }
}
