using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace CC_Regist_System.Models
{
    public class ApplyCardViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string MaritalStatus { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public decimal MonthlyIncome { get; set; }

        [Required]
        public string BankAccountNumber { get; set; }

        public string ?PassportOrBankAccountPath { get; set; }
        public string ?IncomeCertificatePath { get; set; }
        public string ?PhotoPath { get; set; }
        public string ?MalaysianCitizenshipIdCardPath { get; set; }

        [NotMapped]
        public IFormFile PassportOrBankAccount { get; set; }

        [NotMapped]
        public IFormFile IncomeCertificate { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        [NotMapped]
        public IFormFile MalaysianCitizenshipIdCard { get; set; }
    }
}