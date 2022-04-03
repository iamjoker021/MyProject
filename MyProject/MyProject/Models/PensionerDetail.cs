using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    // public enum PensionType { Self, Family }
    // public enum BankType { Public, Private}
    public class PensionerDetail
    {
        [Key]
        public int AdhaarNumber { get; set; }
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
