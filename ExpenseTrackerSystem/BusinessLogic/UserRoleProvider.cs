using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ExpenseTrackerSystem.BusinessLogic
{
    public class UserRoleProvider : RoleProvider
    {
        UserService userService = new UserService();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = new List<string>();
            string errorMsg = string.Empty;
            var usersList = userService.GetUsers(out errorMsg);
            if(usersList != null)
            {
                var result = usersList.FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));
                if (Convert.ToBoolean(result.isAdmin))
                    roles.Add("admin");
                else
                    roles.Add("user");
            }
            else
                roles.Add("user");

            return roles.ToArray();

        }


        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}