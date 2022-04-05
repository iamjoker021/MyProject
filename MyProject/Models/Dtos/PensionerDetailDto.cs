using System.ComponentModel.DataAnnotations;

namespace MyProject.Models.Dtos
{
    public class PensionerDetailDto
    {
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PAN { get; set; }
        public decimal? SalaryEarned { get; set; }
        public decimal Allowances { get; set; }
        public string? PensionType { get; set; }
        public string? BankName { get; set; }
        public long AccountNumber { get; set; }
        public string? BankType { get; set; }
    }
}
