using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankAccounts.Models {
 public abstract class BaseEntity {}
	public class User : BaseEntity{
            [Key]
		public int userId {get; set;}   
		public string firstName {get; set;}	
        public string lastName {get; set;}
        public string email {get; set;}
        public float balance {get;set;}
        public string password {get; set;}
        public DateTime createdAt {get; set;}
        public DateTime updatedAt {get; set;}
        public List<Transaction> Transactions { get; set ; }
        public User(){
            Transactions = new List<Transaction>();
        }
	}
}