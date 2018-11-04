using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set => instance = value;
        }
        private MenuDAO() { }
        public List<Menu> GetListMenuByTableId(int id)
        {
            string query = "Exec USP_GetMenuByTableId @id , @status";
            List<Menu> Result = new List<Menu>();
            //status = 0 is uncheckout
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id , 0});
            if(data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    Menu menu = new Menu(item);
                    Result.Add(menu);
                }
            }
            return Result;
        }
    }
}
