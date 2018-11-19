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
        public List<Product> GetListProductById(int id)
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
        public List<Product> GetListProduct()
        {
            List<Product> ProductList = new List<Product>();
            string query = "Select * From Food Where isDelete = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
                foreach (DataRow item in data.Rows)
                {
                    Product prod = new Product(item);
                    ProductList.Add(prod);
                }
            return ProductList;
        }
        public bool InsertNewProduct(string Name, int idCategory, int Price)
        {
            string query = $"Insert Food ([name], idCategory, price) Values ('{Name}', '{idCategory}', '{Price}')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0 ? true : false;
        }
        public bool UpdateProduct(Product product)
        {
            string query = $"Update Food Set [name] = '{product.Name}', idCategory = '{product.idCategory}', price = '{product.Price}' Where id = '{product.Id}'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0 ? true : false;
        }
        public bool DeleteProductById(int id)
        {
            string query = $"Update Food Set isDelete = '1' Where id = '{id}'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0 ? true : false;
        }

        public List<Product> SearchProductByName(string name)
        {
            List<Product> ProductList = new List<Product>();
            string query = $"Select * From Food Where isDelete = 0 And [dbo].[fuConvertToUnsign1]([name]) Like [dbo].[fuConvertToUnsign1]('%{name}%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
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
