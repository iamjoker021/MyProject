namespace MyProject.Models
{
    public class ProcessPension
    {
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PAN { get; set; }
        public decimal SalaryEarned { get; set; }
        public decimal Allowances { get; set; }
        public string? PensionType { get; set; }
        public string? BankName { get; set; }
        public long AccountNumber { get; set; }
        public string? BankType { get; set; }

        public double GetPensionAmount()
        {
            double rate = (PensionType.ToLower() == "self" ? 0.8 : 0.5);
            double pensionAmt = (rate * (double)SalaryEarned) + (double)Allowances;
            return pensionAmt;
        }

        public int GetBankServiceCharge()
        {
            var charge = BankType.ToLower() == "public" ? 500 : 550;
            return charge;
        }

    }
}
