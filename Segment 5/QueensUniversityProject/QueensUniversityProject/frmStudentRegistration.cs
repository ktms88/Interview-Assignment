using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using BL;
using DAL;

namespace QueensUniversityProject
{
    public partial class frmStudentRegistration : Form
    {
        frmStudentDetailsForm frm1;
        public frmStudentRegistration(frmStudentDetailsForm parent)
        {
            InitializeComponent();
            frm1 = parent;
        }

        //This will set employee ID as an auto incrementing ID
        private void setStudentID()
        {
            blConnection myConn = new blConnection();
            SqlConnection Conn = new SqlConnection(myConn.getConstr());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            //getting data from sql server database
            cmd.CommandText = "SELECT ID FROM RegTmp WHERE ID = (SELECT MAX(ID) FROM RegTmp)";
            Conn.Open();

            object StIDDet = cmd.ExecuteScalar();

            //If there are no records set Emp ID as E0001
            if (StIDDet == null)
            {
                txtStudentID.Text = "S000000001";
            }
            //If there are records in database auto incrementing Emp ID 
            else if (StIDDet != null)
            {
                int StID = Convert.ToInt32(StIDDet);
                txtStudentID.Text = "S" + (StID + 1).ToString("000000000");
            }
        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            setStudentID();
        }


        private bool TL = true;
        private void txtGPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (!TL)
            {
                return;
            }

            TL = false;

            var L = (sender as TextBox);
            //e.Control as TextBox;

            if (L != null)
            {
                L.KeyPress += NumericValidateKeyPress;
            }
        }


        //This will accept only numeric values to text boxes
        private void NumericValidateKeyPress(object sender, KeyPressEventArgs ex)
        {
            if (ex.KeyChar != '1' && ex.KeyChar != '2' && ex.KeyChar != '3' && ex.KeyChar != '4' && ex.KeyChar != '5' && ex.KeyChar != '6' && ex.KeyChar != '7' && ex.KeyChar != '8' && ex.KeyChar != '9' && ex.KeyChar != '0' && ex.KeyChar != '.'  && ex.KeyChar != '\b')
            {
                ex.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStudentTmp();
            //frmStudentDetailsForm frm = new frmStudentDetailsForm();

            //string ActiveMode = "";
            //if (cbActive.Checked == true)
            //{
            //    ActiveMode = "Active";
            //}
            //else
            //{
            //    ActiveMode = "Not active";
            //}
            ////frm.AddRecord(txtStudentID.Text, txtStName.Text, DateTime.Parse(DTPDOB.Value.ToShortDateString()), decimal.Parse(txtGPA.Text), ActiveMode);
            //this.Hide();
            //frm.ShowDialog();

        }


        //This is for save student info
        private void SaveStudentTmp()
        {
            blStudentdet bl = new blStudentdet();
            dalStudentdet dal = new dalStudentdet();
            dal.MyProperty_Exception = "";

            dal.MyProperty_StudenrID = txtStudentID.Text;
            dal.MyProperty_StudentName= txtStName.Text;
            dal.MyProperty_DOB = DTPDOB.Value;
            dal.MyProperty_GPA = decimal.Parse(txtGPA.Text);
            string cbActiv;
            if(cbActive.Checked == true)
            {
                cbActiv = "Active";
            }
            else
            {
                 cbActiv = "false";
            }
            dal.MyProperty_active = cbActiv;

            bl.SaveStInfoTmp(dal);

            if (dal.MyProperty_Exception == "")
            {
                this.Close();
                
            }
        }



        public void clearForm()
        {
            txtStudentID.Text = "";
            txtStName.Text = "";
            txtGPA.Text = "";
            DTPDOB.Value = DateTime.Now;
            setStudentID();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ////public void passValues(stID, namespace, )



    }
}
