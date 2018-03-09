using ManageEmployees.Business;
using ManageEmployees.Data.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace ManageEmployees.Api.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeesController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [Route("employees/getAll")]
        [HttpGet]
        public IHttpActionResult GetAllAsync()
        {
            var listEmployees = _employeeBusiness.GetAllAsync();
            return Ok();
        }
    }
}
