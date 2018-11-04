using System.Data;

namespace QuanLyQuanCafe.DTO
{
    internal class BillInfo
    {
        public BillInfo(int Id, int idFood, int idBill, int count)
        {
            this.Id = Id;
            this.idBill = idBill;
            this.idFood = idFood;
            this.count = count;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.idBill = (int)row["idBill"];
            this.idFood = (int)row["idFood"];
            this.count = (int)row["count"];
        }

        public int Id { get; set; }
        public int idFood { get; set; }
        public int idBill { get; set; }
        public int count { get; set; }
    }
}
