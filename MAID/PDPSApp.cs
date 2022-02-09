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
    public partial class PDPSAppl : Form
    {
        private dataBase dbconnection = new dataBase();
        public PDPSAppl()
        {
            InitializeComponent();
        }

        private void PDPSApp_Load(object sender, EventArgs e)
        {
            
            //dbconnection.clearDB();
            //dbconnection.insertMaid("m1", "ms1");
            //dbconnection.insertTemizlik(2, dataBase.odaTipi.cikis);
            //dbconnection.removeMaid(1);
            //Environment.Exit(0);
        }

        private void btnListMaids_Click(object sender, EventArgs e)
        {
            List<Maid> maidList = dbconnection.selectMaidList();
            lwMaid.Items.Clear();
            for (int i = 0; i < maidList.Count(); i++)
            {
                string[] row = { maidList[i].Id.ToString(), maidList[i].Name, maidList[i].Surname };
                var satir = new ListViewItem(row);
                lwMaid.Items.Add(satir);
            }
        }

        private void btnAddMaid_Click(object sender, EventArgs e)
        {
            dbconnection.insertMaid(txtMaidName.Text, txtMaidSurname.Text);
            txtMaidName.Clear();
            txtMaidSurname.Clear();
        }

        private void cbxMaid_DropDown(object sender, EventArgs e)
        {
            List<Maid> maidList = dbconnection.selectMaidList();
            cbxMaid.Items.Clear();
            foreach(Maid maid in maidList)
            {
                cbxMaid.Items.Add(maid.Id.ToString() + " - " + maid.Name);
            }
        }

        private void cbxFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int floor = (cbxFloor.SelectedIndex + 1) * 100;
            cbxRoom.Items.Clear();
            for(int i = 1; i <= 20; i++)
            {
                cbxRoom.Items.Add((floor + i).ToString());
            }
            cbxRoom.Enabled = true;
        }

        private void btnListCln_Click(object sender, EventArgs e)
        {
            List<Cleaning> cleanings = dbconnection.selectCleaningList();
            lwCleaning.Items.Clear();
            for (int i = 0; i < cleanings.Count(); i++)
            {
                string[] row = { cleanings[i].Maid.Id.ToString(), cleanings[i].Maid.Name, cleanings[i].Maid.Surname,
                cleanings[i].Type.ToString(), cleanings[i].RoomNumber[0].ToString(), cleanings[i].RoomNumber, cleanings[i].Date};
                var satir = new ListViewItem(row);
                lwCleaning.Items.Add(satir);
            }
        }

        private void btnCleaningAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbxMaid.SelectedItem.ToString().Split('-')[0]);
            dataBase.odaTipi type;
            if (rBCaring.Checked) type = dataBase.odaTipi.bakim;
            else type = dataBase.odaTipi.cikis;
            dbconnection.insertTemizlik(id, type, cbxRoom.SelectedItem.ToString());
            cbxRoom.Enabled = false;
            cbxRoom.Items.Clear();
            cbxMaid.Text = "";
        }
    }
}
