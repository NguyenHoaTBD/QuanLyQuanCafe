using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Table
    {
        public Table(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }

        public static int TableWidth = 70;
        public static int TableHeight = 70;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
