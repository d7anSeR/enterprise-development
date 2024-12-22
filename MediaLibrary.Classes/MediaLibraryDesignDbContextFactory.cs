using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApi;

namespace MediaLibrary.Classes;
public class MediaLibraryDesignDbContextFactory : IDesignTimeDbContextFactory<MediaLibraryDbContext>
{
    public MediaLibraryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MediaLibraryDbContext>();
        var connectionString = "Server=localhost;Port=3306;UserID=root;Password=1111;Database=MediaLibrary;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new MediaLibraryDbContext(optionsBuilder.Options);
    }
}
