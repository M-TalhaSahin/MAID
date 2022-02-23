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

            mainTabControl_SelectedIndexChanged(sender, e);
        }
        
        private void btnListMaids_Click(object sender, EventArgs e)
        {
            List<Maid> maidList = dbconnection.selectMaidList(true);
            lwMaid.Items.Clear();
            for (int i = 0; i < maidList.Count(); i++)
            {
                string[] row = { maidList[i].Id.ToString(), maidList[i].Name, maidList[i].Surname, 
                    maidList[i].Rating.ToString(), maidList[i].RoomsCleaned.ToString(), maidList[i].Salary.ToString() };
                var satir = new ListViewItem(row);
                lwMaid.Items.Add(satir);
            }
        }

        private void btnAddMaid_Click(object sender, EventArgs e)
        {
            dbconnection.insertMaid(txtMaidName.Text, txtMaidSurname.Text);
            txtMaidName.Clear();
            txtMaidSurname.Clear();
            btnListMaids_Click(sender, e);
        }

        private void cbxMaid_DropDown(object sender, EventArgs e)
        {
            List<Maid> maidList = dbconnection.selectMaidList(true);
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
            List<Cleaning> cleanings = dbconnection.selectCleaningList(true);
            lwCleaning.Items.Clear();
            for (int i = 0; i < cleanings.Count(); i++)
            {
                string[] row = { cleanings[i].Maid.Id.ToString(), cleanings[i].Maid.Name, cleanings[i].Maid.Surname,
                cleanings[i].Type.ToString(), cleanings[i].RoomNumber[0].ToString(), cleanings[i].RoomNumber, cleanings[i].Date, cleanings[i].Rateing.ToString()};
                var satir = new ListViewItem(row);
                lwCleaning.Items.Add(satir);
            }
        }

        private void btnCleaningAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbxMaid.SelectedItem.ToString().Split('-')[0]);
            dataBase.odaTipi type;
            if (rBCaring.Checked) { type = dataBase.odaTipi.bakim; rBCaring.Checked = false; }
            else { type = dataBase.odaTipi.cikis; rbCheckout.Checked = false; }
            dbconnection.insertTemizlik(id, type, cbxRoom.SelectedItem.ToString(), Convert.ToInt32(cbxRate.SelectedItem.ToString()));
            cbxRoom.Text = "";
            cbxFloor.Text = "";
            cbxRate.Text = "";
            cbxRoom.Enabled = false;
            cbxMaid.Text = "";
            btnListCln_Click(sender, e);
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 0) btnListMaids_Click(sender, e);
            else if (mainTabControl.SelectedIndex == 1) btnListCln_Click(sender, e);
            else btnListMaidHistory_Click(sender, e); btnListHistory_Click(sender, e);
        }

        private void cbxMaidRemove_DropDown(object sender, EventArgs e)
        {
            List<Maid> maidList = dbconnection.selectMaidList(true);
            cbxMaidRemove.Items.Clear();
            foreach (Maid maid in maidList)
            {
                cbxMaidRemove.Items.Add(maid.Id.ToString() + " - " + maid.Name);
            }
        }

        private void btnMaidRemove_Click(object sender, EventArgs e)
        {
            dbconnection.removeMaid(Convert.ToInt32(cbxMaidRemove.SelectedItem.ToString().Split('-')[0]));
            cbxMaidRemove.Text = "";
            btnListMaids_Click(sender, e);
        }

        private void btnListHistory_Click(object sender, EventArgs e)
        {
            List<Cleaning> cleanings = dbconnection.selectCleaningList(false);
            lwCleaningHistory.Items.Clear();
            for (int i = 0; i < cleanings.Count(); i++)
            {
                string[] row = { cleanings[i].Maid.Id.ToString(), cleanings[i].Maid.Name, cleanings[i].Maid.Surname,
                cleanings[i].Type.ToString(), cleanings[i].RoomNumber[0].ToString(), cleanings[i].RoomNumber, cleanings[i].Date, cleanings[i].Rateing.ToString()};
                var satir = new ListViewItem(row);
                lwCleaningHistory.Items.Add(satir);
            }
        }

        private void btnListMaidHistory_Click(object sender, EventArgs e)
        {
            List<Maid> maidList = dbconnection.selectMaidList(false);
            lwMaidHistory.Items.Clear();
            for (int i = 0; i < maidList.Count(); i++)
            {
                string[] row = { maidList[i].Id.ToString(), maidList[i].Name, maidList[i].Surname,
                    maidList[i].Rating.ToString(), maidList[i].RoomsCleaned.ToString() };
                var satir = new ListViewItem(row);
                lwMaidHistory.Items.Add(satir);
            }
        }

        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxSearch.SelectedIndex == 0)
            {
                dateSearch.Visible = false;
                txtSearch.Visible = true;
                txtSearch.Width = 25;
            }
            else if (cbxSearch.SelectedIndex == 1)
            {
                dateSearch.Visible = false;
                txtSearch.Visible = true;
                txtSearch.Width = 100;
            }
            else if (cbxSearch.SelectedIndex == 2)
            {
                dateSearch.Visible = true;
                txtSearch.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxSearch.SelectedIndex == 0)
            {
                
            }
            else if (cbxSearch.SelectedIndex == 1)
            {
                 
            }
            else if (cbxSearch.SelectedIndex == 2)
            {
                
            }
        }
    }
}
