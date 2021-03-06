﻿using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Category
    {
        public Category(int id, string name)
       {
            this.Id = id;
            this.Name = name;
        }
        public Category(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
        }
    public int Id { get; set; }
    public string Name { get; set; }
}
}
