using ManageEmployees.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployees.Business
{
    internal static class FactoryPattern
    {
        public interface IFactory
        {
            double CalculateAnualSalary(EmployeeEntity employee);
        }

        public class HourlySalaryEmployee : IFactory
        {
            public double CalculateAnualSalary(EmployeeEntity employee)
            {
                return 120 * employee.HourlySalary * 12;
            }
        }

        public class MonthlySalaryEmployee : IFactory
        {
            public double CalculateAnualSalary(EmployeeEntity employee)
            {
                return employee.MonthlySalary * 12;
            }
        }

        public abstract class EmployeeFactory
        {
            public abstract IFactory Factory(string employeeType);
        }

        public class ConcreteEmployeeFactory : EmployeeFactory
        {
            public override IFactory Factory(string employeeType)
            {
                switch (employeeType)
                {
                    case "HourlySalaryEmployee":
                        return new HourlySalaryEmployee();
                    case "MonthlySalaryEmployee":
                        return new MonthlySalaryEmployee();
                    default:
                        throw new ApplicationException(string.Format("This type of employee can not be created"));
                }
            }
        }
    }
}
