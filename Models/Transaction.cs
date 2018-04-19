using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankAccounts.Models {

	public class Transaction {
        [Key]
		public int transactionId {get; set;}   //these variable names must match the table column names exactly
        [Display(Name="Deposit/Withdraw:")]
        public float amount {get; set;}
        public DateTime createdAt {get; set;}
        public DateTime updatedAt {get; set;}
       
        [ForeignKey("user")]
        public int userId {get; set;}
        
        public User user {get;set;}
	}
}