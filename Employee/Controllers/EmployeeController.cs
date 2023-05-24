using Employee.Entity;
using Employee.Models;
using Employee.Services;
using Employee.Services.implementation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;
using System.Reflection;


namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.ID,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                ImageUrl = employee.ImageUrl,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                City = employee.City
            }).ToList();
            //return Json(new { data = model });
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employees
                {
                    ID = model.ID,
                    FirstName = model.FirstName,
                    EmployeeNo = model.EmployeeNo,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    DOB = model.DOB,
                    DateJoined = model.DOB,
                    Designation = model.Designation,
                    Phone = model.Phone,
                    Email = model.Email,
                    NationalInsuranceNo = model.NationalInsuranceNo,
                    Address = model.Address,
                    City = model.City,
                    Postcode = model.Postcode,
                    PaymentMethod = model.PaymentMethod,
                    UnionMember = model.UnionMember,
                    StudentLoan = model.StudentLoan
                };

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employees";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.CreateAsSync(employee);
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDetailViewModel
            {

                Id = employee.ID,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                ImageUrl = employee.ImageUrl,
                DOB = employee.DOB,
                DateJoined = employee.DOB,
                Designation = employee.Designation,
                Phone = employee.Phone,
                Email = employee.Email,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                Postcode = employee.Postcode,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteViewModel
            {
                ID = employee.ID,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            var employee = _employeeService.GetById(model.ID);
            if (employee == null)
            {
                return NotFound();
            }
           await _employeeService.DeleteById(model.ID);

            return RedirectToAction("Index");
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel
            {
                ID = employee.ID,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                Phone = employee.Phone,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                DOB = employee.DOB,
                Designation = employee.Designation,
                City = employee.City,
                Address = employee.Address,
                Postcode = employee.Postcode

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.ID);

                employee.ID = model.ID;
                employee.FirstName = model.FirstName;
                employee.EmployeeNo = model.EmployeeNo;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;
                employee.FullName = model.FullName;
                employee.Gender = model.Gender;
                employee.DOB = model.DOB;
                employee.DateJoined = model.DOB;
                employee.Designation = model.Designation;
                employee.Phone = model.Phone;
                employee.Email = model.Email;
                employee.NationalInsuranceNo = model.NationalInsuranceNo;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.Postcode = model.Postcode;
                employee.PaymentMethod = model.PaymentMethod;
                employee.UnionMember = model.UnionMember;
                employee.StudentLoan = model.StudentLoan;

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employees";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                };
                await _employeeService.UpdateAsSync(employee);
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}