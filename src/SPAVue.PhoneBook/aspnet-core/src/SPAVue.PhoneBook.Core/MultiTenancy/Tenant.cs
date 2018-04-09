using Abp.MultiTenancy;
using SPAVue.PhoneBook.Authorization.Users;

namespace SPAVue.PhoneBook.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
