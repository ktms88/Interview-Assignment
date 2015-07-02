using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class dalStudentdet
    {
        public string MyProperty_StudenrID { get; set; }
        public string MyProperty_StudentName { get; set; }
        public DateTime MyProperty_DOB { get; set; }
        public decimal MyProperty_GPA { get; set; }
        public string MyProperty_active { get; set; }

        public string MyProperty_Exception { get; set; }

        private DataSet dsStudent = new DataSet();
        public DataSet MyProperty_dsStudent
        {
            get { return dsStudent; }
            set { dsStudent = value; }
        }


        private DataTable dtStudent = new DataTable();
        public DataTable MyProperty_dtStudent
        {
            get { return dtStudent; }
            set { dtStudent = value; }
        }
    }
}
