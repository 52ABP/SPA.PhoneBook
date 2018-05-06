using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SPACore.PhoneBook.Authorization.Roles;
using SPACore.PhoneBook.Authorization.Users;
using SPACore.PhoneBook.MultiTenancy;
using SPACore.PhoneBook.PhoneBooks.Persons;
using SPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace SPACore.PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, PhoneBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }


        public  DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
