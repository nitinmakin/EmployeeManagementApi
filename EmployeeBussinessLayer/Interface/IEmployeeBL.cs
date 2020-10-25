using EmployeeCommenLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBussinessLayer.Interface
{
   public interface IEmployeeBL
    {
        public List<EmployeeModel> GetEmployee();
        public bool AddEmployee(EmployeeModel employee);
        public bool DeleteEmployeeById(string id);
        public bool Edit(string id, EmployeeModel employee);
        public List<EmployeeModel> GetEmployeeById(string id);
    }
}
