using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using DAL;

namespace QueensUniversityProject
{
    public partial class frmStudentDetailsForm : Form
    {
        frmStudentRegistration frm2 = null;
        public frmStudentDetailsForm()
        {
            InitializeComponent();
            frm2 = new frmStudentRegistration(this);

        }

        //public void AddRecord(string StID, string Name, DateTime DOB, decimal GPAVal, string Active)
        //{

        //    string StID2 = StID;
        //    string Name2 = Name;
        //    string DOB2 = DOB.ToShortDateString();
        //    string GPAVal2 = GPAVal.ToString();
        //    string Active2 = Active;


        //    DataGridViewRow row = (DataGridViewRow)dgvStDetails.Rows[0].Clone();
        //    row.Cells[0].Value = StID;
        //    row.Cells[1].Value = Name;
        //    row.Cells[2].Value = DOB;
        //    row.Cells[3].Value = GPAVal;
        //    row.Cells[4].Value = Active;
        //    dgvStDetails.Rows.Add(row);
        //}

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //if (frm2 != null)
            //{
                frm2.ShowDialog();
            //}
        }

        private void frmStudentDetailsForm_Load(object sender, EventArgs e)
        {
            FillGrdStudents();
        }

        //This is for save student info
        private void SaveStudentDetails()
        {
            blStudentdet bl = new blStudentdet();
            dalStudentdet dal = new dalStudentdet();
            dal.MyProperty_Exception = "";

            for (int i = 0; i < dgvStDetails.Rows.Count; i++)
            {
                dal.MyProperty_StudenrID = dgvStDetails.Rows[i].Cells["StudentID"].Value.ToString();
                dal.MyProperty_StudentName = dgvStDetails.Rows[i].Cells["StudentName"].Value.ToString();
                dal.MyProperty_DOB = DateTime.Parse(dgvStDetails.Rows[i].Cells["DOB"].Value.ToString());
                dal.MyProperty_GPA = decimal.Parse(dgvStDetails.Rows[i].Cells["GPAVG"].Value.ToString());
                dal.MyProperty_active = dgvStDetails.Rows[i].Cells["Active"].Value.ToString();

                bl.SaveStudentInfo(dal);
            }
            if (dal.MyProperty_Exception == "")
            {
                MessageBox.Show("Student Details Saved Successfuly", "Success");
                dgvStDetails.DataSource = null;


            }
        }


        //This will Fill Datagrid 
        public void FillGrdStudents()
        {
            if (!getStudentsNamesToGrid())
            {

            }

        }


        //This set a boolean value For get existance Category Names From Database
        private bool getStudentsNamesToGrid()
        {
            bool bVal = true;

            blStudentdet bl = new blStudentdet();
            dalStudentdet dal = new dalStudentdet();

            dal.MyProperty_Exception = "";

            bl.getStudentListToGrid(dal);

            if (dal.MyProperty_Exception == "")
            {
                //if there are records in temp table setting the datagrid's data source
                if (dal.MyProperty_dsStudent.Tables["loadStudents"].Rows.Count > 0)
                {
                    dgvStDetails.DataSource = dal.MyProperty_dsStudent.Tables["loadStudents"];
                    bVal = true;
                }
                else
                    bVal = false;
            }
            else
            {
                bVal = false;
            }

            return bVal;
        }

        private void dgvStDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //FillGrdStudents();
        }

        private void frmStudentDetailsForm_Activated(object sender, EventArgs e)
        {
            FillGrdStudents();
        }

        private void dgvStDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //FillGrdStudents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStudentDetails();
        }
    }
}
