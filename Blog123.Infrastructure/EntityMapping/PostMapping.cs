using Blog123.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.EntityMapping
{
    public class PostMapping:BaseEntityMapping<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(10000);
            builder.Property(x => x.Summary).IsRequired().HasMaxLength(250);
            base.Configure(builder);
        }
    }
}
