using ADO.NET.Helpers;
using ADO.NET.Services;
using sqltask27th.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sqltask27th.Services
{
    internal class UserService : IBaseService<Users>
    {
        public int Create(Users data)
        {
            string query = $"INSERT INTO Users (FirstName, LastName, ) VALUES (N'{data.FirstName}', N'{data.LastName}', '{data.Email}')";
            return SqlHelper.Exec(query);
        }

        public int Delete(int id)
        {
            string query = $"DELETE FROM Users WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }

        public List<Users> GetAll()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM Users");
            List<Users> list = new List<Users>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Users
                {
                    Id = (int)row["Id"],
                    FirstName = row["FirstName"] != DBNull.Value ? (string)row["FirstName"] : null,
                    LastName = row["LastName"] != DBNull.Value ? (string)row["LastName"] : null,
                 
            }
            return list;
        }

        public Users GetById(int id)
        {
            string query = $"SELECT * FROM Users WHERE Id = {id}";
            DataTable dt = SqlHelper.GetDatas(query);

            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                return new Users
                {
                    Id = (int)row["Id"],
                    FirstName = row["FirstName"] != DBNull.Value ? (string)row["FirstName"] : null,
                    LastName = row["LastName"] != DBNull.Value ? (string)row["LastName"] : null,
                   
            }

            return null;
        }

        public List<Users> GetWhere(string query)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Users data)
        {
            string query = $"UPDATE Users SET FirstName = N'{data.FirstName}', LastName = N'{data.LastName}', Email = '{data.Email}' WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }
    }
}
