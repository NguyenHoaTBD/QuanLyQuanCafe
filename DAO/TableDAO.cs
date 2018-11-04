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

    }
}
