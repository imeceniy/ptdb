using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DataGrabber;
using Word = Microsoft.Office.Interop.Word;

namespace ptdb
{
    public partial class frmData : Form
    {
        public string type = "";
        public frmData()
        {
            InitializeComponent();
        }
        //Открытие через меню
        private void MstOpenDialog_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = ofd.FileName;
            //string fileText = System.IO.File.ReadAllText(fileName);
            var reader = new FileReader_PT4();
            var section_n = new DataSection_PT4();
            reader.ReadFile(fileName);
            //BindingSource binding = new BindingSource();
            //binding.DataSource = reader.Things;
            //dgvMain.DataSource = binding;
            foreach (var thing in reader.Things)
            {
                //dgvMain.Rows.Add();
                //Console.WriteLine($"Thing number {thing.Key}:");
                //textBox1.Text += $"Thing number {thing.Key}:";
                foreach (var section in thing.Value)
                {
                    //Console.WriteLine($"Section {section.Key}:");
                    //textBox1.Text += $"Section {section.Key}:";
                    foreach (var data in section.Value)
                    {
                        //Console.WriteLine($"\t {data.Key}: {data.Value}");
                        //textBox1.Text += $"\t {data.Key}: {data.Value} \n";
                    }
                    //Console.WriteLine();
                }
            }
        }

