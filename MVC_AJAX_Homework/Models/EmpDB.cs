using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC_AJAX_Homework.Models
{
    public class EmpDB
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<EMP> SelectEmp()
        {
            List<EMP> empList = new List<EMP>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("usp_SelectEmp", conn);
                comm.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    empList.Add(new EMP
                    {
                        Empno = Convert.ToInt32(dr["EMPNO"]),
                        Ename = dr["ENAME"].ToString(),
                        Job = dr["JOB"].ToString(),
                        MGR = (dr["MGR"] as int?).GetValueOrDefault(),
                        HireDate =  dr["HIREDATE"].ToString().Substring(0,10),
                        Sal = (dr["SAL"] as int?).GetValueOrDefault(),
                        Comm = (dr["COMM"] as int?).GetValueOrDefault(),
                        Deptno = Convert.ToInt32(dr["DEPTNO"])
                    });
                }
            }
                return empList;
        }
        public int InsertEmp(EMP emp)
        {
            int returnValue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("usp_InsertUpdateEmp", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@empno", emp.Empno);     
                comm.Parameters.AddWithValue("@ename", emp.Ename);
                comm.Parameters.AddWithValue("@job", emp.Job);
                comm.Parameters.AddWithValue("@mgr", emp.MGR);
                comm.Parameters.AddWithValue("@hiredate", emp.HireDate);
                comm.Parameters.AddWithValue("@sal", emp.Sal);
                comm.Parameters.AddWithValue("@comm", emp.Comm);
                comm.Parameters.AddWithValue("@deptno", emp.Deptno);
                comm.Parameters.AddWithValue("@Action", "insert");

                returnValue = comm.ExecuteNonQuery();
            }
            return returnValue;
        }
        public int UpdateEmp(EMP emp)
        {
            int returnValue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("usp_InsertUpdateEmp", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@empno", emp.Empno);     
                comm.Parameters.AddWithValue("@ename", emp.Ename);
                comm.Parameters.AddWithValue("@job", emp.Job);
                comm.Parameters.AddWithValue("@mgr", emp.MGR);
                comm.Parameters.AddWithValue("@hiredate", emp.HireDate);
                comm.Parameters.AddWithValue("@sal", emp.Sal);
                comm.Parameters.AddWithValue("@comm", emp.Comm);
                comm.Parameters.AddWithValue("@deptno", emp.Deptno);
                comm.Parameters.AddWithValue("@Action", "update");

                returnValue = comm.ExecuteNonQuery();
            }
            return returnValue;
        }
        public int DeleteEmp(int ID)
        {
            int returnValue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("usp_DeleteEmp", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@empno", ID);    

                returnValue = comm.ExecuteNonQuery();
            }
            return returnValue;
        }
    }
}