using System;

namespace Leave_Portal
{
    public class Verification // Do not change classname
    {
        public string CheckLeaveRequestDate(DateTime leaveRequestDate) //Do not change method signature
        {
            //Check if the requested leave date belongs to future date, current year and is not a weekend and return respective message

            if (leaveRequestDate.Date < DateTime.Now.Date)
                return "Date must be a future date!";
            if (leaveRequestDate.Year != DateTime.Now.Year)
                return "You can avail leave only for the current year!";
            if ((leaveRequestDate.DayOfWeek == DayOfWeek.Saturday) || (leaveRequestDate.DayOfWeek == DayOfWeek.Sunday))
                return "Date belongs to weekend!";
            return "Leave Granted!";
        }
    }
}
