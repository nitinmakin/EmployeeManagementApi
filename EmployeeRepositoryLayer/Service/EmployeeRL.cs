using EmployeeCommenLayer.Model;
using EmployeeRepositoryLayer.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepositoryLayer.Service
{
   public class EmployeeRL : IEmployeeRL
    {
       
        private readonly IMongoCollection<EmployeeModel> _Employee;
        public EmployeeRL(IEmployeeDataBaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _Employee = database.GetCollection<EmployeeModel>(settings.EmployeeCollectionName);
        }

        /// <summary>
        /// method to add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel employee)
        {
            try
            {
                EmployeeModel newEmployee = new EmployeeModel()
                {
                    // Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PhoneNo = employee.PhoneNo,
                    Email = employee.Email,
                    Password = employee.Password
                };
                _Employee.InsertOne(newEmployee);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// method to get all employee
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployee()
        {
            try
            {
                return this._Employee.Find(employee => true).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// method to get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployeeById(string id)
        {
            try
            {
                return _Employee.Find<EmployeeModel>(employee => employee.Id == id).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to Update Employee details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Edit(string id, EmployeeModel employee)
        {
            try
            {
                _Employee.ReplaceOne(employee => employee.Id == id, employee);
                return true;
            }
            catch { return false; }
        }


        /// <summary>
        /// Method to delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployeeById(string id)
        {
            try
            {
                _Employee.DeleteOne(employee => employee.Id == id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
