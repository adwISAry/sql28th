using ADO.NET.Helpers;
using ADO.NET.Services;
using sqltask27th.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sqltask27th.Services
{
    public class BlogService : IBaseService<Blog>
    {
        int IBaseService<Blog>.Create(Blog data)
        {
            string query = $"INSERT INTO Blogs (Title, Description, UserId) VALUES (N'{data.Title}', N'{data.Description}', '{data.UserId}')";
            return SqlHelper.Exec(query);
        }

        public int Delete(int id)
        {
            string query = $"DELETE FROM Blogs WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }

        List<Blog> IBaseService<Blog>.GetAll()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM Blogs");
            List<Blog> list = new List<Blog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blog
                {
                    Id = (int)row["Id"],
                    Title = row["Title"] != DBNull.Value ? (string)row["Title"] : null,
                    Description = row["Description"] != DBNull.Value ? (string)row["Description"] : null,
                    UserId = row["UserId"] != DBNull.Value ? (string)row["UserId"] : null,
                });
            }
            return list;
        }

        Blog IBaseService<Blog>.GetById(int id)
        {
            string query = $"SELECT * FROM Blogs WHERE Id = {id}";
            DataTable dt = SqlHelper.GetDatas(query);

            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                return new Blog
                {
                    Id = (int)row["Id"],
                    Title = row["Title"] != DBNull.Value ? (string)row["Title"] : null,
                    Description = row["Description"] != DBNull.Value ? (string)row["Description"] : null,
                    UserId = row["UserId"] != DBNull.Value ? (string)row["UserId"] : null,
                };
            }

            return null; 
        }

        int IBaseService<Blog>.Update(int id, Blog data)
        {
            string query = $"UPDATE Blogs SET Title = N'{data.Title}', Description = N'{data.Description}', UserId = '{data.UserId}' WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }

        List<Blog> IBaseService<Blog>.GetWhere(string query)
        {
            throw new NotImplementedException();
        }

        int IBaseService<Blog>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
