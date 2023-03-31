using Blog123.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.EntityMapping
{
    public class AppRoleMapping:BaseEntityMapping<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasDefaultValue("Admin");
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModifiedDate).HasDefaultValue(DateTime.Now);
            //builder.Property(x=> x.Name).IsConcurrencyToken();

            builder.Property(x => x.Status).HasDefaultValue(Domain.Enums.Status.Active);
           
            base.Configure(builder);
        }
    }
}