        private void FrmData_Load(object sender, EventArgs e)
        {
            if (type == "6A")
            {
                lblChoose.Text += "ПТ1-6А";
            }
            else if (type == "6B")
            {
                lblChoose.Text += "ПТ1-6Б";
            }
            else if (type == "4")
            {
                lblChoose.Text += "ПТ1-4";
            }
            else if (type == "4M")
            {
                lblChoose.Text += "ПТ1-4М";
            }
            else if (type == "MR")
            {
                lblChoose.Text += "МР1-2";
                lblSize.Visible = true;
                lblSize.Enabled = true;
                txtSize.Visible = true;
                txtSize.Enabled = true;
            }
            else if (type == "rep600")
            {
                lblChoose.Text += "РЭП600ПТ";
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            tssProgressBar.Value = 0;
            tsslProgress.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Документ MS Word (*.docx)|*.docx",
                Title = "Выберите файл паспорта"
            };
            tssProgressBar.Value += 5;
            openFileDialog.ShowDialog();
            Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();//процесс ворда
            Object docxFileName = openFileDialog.FileName;//имя файла
            Object missing = Type.Missing;
            //открыли дркумент
            
            wordApp.Documents.Open(ref docxFileName, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);

            //путь к папке с временными файлами
            string temp = Path.GetTempPath();

            //открытие файла с параметрами
            var reader_PT4 = new FileReader_PT4();
            var reader_PT6 = new FileReader();
            var reader_MR = new FileReader_MR();
            var reader_PT4M = new FileReader_PT4M();
            var reader_rep = new FileReader_rep();
            ofd.Title = "Выберите файл с данными";
            tssProgressBar.Value += 5;
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = ofd.FileName;
            if (type == "6A" || type == "6B")
            {
                reader_PT6.ReadFile(fileName);
            }
            else if (type == "4")
            {
                reader_PT4.ReadFile(fileName);
            }
            else if (type == "MR")
            {
                reader_MR.ReadFile(fileName);
            }
            else if (type == "4M")
            {
                reader_PT4M.ReadFile(fileName);
            }
            else if (type == "rep600")
            {
                reader_rep.ReadFile(fileName);
            }
            //подготовка к поиску
            object findText = "$Rx1$";
            Word.Find findObject = wordApp.Selection.Find;
            object replaceAll = Word.WdReplace.wdReplaceAll;
            object replaceOne = Word.WdReplace.wdReplaceOne;
            Word.Find findObject1 = wordApp.Selection.Find;
            object replaceOne1 = Word.WdReplace.wdReplaceOne;


            //подготовка к копированию/вставке
            if (type.Contains("6"))
            {
                wordApp.ActiveDocument.PageSetup.BottomMargin = 28.3f;
                wordApp.ActiveDocument.PageSetup.LeftMargin = 35.4f;
                wordApp.ActiveDocument.PageSetup.RightMargin = 35.4f;
                wordApp.ActiveDocument.PageSetup.TopMargin = 35.4f;
                wordApp.ActiveDocument.Select();
                wordApp.Selection.PageSetup.BottomMargin = 28.3f;
                wordApp.Selection.PageSetup.LeftMargin = 35.4f;
                wordApp.Selection.PageSetup.RightMargin = 35.4f;
                wordApp.Selection.PageSetup.TopMargin = 35.4f;
            }
            wordApp.ActiveDocument.StoryRanges[Word.WdStoryType.wdMainTextStory].Copy();
            Object objUnit = Word.WdUnits.wdStory;
            int i = 0;
            int n = 1;
            string letter = "";
            //цикл вывода параметров в паспорта для ПТ1-4
            #region 4
            if (type == "4")
            {
                tsslProgress.Text = "Обработка данных";
                foreach (var thing in reader_PT4.Things)
                {
                    i++;
                    if (tssProgressBar.Value < 95)
                    {
                        tssProgressBar.Value++;
                    }
                    findObject.ClearFormatting();
                    findObject.Text = $"$num$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{thing.Key}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing); findObject.ClearFormatting();
                    findObject.Text = $"$date$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{nudDate.Value}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                    string dateVP = "";
                    dateVP = dtpVP.Text.ToString();
                    findObject.Text = $"$dateVP$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{dateVP}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    foreach (var section in thing.Value)
                    {
                        foreach (var data in section.Value)
                        {
                            //поиск и замена текста
                            if (data.Key.Contains("Rx"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$Rx{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dR"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dR{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < -20 || data.Value > 20)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dR {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("Qa"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$qa{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < 68.7 || data.Value > 71.3)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет Qa {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("dl"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dl{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 0.8)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dl {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("PPCu"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$PPCu{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < -0.4 || data.Value > 0.4)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет PPCu {data.Value}!\r\n";
                                }
                            }
                        }
                    }
                    int countD = reader_PT4.Things.Count;
                    if (i < countD)
                    {
                        wordApp.Selection.EndKey(ref objUnit, ref missing);
                        wordApp.Selection.TypeBackspace();
                        wordApp.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdPasteDefault);
                        wordApp.Selection.HomeKey(ref objUnit, ref missing);
                    }
                }
            }
            #endregion
            #region 4M
            else if (type == "4M")
            {
                tsslProgress.Text = "Обработка данных";
                foreach (var thing in reader_PT4M.Things)
                {
                    i++;
                    if (tssProgressBar.Value < 95)
                    {
                        tssProgressBar.Value++;
                    }
                    findObject.ClearFormatting();
                    findObject.Text = $"$num$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{thing.Key}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing); findObject.ClearFormatting();
                    findObject.Text = $"$date$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{nudDate.Value}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                    string dateVP = "";
                    dateVP = dtpVP.Text.ToString();
                    findObject.Text = $"$dateVP$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{dateVP}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                    foreach (var section in thing.Value)
                    {
                        foreach (var data in section.Value)
                        {
                            //поиск и замена текста
                            if (data.Key.Contains("Rx"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$Rx{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dR"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dR{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < -18 || data.Value > 18)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dR {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("Qa"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$qa{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < 68.7 || data.Value > 71.3)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет Qa {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("dl"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dl{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 0.8)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dl {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("PPCu"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$PPCu{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < -0.4 || data.Value > 0.4)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет PPCu {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("dmkl"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dmkl{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 0.3)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dmkrl {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("rk"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$rk{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 7)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет Rk {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("dck1"))
                            {

                                findObject.ClearFormatting();
                                findObject.Text = $"$dck1_{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 7)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dck1 {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("dck2"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dck2_{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 15)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dck2 {data.Value}!\r\n";
                                }
                            }
                        }
                    }
                    int countD = reader_PT4M.Things.Count;
                    if (i < countD)
                    {
                        wordApp.Selection.EndKey(ref objUnit, ref missing);
                        wordApp.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdPasteDefault);
                        wordApp.Selection.HomeKey(ref objUnit, ref missing);
                    }
                }
            }
            #endregion
            #region rep600
            else if (type == "rep600")
            {
                tsslProgress.Text = "Обработка данных";
                foreach (var thing in reader_rep.Things)
                {
                    i++;

                    if (tssProgressBar.Value < 95)
                    {
                        tssProgressBar.Value++;
                    }
                    if (n == 1)
                    {
                        findObject.ClearFormatting();
                        findObject.Text = $"$num1$";
                        findObject.Replacement.ClearFormatting();
                        findObject.Replacement.Text = $"{thing.Key}";
                        findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                        findObject1.ClearFormatting();
                        findObject1.Text = $"$date1$";
                        findObject1.Replacement.ClearFormatting();
                        findObject1.Replacement.Text = $"{nudDate.Value}";
                        findObject1.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                        string dateVP = "";
                        dateVP = dtpVP.Text.ToString();
                        findObject.Text = $"$dateVP$";
                        findObject.Replacement.ClearFormatting();
                        findObject.Replacement.Text = $"{dateVP}";
                        findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    }
                    if (n == 2)
                    {
                        findObject.ClearFormatting();
                        findObject.Text = $"$num2$";
                        findObject.Replacement.ClearFormatting();
                        findObject.Replacement.Text = $"{thing.Key}";
                        findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                        findObject1.ClearFormatting();
                        findObject1.Text = $"$date2$";
                        findObject1.Replacement.ClearFormatting();
                        findObject1.Replacement.Text = $"{nudDate.Value}";
                        findObject1.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                        findObject.Text = $"$dateVP$";
                        findObject.Replacement.ClearFormatting();
                        findObject.Replacement.Text = $"{dtpVP.Text}";
                        findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    }
                    if (n == 1)
                    {
                        foreach (var section in thing.Value)
                        {
                            foreach (var data in section.Value)
                            {
                                //поиск и замена текста
                                if (data.Key.Contains("Rx"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$Rx1_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.00}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                }
                                if (data.Key.Contains("dR"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$dR1_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value < -18 || data.Value > 18)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет dR {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("Qa"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$qa1_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value < 68.7 || data.Value > 71.3)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет Qa {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("dl"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$dl1_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.00}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value > 0.8)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет dl {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("PPCu"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$PPCu1_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.00}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value < -0.4 || data.Value > 0.4)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет PPCu {data.Value}!\r\n";
                                    }
                                }

                                if (data.Key.Contains("rk"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$rk1_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value > 7)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет Rk {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("dck1"))
                                {

                                    findObject.ClearFormatting();
                                    findObject.Text = $"$dck1_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value > 7)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет dck1 {data.Value}!\r\n";
                                    }
                                }
                            }
                        }

                    }
                    if (n == 2)
                    {
                        foreach (var section in thing.Value)
                        {
                            foreach (var data in section.Value)
                            {
                                //поиск и замена текста
                                if (data.Key.Contains("Rx"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$Rx2_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.00}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                }
                                if (data.Key.Contains("dR"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$dR2_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value < -18 || data.Value > 18)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет dR {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("Qa"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$qa2_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value < 68.7 || data.Value > 71.3)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет Qa {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("dl"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$dl2_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.00}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value > 0.8)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет dl {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("PPCu"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$PPCu2_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.00}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value < -0.4 || data.Value > 0.4)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет PPCu {data.Value}!\r\n";
                                    }
                                }

                                if (data.Key.Contains("rk"))
                                {
                                    findObject.ClearFormatting();
                                    findObject.Text = $"$rk2_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value > 7)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет Rk {data.Value}!\r\n";
                                    }
                                }
                                if (data.Key.Contains("dck1"))
                                {

                                    findObject.ClearFormatting();
                                    findObject.Text = $"$dck2_{section.Key}$";
                                    findObject.Replacement.ClearFormatting();
                                    findObject.Replacement.Text = $"{data.Value:0.0}";
                                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing, ref missing,
                                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                    if (data.Value > 7)
                                    {
                                        errorTxt.Text += $"Номер {thing.Key} имеет dck {data.Value}!\r\n";
                                    }
                                }
                            }
                        }

                    }
                    int countD = reader_rep.Things.Count;
                    if (n > 1)
                    {
                        if (i < countD)
                        {
                            wordApp.Selection.EndKey(ref objUnit, ref missing);
                            //wordApp.Selection.TypeBackspace();
                            wordApp.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdPasteDefault);
                            wordApp.Selection.HomeKey(ref objUnit, ref missing);
                            n = 1;
                        }
                    }
                    else {n++; }
                    
                }

            }
            #endregion
            #region 6a/b
            else if ((type == "6A") || (type == "6B"))
            {
                tsslProgress.Text = "Обработка данных";
                foreach (var thing in reader_PT6.Things)
                {
                    if (tssProgressBar.Value < 95)
                    {
                        tssProgressBar.Value++;
                    }
                    i++;
                    findObject.ClearFormatting();
                    findObject.Text = $"$num$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{thing.Key}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    findObject.Text = $"$date$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{nudDate.Value}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                    string dateVP = "";
                    dateVP = dtpVP.Text.ToString();
                    findObject.Text = $"$dateVP$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{dateVP}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    if (type == "6A")
                    {
                        letter = "А";
                    }
                    else if (type == "6B")
                    {
                        letter = "Б";
                    }
                    findObject.ClearFormatting();
                    findObject.Text = $"$let$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{letter}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    foreach (var section in thing.Value)
                    {
                        foreach (var data in section.Value)
                        {
                            //поиск и замена текста
                            if (data.Key.Contains("Rx"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$Rx{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dR"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dR{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < -18 || data.Value > 18)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dR {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("Qa"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$qa{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < 62.5 || data.Value > 65.5)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет Qa {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("dl"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dl{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 0.8)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dl {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("rk"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$rk{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 7)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет Rk {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("dck"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dck{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value > 7)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет dck {data.Value}!\r\n";
                                }
                            }
                            if (data.Key.Contains("PPCu"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$PPCu{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                if (data.Value < -0.8 || data.Value > 0.8)
                                {
                                    errorTxt.Text += $"Номер {thing.Key} имеет PPCu {data.Value}!\r\n";
                                }
                            }
                        }
                    }
                    int countD = reader_PT6.Things.Count;
                    if (i < countD)
                    {
                        wordApp.Selection.EndKey(ref objUnit, ref missing);
                        wordApp.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdPasteDefault);
                        wordApp.Selection.HomeKey(ref objUnit, ref missing);
                    }
                }
            }
            #endregion
            #region mr
            else if (type == "MR")
            {
                tsslProgress.Text = "Обработка данных";
                foreach (var thing in reader_MR.Things)
                {
                    if (tssProgressBar.Value < 95)
                    {
                        tssProgressBar.Value += 5;
                    }
                    i++;
                    findObject.ClearFormatting();
                    findObject.Text = $"$num$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{thing.Key}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    findObject.Text = $"$date$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{nudDate.Value}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                    findObject.Text = $"$size$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{txtSize.Text}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                    string dateVP = "";
                    dateVP = dtpVP.Text.ToString();
                    findObject.Text = $"$dateVP$";
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = $"{dateVP}";
                    findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    foreach (var section in thing.Value)
                    {
                        foreach (var data in section.Value)
                        {
                            //поиск и замена текста
                            if (data.Key.Contains("Rx"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$Rx{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dR"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dR{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("Qa"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$qa{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dl"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dl{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dlr"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dlr{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("rk"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$rk{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dck"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dck{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.0}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("PPCu"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$PPCu{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dmkl"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dmkl{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("dmklr"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$dmklr{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                            if (data.Key.Contains("index"))
                            {
                                findObject.ClearFormatting();
                                findObject.Text = $"$index{section.Key}$";
                                findObject.Replacement.ClearFormatting();
                                findObject.Replacement.Text = $"{data.Value:0.00}";
                                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                            }
                        }
                    }
                    int countD = reader_MR.Things.Count;
                    if (i < countD)
                    {
                        wordApp.Selection.EndKey(ref objUnit, ref missing);
                        wordApp.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdPasteDefault);
                        wordApp.Selection.HomeKey(ref objUnit, ref missing);

                    }
                }
            }
            #endregion
            //сохранение документа
            tsslProgress.Text = "Сохранение";
            SaveFileDialog saveFD = new SaveFileDialog
            {
                Filter = "Документ MS Word (*.docx)|*.docx",
                Title = "Выберите место сохранения"
            };
            if (saveFD.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            docxFileName = saveFD.FileName;
            wordApp.ActiveDocument.SaveAs2(ref docxFileName, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);
            wordApp.ActiveDocument.Close();
            wordApp.Quit();
            tssProgressBar.Value = 100;
            tsslProgress.Text = "Завершено";
        }

        //тестовая кнопка
        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "MS Word dosuments (*.docx)|*.docx|MS Word dosuments (*.doc)|*.doc"
            };
            openFileDialog.ShowDialog();
            Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();//процесс ворда
            Object docxFileName = openFileDialog.FileName;//имя файла
            Object missing = Type.Missing;
            //открыли документ

            var document = wordApp.Documents.Open(ref docxFileName, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);
            //путь к папке с временными файлами
            string temp = System.IO.Path.GetTempPath();
            document.StoryRanges[Word.WdStoryType.wdMainTextStory].Copy();
            Object objUnit = Word.WdUnits.wdStory;

            for (int i = 0; i <= 50; i++)
            {
                //document.StoryRanges[Word.WdStoryType.wdMainTextStory].Paste();
                //document.Range().Paste();
                wordApp.Selection.EndKey(ref objUnit, ref missing);
                wordApp.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdPasteDefault);
                //document.Content.PasteSpecial(DataType: Word.WdPasteOptions.wdKeepSourceFormatting);

            }
            //сохранение
            SaveFileDialog saveFD = new SaveFileDialog
            {
                Filter = "MS Word dosuments (*.docx)|*.docx|MS Word dosuments (*.doc)|*.doc"
            };
            saveFD.ShowDialog();
            docxFileName = saveFD.FileName;
            wordApp.ActiveDocument.SaveAs2(ref docxFileName, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);
            wordApp.ActiveDocument.Close();


        }

        private void dtpVP_ValueChanged(object sender, EventArgs e)
        {
            //lblDateVP.Text = dtpVP.Text;
        }
    }
}