using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBussinessLayer.Interface;
using EmployeeCommenLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        /// <summary>
        /// bussiness layer Interface
        /// </summary>
        IEmployeeBL businessLayer;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="businessLayer">To Ascess all properties of IEmployeeBL</param>
        public EmployeeManagementController(IEmployeeBL businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        /// <summary>
        /// Method to add Employee
        /// </summary>
        /// <param name="employee">Employee Object</param>
        /// <returns></returns>   
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            try
            {
                bool result = this.businessLayer.AddEmployee(employee);

                if (result == true)
                    return this.Ok(new { success = true, message = "record added", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Record not added" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Method to get the list of Employee
        /// </summary>
        /// <returns>List of employee</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetEmployee()
        {
            try
            {
                var result = this.businessLayer.GetEmployee();
                if (result != null)
                    return this.Ok(new { success = true, message = "displayed all records,..successfully..", data = result });
                else
                    return this.BadRequest(new { success = false, message = "No records present", data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// method to get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}")]
        [AllowAnonymous]
        public IActionResult GetEmployeeById(string id)
        {
            try
            {
                var result = this.businessLayer.GetEmployeeById(id);
                if (result != null)
                    return this.Ok(new { sucess = true, data = result });
                else
                    return this.BadRequest(new { success = false, message = "Opps.. something went wrong" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Method to update employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id:length(24)}")]
        [AllowAnonymous]
        public IActionResult UpdateEmployee(string id, EmployeeModel employee)
        {
            try
            {
                bool result = this.businessLayer.Edit(id, employee);

                if (result == true)
                    return this.Ok(new { success = true, message = "record updated" });
                else
                    return this.BadRequest(new { success = false, message = "record not updated" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Method to delete Employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}")]
        [AllowAnonymous]
        public IActionResult DeleteEmployee(string id)
        {
            try
            {
                bool result = this.businessLayer.DeleteEmployeeById(id);

                if (result == true)
                    return this.Ok(new { success = true, message = "record deleted", data = result });
                else
                    return this.BadRequest(new { success = false, message = "record not deleted" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
