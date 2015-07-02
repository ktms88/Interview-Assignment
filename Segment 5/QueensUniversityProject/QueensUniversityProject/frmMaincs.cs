using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueensUniversityProject
{
    public partial class frmMaincs : Form
    {
        public frmMaincs()
        {
            InitializeComponent();
        }

        private void frmMaincs_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentDetailsForm frm = new frmStudentDetailsForm();
            frm.ShowDialog();
        }
    }
}
