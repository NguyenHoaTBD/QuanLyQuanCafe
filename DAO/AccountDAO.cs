using QuanLyQuanCafe.DTO;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyQuanCafe.DAO
{
    class AccountDAO
    {
        #region  design pattern singleton 
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }
        private AccountDAO() { }
        #endregion
        public string Md5Encoding(string input)
        {
            byte[] temp = Encoding.ASCII.GetBytes(input);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasResult = "";
            foreach (byte item in hasData)
            {
                hasResult += item;
            }
            char[] charArr = hasResult.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr);
        }

        public bool Login(string username, string password)
        {
            string hasPass = Md5Encoding(password);
            DataTable result = new DataTable();
            string query = "Exec USP_Login @userName , @passWord";
            result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, hasPass });
            return result.Rows.Count > 0;
        }

        public Account GetAccountByName(string UserName)
        {
            string query = "Select * From Account Where UserName = '" + UserName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAccount(Account account, string newPassWord)
        {
            string query = "USP_UpdateAccount @userName , @passWord , @disPlayname , @newPassword ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { account.UserName, Md5Encoding(account.PassWord), account.Displayname, Md5Encoding(newPassWord) });

            return result > 0;
        }

        public DataTable GetListAccount()
        {
            DataTable ListAcc = DataProvider.Instance.ExecuteQuery("Select UserName, DisplayName, Type From Account Where isDelete = 0");
            return ListAcc;
        }
        public bool ResetPassWord(string userName)
        {
            string query = "Update Account Set PassWord = '" + Md5Encoding("0") + "' Where UserName = '" + userName + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
