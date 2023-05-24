using Employee.DataAccess;
using Employee.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Employee.Services.implementation
{
    public class PaymentRecordServices : IPaymentRecordService
    {
        private decimal contractualEarnings;
        private decimal overtimeHours;
        private ApplicationDbContext _context;
        public PaymentRecordServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {

            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecords paymentRecord)
        {
           _context.PaymentRecord.Add(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecords> GetAll()
        {
            return _context.PaymentRecord
                 .OrderBy(p => p.Employees.FullName)
                 .AsNoTracking()
                 .ToList();
        }

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var ListTaxYear = _context.TaxYear.Select(t => new SelectListItem
            {
                Text = t.YearOfTax,
                Value = t.Id.ToString()
            });
            return ListTaxYear;
        }

        public PaymentRecords GetById(int id)
        {
            return _context.PaymentRecord.FirstOrDefault(t => t.Id == id);
        }

        public TaxYear GetTaxYearById(int id)
        {
            return _context.TaxYear.FirstOrDefault(t => t.Id == id);
        }

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        {
            return totalEarnings - totalDeduction;
        }

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours)
        {
            return overtimeHours * overtimeRate;
        }

        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked < contractualHours)
            {
                overtimeHours = 0.0m;
            }
            else
            {
                overtimeHours = hoursWorked - contractualHours;
            }
            return overtimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate)
        {
            return hourlyRate * 1.5m;
        }

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees)
        {
            return tax + nic + studentLoanRepayment + unionFees;
        }

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            return overtimeEarnings + contractualEarnings;
        }
    }
}
