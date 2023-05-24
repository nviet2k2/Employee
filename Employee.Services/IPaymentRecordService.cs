using Employee.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Employee.Services
{
    public interface IPaymentRecordService
    {
        Task CreateAsync(PaymentRecords paymentRecord);
        PaymentRecords GetById(int id);
        TaxYear GetTaxYearById(int id);
        IEnumerable<PaymentRecords> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OvertimeHours(decimal hoursWorked, decimal contractualHours);
        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);
        decimal OvertimeRate(decimal hourlyRate);
        decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours);
        decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings);
        decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees);
        decimal NetPay(decimal totalEarnings, decimal totalDeduction);
    }
}
