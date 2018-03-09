using ManageEmployees.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace ManageEmployees.WebApi.Controllers
{
    public class EmployeeInformationController : Controller
    {
        static HttpClient client = new HttpClient();

        // GET: EmployeeInformation
        public ActionResult Index()
        {
            var employeesList = new List<EmployeeModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51010/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetAsync("api/employees/getall");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EmployeeModel[]>();
                    readTask.Wait();
                    var employees = readTask.Result;
                    foreach (var employee in employees)
                    {
                        employeesList.Add(new EmployeeModel
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
                }
            }

            return View(employeesList);
        }
    }
}