using Blog123.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.EntityMapping
{
    public class AuthorMapping:BaseEntityMapping<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(20).IsRequired();
            base.Configure(builder);
        }
    }
}
