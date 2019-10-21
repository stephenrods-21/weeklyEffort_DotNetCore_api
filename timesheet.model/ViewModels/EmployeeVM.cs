using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.model.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int TotalWeeklyEffort { get; set; }
        public int AvgWeeklyEffort { get; set; }
    }
}
