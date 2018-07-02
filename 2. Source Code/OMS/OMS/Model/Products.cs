﻿using System;
using System.Collections.ObjectModel;
using System.Data;

namespace OMS.Model
{
    public class Products
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }
        public string Price { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Quantity { get; set; }
        public Accounts CreatedBy { get; set; }
        public string Status { get; set; }

        public ObservableCollection< Products> LoadProduct()
        {
            DBConnect dbConnect = new DBConnect();
            ObservableCollection<Products> temp= new ObservableCollection<Products>();
            const string query = @"select * from Products where status = 'Chưa xóa';";
            DataTable dataTable = dbConnect.SelectQuery(query);
            foreach (var row in dataTable.Rows)
            {
                Products product = new Products
                {
                    Id = (string)((DataRow)row).ItemArray[0],
                    Name = (string)((DataRow)row).ItemArray[1],
                    Description = (string)((DataRow)row).ItemArray[2],
                    Weight = (string)((DataRow)row).ItemArray[3],
                    Width = (string)((DataRow)row).ItemArray[4],
                    Height = (string)((DataRow)row).ItemArray[5],
                    Length = (string)((DataRow)row).ItemArray[6],
                    Price = (string)((DataRow)row).ItemArray[7],
                    Image1 = (string)((DataRow)row).ItemArray[8],
                    Image2 = (string)((DataRow)row).ItemArray[9],
                    Image3 = (string)((DataRow)row).ItemArray[10],
                    Quantity = Convert.ToInt32(((DataRow)row).ItemArray[11]),
                    CreatedBy = new Accounts { Id = Convert.ToInt32(((DataRow)row).ItemArray[12]) },
                    Status = (string)((DataRow)row).ItemArray[13]
                };
                temp.Add(product);
            }
            return temp;
        }

    }
}