using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepositoryLayer
{
   public class EmployeeDataBaseSetting : IEmployeeDataBaseSetting
    {   
            public string NotesCollectionName { get; set; }
            public string EmployeeCollectionName { get; set; }
            // public string NotesCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
    }

        public interface IEmployeeDataBaseSetting
        {
            public string NotesCollectionName { get; set; }
            string EmployeeCollectionName { get; set; }
            //     public string NotesCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
    
}
