using Blog123.Domain.Entities.Abstract;
using Blog123.Domain.Entities.Concrete;
using Blog123.Infrastructure.EntityMapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.DataAccess
{
    public class Blog123DbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public Blog123DbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<CategoryPost> CategoryPost { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var entities = ChangeTracker.Entries<IBaseEntity>();
            
            
            foreach (var item in entities)
            {
                

                if (item.State == EntityState.Added)
                {
                    //if (item.GetType() == typeof(Category))
                    //{
                    //    item.State = EntityState.Modified;
                    //}
                    item.Entity.CreatedDate = DateTime.Now;
                    item.Entity.ModifiedDate = DateTime.Now;
                    item.Entity.CreatedBy = "Admin";
                    item.Entity.ModifiedBy = "Admin";
                    item.Entity.Status = Domain.Enums.Status.Active;
                }
                else if (item.State == EntityState.Modified || item.State == EntityState.Deleted)
                {
                    item.Entity.CreatedDate = DateTime.Now;
                    item.Entity.CreatedBy = "Admin";
                    item.Entity.Status = Domain.Enums.Status.Active;
                    item.Entity.ModifiedDate = DateTime.Now;
                    item.Entity.ModifiedBy = "Admin";
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Like>().HasKey(x => new { x.PostID, x.UserID });
            builder.Entity<Like>().HasOne(x => x.User).WithMany(x => x.Likes).HasForeignKey(x=>x.UserID).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Like>().HasOne(x => x.Post).WithMany(x => x.Likes).HasForeignKey(x=>x.PostID).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Post>().HasKey(x => x.Id);
            builder.Entity<Post>().HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorID).OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<CategoryPost>().HasKey(x => new { x.PostId, x.CategoryId });
            builder.Entity<CategoryPost>().HasOne(x => x.Post).WithMany(x => x.Categories).HasForeignKey(x => x.PostId);
            builder.Entity<CategoryPost>().HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId);

            builder.ApplyConfiguration(new AppUserMapping());
            builder.ApplyConfiguration(new CategoryMapping());
            builder.ApplyConfiguration(new AuthorMapping());
            builder.ApplyConfiguration(new PostMapping());
            builder.ApplyConfiguration(new AppRoleMapping());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }


    }
}
