using Employee.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
	public class PaymentRecordController : Controller
	{
		private readonly IPaymentRecordService _paymentRecordService;
        public PaymentRecordController(IPaymentRecordService paymentRecordService)
        {
			_paymentRecordService = paymentRecordService;
        }
        public IActionResult Index()
		{
			return View();
		}
	}
}
