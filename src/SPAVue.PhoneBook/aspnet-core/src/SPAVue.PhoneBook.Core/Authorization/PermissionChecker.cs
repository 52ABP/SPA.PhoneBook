using Abp.Authorization;
using SPAVue.PhoneBook.Authorization.Roles;
using SPAVue.PhoneBook.Authorization.Users;

namespace SPAVue.PhoneBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
