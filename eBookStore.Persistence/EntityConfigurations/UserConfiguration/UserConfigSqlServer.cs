using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.UserConfiguration
{
    public class UserConfigSqlServer : IEntityTypeConfiguration<BookStoreUser>
    {
        public void Configure(EntityTypeBuilder<BookStoreUser> builder)
        {
            #region Configurations
            builder.ToTable("User", DbObject.SchemaNameUsers).HasKey(k => k.Id);

            builder.
                Property(x => x.Id).
                HasColumnName("Id").
                HasColumnType("int").
                HasMaxLength(35).IsRequired();
            #endregion

        }
    }
}
