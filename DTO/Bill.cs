using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class Bill
    {
        public Bill(int Id, DateTime? CheckIn, DateTime? CheckOut, int idTable, int Status)
        {
            this.Id = Id;
            this.CheckIn = CheckIn;
            this.CheckOut = CheckOut;
            this.idTable = idTable;
            this.Status = Status;
        }
        public Bill(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.CheckIn = (DateTime?)row["DateCheckIn"];
            var checkOutTemp = row["DateCheckOut"];
            if (checkOutTemp.ToString() != "")
                this.CheckOut = (DateTime?)row["DateCheckOut"]; 
            this.idTable = (int)row["idTable"];
            this.Status = (int)row["Status"];
        }
        public int Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int idTable { get; set; }
        public int Status { get; set; }
    }
}
