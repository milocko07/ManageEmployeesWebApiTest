using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageEmployees.WebApi.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public object RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
        public double TotalSalary { get; set; }
    }
}