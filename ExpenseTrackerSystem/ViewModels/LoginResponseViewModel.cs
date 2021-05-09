using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerSystem.ViewModels
{
    public class LoginResponseViewModel
    {
        public string Token;
        public UserDetail UserDetails { get; set; }
    }
    public class UserDetail
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<bool> isAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool isActive { get; set; }
    }
}