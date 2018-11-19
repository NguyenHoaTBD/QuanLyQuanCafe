using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        public Account()
        {
        }
        public Account(DataRow row)
        {
            UserName = row["USerName"].ToString();
            Displayname = row["DisplayName"].ToString();
            PassWord = row["PassWord"].ToString();
            Type = (int)row["Type"];
        }
        public string UserName { get; set; }
        public string Displayname { get; set; }
        public string PassWord { get; set; }
        public int Type { get; set; }
    }
}
