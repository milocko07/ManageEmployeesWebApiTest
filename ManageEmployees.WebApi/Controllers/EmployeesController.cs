using ManageEmployees.Business;
using ManageEmployees.Data.Entities;
using ManageEmployees.WebApi.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace ManageEmployees.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeesController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [Route("api/employees/getAll")]
        [HttpGet]
        public IHttpActionResult GetAllAsync()
        {
            var listEmployees = _employeeBusiness.GetAllAsync();

            var employeeViewModelList = new List<EmployeeViewModel>();

            foreach (var employee in listEmployees.Result)
            {
                employeeViewModelList.Add(new EmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    ContractTypeName = employee.ContractTypeName,
                    RoleId = employee.RoleId,
                    RoleName = employee.RoleName,
                    RoleDescription = employee.RoleDescription,
                    HourlySalary = employee.HourlySalary,
                    MonthlySalary = employee.MonthlySalary,
                    TotalSalary = employee.TotalSalary,
                });
            } 
            return Ok(employeeViewModelList);
        }
    }
}
