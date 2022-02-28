using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace MAID
{
    public partial class PDPSAppl : Form
    {
        private dataBase dbconnection = new dataBase();
        public PDPSAppl()
        {
            InitializeComponent();
            cbxSearch.SelectedIndex = 1;
        }
        ~PDPSAppl()
        {
            GC.Collect();
        }

        private void PDPSApp_Load(object sender, EventArgs e)
        {
            //dbconnection.clearDB();
            cowification();
            mainTabControl_SelectedIndexChanged(sender, e);
        }
        private void cowification()
        {
            txtOutput.Clear();
            txtOutput.AppendText("\\|/                                          \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("                        ( _ _ )                                  /🟄\\                \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("      ``\\ - - - - - - ( o o )                               (  \\i \\ )");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("         | |              ( _ _ )                            ( / * / o \\ )                       \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("         | | w - - | |                    \\|/                  ( / / \\ i )                 \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("                                \\|/                    \\|/           |   |");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("   \\|/                                    \\|/                        |   |       \\|/                      \\|/");
        }
        private void cowHeadBang()
        {
            txtOutput.Clear();
            txtOutput.AppendText("\\|/                                          \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("                          ( _ _ )                                /🟄\\                \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("      ``\\ - - - - - -   ( o o )                             (  \\i \\ )");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("         | |                ( _ _ )                          ( / * / o \\ )                       \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("         | | w - - | |                    \\|/                  ( / / \\ i )                 \\|/");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("                                \\|/                    \\|/           |   |");
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("   \\|/                                    \\|/                        |   |       \\|/                      \\|/");
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
            if(txtMaidName.Text == "" || txtMaidSurname.Text == "")
            {
                MessageBox.Show("Please fill maid properties", "Error");
            }
            else
            {
                dbconnection.insertMaid(txtMaidName.Text, txtMaidSurname.Text);
                txtMaidName.Clear();
                txtMaidSurname.Clear();
                btnListMaids_Click(sender, e);
            }
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
                cleanings[i].Type.ToString(), cleanings[i].RoomNumber[0].ToString(), cleanings[i].RoomNumber, cleanings[i].Date, cleanings[i].Rating.ToString(), cleanings[i].CId.ToString()};
                var satir = new ListViewItem(row);
                lwCleaning.Items.Add(satir);
            }
        }

        private void btnCleaningAdd_Click(object sender, EventArgs e)
        {
            if(cbxMaid.Text == "" || cbxFloor.Text == "" || cbxRoom.Text == "" || cbxRate.Text == "" || rBCaring.Checked == false && rbCheckout.Checked == false)
                MessageBox.Show("Please fill all properties.", "Error");
            else
            {
                int id = Convert.ToInt32(cbxMaid.SelectedItem.ToString().Split('-')[0]);
                dataBase.odaTipi type;
                if (rBCaring.Checked) { type = dataBase.odaTipi.bakim; rBCaring.Checked = false; }
                else { type = dataBase.odaTipi.cikis; rbCheckout.Checked = false; }
                dbconnection.insertTemizlik(id, type, cbxRoom.SelectedItem.ToString(), Convert.ToInt32(cbxRate.SelectedItem.ToString()), txtCleaningYorum.Text);
                cbxRoom.Text = "";
                cbxFloor.Text = "";
                cbxRate.Text = "";
                cbxRoom.Enabled = false;
                cbxMaid.Text = "";
                txtCleaningYorum.Text = "";
                btnListCln_Click(sender, e);
            }
           
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
            if(cbxMaidRemove.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete? ", "Maid Delete", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    dbconnection.removeMaid(Convert.ToInt32(cbxMaidRemove.SelectedItem.ToString().Split('-')[0]));
                    cbxMaidRemove.Text = "";
                    btnListMaids_Click(sender, e);
                }
            }
            else
                MessageBox.Show("Please select maid", "Error");
        }

        private void btnListHistory_Click(object sender, EventArgs e)
        {
            List<Cleaning> cleanings = dbconnection.selectCleaningList(false);
            lwCleaningHistory.Items.Clear();
            for (int i = 0; i < cleanings.Count(); i++)
            {
                string[] row = { cleanings[i].Maid.Id.ToString(), cleanings[i].Maid.Name, cleanings[i].Maid.Surname,
                cleanings[i].Type.ToString(), cleanings[i].RoomNumber[0].ToString(), cleanings[i].RoomNumber, cleanings[i].Date, cleanings[i].Rating.ToString()};
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
                txtSearch.Clear();
                dateSearch.Visible = false;
                txtSearch.Visible = true;
                txtSearch.Width = 25;
            }
            else if (cbxSearch.SelectedIndex == 1)
            {
                txtSearch.Clear();
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
            List<Cleaning> cleanings = null;
            if (txtSearch.Text == "")
                MessageBox.Show("Please fill search box.", "Error");
            else
            {
                if (cbxSearch.SelectedIndex == 0)
                {
                    cleanings = dbconnection.selectCleaningList(true, id: Convert.ToInt32(txtSearch.Text));

                }
                else if (cbxSearch.SelectedIndex == 1)
                {
                    cleanings = dbconnection.selectCleaningList(true, name: txtSearch.Text);
                }
                else if (cbxSearch.SelectedIndex == 2)
                {
                    cleanings = dbconnection.selectCleaningList(true, date: dateSearch.Text);
                }

                lwCleaning.Items.Clear();
                for (int i = 0; i < cleanings.Count(); i++)
                {
                    string[] row = { cleanings[i].Maid.Id.ToString(), cleanings[i].Maid.Name, cleanings[i].Maid.Surname,
                    cleanings[i].Type.ToString(), cleanings[i].RoomNumber[0].ToString(), cleanings[i].RoomNumber, cleanings[i].Date, cleanings[i].Rating.ToString(), cleanings[i].CId.ToString()};
                    var satir = new ListViewItem(row);
                    lwCleaning.Items.Add(satir);
                }
            }
        }

        private void lwCleaning_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("yorum ->" + dbconnection.selectCleaningYorum(Convert.ToInt32(lwCleaning.SelectedItems[0].SubItems[8].Text)));
        }
        private void ToExcel(ListView myList)
        {
            GC.Collect();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(1);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            int i = 1;
            int i2 = 1;
            foreach (ColumnHeader ch in myList.Columns)
            {
                ws.Cells[i2, i] = ch.Text;
                if(i % 2 == 0)
                    ws.Cells[i2, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
                else
                    ws.Cells[i2, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                i++;
            }
            i = 1;
            i2 = 2;
            foreach (ListViewItem lvi in myList.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text;
                    if (i % 2 == 0)
                        ws.Cells[i2, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
                    i++;
                }
                i2++;
                i = 1;
            }
            ws.Columns.AutoFit();
            ws.Columns.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
        }

        private void btnMaidExport_Click(object sender, EventArgs e)
        {
            ToExcel(lwMaid);
        }

        private void btnExportCleaning_Click(object sender, EventArgs e)
        {
            ToExcel(lwCleaning);
        }

        private void btnCowDisco_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                cowHeadBang();
                System.Threading.Thread.Sleep(200);
                cowification();
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
