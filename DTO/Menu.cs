using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Menu
    {
        public Menu(int count, int price, float totalPrice, string categoryName)
        {
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
            this.Name = categoryName;
        }
        public Menu(DataRow row)
        {
            this.Count = (int)row["Count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
            this.Name = row["Name"].ToString();
        }
        public int Count { get; set; }
        public float Price { get; set; }
        public float TotalPrice{get;set;}
        public string Name { get; set; }
    }
}
