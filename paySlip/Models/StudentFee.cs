using System.ComponentModel.DataAnnotations;

namespace paySlip.Models
{
    public class StudentFee
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TotalFee { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
    }

}
