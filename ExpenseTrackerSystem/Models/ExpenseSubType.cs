using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerSystem.Models
{
    public class ExpenseSubType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int ExpenseTypeID { get; set; }
    }
}