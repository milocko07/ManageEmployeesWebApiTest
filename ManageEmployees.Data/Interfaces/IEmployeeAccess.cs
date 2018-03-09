using ManageEmployees.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageEmployees.Data.Interfaces
{
    public interface IEmployeeAccess
    {
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();
    }
}
