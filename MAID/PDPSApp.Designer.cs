
namespace MAID
{
    partial class PDPSAppl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabMaid = new System.Windows.Forms.TabPage();
            this.btnListMaids = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.gBAddMaid = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaidName = new System.Windows.Forms.TextBox();
            this.btnAddMaid = new System.Windows.Forms.Button();
            this.txtMaidSurname = new System.Windows.Forms.TextBox();
            this.lwMaid = new System.Windows.Forms.ListView();
            this.lwmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmRatingAvg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmRoomsCleaned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCleaning = new System.Windows.Forms.TabPage();
            this.lwCleaning = new System.Windows.Forms.ListView();
            this.lwmClnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmClnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmClnSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmClnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmClnFloor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmClnRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmClnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwmClnRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnListCln = new System.Windows.Forms.Button();
            this.gBCleaning = new System.Windows.Forms.GroupBox();
            this.cbxRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gBCleaningRB = new System.Windows.Forms.GroupBox();
            this.rBCaring = new System.Windows.Forms.RadioButton();
            this.rbCheckout = new System.Windows.Forms.RadioButton();
            this.cbxRoom = new System.Windows.Forms.ComboBox();
            this.cbxFloor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxMaid = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCleaningAdd = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.tabMaid.SuspendLayout();
            this.gBAddMaid.SuspendLayout();
            this.tabCleaning.SuspendLayout();
            this.gBCleaning.SuspendLayout();
            this.gBCleaningRB.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.AccessibleName = "";
            this.mainTabControl.Controls.Add(this.tabMaid);
            this.mainTabControl.Controls.Add(this.tabCleaning);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1464, 679);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabMaid
            // 
            this.tabMaid.Controls.Add(this.btnListMaids);
            this.tabMaid.Controls.Add(this.txtOutput);
            this.tabMaid.Controls.Add(this.gBAddMaid);
            this.tabMaid.Controls.Add(this.lwMaid);
            this.tabMaid.Location = new System.Drawing.Point(4, 25);
            this.tabMaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMaid.Name = "tabMaid";
            this.tabMaid.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMaid.Size = new System.Drawing.Size(1456, 650);
            this.tabMaid.TabIndex = 0;
            this.tabMaid.Text = "Maid";
            this.tabMaid.UseVisualStyleBackColor = true;
            // 
            // btnListMaids
            // 
            this.btnListMaids.Location = new System.Drawing.Point(624, 26);
            this.btnListMaids.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListMaids.Name = "btnListMaids";
            this.btnListMaids.Size = new System.Drawing.Size(75, 23);
            this.btnListMaids.TabIndex = 8;
            this.btnListMaids.Text = "List";
            this.btnListMaids.UseVisualStyleBackColor = true;
            this.btnListMaids.Click += new System.EventHandler(this.btnListMaids_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(44, 300);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(473, 320);
            this.txtOutput.TabIndex = 8;
            // 
            // gBAddMaid
            // 
            this.gBAddMaid.Controls.Add(this.label2);
            this.gBAddMaid.Controls.Add(this.label1);
            this.gBAddMaid.Controls.Add(this.txtMaidName);
            this.gBAddMaid.Controls.Add(this.btnAddMaid);
            this.gBAddMaid.Controls.Add(this.txtMaidSurname);
            this.gBAddMaid.Location = new System.Drawing.Point(44, 55);
            this.gBAddMaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBAddMaid.Name = "gBAddMaid";
            this.gBAddMaid.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBAddMaid.Size = new System.Drawing.Size(473, 180);
            this.gBAddMaid.TabIndex = 5;
            this.gBAddMaid.TabStop = false;
            this.gBAddMaid.Text = "Insert Maid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Surame";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // txtMaidName
            // 
            this.txtMaidName.Location = new System.Drawing.Point(63, 60);
            this.txtMaidName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaidName.Name = "txtMaidName";
            this.txtMaidName.Size = new System.Drawing.Size(159, 22);
            this.txtMaidName.TabIndex = 0;
            // 
            // btnAddMaid
            // 
            this.btnAddMaid.Location = new System.Drawing.Point(347, 126);
            this.btnAddMaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddMaid.Name = "btnAddMaid";
            this.btnAddMaid.Size = new System.Drawing.Size(75, 23);
            this.btnAddMaid.TabIndex = 4;
            this.btnAddMaid.Text = "Add";
            this.btnAddMaid.UseVisualStyleBackColor = true;
            this.btnAddMaid.Click += new System.EventHandler(this.btnAddMaid_Click);
            // 
            // txtMaidSurname
            // 
            this.txtMaidSurname.Location = new System.Drawing.Point(261, 60);
            this.txtMaidSurname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaidSurname.Name = "txtMaidSurname";
            this.txtMaidSurname.Size = new System.Drawing.Size(159, 22);
            this.txtMaidSurname.TabIndex = 1;
            // 
            // lwMaid
            // 
            this.lwMaid.AllowDrop = true;
            this.lwMaid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lwmID,
            this.lwmName,
            this.lwmSurname,
            this.lwmRatingAvg,
            this.lwmRoomsCleaned});
            this.lwMaid.FullRowSelect = true;
            this.lwMaid.GridLines = true;
            this.lwMaid.HideSelection = false;
            this.lwMaid.Location = new System.Drawing.Point(624, 55);
            this.lwMaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lwMaid.Name = "lwMaid";
            this.lwMaid.Size = new System.Drawing.Size(801, 565);
            this.lwMaid.TabIndex = 3;
            this.lwMaid.UseCompatibleStateImageBehavior = false;
            this.lwMaid.View = System.Windows.Forms.View.Details;
            // 
            // lwmID
            // 
            this.lwmID.Text = "ID";
            // 
            // lwmName
            // 
            this.lwmName.Text = "Name";
            this.lwmName.Width = 124;
            // 
            // lwmSurname
            // 
            this.lwmSurname.Text = "Surname";
            this.lwmSurname.Width = 145;
            // 
            // lwmRatingAvg
            // 
            this.lwmRatingAvg.Text = "Rating";
            // 
            // lwmRoomsCleaned
            // 
            this.lwmRoomsCleaned.Text = "Rooms Cleaned";
            this.lwmRoomsCleaned.Width = 99;
            // 
            // tabCleaning
            // 
            this.tabCleaning.Controls.Add(this.lwCleaning);
            this.tabCleaning.Controls.Add(this.btnListCln);
            this.tabCleaning.Controls.Add(this.gBCleaning);
            this.tabCleaning.Location = new System.Drawing.Point(4, 25);
            this.tabCleaning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCleaning.Name = "tabCleaning";
            this.tabCleaning.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCleaning.Size = new System.Drawing.Size(1456, 650);
            this.tabCleaning.TabIndex = 1;
            this.tabCleaning.Text = "Cleaning";
            this.tabCleaning.UseVisualStyleBackColor = true;
            // 
            // lwCleaning
            // 
            this.lwCleaning.AllowDrop = true;
            this.lwCleaning.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lwmClnID,
            this.lwmClnName,
            this.lwmClnSurname,
            this.lwmClnType,
            this.lwmClnFloor,
            this.lwmClnRoom,
            this.lwmClnDate,
            this.lwmClnRate});
            this.lwCleaning.FullRowSelect = true;
            this.lwCleaning.GridLines = true;
            this.lwCleaning.HideSelection = false;
            this.lwCleaning.Location = new System.Drawing.Point(617, 58);
            this.lwCleaning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lwCleaning.Name = "lwCleaning";
            this.lwCleaning.Size = new System.Drawing.Size(801, 565);
            this.lwCleaning.TabIndex = 10;
            this.lwCleaning.UseCompatibleStateImageBehavior = false;
            this.lwCleaning.View = System.Windows.Forms.View.Details;
            // 
            // lwmClnID
            // 
            this.lwmClnID.Text = "ID";
            this.lwmClnID.Width = 26;
            // 
            // lwmClnName
            // 
            this.lwmClnName.Text = "Name";
            this.lwmClnName.Width = 86;
            // 
            // lwmClnSurname
            // 
            this.lwmClnSurname.Text = "Surname";
            this.lwmClnSurname.Width = 100;
            // 
            // lwmClnType
            // 
            this.lwmClnType.Text = "Type";
            this.lwmClnType.Width = 76;
            // 
            // lwmClnFloor
            // 
            this.lwmClnFloor.Text = "Floor";
            // 
            // lwmClnRoom
            // 
            this.lwmClnRoom.Text = "Room";
            this.lwmClnRoom.Width = 50;
            // 
            // lwmClnDate
            // 
            this.lwmClnDate.Text = "Date";
            this.lwmClnDate.Width = 59;
            // 
            // lwmClnRate
            // 
            this.lwmClnRate.Text = "Rating";
            // 
            // btnListCln
            // 
            this.btnListCln.Location = new System.Drawing.Point(617, 14);
            this.btnListCln.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListCln.Name = "btnListCln";
            this.btnListCln.Size = new System.Drawing.Size(75, 23);
            this.btnListCln.TabIndex = 9;
            this.btnListCln.Text = "List";
            this.btnListCln.UseVisualStyleBackColor = true;
            this.btnListCln.Click += new System.EventHandler(this.btnListCln_Click);
            // 
            // gBCleaning
            // 
            this.gBCleaning.Controls.Add(this.cbxRate);
            this.gBCleaning.Controls.Add(this.label6);
            this.gBCleaning.Controls.Add(this.gBCleaningRB);
            this.gBCleaning.Controls.Add(this.cbxRoom);
            this.gBCleaning.Controls.Add(this.cbxFloor);
            this.gBCleaning.Controls.Add(this.label5);
            this.gBCleaning.Controls.Add(this.label3);
            this.gBCleaning.Controls.Add(this.cbxMaid);
            this.gBCleaning.Controls.Add(this.label4);
            this.gBCleaning.Controls.Add(this.btnCleaningAdd);
            this.gBCleaning.Location = new System.Drawing.Point(37, 43);
            this.gBCleaning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBCleaning.Name = "gBCleaning";
            this.gBCleaning.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBCleaning.Size = new System.Drawing.Size(473, 283);
            this.gBCleaning.TabIndex = 7;
            this.gBCleaning.TabStop = false;
            this.gBCleaning.Text = "Insert Cleaning";
            // 
            // cbxRate
            // 
            this.cbxRate.FormattingEnabled = true;
            this.cbxRate.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbxRate.Location = new System.Drawing.Point(160, 231);
            this.cbxRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxRate.Name = "cbxRate";
            this.cbxRate.Size = new System.Drawing.Size(52, 24);
            this.cbxRate.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rate";
            // 
            // gBCleaningRB
            // 
            this.gBCleaningRB.Controls.Add(this.rBCaring);
            this.gBCleaningRB.Controls.Add(this.rbCheckout);
            this.gBCleaningRB.Location = new System.Drawing.Point(309, 75);
            this.gBCleaningRB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBCleaningRB.Name = "gBCleaningRB";
            this.gBCleaningRB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBCleaningRB.Size = new System.Drawing.Size(120, 91);
            this.gBCleaningRB.TabIndex = 8;
            this.gBCleaningRB.TabStop = false;
            // 
            // rBCaring
            // 
            this.rBCaring.AutoSize = true;
            this.rBCaring.Location = new System.Drawing.Point(16, 57);
            this.rBCaring.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rBCaring.Name = "rBCaring";
            this.rBCaring.Size = new System.Drawing.Size(70, 21);
            this.rBCaring.TabIndex = 15;
            this.rBCaring.TabStop = true;
            this.rBCaring.Text = "Caring";
            this.rBCaring.UseVisualStyleBackColor = true;
            // 
            // rbCheckout
            // 
            this.rbCheckout.AutoSize = true;
            this.rbCheckout.Location = new System.Drawing.Point(16, 23);
            this.rbCheckout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbCheckout.Name = "rbCheckout";
            this.rbCheckout.Size = new System.Drawing.Size(88, 21);
            this.rbCheckout.TabIndex = 14;
            this.rbCheckout.TabStop = true;
            this.rbCheckout.Text = "Checkout";
            this.rbCheckout.UseVisualStyleBackColor = true;
            // 
            // cbxRoom
            // 
            this.cbxRoom.Enabled = false;
            this.cbxRoom.FormattingEnabled = true;
            this.cbxRoom.Location = new System.Drawing.Point(171, 162);
            this.cbxRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxRoom.Name = "cbxRoom";
            this.cbxRoom.Size = new System.Drawing.Size(103, 24);
            this.cbxRoom.TabIndex = 11;
            // 
            // cbxFloor
            // 
            this.cbxFloor.FormattingEnabled = true;
            this.cbxFloor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbxFloor.Location = new System.Drawing.Point(63, 162);
            this.cbxFloor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxFloor.Name = "cbxFloor";
            this.cbxFloor.Size = new System.Drawing.Size(52, 24);
            this.cbxFloor.TabIndex = 10;
            this.cbxFloor.SelectedIndexChanged += new System.EventHandler(this.cbxFloor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Floor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Room";
            // 
            // cbxMaid
            // 
            this.cbxMaid.FormattingEnabled = true;
            this.cbxMaid.Location = new System.Drawing.Point(63, 82);
            this.cbxMaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxMaid.Name = "cbxMaid";
            this.cbxMaid.Size = new System.Drawing.Size(185, 24);
            this.cbxMaid.TabIndex = 7;
            this.cbxMaid.DropDown += new System.EventHandler(this.cbxMaid_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maid";
            // 
            // btnCleaningAdd
            // 
            this.btnCleaningAdd.Location = new System.Drawing.Point(235, 231);
            this.btnCleaningAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCleaningAdd.Name = "btnCleaningAdd";
            this.btnCleaningAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCleaningAdd.TabIndex = 4;
            this.btnCleaningAdd.Text = "Add";
            this.btnCleaningAdd.UseVisualStyleBackColor = true;
            this.btnCleaningAdd.Click += new System.EventHandler(this.btnCleaningAdd_Click);
            // 
            // PDPSAppl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 704);
            this.Controls.Add(this.mainTabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PDPSAppl";
            this.Text = "PDPS";
            this.Load += new System.EventHandler(this.PDPSApp_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabMaid.ResumeLayout(false);
            this.tabMaid.PerformLayout();
            this.gBAddMaid.ResumeLayout(false);
            this.gBAddMaid.PerformLayout();
            this.tabCleaning.ResumeLayout(false);
            this.gBCleaning.ResumeLayout(false);
            this.gBCleaning.PerformLayout();
            this.gBCleaningRB.ResumeLayout(false);
            this.gBCleaningRB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabMaid;
        private System.Windows.Forms.ListView lwMaid;
        private System.Windows.Forms.TextBox txtMaidSurname;
        private System.Windows.Forms.TextBox txtMaidName;
        private System.Windows.Forms.TabPage tabCleaning;
        private System.Windows.Forms.GroupBox gBAddMaid;
        private System.Windows.Forms.Button btnAddMaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBCleaning;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCleaningAdd;
        private System.Windows.Forms.ComboBox cbxRoom;
        private System.Windows.Forms.ComboBox cbxFloor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxMaid;
        private System.Windows.Forms.GroupBox gBCleaningRB;
        private System.Windows.Forms.RadioButton rBCaring;
        private System.Windows.Forms.RadioButton rbCheckout;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnListMaids;
        private System.Windows.Forms.ColumnHeader lwmID;
        private System.Windows.Forms.ColumnHeader lwmName;
        private System.Windows.Forms.ColumnHeader lwmSurname;
        private System.Windows.Forms.ListView lwCleaning;
        private System.Windows.Forms.ColumnHeader lwmClnID;
        private System.Windows.Forms.ColumnHeader lwmClnName;
        private System.Windows.Forms.ColumnHeader lwmClnSurname;
        private System.Windows.Forms.ColumnHeader lwmClnType;
        private System.Windows.Forms.ColumnHeader lwmClnFloor;
        private System.Windows.Forms.ColumnHeader lwmClnRoom;
        private System.Windows.Forms.ColumnHeader lwmClnDate;
        private System.Windows.Forms.Button btnListCln;
        private System.Windows.Forms.ComboBox cbxRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader lwmClnRate;
        private System.Windows.Forms.ColumnHeader lwmRatingAvg;
        private System.Windows.Forms.ColumnHeader lwmRoomsCleaned;
    }
}

