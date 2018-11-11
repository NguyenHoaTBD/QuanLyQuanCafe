using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class CategoryDAO
    {
        #region Singleton
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set => instance = value;
        }
        private CategoryDAO() { }
        #endregion

        public List<Category> GetListCategory()
        {
            List<Category> CategoryList = new List<Category>();
            string query = "Select * From dbo.FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
                foreach (DataRow item in data.Rows)
                {
                    Category cat = new Category(item);
                    CategoryList.Add(cat);
                }
            return CategoryList;
        }
    }
}
