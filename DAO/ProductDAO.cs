using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class ProductDAO
    {
        #region Singleton
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return instance; }
            private set => instance = value;
        }
        private ProductDAO() { }
        #endregion

        /// <summary>
        /// Return List of Priduct by id category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Product> GetListCategory(int id)
        {
            List<Product> ProductList = new List<Product>();
            string query = "Exec USP_GetListFoodByCategoryId @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            if (data.Rows.Count > 0)
                foreach (DataRow item in data.Rows)
                {
                    Product prod = new Product(item);
                    ProductList.Add(prod);
                }
            return ProductList;
        }
    }
}
