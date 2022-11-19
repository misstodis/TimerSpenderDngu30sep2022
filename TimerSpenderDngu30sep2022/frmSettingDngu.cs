using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace TimerSpenderDngu30sep2022
{
    public partial class frmSettingDngu : Form
    {
        bool showChartDngu = false;
        bool showExcelDngu = false;
        TimeSpenderDngu formMainDngu = new TimeSpenderDngu();
        //define a list 
        List<TaskDngu> taskListDngu = new List<TaskDngu>();
        List<string> defaultListTaskDngu = new List<string>();
        List<string> listTaskDateDngu = new List<string>();
        List<TaskDngu> allUniqueTaskDone = new List<TaskDngu>();
        // define time spend
        int timeSpendDngu;
        //define a default path for save log
        string defaultSaveLogDngu;
        //make a delegate to comunicate with main form (SEND info from this to the main form)
        public delegate void sendToMainForm(List<TaskDngu> list, int p_timeSpendDngu, string p_defaultSaveLogDngu, List<string> p_defaultListTaskDngu);
        public sendToMainForm sendInfoToMainForm;
        //chart types
        string[] chartTypesDngu = new string[] { "Column", "Bar", "Pie" };
        string[] chartSortDngu = new string[] { "Name Ascending", "Name Descending", "Time Ascending", "Time Decending", "Date Ascending", "Date Descending" };
        //random for color
        Random randomColorDngu = new Random();
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
        //list of past date
        List<string> listPastDays = null;


        // define form contructor with a parmameter to GET information from main form
        public frmSettingDngu(List<TaskDngu> p_taskListDngu, int p_timeSpendDngu, string p_defaultSaveLogDngu, List<string> p_defaultListTaskDngu)
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
            defaultListTaskDngu = p_defaultListTaskDngu;
        }

        private void LoadDefaultTaskToListBoxDngu()
        {
            // clear listbox
            lsbTaskDngu.Items.Clear();
            //load defautl task to list box
            foreach (var item in defaultListTaskDngu)
            {
                lsbTaskDngu.Items.Add(item);
            }
        }

        private void HandleSetChartDateDngu()
        {
            cmbChartDate.Items.Clear();
            cmbChartDate.Items.Add("All");
            var UniqueDates = listTaskDateDngu.Distinct().ToList();
            foreach (var date in UniqueDates)
            {
                cmbChartDate.Items.Add(date);
            }
            cmbChartDate.SelectedIndex = 1;
        }
        private void ChartCreate(TaskDngu p_task , int p_chartStart , string p_chartType)
        {
            switch (p_chartType)
            {
                case "Pie":
                    crtTaskDngu.Series["Time spend"].Points.Add(taskListDngu[p_chartStart].GetCountTimeDngu());
                    crtTaskDngu.Series["Time spend"].Points[p_chartStart].AxisLabel = p_task.GetCountTimeDngu().ToString();
                    crtTaskDngu.Series["Time spend"].Points[p_chartStart].LegendText = p_task.GetTaskDngu();
                    crtTaskDngu.Series["Time spend"].Points[p_chartStart].Color = Color.FromArgb(randomColorDngu.Next(0, 225), randomColorDngu.Next(0, 225), randomColorDngu.Next(0, 225));
                    //p_chartStart++;
                    break;
                case "Column":
                case "Bar":
                    crtTaskDngu.Series["Time spend"].Points.Add(p_task.GetCountTimeDngu());
                    crtTaskDngu.Series["Time spend"].Points[p_chartStart].AxisLabel = p_task.GetTaskDngu();
                    crtTaskDngu.Series["Time spend"].Points[p_chartStart].Color = Color.FromArgb(randomColorDngu.Next(0, 225), randomColorDngu.Next(0, 225), randomColorDngu.Next(0, 225));
                    //p_chartStart++;
                    break;
            }
        }

        private void ChartGenerateDngu(string p_dateTask = "All", List<string> p_listPastDays = null, string p_chartType = "Column")
        {
            // clean the chart
            crtTaskDngu.Series["Time spend"].Points.Clear();
            //loop and print information to chart
            int chartStartDngu = 0;

            if (p_dateTask == "All")
            {
                foreach (var taskDngu in allUniqueTaskDone)
                {
                    // check for slected type of the chart
                    ChartCreate(taskDngu, chartStartDngu, p_chartType);
                    chartStartDngu++;
                }
            }
            else
            {
                if (p_listPastDays != null)
                {
                    foreach (var task in p_listPastDays)
                    {
                        Console.WriteLine(task);
                    }
                    foreach (var taskDngu in taskListDngu)
                    {
                        if (listPastDays.Contains(taskDngu.GetDateOfTaskDngu()))
                        {
                            // check for slected type of the chart
                            ChartCreate(taskDngu, chartStartDngu, p_chartType);
                            chartStartDngu++;
                        }
                    }
                }
                else
                {
                    foreach (var taskDngu in taskListDngu)
                    {
                        if (p_dateTask == taskDngu.GetDateOfTaskDngu())
                        {
                            // check for slected type of the chart
                            ChartCreate(taskDngu, chartStartDngu, p_chartType);
                            chartStartDngu++;
                        }
                    }
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

        private void handleAllUniqueTaskToList(TaskDngu p_taskFromExcel)
        {
            if (allUniqueTaskDone.Count == 0)
            {
                allUniqueTaskDone.Add(p_taskFromExcel);
            }
            else
            {
                int uniqueTask = allUniqueTaskDone.FindIndex(index => index.GetTaskDngu() == p_taskFromExcel.GetTaskDngu());
                if (uniqueTask >= 0)
                {
                    allUniqueTaskDone[uniqueTask].SetCountimeDngu(p_taskFromExcel.GetCountTimeDngu());
                }
                else
                {
                    allUniqueTaskDone.Add(p_taskFromExcel);
                }
            }
        }

        private void handleAddExcelItemsToTaskListDngu(TaskDngu p_taskFromExcel)
        {    
            /* 
             * 1. if tasklist empty then adding niew task (object) in
             * 2. if tasklist not empty:
             *  - check if there an task with same name exist in the tasklist , if that then increase the time of the task an break the if 
             *  - if there not exist an task with same name and this is the last element in the list , then adding the task to the list and break the if
             */
            if (!taskListDngu.Any())
            {
                taskListDngu.Add(p_taskFromExcel);
            }
            else
            {
                for (int i = 0; i < taskListDngu.Count; i++)
                {
                    //int index = taskListDngu.FindIndex(indexD => indexD.GetTaskDngu() == p_taskFromExcel.GetTaskDngu());
                    //int indexDengu = taskListDngu.FindIndex(indexD => indexD.GetDateOfTaskDngu() == p_taskFromExcel.GetDateOfTaskDngu());

                    Console.WriteLine(taskListDngu[i].GetTaskDngu() + " on " + taskListDngu[i].GetDateOfTaskDngu() + " VS " + p_taskFromExcel.GetTaskDngu() + " on " + p_taskFromExcel.GetDateOfTaskDngu());
                    if (taskListDngu[i].GetTaskDngu() == p_taskFromExcel.GetTaskDngu() && taskListDngu[i].GetDateOfTaskDngu() == p_taskFromExcel.GetDateOfTaskDngu())
                    {
                        Console.WriteLine("COUNT UP");
                        taskListDngu[i].SetCountimeDngu(p_taskFromExcel.GetCountTimeDngu());
                        break;
                    }
                    else if (i == taskListDngu.Count - 1 && taskListDngu[i].GetTaskDngu() == p_taskFromExcel.GetTaskDngu() && taskListDngu[i].GetDateOfTaskDngu() != p_taskFromExcel.GetDateOfTaskDngu())
                    {
                        Console.WriteLine("NOT same Date : ADD");
                        taskListDngu.Add(p_taskFromExcel);
                        break;
                    }
                    else if (i == taskListDngu.Count - 1 && taskListDngu[i].GetTaskDngu() != p_taskFromExcel.GetTaskDngu())
                    {
                        Console.WriteLine("LAST : ADD");
                        taskListDngu.Add(p_taskFromExcel);
                        break;
                    }
                }
            }
            
        }

        private void frmSettingDngu_Load(object sender, EventArgs e)
        {
            //loading custom cursor
            formMainDngu.LoadCursorDngu(this);
            //load tasks to listbox
            LoadDefaultTaskToListBoxDngu();
            // set value for numericUpDown box 
            nudLogIntervalDngu.Value = timeSpendDngu;
            // turnof Close (x) button
            this.ControlBox = false;
            //adding chart types in combobox
            cmbChartTypesDngu.Items.AddRange(chartTypesDngu);
            cmbChartTypesDngu.SelectedIndex = 0;
            //set size form
            this.Width = 705;
            this.Height = 460;
            //loading date to combobox
            listTaskDateDngu.Add(dateTimeNowDngu.ToShortDateString());
            cmbChartDate.SelectedIndex = 0;
            //adding chart sort in combobox
            cmbChartSortDngu.Items.AddRange(chartSortDngu);
            cmbChartSortDngu.SelectedIndex = 0;
            //adding date of task to list
            foreach (var task in taskListDngu)
            {
                listTaskDateDngu.Add(task.GetDateOfTaskDngu());
            }
            cmbChartDate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChartSortDngu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChartTypesDngu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAddStandartTaskDngu_Click(object sender, EventArgs e)
        {
            if (txbAddStandartTaskDngu.Text != "")
            {
                foreach (var taskName in defaultListTaskDngu)
                {
                    if (taskName == txbAddStandartTaskDngu.Text)
                    {
                        MessageBox.Show("the task name already in exist, please make an others", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    else
                    {
                        defaultListTaskDngu.Add(txbAddStandartTaskDngu.Text);
                        txbAddStandartTaskDngu.Text = "";
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("please fill in the field before adding!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadDefaultTaskToListBoxDngu();
        }

        private void btnDeleteTaskDngu_Click(object sender, EventArgs e)
        {
            //delete task in the list, define on selected index of the list box
            defaultListTaskDngu.RemoveAt(lsbTaskDngu.SelectedIndex);
            // loading task to listbox
            LoadDefaultTaskToListBoxDngu();
        }

        private void btnSaveSetttingDngu_Click(object sender, EventArgs e)
        {
            // send changed informationi to main form
            //convert value form numericUpDown to int32 and send it to main form to change the timeSpendDngu
            sendInfoToMainForm(taskListDngu, Convert.ToInt32(nudLogIntervalDngu.Value), defaultSaveLogDngu, defaultListTaskDngu);
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
                            writeLogFileDngu.WriteLine(item.GetTaskDngu() + " done in " + item.GetCountTimeDngu().ToString() + " minute" + " on " + item.GetDateOfTaskDngu());
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
            if (taskListDngu.Count() > 0)
            {
                showChartDngu = showChartDngu ? false : true;
                this.Height = showChartDngu ? 889 : 460;
                btnShowChart.Text = showChartDngu ? "Hide chart" : "Show chart";
                cmbChartDate.SelectedIndex = 0;
                ChartGenerateDngu();
                HandleSetChartDateDngu();
            }
            else
            {
                MessageBox.Show("there are nothing");
            }

        }

        private void cmbChartTypesDngu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTaskDateDngu.Count > 0)
            {
                //check slected text in combobox
                switch (cmbChartTypesDngu.SelectedItem.ToString())
                {
                    // change chart type and generate chart
                    case "Column":
                        crtTaskDngu.Series["Time spend"].ChartType = SeriesChartType.Column;
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                    case "Bar":
                        crtTaskDngu.Series["Time spend"].ChartType = SeriesChartType.Bar;
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                    case "Pie":
                        crtTaskDngu.Series["Time spend"].ChartType = SeriesChartType.Pie;
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                }
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

            if (taskListDngu.Count > 0)
            {
                //get emptycell
                int cellExcelStart = last.Row + 1;
                for (int i = 0; i < taskListDngu.Count; i++)
                {
                    xlWorksheet.Cells[cellExcelStart, 1] = taskListDngu[i].GetTaskDngu();
                    cellExcelStart++;
                    xlWorksheet.Cells[cellExcelStart, 1] = taskListDngu[i].GetCountTimeDngu();
                    cellExcelStart++;
                    xlWorksheet.Cells[cellExcelStart, 1] = taskListDngu[i].GetIsDefaultDngu();
                    cellExcelStart++;
                    xlWorksheet.Cells[cellExcelStart, 1] = DateTime.Parse(taskListDngu[i].GetDateOfTaskDngu()).ToOADate();
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
            string taskNameDngu, taskDateDngu;
            int taskTimeDngu;
            bool taskIsDefDngu;
            int cellExcelStart = 1;
            //cleart tabel
            dgvExcelDngu.Rows.Clear();
            dgvExcelDngu.Refresh();
            CheckForExcelDoc();
            // make a loop to print value from excel on the tabel
            //note : excel cell staat at number 1
            for (int i = 0; i < xlRange.Rows.Count / 4; i++)
            {
                if (xlRange.Cells[cellExcelStart, 1] != null && xlRange.Cells[cellExcelStart, 1].Value2 != null)
                {
                    taskNameDngu = Convert.ToString(xlRange.Cells[cellExcelStart, 1].Value2);
                    cellExcelStart++;
                    taskTimeDngu = Convert.ToInt32(xlRange.Cells[cellExcelStart, 1].Value2);
                    cellExcelStart++;
                    taskIsDefDngu = Convert.ToBoolean(xlRange.Cells[cellExcelStart, 1].Value2);
                    cellExcelStart++;
                    if (xlRange.Cells[cellExcelStart, 1].Value.GetType() == typeof(DateTime))
                    {
                        taskDateDngu = xlRange.Cells[cellExcelStart, 1].Value.ToShortDateString();
                    }
                    else if (xlRange.Cells[cellExcelStart, 1].Value.GetType() == typeof(Double))
                    {
                        taskDateDngu = DateTime.FromOADate(xlRange.Cells[cellExcelStart, 1].Value).ToShortDateString();
                    }
                    else
                    {
                        taskDateDngu = Convert.ToString(xlRange.Cells[cellExcelStart, 1].Value2);
                    }
                    cellExcelStart++;
                    //adding value on tabel
                    dgvExcelDngu.Rows.Add(taskNameDngu, taskTimeDngu, taskDateDngu, taskIsDefDngu);

                    //make a task (object) and store information in
                    TaskDngu taskFromExecel = new TaskDngu(taskNameDngu, taskTimeDngu, taskIsDefDngu, taskDateDngu);
                    //handle adding the task from execel to the list 
                    handleAddExcelItemsToTaskListDngu(taskFromExecel);
                    handleAllUniqueTaskToList(taskFromExecel);
                    // adding date to a list
                    listTaskDateDngu.Add(taskDateDngu);
                }
            }
            CleanUpExcel();
            //generate the charts
            ChartGenerateDngu();

        }

        private void cmbChartDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartGenerateDngu(cmbChartDate.SelectedItem.ToString());
        }

        private void cmbChartSortDngu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (taskListDngu.Count > 0)
            {
                switch (cmbChartSortDngu.SelectedItem.ToString())
                {
                    case "Name Ascending":
                        taskListDngu = taskListDngu.OrderBy(x => x.GetTaskDngu()).ToList();
                        allUniqueTaskDone = allUniqueTaskDone.OrderBy(x => x.GetTaskDngu()).ToList();
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                    case "Name Descending":
                        taskListDngu = taskListDngu.OrderByDescending(x => x.GetTaskDngu()).ToList();
                        allUniqueTaskDone = allUniqueTaskDone.OrderByDescending(x => x.GetTaskDngu()).ToList();
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                    case "Time Ascending":
                        taskListDngu = taskListDngu.OrderBy(x => x.GetCountTimeDngu()).ToList();
                        allUniqueTaskDone = allUniqueTaskDone.OrderBy(x => x.GetCountTimeDngu()).ToList();
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                    case "Time Decending":
                        taskListDngu = taskListDngu.OrderByDescending(x => x.GetCountTimeDngu()).ToList();
                        allUniqueTaskDone = allUniqueTaskDone.OrderByDescending(x => x.GetCountTimeDngu()).ToList();
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                    case "Date Ascending":
                        taskListDngu = taskListDngu.OrderBy(x => DateTime.Parse(x.GetDateOfTaskDngu())).ToList();
                        allUniqueTaskDone = allUniqueTaskDone.OrderBy(x => DateTime.Parse(x.GetDateOfTaskDngu())).ToList();
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays, cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                    case "Date Descending":
                        taskListDngu = taskListDngu.OrderByDescending(x => DateTime.Parse(x.GetDateOfTaskDngu())).ToList();
                        allUniqueTaskDone = allUniqueTaskDone.OrderByDescending(x => DateTime.Parse(x.GetDateOfTaskDngu())).ToList();
                        ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays,cmbChartTypesDngu.SelectedItem.ToString());
                        break;
                }
            }
        }

        private void btnPastDays_Click(object sender, EventArgs e)
        {
            listPastDays = new List<string>();
            listPastDays.Clear();
            double HowManyDays = Convert.ToDouble(nudPastdays.Value);
            double getDateToday = dateTimeNowDngu.ToOADate();
            double pastDays ;

            if (cmbChartDate.SelectedItem.ToString() != "All")
            {
                double selectedDate = DateTime.Parse(cmbChartDate.SelectedItem.ToString()).ToOADate();
                Console.WriteLine(selectedDate);
                for (int i = 0; i <= Convert.ToInt32(HowManyDays); i++)
                {
                    pastDays = selectedDate - Convert.ToDouble(i);
                    listPastDays.Add(DateTime.FromOADate(pastDays).ToShortDateString());
                    Console.WriteLine(DateTime.FromOADate(pastDays).ToShortDateString());
                    ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays);
                }
            }
            else if (cmbChartDate.SelectedItem.ToString() == "All")
            {
                MessageBox.Show("With All at date selection , you can't select for a past day. \n Please choose a date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < Convert.ToInt32(HowManyDays); i++)
                {
                    pastDays = getDateToday - Convert.ToDouble(i);
                    Console.WriteLine(DateTime.FromOADate(pastDays).ToShortDateString());
                    listPastDays.Add(DateTime.FromOADate(pastDays).ToShortDateString());
                    ChartGenerateDngu(cmbChartDate.SelectedItem.ToString(), listPastDays);
                }
            }
        }
    }
}
