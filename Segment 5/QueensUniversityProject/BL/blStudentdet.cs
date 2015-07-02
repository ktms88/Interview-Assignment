using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BL
{
    public class blStudentdet
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter ada;

        //Creating a instance of blConnection
        blConnection myConn = new blConnection();

        public blStudentdet()
        {
            conn = new SqlConnection(myConn.getConstr());  // Calling the getConstr method in blConnection
            conn.Open();

            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            ada = new SqlDataAdapter();
            ada.SelectCommand = cmd;
        }


        //BL add temp students
        public void SaveStInfoTmp(dalStudentdet obj)
        {
            try
            {
                cmd.CommandText = "SaveStInfoTmp";

                cmd.Parameters.AddWithValue("@studentID", obj.MyProperty_StudenrID);
                cmd.Parameters.AddWithValue("@stName", obj.MyProperty_StudentName);
                cmd.Parameters.AddWithValue("@DOB", obj.MyProperty_DOB);
                cmd.Parameters.AddWithValue("@GPA", obj.MyProperty_GPA);
                cmd.Parameters.AddWithValue("@Active", obj.MyProperty_active);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {

                obj.MyProperty_Exception = ex.Message;
            }
        }


        //BL add temp students
        public void SaveStudentInfo(dalStudentdet obj)
        {
            try
            {
                cmd.CommandText = "SaveStudentInfo";

                cmd.Parameters.AddWithValue("@studentID", obj.MyProperty_StudenrID);
                cmd.Parameters.AddWithValue("@stName", obj.MyProperty_StudentName);
                cmd.Parameters.AddWithValue("@DOB", obj.MyProperty_DOB);
                cmd.Parameters.AddWithValue("@GPA", obj.MyProperty_GPA);
                cmd.Parameters.AddWithValue("@Active", obj.MyProperty_active);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {

                obj.MyProperty_Exception = ex.Message;
            }
        }

        //BL get student list to grid
        public dalStudentdet getStudentListToGrid(dalStudentdet obj)
        {
            try
            {
                cmd.CommandText = "loadTaksToGrid";
                ada.Fill(obj.MyProperty_dsStudent, "loadStudents");
                ada.Fill(obj.MyProperty_dtStudent);
                return obj;
            }
            catch (Exception ex)
            {
                obj.MyProperty_Exception = ex.Message;
                return obj;
            }

        }



    }
}
