using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
        private BillDAO() { }

        /// <summary>
        /// Return Id table if success else return -1
        /// </summary>
        /// <param name="table"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetUncheckOutBillByTableId(int table, int status)
        {
            string query = "Exec USP_GETBillByTableAndStatus @idTable , @status ";
            int result = 0;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {table, status});
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

    }
}
