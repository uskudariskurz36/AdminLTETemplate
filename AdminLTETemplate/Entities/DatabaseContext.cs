using MFramework.Services.FakeData;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AdminLTETemplate.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            if (Database.CanConnect())
            {
                if (Albums.Any() == false)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        Album album = new Album
                        {
                            Name = NameData.GetCompanyName(),
                            Description = TextData.GetSentence()
                        };

                        Albums.Add(album);
                    }

                    SaveChanges();
                }
            }
        }

        public DbSet<Album> Albums { get; set; }
    }

    public class Album
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
