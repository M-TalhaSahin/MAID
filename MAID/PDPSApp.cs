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
            initCalcPages(sender, e);
        }
        private void initCalcPages(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].BackColor = Color.GhostWhite;
            chart2.ChartAreas[0].BackColor = Color.GhostWhite;
            chart3.ChartAreas[0].BackColor = Color.GhostWhite;
            chart4.ChartAreas[0].BackColor = Color.GhostWhite;
            chart5.ChartAreas[0].BackColor = Color.GhostWhite;
            chart6.ChartAreas[0].BackColor = Color.GhostWhite;
            txtBCVshift.Text = "7";
            txtBCVbreak.Text = "1";
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;
            dtpBCVstart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpBCVend.Value = DateTime.Now;
            dtpIGVStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpIGVEnd.Value = DateTime.Now;
            dtpEASOStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEASOEnd.Value = DateTime.Now;
            dtpKKOStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpKKOEnd.Value = DateTime.Now;
            dtpSumStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpSumEnd.Value = DateTime.Now;
            btnGSVRef_Click(sender, e);
            btnIGVShow_Click(sender, e);
            btnEASOShow_Click(sender, e);
            btnKKOShow_Click(sender, e);
            btnSumShow_Click(sender, e);
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
                cbxRoom.SelectedIndex = -1;
                cbxFloor.SelectedIndex = -1;
                cbxRate.SelectedIndex = -1;
                cbxRoom.Enabled = false;
                cbxMaid.SelectedIndex = -1;
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
                gBsearchCC.Visible = false;
                txtSearch.Width = 25;
            }
            else if (cbxSearch.SelectedIndex == 1)
            {
                txtSearch.Clear();
                dateSearch.Visible = false;
                txtSearch.Visible = true;
                gBsearchCC.Visible = false;
                txtSearch.Width = 100;
            }
            else if (cbxSearch.SelectedIndex == 2)
            {
                dateSearch.Visible = true;
                txtSearch.Visible = false;
                gBsearchCC.Visible = false;
            }
            else if (cbxSearch.SelectedIndex == 3)
            {
                srcRBCheckout.Checked = false;
                srcRbCare.Checked = false;
                txtSearch.Clear();
                gBsearchCC.Visible = true;
                dateSearch.Visible = false;
                txtSearch.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Cleaning> cleanings = null;
            if (txtSearch.Text == "" && (cbxSearch.SelectedIndex == 0 || cbxSearch.SelectedIndex == 1))
                MessageBox.Show("Please fill search box.", "Error");
            if(srcRbCare.Checked == false && srcRBCheckout.Checked == false && cbxSearch.SelectedIndex == 3)
            {
                MessageBox.Show("Please select a type.", "Error");
            }
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
                else if (cbxSearch.SelectedIndex == 3)
                {
                    if (srcRBCheckout.Checked)
                    {
                        cleanings = dbconnection.selectCleaningList(true, rtype: "checkout");
                    }
                    else if (srcRbCare.Checked)
                    {
                        cleanings = dbconnection.selectCleaningList(true, rtype: "care");
                    }
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void btnSavePricing_Click(object sender, EventArgs e)
        {
            if (txtCaring.Text == "" || txtCheckout.Text == "")
                MessageBox.Show("Please fill all properties", "ERROR");
            else
            {
                dbconnection.updatePrice(Convert.ToDouble(txtCheckout.Text), Convert.ToDouble(txtCaring.Text));
                MessageBox.Show("Price values succesfully updated");
                txtCaring.Clear();
                txtCheckout.Clear();
            }
        }

        private void lwMaidHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGSVCalc_Click(object sender, EventArgs e)
        {
            double x, y, z, r;
            x = float.Parse(txtGSVCheckOut.Text) * 26.76;
            y = float.Parse(txtGSVCare.Text) * 11.88;
            z = float.Parse(txtGSVMaidNum.Text) * 420;
            r = (x + y) / z;
            txtGSVResult.Text = r.ToString();
        }

        private void btnGSVSave_Click(object sender, EventArgs e)
        {
            dbconnection.insertCalculation("GSV", float.Parse(txtGSVResult.Text));
        }

        private void btnGSVRef_Click(object sender, EventArgs e)
        {
            List<dataBase.CalcResult> resultList = dbconnection.selectCalculation("GSV", dtpStart.Value, dtpEnd.Value);
            chart1.Series.Clear();
            chart1.Series.Add("GSV");
            chart1.Series["GSV"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < resultList.Count; i++)
            {
                chart1.Series["GSV"].Points.AddXY(i, resultList[i].result);
                chart1.Series["GSV"].Points[i].AxisLabel = resultList[i].date.ToShortDateString();
            }
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart1.Series["GSV"].BorderWidth = 2;
            //chart1.ChartAreas[0].AxisX.Title = "DATE";
            //chart1.ChartAreas[0].AxisY.Title = "VALUE";
        }

        private void cbxEmployee_DropDown(object sender, EventArgs e)
        {
            List<Maid> maidList = dbconnection.selectMaidList(true);
            cbxBCVemployee.Items.Clear();
            foreach (Maid maid in maidList)
            {
                cbxBCVemployee.Items.Add(maid.Id.ToString() + " - " + maid.Name);
            }
        }

        private void btnBCVcalc_Click(object sender, EventArgs e)
        {
            double x, y = 0, z, r;
            int[] delay = new int[11] { 45, 45, 45, 15, 7, 11, 6, 10, 17, 20, 8 };

            x = float.Parse(txtBCVbreak.Text) * 60;

            for(int i=0; i < lbBCVdelay.SelectedIndices.Count; i++)
            {
                y += delay[lbBCVdelay.SelectedIndices[i]];
            }

            z = float.Parse(txtBCVshift.Text) * 60;
            r = (420 - x - y) / z;
            txtBCVresult.Text = r.ToString();

        }

        private void btnBCVsave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbxBCVemployee.SelectedItem.ToString().Split('-')[0]);
            dbconnection.insertBCVCalc(id, float.Parse(txtBCVresult.Text));
        }

        private void btnBCVshow_Click(object sender, EventArgs e)
        {
            List<dataBase.CalcResult> resultList = dbconnection.selectBCV(Convert.ToInt32(cbxBCVemployee.SelectedItem.ToString().Split('-')[0]), dtpBCVstart.Value, dtpBCVend.Value);
            chart2.Series.Clear();
            chart2.Series.Add("GSV");
            chart2.Series["GSV"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < resultList.Count; i++)
            {
                chart2.Series["GSV"].Points.AddXY(i, resultList[i].result);
                chart2.Series["GSV"].Points[i].AxisLabel = resultList[i].date.ToShortDateString();
            }
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart2.Series["GSV"].BorderWidth = 2;
            //chart1.ChartAreas[0].AxisX.Title = "DATE";
            //chart1.ChartAreas[0].AxisY.Title = "VALUE";
        }

        private void btnIGVCalc_Click(object sender, EventArgs e)
        {
            double x, y, z = 0, t;
            int[] delay = new int[11] { 45, 45, 45, 15, 7, 11, 6, 10, 17, 20, 8 };

            x = Convert.ToInt32(txtIGVCheckOut.Text) * 26.79;
            y = Convert.ToInt32(txtIGVCare.Text) * 11.88;
            t = Convert.ToInt32(txtIGVEmployee.Text);

            for (int i = 0; i < lbIGVDelay.SelectedIndices.Count; i++)
            {
                z += delay[lbIGVDelay.SelectedIndices[i]];
            }

            txtIGVRes.Text = ((x + y) / (420 * t - 60 * t - z)).ToString();
        }

        private void btnIGVSave_Click(object sender, EventArgs e)
        {
            dbconnection.insertCalculation("IGV", float.Parse(txtIGVRes.Text));
        }

        private void btnIGVShow_Click(object sender, EventArgs e)
        {
            List<dataBase.CalcResult> resultList = dbconnection.selectCalculation("IGV", dtpIGVStart.Value, dtpIGVEnd.Value);
            chart3.Series.Clear();
            chart3.Series.Add("IGV");
            chart3.Series["IGV"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < resultList.Count; i++)
            {
                chart3.Series["IGV"].Points.AddXY(i, resultList[i].result);
                chart3.Series["IGV"].Points[i].AxisLabel = resultList[i].date.ToShortDateString();
            }
            chart3.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart3.Series["IGV"].BorderWidth = 2;
        }

        private void btnEASOCalc_Click(object sender, EventArgs e)
        {
            double x, y = 0, z, res;
            int[] delay = new int[11] { 45, 45, 45, 15, 7, 11, 6, 10, 17, 20, 8 };
            x = float.Parse(txtEASOEmployeeNum.Text) * 420;
            z = float.Parse(txtEASOBreak.Text) * 60;

            for (int i = 0; i < lbEASODelay.SelectedIndices.Count; i++)
            {
                y += delay[lbEASODelay.SelectedIndices[i]];
            }

            res = (x - y - z) / x;
            txtEASOResult.Text = res.ToString();
        }

        private void btnEASOShow_Click(object sender, EventArgs e)
        {
            List<dataBase.CalcResult> resultList = dbconnection.selectCalculation("EASO", dtpEASOStart.Value, dtpEASOEnd.Value);
            chart4.Series.Clear();
            chart4.Series.Add("EASO");
            chart4.Series["EASO"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < resultList.Count; i++)
            {
                chart4.Series["EASO"].Points.AddXY(i, resultList[i].result);
                chart4.Series["EASO"].Points[i].AxisLabel = resultList[i].date.ToShortDateString();
            }
            chart4.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart4.Series["EASO"].BorderWidth = 2;
        }

        private void btnEASOSave_Click(object sender, EventArgs e)
        {
            dbconnection.insertCalculation("EASO", float.Parse(txtEASOResult.Text));
        }

        private void btnKKOCalc_Click(object sender, EventArgs e)
        {
            double x, y = 0, z, res;
            int[] delay = new int[11] { 45, 45, 45, 15, 7, 11, 6, 10, 17, 20, 8 };
            x = float.Parse(txtKKOEmployeeNum.Text) * 420;
            z = float.Parse(txtKKOBreak.Text) * 60;

            for (int i = 0; i < lbKKODelay.SelectedIndices.Count; i++)
            {
                y += delay[lbKKODelay.SelectedIndices[i]];
            }

            res = (x - y - z) / x;
            txtKKOResult.Text = res.ToString();
        }

        private void btnKKOSave_Click(object sender, EventArgs e)
        {
            dbconnection.insertCalculation("KKO", float.Parse(txtKKOResult.Text));
        }

        private void btnKKOShow_Click(object sender, EventArgs e)
        {
            List<dataBase.CalcResult> resultList = dbconnection.selectCalculation("KKO", dtpKKOStart.Value, dtpKKOEnd.Value);
            chart5.Series.Clear();
            chart5.Series.Add("KKO");
            chart5.Series["KKO"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < resultList.Count; i++)
            {
                chart5.Series["KKO"].Points.AddXY(i, resultList[i].result);
                chart5.Series["KKO"].Points[i].AxisLabel = resultList[i].date.ToShortDateString();
            }
            chart5.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart5.Series["KKO"].BorderWidth = 2;
        }
        private void btnSumShow_Click(object sender, EventArgs e)
        {
            chart6.Series.Clear();
            chart6.Series.Add("GSV");
            chart6.Series["GSV"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart6.Series.Add("IGV");
            chart6.Series["IGV"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart6.Series.Add("EASO");
            chart6.Series["EASO"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart6.Series.Add("KKO");
            chart6.Series["KKO"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            List<List<dataBase.CalcResult>> resultSum = new List<List<dataBase.CalcResult>>();

            string [] map = new string[4] { "GSV", "IGV", "EASO", "KKO" };
            resultSum.Add(dbconnection.selectCalculation("GSV", dtpSumStart.Value, dtpSumEnd.Value));
            chart6.Series["GSV"].BorderWidth = 2;
            resultSum.Add(dbconnection.selectCalculation("IGV", dtpSumStart.Value, dtpSumEnd.Value));
            chart6.Series["IGV"].BorderWidth = 2;
            resultSum.Add(dbconnection.selectCalculation("EASO", dtpSumStart.Value, dtpSumEnd.Value));
            chart6.Series["EASO"].BorderWidth = 2;
            resultSum.Add(dbconnection.selectCalculation("KKO", dtpSumStart.Value, dtpSumEnd.Value));
            chart6.Series["KKO"].BorderWidth = 2;

            for (int i = 0; i < resultSum.Count; i++)
            {
                for(int j = 0; j < resultSum[i].Count; j++)
                {
                    chart6.Series[map[i]].Points.AddXY(j, resultSum[i][j].result);
                    chart6.Series[map[i]].Points[j].AxisLabel = resultSum[i][j].date.ToShortDateString();
                }
            }
            chart6.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            
        }

        private void tabEASO_Click(object sender, EventArgs e)
        {

        }
    }
}
