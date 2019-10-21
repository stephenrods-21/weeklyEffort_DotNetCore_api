using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.model.ViewModels
{
    public class TimeSheetVM
    {
        public TimeSheetVM()
        {
            TimeSheetDetailVM = new List<TimeSheetDetailVM>();
        }
        public int EmployeeId { get; set; }
        public List<TimeSheetDetailVM> TimeSheetDetailVM { get; set; }
        public int TotalSunEffort { get; set; }
        public int TotalMonEffort { get; set; }
        public int TotalTueEffort { get; set; }
        public int TotalWedEffort { get; set; }
        public int TotalThurEffort { get; set; }
        public int TotalFriEffort { get; set; }
        public int TotalSatEffort { get; set; }
    }

    public class TimeSheetDetailVM
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int Sun { get; set; }
        public int Mon { get; set; }
        public int Tue { get; set; }
        public int Wed { get; set; }
        public int Thur { get; set; }
        public int Fri { get; set; }
        public int Sat { get; set; }
    }
}
