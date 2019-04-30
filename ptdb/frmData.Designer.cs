namespace ptdb
{
    partial class frmData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmData));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mstOpenDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.izdCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numIzd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppcu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nudDate = new System.Windows.Forms.NumericUpDown();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblChoose = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.errorTxt = new System.Windows.Forms.TextBox();
            this.errorLbl = new System.Windows.Forms.Label();
            this.lblDateVP = new System.Windows.Forms.Label();
            this.dtpVP = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDate)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(968, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mst";
            this.menuStrip1.Visible = false;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstOpenDialog});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(83, 38);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // mstOpenDialog
            // 
            this.mstOpenDialog.Name = "mstOpenDialog";
            this.mstOpenDialog.Size = new System.Drawing.Size(248, 38);
            this.mstOpenDialog.Text = "Открыть .CK";
            this.mstOpenDialog.Click += new System.EventHandler(this.MstOpenDialog_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "Файл параметров (.CK)|*.ck|Файл параметров (.PP)|*.pp";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.izdCheck,
            this.numIzd,
            this.rx,
            this.dRx,
            this.qa,
            this.dl,
            this.ppcu,
            this.rk,
            this.dck});
            this.dgvMain.Location = new System.Drawing.Point(36, 544);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(6);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(304, 245);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.Visible = false;
            // 
            // izdCheck
            // 
            this.izdCheck.Frozen = true;
            this.izdCheck.HeaderText = "Выбор";
            this.izdCheck.Name = "izdCheck";
            // 
            // numIzd
            // 
            this.numIzd.HeaderText = "№ изделия";
            this.numIzd.Name = "numIzd";
            this.numIzd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numIzd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rx
            // 
            this.rx.HeaderText = "Rx";
            this.rx.Name = "rx";
            this.rx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dRx
            // 
            this.dRx.HeaderText = "dRx";
            this.dRx.Name = "dRx";
            // 
            // qa
            // 
            this.qa.HeaderText = "Qa";
            this.qa.Name = "qa";
            // 
            // dl
            // 
            this.dl.HeaderText = "dл";
            this.dl.Name = "dl";
            // 
            // ppcu
            // 
            this.ppcu.HeaderText = "PPCu";
            this.ppcu.Name = "ppcu";
            // 
            // rk
            // 
            this.rk.HeaderText = "rk";
            this.rk.Name = "rk";
            // 
            // dck
            // 
            this.dck.HeaderText = "dck";
            this.dck.Name = "dck";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(36, 362);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(221, 105);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Создать документ";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(349, 633);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 127);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // nudDate
            // 
            this.nudDate.Location = new System.Drawing.Point(36, 100);
            this.nudDate.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDate.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDate.Name = "nudDate";
            this.nudDate.Size = new System.Drawing.Size(221, 31);
            this.nudDate.TabIndex = 4;
            this.nudDate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(31, 72);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(287, 25);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Введите дату изготовления";
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(12, 9);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(226, 25);
            this.lblChoose.TabIndex = 6;
            this.lblChoose.Text = "Выбранное изделие: ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssProgressBar,
            this.tsslProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(968, 38);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssProgressBar
            // 
            this.tssProgressBar.Name = "tssProgressBar";
            this.tssProgressBar.Size = new System.Drawing.Size(200, 32);
            // 
            // tsslProgress
            // 
            this.tsslProgress.Name = "tsslProgress";
            this.tsslProgress.Size = new System.Drawing.Size(0, 33);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Enabled = false;
            this.lblSize.Location = new System.Drawing.Point(31, 138);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(337, 50);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "Введите кол-во секций и длинну\r\n(XxXXX)\r\n";
            this.lblSize.Visible = false;
            // 
            // txtSize
            // 
            this.txtSize.Enabled = false;
            this.txtSize.Location = new System.Drawing.Point(36, 191);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(221, 31);
            this.txtSize.TabIndex = 9;
            this.txtSize.Visible = false;
            // 
            // errorTxt
            // 
            this.errorTxt.Location = new System.Drawing.Point(464, 72);
            this.errorTxt.Multiline = true;
            this.errorTxt.Name = "errorTxt";
            this.errorTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorTxt.Size = new System.Drawing.Size(481, 309);
            this.errorTxt.TabIndex = 10;
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.Location = new System.Drawing.Point(459, 44);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(367, 25);
            this.errorLbl.TabIndex = 11;
            this.errorLbl.Text = "Изделия с пороговыми значениями";
            // 
            // lblDateVP
            // 
            this.lblDateVP.AutoSize = true;
            this.lblDateVP.Location = new System.Drawing.Point(31, 240);
            this.lblDateVP.Name = "lblDateVP";
            this.lblDateVP.Size = new System.Drawing.Size(238, 25);
            this.lblDateVP.TabIndex = 12;
            this.lblDateVP.Text = "Введите дату приемки";
            // 
            // dtpVP
            // 
            this.dtpVP.CustomFormat = "dd.MM.yyyy";
            this.dtpVP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVP.Location = new System.Drawing.Point(36, 278);
            this.dtpVP.Name = "dtpVP";
            this.dtpVP.Size = new System.Drawing.Size(282, 31);
            this.dtpVP.TabIndex = 13;
            this.dtpVP.ValueChanged += new System.EventHandler(this.dtpVP_ValueChanged);
            // 
            // frmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 571);
            this.Controls.Add(this.dtpVP);
            this.Controls.Add(this.lblDateVP);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.errorTxt);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.nudDate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmData";
            this.Text = "Подготовка данных";
            this.Load += new System.EventHandler(this.FrmData_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDate)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mstOpenDialog;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewCheckBoxColumn izdCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn numIzd;
        private System.Windows.Forms.DataGridViewTextBoxColumn rx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRx;
        private System.Windows.Forms.DataGridViewTextBoxColumn qa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppcu;
        private System.Windows.Forms.DataGridViewTextBoxColumn rk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dck;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nudDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tssProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslProgress;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox errorTxt;
        private System.Windows.Forms.Label errorLbl;
        private System.Windows.Forms.Label lblDateVP;
        private System.Windows.Forms.DateTimePicker dtpVP;
    }
}