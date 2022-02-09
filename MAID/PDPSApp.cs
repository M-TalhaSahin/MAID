using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID
{
    public partial class PDPSApp : Form
    {
        public PDPSApp()
        {
            InitializeComponent();
        }

        private void PDPSApp_Load(object sender, EventArgs e)
        {
            var dbconnection = new dataBase();
            //dbconnection.clearDB();
            //dbconnection.insertMaid("m1", "ms1");
            //dbconnection.insertTemizlik(2, dataBase.odaTipi.cikis);
            //dbconnection.removeMaid(1);
            Environment.Exit(0);
        }
    }
}
