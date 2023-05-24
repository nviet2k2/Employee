using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Employee.Services
{
    public interface IEmployeeService
    {
        Task CreateAsSync(Employees newEmployee);
        Task UpdateById(int id);
        Task UpdateAsSync(Employees newEmployee);
        Task DeleteById(int id);
        Employees GetById(int id);
        IEnumerable<Employees> GetAll();
        IEnumerable<SelectListItem> GetAllEmployeesForPayroll();
        decimal UnionFrees(int id);
        decimal StudentLoanRepaymentAmount(int id, decimal totalAmount);

    }
}
