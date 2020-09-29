using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lavanderia.Infra.Contexts
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private const string connection =
            "Server=localhost;DataBase=lavanderia;Uid=root;Pwd=123456789";

        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connection);
            return new DataContext(optionsBuilder.Options);
        }
    }
}