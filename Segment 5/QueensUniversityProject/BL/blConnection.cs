using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class blConnection
    {
        // This will assign DB Connection path to a variable
        private string constr = "Data Source=.\\MSSQLEXPRESS;Initial Catalog=QueensUniProjDB;Integrated Security=True";
        public string getConstr()
        {
            return constr;
        }
    }
}
