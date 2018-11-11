using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class TableDAO
    {
        #region Singleton design parten
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return instance;
            }
            private set => instance = value;
        }
        private TableDAO() { }
        #endregion

        public List<Table> GetListTable()
        {
            List<Table> listTable = new List<Table>();
            string query = "Exec USP_GetListTable";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in result.Rows)
            {
                Table table = new Table(row);
                listTable.Add(table);
            }
            return listTable;
        }
        public void ChangeStatusTable(int id, string status)
        {
            string query = "Update TableFood Set [status] = '" + status + "' Where id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public bool SwitchTable(int idFirstTable, int idSecondTable)
        {
            string query = "EXEC USP_SwitchTable @idFirstTable , @idsecondTable ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {idFirstTable, idSecondTable });

            return result > 0 ? true : false;
        }
    }
}
