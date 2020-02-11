using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TireLire.DataAcces;
using TireLire.Models;

namespace TireLire.Outils
{
    public class customRoleResolver : RoleProvider
    {

        //Instanciation du repository de roles
        Repository<Role> rep = new EFRepository<Role>();

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

            return rep.Lister().Select(r => r.RoleAttribue).ToArray();

        }

        public override string[] GetRolesForUser(string username)
        {

            var listeRoles = rep.Lister().Where(u => u.mail == username);

            return listeRoles == null ? new string[] { } : listeRoles.Select(r => r.RoleAttribue).ToArray<string>();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return rep.Lister().Where(r => r.mail == username && r.RoleAttribue == roleName).Count() > 0;
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