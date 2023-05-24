using System.ComponentModel.DataAnnotations;
namespace Employee.Models
{
    public class TaxYearDetailViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string YearOfTax { get; set; }
    }
}
