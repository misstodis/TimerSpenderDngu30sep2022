using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerSpenderDngu30sep2022
{
    public class DoingDngu
    {
        string doingDngu = "";
        int countTimesDngu = 0;
        bool isDefaultDngu = true;
        string dateOfTaskDngu ="";


        public DoingDngu(string p_doingDngu, int p_countTimesDngu, string p_dateOfTask, bool p_isDefault = true)
        {
            doingDngu = p_doingDngu;
            countTimesDngu = p_countTimesDngu;
            isDefaultDngu = p_isDefault;
            dateOfTaskDngu = p_dateOfTask; 
        }

        public string GetTaskDngu()
        {
            return doingDngu;
        }
        public int GetCountTimeDngu()
        {
            return countTimesDngu;
        }

        public bool GetIsDefaultDngu()
        {
            return isDefaultDngu;
        }
        public string GetDateOfTaskDngu()
        {
            return dateOfTaskDngu;
        }

        public void SetCountimeDngu(int timeSpendDngu)
        {
            countTimesDngu += timeSpendDngu;
        }

        public void setAsDefaultDngu()
        {
            isDefaultDngu = true;
        }

    }
}