using System.Data;

namespace QuanLyQuanCafe.DAO
{
    internal class AccountDAO
    {
        //design pattern singleton 
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            DataTable result = new DataTable();
            string query = "Exec USP_Login @userName , @passWord";
            result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }
    }
}
