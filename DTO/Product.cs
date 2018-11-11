using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Product
    {
        public Product(int id, string name, int idCategory, int price)
        {
            this.Id = id;
            this.Name = name;
            this.idCategory = idCategory;
            this.Price = price;
        }
        public Product(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.idCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int idCategory { get; set; }
        public float Price { get; set; }
    }
}
