using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class BillInfoDAO
    {
        #region Singleton pattern
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return instance;}
            private set => instance = value;
        }
        private BillInfoDAO() { }
        #endregion

        public List<BillInfo> GetlistBillInfo(int id)
        {
            List<BillInfo> billinfoList = new List<BillInfo>();
            string query = "Exec USP_GetListBillInfo @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            if(data.Rows.Count > 0)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    BillInfo billinfo = new BillInfo(dataRow);
                    billinfoList.Add(billinfo);
                }
            }
            return billinfoList;
        }
        public void InsertBillInfo(int idProduct, int idBill, int count)
        {
            string query = "Exec USP_InsertBillInfo @idBill , @idProduct , @count";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill, idProduct, count });
        }
    }
}
