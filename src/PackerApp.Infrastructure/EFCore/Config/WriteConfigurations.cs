using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackerApp.Domain.Entities;
using PackerApp.Domain.ValueObjects;

namespace PackerApp.Infrastructure.EFCore.Config;

  internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
    {
        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            builder.HasKey(pl => pl.Id);

            var localizationConvertion = new ValueConverter<Localization, string>(l => l.ToString(),
                l => Localization.Create(l));

            var packingListNameConvertion = new ValueConverter<PackingListName, string>(pln => pln.Value,
                pln => new PackingListName(pln));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new PackingListId(id));

            builder
                .Property(typeof(Localization), "_localization")
                .HasConversion(localizationConvertion)
                .HasColumnName("Localization");

            builder
                .Property(typeof(PackingListName), "_name")
                .HasConversion(packingListNameConvertion)
                .HasColumnName("Name");

            builder.HasMany(typeof(PackingItem), "_items");

            builder.ToTable("PackingLists");
        }

        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(pi => pi.Name);
            builder.Property(pi => pi.Quantity);
            builder.Property(pi => pi.IsPacked);
            builder.ToTable("PackingItems");
        }
    }