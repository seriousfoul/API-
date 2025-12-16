namespace WebApplication3.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Numerics;

public class DBManager
{
    private readonly string conn = "Data Source=(localdb)\\MSSQLLocalDB;Database=test2;User ID=student;Password=student;Trusted_Connection=True";

    public List<DBClass> UserSelect(string name)
    {
        List<DBClass> list = new List<DBClass>();
        try
        {
            string sql = "UserSelect";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@name", name);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommamd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int sex = 0;
                    if (reader.GetBoolean(4))
                        sex = 1;                    

                    list.Add(
                        new DBClass
                        {
                            userId = reader.GetInt32(0),
                            name = reader.GetString(1),
                            phone = reader.GetString(2),
                            address = reader.GetString(3),
                            sex = sex
                        }
                    );
                }
            }            
            else
            {
                return null;
            }
            sqlConnect.Close();

            return list;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public bool UserInsert(string name = "john", string phone = "0912345678", string address = "abcd",int sex = 0) {
        try
        {
            string sql = "UserInsert";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@name", name);
            sqlCommamd.Parameters.AddWithValue("@phone", phone);
            sqlCommamd.Parameters.AddWithValue("@address", address);
            sqlCommamd.Parameters.AddWithValue("@sex", sex);
            sqlConnect.Open();
            int count = sqlCommamd.ExecuteNonQuery();
            sqlConnect.Close();

            return count > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UserUpdate(string oldName = "john", string newName = "john")
    {
        try
        {
            var sql = "UserUpdate";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@oldName", oldName);
            sqlCommamd.Parameters.AddWithValue("@newName", newName);

            sqlConnect.Open();
            int count = sqlCommamd.ExecuteNonQuery();
            sqlConnect.Close();

            return count > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UserDelete(string name)
    {
        try
        {
            string sql = "UserDelete";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@name", name);
            sqlConnect.Open();
            int count = sqlCommamd.ExecuteNonQuery();
            sqlConnect.Close();

            return count > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public List<DBClass> AllUserSelect()
    {
        List<DBClass> list = new List<DBClass>();
        try
        {
            string sql = "select * from [user]";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommamd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int sex = 0;
                    if (reader.GetBoolean(4))
                        sex = 1;

                    list.Add(
                        new DBClass
                        {
                            userId = reader.GetInt32(0),
                            name = reader.GetString(1),
                            phone = reader.GetString(2),
                            address = reader.GetString(3),
                            sex = sex
                        }
                    );
                }
            }
            else
            {
                return null;
            }
            sqlConnect.Close();

            return list;
        }
        catch (Exception ex)
        {
            return null;
        }
    }



}



