using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ıdentitySample.Context
{
    public class AppDbContext:IdentityDbContext<AppUser, AppRole,string>
    {

        public DbSet<UserFavBlog> UserFavBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }


      
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AppUser>().HasMany(x => x.UserFavBlogs).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            
            builder.Entity<Blog>().HasMany(x => x.UserFavBlogs).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);

            builder.Entity<UserFavBlog>().HasKey(x => new { x.AppUserId, x.BlogId });



            base.OnModelCreating(builder);
        }
    }


    public class AppUser:IdentityUser
    {
        public string? ImagePath { get; set; }
        public List<UserFavBlog> UserFavBlogs { get; set; } = new();
    }
    public class AppRole: IdentityRole
    {

    }
    public class Blog
    {
        public int Id { get; set; }
        public string Header { get; set; }    
        public string Content { get; set; }

        public string ImagePath { get; set; }

        public List<UserFavBlog> UserFavBlogs { get; set; } = new();
     }
    public class UserFavBlog
    {
        public string AppUserId { get; set; }
        public int BlogId { get; set; }

        public AppUser AppUser { get; set; }
        public Blog Blog { get; set; }


    }
}
