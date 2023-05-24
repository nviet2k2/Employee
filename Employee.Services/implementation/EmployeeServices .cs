using Employee.DataAccess;
using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Employee.Services.implementation
{
    public class EmployeeServices : IEmployeeService

    {
        private ApplicationDbContext _context;
        public EmployeeServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(Employees newEmployee)
        {
            _context.Employee.Add(newEmployee);

            await _context.SaveChangesAsync();
        }
         
        public async Task DeleteById(int id)
        {
            var employee = GetById(id);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employees> GetAll()
        {
            return _context.Employee.ToList();
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            var ListEmployee = _context.Employee.Select(e => new SelectListItem
            {
             Text = e.FullName,
             Value=e.ID.ToString(),
            });
            return ListEmployee;
        }

        public Employees GetById(int id)
        {
            return _context.Employee.Where(x => x.ID == id).FirstOrDefault();
        }

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();

        }

        public decimal UnionFrees(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsSync(Employees newEmployee)
        {
            _context.Employee.Update(newEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
