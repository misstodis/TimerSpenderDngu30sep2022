using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TimerSpenderDngu30sep2022.frmSettingDngu;
using System.IO;

namespace TimerSpenderDngu30sep2022
{
    public partial class TimeSpenderDngu : Form
    {
        int timeSpendDngu = 3;
        int timerCountDngu = 0;
        // date
        DateTime dateTimeNowDngu = DateTime.Now;
        //define class
        TaskDngu makeTaskDngu = null;
        //define a list
        List<TaskDngu> taskListDngu = new List<TaskDngu>();
        List<string> defaultListTaskDngu = new List<string> { "Home work", "Watching movie", "Sport", "Play game" };
        List<string> listActionDone = new List<string>();
        //define a path for default save log
        string defaultSaveLogDngu = Application.StartupPath + "DefaultLog.txt";
        //custom cursor
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        public static extern IntPtr LoadCursorFromFile(string filename);

        public TimeSpenderDngu()
        {
            InitializeComponent();
        }

        // a method to show the form
        private void ShowTheFormDngu()
        {
            //show the form
            this.Show();
            //show the form in taskbar
            this.ShowInTaskbar = true;
            //disable show icon in system tray
            ntfiDngu.Visible = false;
            btnSaveWorkDngu.Enabled = true;
        }
        private void HideTheFormDngu()
        {
            // hide the form
            this.Hide();
            // show icon into the system tray
            ntfiDngu.Visible = true;
            ntfiDngu.ShowBalloonTip(1000);
            tmrToSpendDngu.Start();
            btnSaveWorkDngu.Enabled = false;
        }

        //this is a funtion to load a custom cursor
        public void LoadCursorDngu(Form p_formDngu)
        {
            //this using for custom cursor
            Cursor myCursorDngu;
            IntPtr handle = LoadCursorFromFile(System.Windows.Forms.Application.StartupPath + "\\normal.cur");
            myCursorDngu = new Cursor(handle);
            p_formDngu.Cursor = myCursorDngu;

        }

