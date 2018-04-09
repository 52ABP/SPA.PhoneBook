using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SPAVue.PhoneBook.Authorization.Roles;
using SPAVue.PhoneBook.Authorization.Users;
using SPAVue.PhoneBook.MultiTenancy;

namespace SPAVue.PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, PhoneBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }
    }
}
