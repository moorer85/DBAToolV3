
using DBAToolV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBATool.Data
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();

        IEnumerable<Employee> GetEmployees();

        void Add(Employee newEmployee);

        /////// int GetAssetCount(int branchId);

        Employee Get(int id);

    }
}
