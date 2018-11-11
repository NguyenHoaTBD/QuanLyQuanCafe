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
            try
            {
                string query = "Exec USP_GETBillByTableAndStatus @idTable , @status ";
                int result = 0;
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { table, status });
                if (data.Rows.Count > 0)
                {
                    Bill bill = new Bill(data.Rows[0]);
                    return bill.Id;
                }
                return -1;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        public void InsertBill(int idTable)
        {
            string query = "Exec USP_InsertBill @idTable";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTable });
        }
        /// <summary>
        /// Get id max bill
        /// </summary>
        /// <returns></returns>
        public int GetBillIdMax()
        {
            try
            {
                string query = "Select Max(Id) From Bill";
                return (int)DataProvider.Instance.ExecuteScalar(query);
            }
            catch
            {
                return 1;
            }
        }
        /// <summary>
        /// Check out 
        /// </summary>
        public void CheckOut(int idBill, int disCount)
        {
            string query = "Exec USP_CheckOut @idBill , @disCount";
            int checkout = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill, disCount });
        }
    }
}
