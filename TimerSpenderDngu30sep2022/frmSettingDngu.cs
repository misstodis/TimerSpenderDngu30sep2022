﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ApplicationDngu = System.Windows.Forms.Application;
//excel
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;

namespace TimerSpenderDngu30sep2022
{
    public partial class frmSettingDngu : Form
    {
        bool showChartDngu =false;
        bool showExcelDngu = false;
        TimeSpenderDngu formMainDngu = new TimeSpenderDngu();
        //define a list 
        List<DoingDngu> taskListDngu = new List<DoingDngu>();
        List<DoingDngu> taskDoneListDngu = new List<DoingDngu>();
        // define time spend
        int timeSpendDngu;
        //define a default path for save log
        string defaultSaveLogDngu;
        //make a delegate to comunicate with main form (SEND info from this to the main form)
        public delegate void sendToMainForm(List<DoingDngu> list, int p_timeSpendDngu, string p_defaultSaveLogDngu);
        public sendToMainForm sendInfoToMainForm;
        //chart types
        string[] chartTypes = new string[] {"Column", "Bar", "Pie" };
        //random for color
        Random randomColor = new Random();
        //excel
        string defaultExcelPathDngu = ApplicationDngu.StartupPath + "DefaultSaveTask.xlsx";
        Workbook xlWorkbook;
        Worksheet xlWorksheet;
        object misValue = System.Reflection.Missing.Value;
        Range xlRange = null;
        Excel.Application xlApp = null;
        FileInfo fileInfo = null;
        // date
        DateTime dateTimeNowDngu = DateTime.Now;

        // define form contructor with a parmameter to GET information from main form
        public frmSettingDngu(List<DoingDngu> p_taskListDngu, int p_timeSpendDngu, string p_defaultSaveLogDngu, List<DoingDngu> p_messageListDngu)
        {
            InitializeComponent();
            //get the task list from main form
            taskListDngu = p_taskListDngu;
            // set time to timeSpendDngu
            timeSpendDngu = p_timeSpendDngu;
            // set value for numerUpdown box
            nudLogIntervalDngu.Value = timeSpendDngu;
            // set defaukt save paht
            defaultSaveLogDngu = p_defaultSaveLogDngu;
            // show save path in text box
            txbFilelocationDngu.Text = p_defaultSaveLogDngu;
            taskDoneListDngu = p_messageListDngu;
        }

        private void LoadDefaultTaskToListBoxDngu(List<DoingDngu> listDngu)
        {
            // clear listbox
            lsbTaskDngu.Items.Clear();
            //load defautl task to list box
            foreach (var item in listDngu)
            {
                if (item.GetIsDefaultDngu())
                {
                    lsbTaskDngu.Items.Add(item.GetDoingDngu());
                }
            }
        }

        private void ChartGenerateDngu(string chartType = "Column")
        {
            // clean the chart
            crtStatsDngu.Series["Time spend"].Points.Clear();
            //loop and print information to chart
            for (int i = 0; i < taskDoneListDngu.Count(); i++)
            {
                // check for slected type of the chart
                switch (chartType)
                {
                    case "Pie":
                        crtStatsDngu.Series["Time spend"].Points.Add(taskDoneListDngu[i].GetCountTimeDngu());
                        crtStatsDngu.Series["Time spend"].Points[i].AxisLabel = taskDoneListDngu[i].GetCountTimeDngu().ToString();
                        crtStatsDngu.Series["Time spend"].Points[i].LegendText = taskDoneListDngu[i].GetDoingDngu();
                        crtStatsDngu.Series["Time spend"].Points[i].Color = Color.FromArgb(randomColor.Next(0, 225), randomColor.Next(0, 225), randomColor.Next(0, 225));
                        break;
                    case "Column":
                    case "Bar":
                        crtStatsDngu.Series["Time spend"].Points.Add(taskDoneListDngu[i].GetCountTimeDngu());
                        crtStatsDngu.Series["Time spend"].Points[i].AxisLabel = taskDoneListDngu[i].GetDoingDngu();
                        crtStatsDngu.Series["Time spend"].Points[i].Color = Color.FromArgb(randomColor.Next(0, 225), randomColor.Next(0, 225), randomColor.Next(0, 225));
                        break;
                }
            }
        }

