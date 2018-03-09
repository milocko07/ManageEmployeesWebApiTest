using ManageEmployees.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployeesTest
{
    class Program
    {
        private static readonly IEmployeeBusiness _employeeBusiness;

        static void Main(string[] args)
        {
            CallApi();
        }

        static async void CallApi()
        {
            try
            {
                //ManageEmployees.Business.EmployeeBusiness employeeBusiness = new ManageEmployees.Business.EmployeeBusiness(_employeeBusiness);

                //var employeesListTest = await employeeBusiness.GetAllAsync();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
