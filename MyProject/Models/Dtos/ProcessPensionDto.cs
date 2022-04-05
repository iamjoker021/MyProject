namespace MyProject.Models.Dtos
{
    public class ProcessPensionDto
    {
        public decimal? SalaryEarned { get; set; }
        public decimal Allowances { get; set; }
        public string? PensionType { get; set; }
        public string? BankType { get; set; }
    }
}
