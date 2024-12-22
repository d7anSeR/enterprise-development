using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi;

namespace MediaLibrary.Classes;

public interface IMediaLibraryDbContextFactory
{
    MediaLibraryDbContext CreateDbContext();
}

public class MediaLibraryDbContextFactory(IConfiguration configuration): IMediaLibraryDbContextFactory
{
    public MediaLibraryDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MediaLibraryDbContext>();
        var connectionString = configuration.GetConnectionString("MySql");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new MediaLibraryDbContext(optionsBuilder.Options);
    }
}