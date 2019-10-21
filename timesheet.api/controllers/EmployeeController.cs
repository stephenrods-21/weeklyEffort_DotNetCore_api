using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timesheet.business;
using timesheet.model.ViewModels;

namespace timesheet.api.controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(string text)
        {
            var items = await this.employeeService.GetEmployeesAsync();
            return Ok(items);
        }

        [HttpGet("getalltasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var items = await this.employeeService.GetAllTasksAsync();
            return Ok(items);
        }

        [HttpGet("gettimesheetbyemployeeidasync")]
        public async Task<IActionResult> GetTimeSheetByEmployeeIdAsync(int empId)
        {
            var items = await this.employeeService.GetTimeSheetByEmployeeIdAsync(empId);
            return Ok(items);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(TimeSheetVM model)
        {
            await this.employeeService.UpdateAsync(model);
            return Ok(true);
        }
    }
}