using EmployeeCommenLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepositoryLayer.Interface
{
   public interface IEmployeeRL
    {
        public bool AddEmployee(EmployeeModel employee);
        public List<EmployeeModel> GetEmployee();
        public List<EmployeeModel> GetEmployeeById(string id);
        public bool Edit(string id, EmployeeModel employee);
        public bool DeleteEmployeeById(string id);
    }
}
