namespace WebApplication3.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Numerics;

public class DBManager
{
    // SQL SERVER 所需參數
    private readonly string conn = "Data Source=(localdb)\\MSSQLLocalDB;Database=BackendExamHub;User ID=student;Password=student;Trusted_Connection=True";

    // 執行Select語法，並回傳給API
    public List<DBSelectOutClass> UserSelect(DBNameInClass data)
    {
        List<DBSelectOutClass> list = new List<DBSelectOutClass>();
        try
        {
            string sql = "ACPD_Select";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@name", data.name);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommamd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(
                        new DBSelectOutClass
                        {
                            sID = reader["ACPD_SID"].ToString(),
                            cName = reader["ACPD_Cname"].ToString(),
                            eName = reader["ACPD_Ename"].ToString(),
                            sName = reader["ACPD_Sname"].ToString(),
                            eMail = reader["ACPD_EMail"].ToString(),
                            status = (byte)reader["ACPD_Status"],
                            stop = (bool)reader["ACPD_Stop"],
                            stopMemo = reader["ACPD_StopMemo"].ToString(),
                            loginID = reader["ACPD_LoginID"].ToString(),
                            loginPWD = reader["ACPD_LoginPWD"].ToString(),
                            memo = reader["ACPD_Memo"].ToString(),
                            nowDateTime = reader.GetDateTime(reader.GetOrdinal("ACPD_NowDateTime")),
                            nowID = reader["ACPD_NowID"].ToString(),
                            updDateTime = reader.GetDateTime(reader.GetOrdinal("ACPD_UPDDateTime")),
                            updID = reader["ACPD_UPDID"].ToString()
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


    public bool UserInsert(DBInsertInClass data) {
        try
        {
            string sql = "ACPD_Insert";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@Cname", data.cName);
            sqlCommamd.Parameters.AddWithValue("@Ename", data.eName);
            sqlCommamd.Parameters.AddWithValue("@Sname", data.sName);
            sqlCommamd.Parameters.AddWithValue("@Email", data.eMail);
            sqlCommamd.Parameters.AddWithValue("@LoginID", data.loginID);
            sqlCommamd.Parameters.AddWithValue("@LoginPWD", data.loginPWD);
            sqlCommamd.Parameters.AddWithValue("@CreaterName", data.createrName);

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

    public bool UserUpdate(DBUpdateInClass data)
    {
        try
        {
            var sql = "ACPD_Update";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@oldName", data.oldName);
            sqlCommamd.Parameters.AddWithValue("@newName", data.newName);

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

    public bool UserDelete(DBNameInClass data)
    {
        try
        {
            string sql = "ACPD_Delete";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlCommamd.CommandType = CommandType.StoredProcedure;
            sqlCommamd.Parameters.AddWithValue("@name", data.name);
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

    public List<DBSelectOutClass> AllUserSelect()
    {
        List<DBSelectOutClass> list = new List<DBSelectOutClass>();
        try
        {
            string sql = "select * from MyOffice_ACPD";
            var sqlConnect = new SqlConnection(conn);
            var sqlCommamd = new SqlCommand(sql, sqlConnect);
            sqlConnect.Open();
                        
            SqlDataReader reader = sqlCommamd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(
                        new DBSelectOutClass
                        {                            
                            sID = reader["ACPD_SID"].ToString(),
                            cName = reader["ACPD_Cname"].ToString(),
                            eName = reader["ACPD_Ename"].ToString(),
                            sName = reader["ACPD_Sname"].ToString(),
                            eMail = reader["ACPD_EMail"].ToString(),
                            status = (byte)reader["ACPD_Status"],
                            stop = (bool)reader["ACPD_Stop"],
                            stopMemo = reader["ACPD_StopMemo"].ToString(),
                            loginID = reader["ACPD_LoginID"].ToString(),
                            loginPWD = reader["ACPD_LoginPWD"].ToString(),
                            memo = reader["ACPD_Memo"].ToString(),
                            nowDateTime = reader.GetDateTime(reader.GetOrdinal("ACPD_NowDateTime")),
                            nowID = reader["ACPD_NowID"].ToString(),
                            updDateTime = reader.GetDateTime(reader.GetOrdinal("ACPD_UPDDateTime")),
                            updID = reader["ACPD_UPDID"].ToString()
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



