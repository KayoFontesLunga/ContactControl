using ContactControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactControl.Data.Map;

public class ContactMap : IEntityTypeConfiguration<ContactModel>
{
    public void Configure(EntityTypeBuilder<ContactModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasKey(x => x.User);
    }
}
