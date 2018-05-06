using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SPACore.PhoneBook.EntityFrameworkCore
{
    public static class PhoneBookDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PhoneBookDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PhoneBookDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
