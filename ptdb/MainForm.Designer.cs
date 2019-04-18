namespace ptdb
{
    partial class main_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.gbIzd = new System.Windows.Forms.GroupBox();
            this.rbPT4M = new System.Windows.Forms.RadioButton();
            this.rbMR = new System.Windows.Forms.RadioButton();
            this.rbPT4 = new System.Windows.Forms.RadioButton();
            this.rbPT6B = new System.Windows.Forms.RadioButton();
            this.rbPT6A = new System.Windows.Forms.RadioButton();
            this.btnChoice = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.amountNud = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.rbRep600 = new System.Windows.Forms.RadioButton();
            this.gbIzd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNud)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbIzd
            // 
            this.gbIzd.Controls.Add(this.rbRep600);
            this.gbIzd.Controls.Add(this.rbPT4M);
            this.gbIzd.Controls.Add(this.rbMR);
            this.gbIzd.Controls.Add(this.rbPT4);
            this.gbIzd.Controls.Add(this.rbPT6B);
            this.gbIzd.Controls.Add(this.rbPT6A);
            this.gbIzd.Location = new System.Drawing.Point(24, 23);
            this.gbIzd.Margin = new System.Windows.Forms.Padding(6);
            this.gbIzd.Name = "gbIzd";
            this.gbIzd.Padding = new System.Windows.Forms.Padding(6);
            this.gbIzd.Size = new System.Drawing.Size(356, 266);
            this.gbIzd.TabIndex = 0;
            this.gbIzd.TabStop = false;
            this.gbIzd.Text = "Выберите изделие";
            this.gbIzd.Enter += new System.EventHandler(this.gbIzd_Enter);
            // 
            // rbPT4M
            // 
            this.rbPT4M.AutoSize = true;
            this.rbPT4M.Location = new System.Drawing.Point(8, 157);
            this.rbPT4M.Name = "rbPT4M";
            this.rbPT4M.Size = new System.Drawing.Size(120, 29);
            this.rbPT4M.TabIndex = 5;
            this.rbPT4M.TabStop = true;
            this.rbPT4M.Text = "ПТ1-4М";
            this.rbPT4M.UseVisualStyleBackColor = true;
            // 
            // rbMR
            // 
            this.rbMR.AutoSize = true;
            this.rbMR.Location = new System.Drawing.Point(8, 192);
            this.rbMR.Name = "rbMR";
            this.rbMR.Size = new System.Drawing.Size(106, 29);
            this.rbMR.TabIndex = 4;
            this.rbMR.TabStop = true;
            this.rbMR.Text = "МР1-2";
            this.rbMR.UseVisualStyleBackColor = true;
            // 
            // rbPT4
            // 
            this.rbPT4.AutoSize = true;
            this.rbPT4.Location = new System.Drawing.Point(9, 119);
            this.rbPT4.Margin = new System.Windows.Forms.Padding(6);
            this.rbPT4.Name = "rbPT4";
            this.rbPT4.Size = new System.Drawing.Size(102, 29);
            this.rbPT4.TabIndex = 3;
            this.rbPT4.TabStop = true;
            this.rbPT4.Text = "ПТ1-4";
            this.rbPT4.UseVisualStyleBackColor = true;
            // 
            // rbPT6B
            // 
            this.rbPT6B.AutoSize = true;
            this.rbPT6B.Location = new System.Drawing.Point(8, 78);
            this.rbPT6B.Margin = new System.Windows.Forms.Padding(6);
            this.rbPT6B.Name = "rbPT6B";
            this.rbPT6B.Size = new System.Drawing.Size(116, 29);
            this.rbPT6B.TabIndex = 2;
            this.rbPT6B.TabStop = true;
            this.rbPT6B.Text = "ПТ1-6Б";
            this.rbPT6B.UseVisualStyleBackColor = true;
            // 
            // rbPT6A
            // 
            this.rbPT6A.AutoSize = true;
            this.rbPT6A.Location = new System.Drawing.Point(8, 37);
            this.rbPT6A.Margin = new System.Windows.Forms.Padding(6);
            this.rbPT6A.Name = "rbPT6A";
            this.rbPT6A.Size = new System.Drawing.Size(116, 29);
            this.rbPT6A.TabIndex = 1;
            this.rbPT6A.TabStop = true;
            this.rbPT6A.Text = "ПТ1-6А";
            this.rbPT6A.UseVisualStyleBackColor = true;
            // 
            // btnChoice
            // 
            this.btnChoice.Location = new System.Drawing.Point(24, 319);
            this.btnChoice.Margin = new System.Windows.Forms.Padding(6);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(150, 44);
            this.btnChoice.TabIndex = 1;
            this.btnChoice.Text = "Выбрать";
            this.btnChoice.UseVisualStyleBackColor = true;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(358, 256);
            this.printBtn.Margin = new System.Windows.Forms.Padding(6);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(150, 44);
            this.printBtn.TabIndex = 2;
            this.printBtn.Text = "Ок";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(409, 319);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(148, 44);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Справка";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 87);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(496, 160);
            this.textBox1.TabIndex = 4;
            // 
            // amountNud
            // 
            this.amountNud.Location = new System.Drawing.Point(388, 46);
            this.amountNud.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.amountNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountNud.Name = "amountNud";
            this.amountNud.Size = new System.Drawing.Size(120, 31);
            this.amountNud.TabIndex = 5;
            this.amountNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.amountNud);
            this.groupBox1.Controls.Add(this.printBtn);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 309);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Для печати паспортов (ПТ1-4М,6, МР1-2)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите кол-во паспортов";
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(400, 23);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(168, 45);
            this.aboutBtn.TabIndex = 7;
            this.aboutBtn.Text = "О программе";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // rbRep600
            // 
            this.rbRep600.AutoSize = true;
            this.rbRep600.Location = new System.Drawing.Point(9, 227);
            this.rbRep600.Name = "rbRep600";
            this.rbRep600.Size = new System.Drawing.Size(151, 29);
            this.rbRep600.TabIndex = 6;
            this.rbRep600.TabStop = true;
            this.rbRep600.Text = "РЭП600ПТ";
            this.rbRep600.UseVisualStyleBackColor = true;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 721);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnChoice);
            this.Controls.Add(this.gbIzd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "main_form";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.main_form_Load);
            this.gbIzd.ResumeLayout(false);
            this.gbIzd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNud)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIzd;
        private System.Windows.Forms.RadioButton rbPT4;
        private System.Windows.Forms.RadioButton rbPT6B;
        private System.Windows.Forms.RadioButton rbPT6A;
        private System.Windows.Forms.Button btnChoice;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rbMR;
        private System.Windows.Forms.RadioButton rbPT4M;
        private System.Windows.Forms.NumericUpDown amountNud;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.RadioButton rbRep600;
    }
}

