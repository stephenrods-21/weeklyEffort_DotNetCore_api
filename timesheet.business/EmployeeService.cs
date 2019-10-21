using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timesheet.data;
using timesheet.model;
using timesheet.model.ViewModels;

namespace timesheet.business
{
    public class EmployeeService
    {
        private TimesheetDb db { get; }
        public EmployeeService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public async Task<List<EmployeeVM>> GetEmployeesAsync()
        {
            List<EmployeeVM> employeeList = new List<EmployeeVM>();
            var employees = await this.db.Employees.Include(r => r.TimeSheets).ToListAsync();

            foreach (var employee in employees)
            {
                int totalWeeklyEffort = employee.TimeSheets.Sum(r => r.Sun);
                totalWeeklyEffort += employee.TimeSheets.Sum(r => r.Mon);
                totalWeeklyEffort += employee.TimeSheets.Sum(r => r.Tue);
                totalWeeklyEffort += employee.TimeSheets.Sum(r => r.Wed);
                totalWeeklyEffort += employee.TimeSheets.Sum(r => r.Thur);
                totalWeeklyEffort += employee.TimeSheets.Sum(r => r.Fri);
                totalWeeklyEffort += employee.TimeSheets.Sum(r => r.Sat);


                int sunEffort = employee.TimeSheets.Sum(r => r.Sun);
                employeeList.Add(new EmployeeVM
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Code = employee.Code,
                    TotalWeeklyEffort = totalWeeklyEffort,
                    AvgWeeklyEffort = totalWeeklyEffort / 7
                });
            }
            return employeeList;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await this.db.Employees.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TimeSheet> GetTimeSheetById(int tId)
        {
            return await this.db.TimeSheets.Where(r => r.Id == tId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(TimeSheetVM model)
        {
            Employee employee = new Employee();
            TimeSheet timeSheet = new TimeSheet();
            List<TimeSheet> newTmeSheetList = new List<TimeSheet>();
            var tasks = model.TimeSheetDetailVM;

            var employeeDetails = await this.db.Employees.Include(r => r.TimeSheets).Where(r => r.Id == model.EmployeeId).FirstOrDefaultAsync();
            if (employeeDetails != null)
            {
                foreach (var task in model.TimeSheetDetailVM)
                {
                    var editTask = employeeDetails.TimeSheets.Where(r => r.Id == task.Id).FirstOrDefault();
                    if (editTask != null)
                    {
                        // update the existing task
                        editTask.Sun = task.Sun;
                        editTask.Mon = task.Mon;
                        editTask.Tue = task.Tue;
                        editTask.Wed = task.Wed;
                        editTask.Thur = task.Thur;
                        editTask.Fri = task.Fri;
                        editTask.Sat = task.Sat;
                        editTask.TaskId = task.TaskId;
                    }
                    else
                    {
                        //create a new task
                        var newTaskSheet = new TimeSheet
                        {
                            EmployeeId = employeeDetails.Id,
                            TaskId = task.TaskId,
                            Sun = task.Sun,
                            Mon = task.Mon,
                            Tue = task.Tue,
                            Wed = task.Wed,
                            Thur = task.Thur,
                            Fri = task.Fri,
                            Sat = task.Sat
                        };

                        newTmeSheetList.Add(newTaskSheet);
                    }
                }

                if(newTmeSheetList.Any())
                {
                    foreach(var timesheet in newTmeSheetList)
                    {
                        employeeDetails.TimeSheets.Add(timesheet);
                    }
                }
            }

            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<IList<timesheet.model.Task>> GetAllTasksAsync()
        {
            return await this.db.Tasks.ToListAsync();
        }

        public async Task<TimeSheetVM> GetTimeSheetByEmployeeIdAsync(int empId)
        {
            TimeSheetVM timeSheetList = new TimeSheetVM();
            var employeeTimesheet = await this.db.TimeSheets
                 .Include(k => k.Employee)
                .Include(m => m.Task)
                .Where(r => r.EmployeeId == empId).ToListAsync();

            foreach (var item in employeeTimesheet)
            {
                timeSheetList.TimeSheetDetailVM.Add(new TimeSheetDetailVM
                {
                    Id = item.Id,
                    TaskId = item.TaskId,
                    TaskName = item.Task.Name,
                    Sun = item.Sun,
                    Mon = item.Mon,
                    Tue = item.Tue,
                    Wed = item.Wed,
                    Thur = item.Thur,
                    Fri = item.Fri,
                    Sat = item.Sat
                });
            }

            timeSheetList.EmployeeId = empId;
            timeSheetList.TotalSunEffort = timeSheetList.TimeSheetDetailVM.Sum(r => r.Sun);
            timeSheetList.TotalMonEffort = timeSheetList.TimeSheetDetailVM.Sum(r => r.Mon);
            timeSheetList.TotalTueEffort = timeSheetList.TimeSheetDetailVM.Sum(r => r.Tue);
            timeSheetList.TotalWedEffort = timeSheetList.TimeSheetDetailVM.Sum(r => r.Wed);
            timeSheetList.TotalThurEffort = timeSheetList.TimeSheetDetailVM.Sum(r => r.Thur);
            timeSheetList.TotalFriEffort = timeSheetList.TimeSheetDetailVM.Sum(r => r.Fri);
            timeSheetList.TotalSatEffort = timeSheetList.TimeSheetDetailVM.Sum(r => r.Sat);

            return timeSheetList;
        }
    }
}