        private void TimeSpenderDngu_Load(object sender, EventArgs e)
        {
            //set the form away stay when u clicked outside 
            this.TopMost = true;
            //set width , height form
            this.Width = 441;
            this.Height = 479;
            // only select on drop box
            cmbListTaskDngu.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadCursorDngu(this);

            //setting for notifyicon
            ntfiDngu.BalloonTipTitle = "Time spender";
            ntfiDngu.BalloonTipText = "Time spender start , let make a good work !";
            ntfiDngu.Text = "Time spender";

            foreach (var item in defaultListTaskDngu)
            {
                cmbListTaskDngu.Items.Add(item);
            }
            
        }
        private void btnSaveWorkDngu_Click(object sender, EventArgs e)
        {
            listActionDone.Clear();
            if (cmbListTaskDngu.SelectedItem == null && rtbDoDngu.Text == "")
            {
                MessageBox.Show("Please choose or wirte something todo before saving ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbListTaskDngu.SelectedItem != null && rtbDoDngu.Text == "")
            {
                string selectedTaskDngu = cmbListTaskDngu.SelectedItem.ToString();
                if (!taskListDngu.Any())
                {
                    makeTaskDngu = new TaskDngu(selectedTaskDngu, timeSpendDngu, true,dateTimeNowDngu.ToShortDateString());
                    taskListDngu.Add(makeTaskDngu);
                }
                else
                {
                    for (int i = 0; i < taskListDngu.Count; i++)
                    {
                        if (taskListDngu[i].GetTaskDngu() == selectedTaskDngu && taskListDngu[i].GetDateOfTaskDngu() == dateTimeNowDngu.ToShortDateString())
                        {
                            makeTaskDngu = new TaskDngu(selectedTaskDngu, timeSpendDngu, true, dateTimeNowDngu.ToShortDateString());
                            makeTaskDngu.SetCountimeDngu(taskListDngu[i].GetCountTimeDngu());
                            taskListDngu.Add(makeTaskDngu);
                            taskListDngu.RemoveAt(i);
                            break;
                        }
                        else if( i == taskListDngu.Count() - 1 && taskListDngu[i].GetTaskDngu() == selectedTaskDngu && taskListDngu[i].GetDateOfTaskDngu() != dateTimeNowDngu.ToShortDateString())
                        {
                            makeTaskDngu = new TaskDngu(selectedTaskDngu, timeSpendDngu, true, dateTimeNowDngu.ToShortDateString());
                            taskListDngu.Add(makeTaskDngu);
                            break;
                        }
                        else if (i == taskListDngu.Count() -1 && taskListDngu[i].GetTaskDngu() != selectedTaskDngu)
                        {
                            makeTaskDngu = new TaskDngu(selectedTaskDngu, timeSpendDngu, true, dateTimeNowDngu.ToShortDateString());
                            taskListDngu.Add(makeTaskDngu);
                            break;
                        }
                    }
                }
                //hide the form
                HideTheFormDngu();
            }
            else if (cmbListTaskDngu.SelectedItem == null && rtbDoDngu.Text != "")
            {
                if (!taskListDngu.Any())
                {
                    makeTaskDngu = new TaskDngu(rtbDoDngu.Text, timeSpendDngu, false, dateTimeNowDngu.ToShortDateString());
                    taskListDngu.Add(makeTaskDngu);
                }
                else
                {
                    for (int i = 0; i < taskListDngu.Count(); i++)
                    {
                        if (taskListDngu[i].GetTaskDngu() == rtbDoDngu.Text && taskListDngu[i].GetDateOfTaskDngu() == dateTimeNowDngu.ToShortDateString())
                        {
                            taskListDngu[i].SetCountimeDngu(timeSpendDngu);
                            break;
                        }
                        else if (i == taskListDngu.Count() - 1 && taskListDngu[i].GetTaskDngu() == rtbDoDngu.Text && taskListDngu[i].GetDateOfTaskDngu() != dateTimeNowDngu.ToShortDateString())
                        {
                            makeTaskDngu = new TaskDngu(rtbDoDngu.Text, timeSpendDngu, false, dateTimeNowDngu.ToShortDateString());
                            taskListDngu.Add(makeTaskDngu);
                            break;
                        }
                        else if (i == taskListDngu.Count() - 1 && taskListDngu[i].GetTaskDngu() != rtbDoDngu.Text)
                        {
                            makeTaskDngu = new TaskDngu(rtbDoDngu.Text, timeSpendDngu, false, dateTimeNowDngu.ToShortDateString());
                            taskListDngu.Add(makeTaskDngu);
                            break;
                        }
                    }
                }
                //hide the form
                HideTheFormDngu();
            }
        }

        private void ntfiDngu_MouseDoubleClick(object sender, EventArgs e)
        {
            ShowTheFormDngu();
        }

        private void btnShowDngu_Click(object sender, EventArgs e)
        {
            string messageDngu = "";
            //loop the donelist to get what u have done
            foreach (var item in taskListDngu)
            {

                if (item.GetCountTimeDngu() > 0)
                {
                    messageDngu = item.GetTaskDngu() + " in: " + item.GetCountTimeDngu().ToString() + " minutes done" + " on " + item.GetDateOfTaskDngu();
                    listActionDone.Add(messageDngu);
                }
            }
            var messageAction = string.Join(Environment.NewLine, listActionDone);
            MessageBox.Show(messageAction);
        }

        private void timeToSpendDngu_Tick(object sender, EventArgs e)
        {
            timerCountDngu++;
            //after 3 seconds , show the form 
            if (timerCountDngu >= timeSpendDngu)
            {
                ShowTheFormDngu();
                timerCountDngu = 0;
                tmrToSpendDngu.Stop();
                cmbListTaskDngu.SelectedItem = null;
                rtbDoDngu.Text = "";
            }
        }

        private void rtbDoDngu_TextChanged(object sender, EventArgs e)
        {
            cmbListTaskDngu.SelectedItem = null;
        }

        private void cmbListDoDngu_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbDoDngu.Text = "";
        }

        //this void will get data from settingform throught delegate
        void loadDataDngu(List<TaskDngu> data, int p_timeSpendDngu, string p_defaultSaveLogDngu , List<string> p_defaultListTaskDngu)
        {
            // set time spend when the time changed in setting form
            timeSpendDngu = p_timeSpendDngu;
            //set change path voor save log after changed in setting form
            defaultSaveLogDngu = p_defaultSaveLogDngu;

            // clear combobox en store new task in 
            cmbListTaskDngu.Items.Clear();
            foreach (var item in p_defaultListTaskDngu)
            {
                cmbListTaskDngu.Items.Add(item);
            }
        }
        private void btnSettingDngu_Click(object sender, EventArgs e)
        {

            var settingFrom = new frmSettingDngu(taskListDngu, timeSpendDngu, defaultSaveLogDngu, defaultListTaskDngu);
            // set void loadDataDngu for delegate in settingform
            settingFrom.sendInfoToMainForm = new sendToMainForm(loadDataDngu);
            // make the form to front
            settingFrom.TopMost = true;
            settingFrom.Focus();
            //show the setting form with ShowDialog , this mean that u can ONLY click on second form
            settingFrom.ShowDialog();
        }
    }
}