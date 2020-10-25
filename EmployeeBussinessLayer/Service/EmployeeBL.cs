using EmployeeBussinessLayer.Interface;
using EmployeeCommenLayer.Model;
using EmployeeRepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBussinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private IEmployeeRL repositoryLayer;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="repositoryLayer"></param>
        public EmployeeBL(IEmployeeRL repositoryLayer)
        {
            try
            {
                this.repositoryLayer = repositoryLayer;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Method to get employee
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployee()
        {
            try
            {
                return this.repositoryLayer.GetEmployee();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    

        /// <summary>
        ///Method to add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>bool value</returns>
        public bool AddEmployee(EmployeeModel employee)
        {
            try
            {
                return this.repositoryLayer.AddEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to delete emp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployeeById(string id)
        {
            try
            {
                return this.repositoryLayer.DeleteEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to Edit Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Edit(string id, EmployeeModel employee)
        {
            try
            {
                return this.repositoryLayer.Edit(id, employee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to get employee By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployeeById(string id)
        {
            try
            {
                return this.repositoryLayer.GetEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
