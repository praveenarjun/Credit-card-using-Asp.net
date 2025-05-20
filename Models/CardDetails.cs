using System;

namespace CC_Regist_System.Models
{
    public class CardDetails
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string FullName { get; set; }
    }
}