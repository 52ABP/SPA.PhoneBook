using Abp.Authorization;
using SPACore.PhoneBook.Authorization.Roles;
using SPACore.PhoneBook.Authorization.Users;

namespace SPACore.PhoneBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
