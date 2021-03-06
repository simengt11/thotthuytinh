﻿using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Windows;

namespace OMS.Model
{
    public class DBConnect
    {
        private readonly SQLiteConnection _con = new SQLiteConnection();
        private static string _path = "";


        public bool Init()
        {
            string dbName = "OrderDatabase.db3";
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, dbName);
            if (!File.Exists(filePath))
            {
                return false;
            }
            _path = filePath;
            return true;            
        }

        public void CreateConection()
        {
            string strConnect = "Data Source=" + _path + ";Version=3; Pooling=true";
            _con.ConnectionString = strConnect;
            _con.Open();
        }

        public void CloseConnection()
        {
            _con.Close();
        }

        public void ExecuteQuery(string query)
        {
            CreateConection();
            SQLiteCommand cmd = new SQLiteCommand(query, _con);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        public int ExecuteQueryToGetIdAndCount(string query)
        {
            CreateConection();
            SQLiteCommand cmd = new SQLiteCommand(query, _con);
            var reader = cmd.ExecuteReader();
            string a;
            using (DataTable dt = new DataTable())
            {
                dt.Load(reader);
                try
                {
                    DataRow row = dt.Rows[0];
                    a = row[0].ToString();
                }
                catch (Exception)
                {
                    a = "0";
                }
            }
            CloseConnection();
            return int.Parse(a);
        }

        public DataTable SelectQuery(string query)
        {
            CreateConection();
            DataTable dataTable = new DataTable();
            SQLiteCommand command = new SQLiteCommand(query, _con)
            {
                CommandText = query
            };
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(dataTable);
            CloseConnection();
            return dataTable;
        }
    }
}