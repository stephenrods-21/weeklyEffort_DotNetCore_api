using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace timesheet.model
{
    public class TimeSheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public int Sun { get; set; }
        public int Mon { get; set; }
        public int Tue { get; set; }
        public int Wed { get; set; }
        public int Thur { get; set; }
        public int Fri { get; set; }
        public int Sat { get; set; }

    }
}
