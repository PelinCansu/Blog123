using Blog123.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.EntityMapping
{
    public class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedBy).IsRequired(false);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.ModifiedBy).IsRequired(false);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}