        public void CheckForExcelDoc()
        {
            fileInfo = new FileInfo(defaultExcelPathDngu);
            xlApp = new Excel.Application();
            if (fileInfo.Extension == ".xlsx")
            {
                defaultExcelPathDngu = defaultExcelPathDngu.Remove(defaultExcelPathDngu.Length - 1);
            }
            if (File.Exists(defaultExcelPathDngu))
            {
                xlWorkbook = xlApp.Workbooks.Open(defaultExcelPathDngu);
                xlWorksheet = xlWorkbook.Sheets[1];
            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Worksheet)xlWorkbook.Worksheets.get_Item(1);
                xlWorkbook.SaveAs(defaultExcelPathDngu, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            xlRange = xlWorksheet.UsedRange;
        }

        public void CleanUpExcel()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release  com ojtect to fully kill excel process from running in de background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private void handleAddExcelItemsToTaskDoneListDngu(DoingDngu p_taskFormExcel)
        {
            /* 
             * 1. if donelist empty then adding niew task (object) in
             * 2. if donelist not empty:
             *  - check if there an task with same name exist in the donelist , if that then increase the time of the task an break the if 
             *  - if there not exist an task with same name and this is the last element in the list , then adding the task to the list and break the if
             */
            if (!taskDoneListDngu.Any())
            {
                taskDoneListDngu.Add(p_taskFormExcel);
            }
            else
            {
                for (int i = 0; i < taskDoneListDngu.Count; i++)
                {
                    if (taskDoneListDngu[i].GetDoingDngu() == p_taskFormExcel.GetDoingDngu() && taskDoneListDngu[i].GetDateOfTaskDngu() == p_taskFormExcel.GetDateOfTaskDngu())
                    {
                        taskDoneListDngu[i].SetCountimeDngu(p_taskFormExcel.GetCountTimeDngu());
                        break;
                    }
                    else if (taskDoneListDngu[i].GetDoingDngu() == p_taskFormExcel.GetDoingDngu() && taskDoneListDngu[i].GetDateOfTaskDngu() != p_taskFormExcel.GetDateOfTaskDngu())
                    {
                        taskDoneListDngu.Add(p_taskFormExcel);
                        break;
                    }
                    else if (i == taskDoneListDngu.Count - 1 && taskDoneListDngu[i].GetDoingDngu() != p_taskFormExcel.GetDoingDngu())
                    {
                        taskDoneListDngu.Add(p_taskFormExcel);
                        break;
                    }
                }
            }
        }

        private void handleAddExcelItemstoTaskListDngu(DoingDngu p_taskFormExcel)
        {
            /* 
            * 1. standart in the tasklist already exist a tasks
            *  - check if there an task with same name exist in the tasklist , if that then increase the time of the task an break the if 
            *  - if there not exist an task with same name and this is the last element in the list , then adding the task to the list and break the if
            */
            for (int i = 0; i < taskListDngu.Count; i++)
            {
                //if (taskListDngu[i].GetDoingDngu() == p_taskFormExcel.GetDoingDngu() && taskListDngu[i].GetDateOfTaskDngu() == p_taskFormExcel.GetDateOfTaskDngu() )
                //{
                //    taskListDngu[i].SetCountimeDngu(p_taskFormExcel.GetCountTimeDngu());
                //}
                if(taskListDngu[i].GetDoingDngu() == p_taskFormExcel.GetDoingDngu() && taskListDngu[i].GetDateOfTaskDngu() != p_taskFormExcel.GetDateOfTaskDngu())
                {
                    taskListDngu.Add(p_taskFormExcel);
                }
                if (i == taskListDngu.Count - 1 && taskListDngu[i].GetDoingDngu() != p_taskFormExcel.GetDoingDngu() && taskListDngu[i].GetDateOfTaskDngu() != p_taskFormExcel.GetDateOfTaskDngu())
                {
                    taskListDngu.Add(p_taskFormExcel);
                    break;
                }
            }
        }

        private void frmSettingDngu_Load(object sender, EventArgs e)
        {
            //loading custom cursor
            formMainDngu.LoadCursorDngu(this);
            //load tasks to listbox
            LoadDefaultTaskToListBoxDngu(taskListDngu);
            // set value for numericUpDown box 
            nudLogIntervalDngu.Value = timeSpendDngu;
            // turnof Close (x) button
            this.ControlBox = false;
            //adding chart types in combobox
            cmbChartTypesDngu.Items.AddRange(chartTypes);
            cmbChartTypesDngu.SelectedIndex = 0;
            //set size form
            this.Width = 705;
            this.Height = 460;
        }

        private void btnAddStandartTaskDngu_Click(object sender, EventArgs e)
        {
            if (txbAddStandartTaskDngu.Text != "")
            {
                for (var i = 0; i < taskListDngu.Count(); i++ )
                {
                    //check exist task in tasklist, if this exist and is standart then warning
                    if (txbAddStandartTaskDngu.Text == taskListDngu[i].GetDoingDngu() && taskListDngu[i].GetIsDefaultDngu() == true)
                    {
                        MessageBox.Show("the task name already in exist, please make an others","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    // if task exist and is not default then set is as default
                    else if (txbAddStandartTaskDngu.Text == taskListDngu[i].GetDoingDngu() && taskListDngu[i].GetIsDefaultDngu() != true)
                    {
                        taskListDngu[i].setAsDefaultDngu();
                    }
                    if ( i == taskListDngu.Count()-1 && txbAddStandartTaskDngu.Text != taskListDngu[i].GetDoingDngu())
                    {
                        // make a new default task
                        DoingDngu newTaskDngu = new DoingDngu(txbAddStandartTaskDngu.Text, 0,dateTimeNowDngu.ToShortDateString());
                        //adding to the list
                        taskListDngu.Add(newTaskDngu);
                        // load the list to listbox
                        txbAddStandartTaskDngu.Text = "";
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("please fill in the field before adding!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadDefaultTaskToListBoxDngu(taskListDngu);
        }

        private void btnDeleteTaskDngu_Click(object sender, EventArgs e)
        {
            //delete task in the list, define on selected index of the list box
            taskListDngu.RemoveAt(lsbTaskDngu.SelectedIndex);
            // loading task to listbox
            LoadDefaultTaskToListBoxDngu(taskListDngu);
        }

        private void btnSaveSetttingDngu_Click(object sender, EventArgs e)
        {
            // send changed informationi to main form
            //convert value form numericUpDown to int32 and send it to main form to change the timeSpendDngu
            sendInfoToMainForm(taskListDngu, Convert.ToInt32(nudLogIntervalDngu.Value), defaultSaveLogDngu);
            // close the form
            this.Close();
        }

        private void btnFinishedDngu_Click(object sender, EventArgs e)
        {
            //show waring message box before close app
            DialogResult dresult = MessageBox.Show("This will close the app and save all your actions \n Are you sure to close this app ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            // check what user clicked , if oke save file txt and close the app
            if (dresult == DialogResult.OK)
            {
                // define stream write to writing in txt file
                StreamWriter writeLogFileDngu = new StreamWriter(txbFilelocationDngu.Text);
                // wirting task u are finised in txt file
                using (writeLogFileDngu)
                {
                    // loop the task
                    foreach (var item in taskListDngu)
                    {
                        // check the task done en write it in txt file
                        if (item.GetCountTimeDngu() > 0)
                        {
                            writeLogFileDngu.WriteLine(item.GetDoingDngu() + " done in " + item.GetCountTimeDngu().ToString() + " minute" + " on " + item.GetDateOfTaskDngu());
                        }
                    }
                }
                ApplicationDngu.Exit();
            }
        }

        private void btnFileLocationDngu_Click(object sender, EventArgs e)
        {
            // lezen op de nieuw text file
            ofdOpenLogDngu.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // open dialog , and if u oke clicked
            if (ofdOpenLogDngu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //change file path on textbox
                txbFilelocationDngu.Text = ofdOpenLogDngu.FileName;
                // change default file path
                defaultSaveLogDngu = ofdOpenLogDngu.FileName;
            }

        }

        private void btnCloseSettingDngu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudLogIntervalDngu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //number box accept only nummer and backspace
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void nudLogIntervalDngu_ValueChanged(object sender, EventArgs e)
        {
            // check if log interval set as 0 , then warning and set back to 3
            if (Convert.ToInt32(nudLogIntervalDngu.Value) == 0)
            {
                MessageBox.Show("can't store 0 in log interval field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudLogIntervalDngu.Value = 3;
            }
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            if (taskDoneListDngu.Count() >0)
            {
                showChartDngu = showChartDngu ? false : true;
                this.Height = showChartDngu ? 770 : 460;
                btnShowChart.Text = showChartDngu ? "Hide chart" : "Show chart";
                ChartGenerateDngu(cmbChartTypesDngu.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("there are nothing");
            }
           
        }

        private void cmbChartTypesDngu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check slected text in combobox
            switch (cmbChartTypesDngu.SelectedItem.ToString())
            {
                // change chart type and generate chart
                case "Column":
                    crtStatsDngu.Series["Time spend"].ChartType = SeriesChartType.Column;
                    ChartGenerateDngu(cmbChartTypesDngu.SelectedItem.ToString());
                    break;
                case "Bar":
                    crtStatsDngu.Series["Time spend"].ChartType = SeriesChartType.Bar;
                    ChartGenerateDngu(cmbChartTypesDngu.SelectedItem.ToString());
                    break;
                case "Pie":
                    crtStatsDngu.Series["Time spend"].ChartType = SeriesChartType.Pie;
                    ChartGenerateDngu(cmbChartTypesDngu.SelectedItem.ToString());
                    break;
            }
        }

        private void btnShowExcelDngu_Click(object sender, EventArgs e)
        {
            showExcelDngu = showExcelDngu ? false : true;
            this.Width = showExcelDngu ? 1244 : 705;
            btnShowExcelDngu.Text = showExcelDngu ? "Hide Excel" : "Show excel";
        }
        private void btnSaveExcelDngu_Click(object sender, EventArgs e)
        {
            CheckForExcelDoc();
            //define to get last cell have value in excel
            Excel.Range last = xlWorksheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

            if (taskDoneListDngu.Count > 0)
            {
                //get emptycell
                int cellExcelStart = last.Row + 1;
                for (int i = 0; i < taskDoneListDngu.Count; i++)
                {
                    xlWorksheet.Cells[cellExcelStart, 1] = taskDoneListDngu[i].GetDoingDngu();
                    xlWorksheet.Cells[cellExcelStart, 2] = taskDoneListDngu[i].GetCountTimeDngu();
                    xlWorksheet.Cells[cellExcelStart, 3] = taskDoneListDngu[i].GetDateOfTaskDngu();
                    xlWorksheet.Cells[cellExcelStart, 4] = taskDoneListDngu[i].GetIsDefaultDngu();
                    cellExcelStart++;
                }
                xlApp.Visible = false;
                xlApp.UserControl = false;
                xlWorkbook.Save();

                CleanUpExcel();
            }
        }
        private void btnDisplayExcel_Click(object sender, EventArgs e)
        {
            //cleart tabel
            dgvExcelDngu.Rows.Clear();
            dgvExcelDngu.Refresh();
            CheckForExcelDoc();
            // make a loop to print value from excel on the tabel
            //note : excel cell staat at number 1 , that why "int i" in the loop need to be 1
            for (int i = 1; i <= xlRange.Rows.Count; i++)
            {
                if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                {
                    //adding value on tabel
                    dgvExcelDngu.Rows.Add(xlRange.Cells[i, 1].Value2, xlRange.Cells[i, 2].Value2, xlRange.Cells[i, 3].Value2, xlRange.Cells[i,4].Value2);
                    //make a task (object) and store information in
                    DoingDngu taksFromExecel = new DoingDngu(Convert.ToString(xlRange.Cells[i, 1].Value2), Convert.ToInt32(xlRange.Cells[i, 2].Value2), Convert.ToString(xlRange.Cells[i, 3].Value2)  ,Convert.ToBoolean(xlRange.Cells[i, 4].Value2));
                    //handle adding the task from execel to the list 
                    handleAddExcelItemsToTaskDoneListDngu(taksFromExecel);
                    handleAddExcelItemstoTaskListDngu(taksFromExecel);
                }
            }
            //load task to listbox
            LoadDefaultTaskToListBoxDngu(taskListDngu);
            //generate the chart
            ChartGenerateDngu();
            //close excel
            CleanUpExcel();
        }
    }
}