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
        DoingDngu makeTaskDngu = null;
        //define a list
        List<DoingDngu> taskListDngu = new List<DoingDngu>();
        List<DoingDngu> taskDoneListDngu = new List<DoingDngu>();
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

        //this message method will make the show task in order
        private void DoneTask(DoingDngu p_taskDngu)
        {
            //check if there already have a task in the list, if not then store the task in the list
            if (!taskDoneListDngu.Any())
            {
                taskDoneListDngu.Add(p_taskDngu);
            }
            //if there an tasks in the list
            else
            {
                //loop the message list to find the task
                for (int i = 0; i < taskDoneListDngu.Count(); i++)
                {
                    // check unitl the last element in the list, if there nothing like eachother then store a task in message list

                    // if find a same task in the message list then replace it with the new task
                    //Console.WriteLine("before: " + taskDoneListDngu[i].GetDoingDngu() + " " + taskDoneListDngu[i].GetDateOfTaskDngu());
                    if (p_taskDngu.GetDoingDngu() == taskDoneListDngu[i].GetDoingDngu() && p_taskDngu.GetDateOfTaskDngu() == taskDoneListDngu[i].GetDateOfTaskDngu())
                    {
                        taskDoneListDngu[i] = p_taskDngu ;
                        break;
                    }
                    else if (i == taskDoneListDngu.Count() - 1 && taskDoneListDngu[i].GetDoingDngu() != p_taskDngu.GetDoingDngu() && p_taskDngu.GetDateOfTaskDngu() != taskDoneListDngu[i].GetDateOfTaskDngu())
                    {
                        taskDoneListDngu.Add(p_taskDngu);
                        break;
                    }
                }
            }
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

            //make a class doing thing and store it in the list
            makeTaskDngu = new DoingDngu("Home Work", 0, dateTimeNowDngu.ToShortDateString() );
            taskListDngu.Add(makeTaskDngu);
            makeTaskDngu = new DoingDngu("Playing game", 0, dateTimeNowDngu.ToShortDateString());
            taskListDngu.Add(makeTaskDngu);
            makeTaskDngu = new DoingDngu("Watching movie", 0, dateTimeNowDngu.ToShortDateString());
            taskListDngu.Add(makeTaskDngu);
            makeTaskDngu = new DoingDngu("Learning", 0, dateTimeNowDngu.ToShortDateString());
            taskListDngu.Add(makeTaskDngu);
            makeTaskDngu = new DoingDngu("Workout", 0, dateTimeNowDngu.ToShortDateString());
            taskListDngu.Add(makeTaskDngu);

            //store class in the combobox
            foreach (var item in taskListDngu)
            {
                if (item.GetIsDefaultDngu())
                {
                    cmbListTaskDngu.Items.Add(item.GetDoingDngu());
                }
            }
        }
        private void btnSaveWorkDngu_Click(object sender, EventArgs e)
        {
            if (cmbListTaskDngu.SelectedItem == null && rtbDoDngu.Text == "")
            {
                MessageBox.Show("Please choose or wirte something todo before saving ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbListTaskDngu.SelectedItem != null && rtbDoDngu.Text == "")
            {
                string selectedTaskDngu = cmbListTaskDngu.SelectedItem.ToString();
                foreach (var item in taskListDngu)
                {
                    // check if there a task already exsist, if it exsist then increase it , and store it in and message list
                    if (item.GetDoingDngu() == selectedTaskDngu && item.GetDateOfTaskDngu() == dateTimeNowDngu.ToShortDateString())
                    {

                        item.SetCountimeDngu(timeSpendDngu);
                        DoneTask(item);
                        break;
                    }
                    else if (item.GetDoingDngu() == selectedTaskDngu && item.GetDateOfTaskDngu() != dateTimeNowDngu.ToShortDateString())
                    {
                        makeTaskDngu = new DoingDngu(selectedTaskDngu, timeSpendDngu, dateTimeNowDngu.ToShortDateString());
                        taskListDngu.Add(makeTaskDngu);
                        DoneTask(makeTaskDngu);
                        break;
                    }
                }
                //hide the form
                HideTheFormDngu();
            }
            else if (cmbListTaskDngu.SelectedItem == null && rtbDoDngu.Text != "")
            {
                for (int i = 0; i < taskListDngu.Count(); i++)
                {
                    // check if there a task already exsist and sameday as today, then increase it.
                    if (taskListDngu[i].GetDoingDngu() == rtbDoDngu.Text && taskDoneListDngu[i].GetDateOfTaskDngu() == dateTimeNowDngu.ToShortDateString())
                    {
                        taskListDngu[i].SetCountimeDngu(timeSpendDngu);
                        break;
                    }
                    //check unitl the last element in the list, if there nothing like eachother , make e new class store it in the task list and message list
                    else if (i == taskListDngu.Count() - 1 && taskListDngu[i].GetDoingDngu() != rtbDoDngu.Text)
                    {
                        makeTaskDngu = new DoingDngu(rtbDoDngu.Text, timeSpendDngu, dateTimeNowDngu.ToShortDateString(),false);
                        taskListDngu.Add(makeTaskDngu);
                        DoneTask(makeTaskDngu);
                        break;
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
            foreach (var item in taskDoneListDngu)
            {
                if (item.GetCountTimeDngu() > 0)
                {
                    if (messageDngu == "")
                    {
                        messageDngu = item.GetDoingDngu() + " in: " + item.GetCountTimeDngu().ToString() + " minutes done" + " on " + item.GetDateOfTaskDngu() + "\n";
                    }
                    else
                    {
                        messageDngu = messageDngu + "\n" + item.GetDoingDngu() + " in: " + item.GetCountTimeDngu().ToString() + " minutes done" + " on " + item.GetDateOfTaskDngu() + "\n";
                    }
                }
            }
            MessageBox.Show(messageDngu);
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
        void loadDataDngu(List<DoingDngu> data, int p_timeSpendDngu, string p_defaultSaveLogDngu)
        {
            // set time spend when the time changed in setting form
            timeSpendDngu = p_timeSpendDngu;
            //set change path voor save log after changed in setting form
            defaultSaveLogDngu = p_defaultSaveLogDngu;

            // clear combobox en store new task in 
            cmbListTaskDngu.Items.Clear();
            foreach (var item in data)
            {
                cmbListTaskDngu.Items.Add(item.GetDoingDngu());
            }
        }
        private void btnSettingDngu_Click(object sender, EventArgs e)
        {

            var settingFrom = new frmSettingDngu(taskListDngu, timeSpendDngu, defaultSaveLogDngu, taskDoneListDngu);
            // set void loadDataDngu for delegate in settingform
            settingFrom.sendInfoToMainForm = new sendToMainForm(loadDataDngu);
            // make the form to front
            settingFrom.TopMost = true;
            settingFrom.Focus();
            //show the setting form with ShowDialog , this mean that u can ONLY click on second form
            settingFrom.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dateTest = "14/10/2022";
            string dateTest2 = "14/10/2022";

            if (dateTest == dateTest2)
            {
                MessageBox.Show("good");
            }
            else
            {
                MessageBox.Show("bad");
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (var item in taskListDngu)
            {
                Console.WriteLine(item.GetDoingDngu() + " in " + item.GetCountTimeDngu() + " on " + item.GetDateOfTaskDngu());
            }
        }
    }
}