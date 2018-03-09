using ManageEmployees.Data.Entities;
using ManageEmployees.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ManageEmployees.Data.Access
{
    public class EmployeeAccess : IEmployeeAccess
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            var employeesList = new List<EmployeeEntity>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetAsync("api/Employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<EmployeeEntity[]>();
                    var employees = readTask;

                    foreach (var employee in employees)
                    {
                        employeesList.Add(new EmployeeEntity
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            ContractTypeName = employee.ContractTypeName,
                            RoleId = employee.RoleId,
                            RoleName = employee.RoleName,
                            RoleDescription = employee.RoleDescription,
                            HourlySalary = employee.HourlySalary,
                            MonthlySalary = employee.MonthlySalary,
                        });
                    }
                }
            }

            return employeesList;
        }
    }
}