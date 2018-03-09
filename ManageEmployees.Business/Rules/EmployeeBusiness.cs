using ManageEmployees.Data.Access;
using ManageEmployees.Data.Entities;
using ManageEmployees.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ManageEmployees.Business.FactoryPattern;

namespace ManageEmployees.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeAccess _employeeAccess;

        public EmployeeBusiness(IEmployeeAccess employeeAccess)
        {
            _employeeAccess = employeeAccess;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            var listEmployees = await _employeeAccess.GetAllAsync();
            foreach (var employee in listEmployees)
            {
                EmployeeFactory EmployeeFactory = new ConcreteEmployeeFactory();

                IFactory typeEmployee = EmployeeFactory.Factory(employee.ContractTypeName);
                employee.TotalSalary = typeEmployee.CalculateAnualSalary(employee);
            }

            return listEmployees;
        }
    }
}
