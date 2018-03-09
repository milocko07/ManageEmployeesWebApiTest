using ManageEmployees.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageEmployees.Business
{
    public interface IEmployeeBusiness
    {
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();
    }
}
