using curso.api.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace curso.api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            CursoDbContext contexto = new CursoDbContext(optionsBuilder.Options);
            return contexto;
        }
    }
}
