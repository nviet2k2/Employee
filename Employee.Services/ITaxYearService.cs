using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Services
{
    public interface ITaxYearService
    {
        Task CreateAsSync(TaxYear newtaxYear);
        Task UpdateById(int id);
        Task UpdateAsSync(TaxYear newtaxYear);
        Task DeleteById(int id);
        TaxYear GetById(int id);
        IEnumerable<TaxYear> GetAll();
    }
}
