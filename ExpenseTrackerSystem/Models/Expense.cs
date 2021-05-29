using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerSystem.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string DatePurchased { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> IsValuable { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SubTypeId { get; set; }
    }
}