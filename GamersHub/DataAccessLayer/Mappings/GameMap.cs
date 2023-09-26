using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Mappings
{
    internal class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(game => game.GameName).HasColumnName("Name");
            builder.Property(game => game.GameName).HasColumnType("nvarchar(100)");
            builder.Property(game => game.GameName).IsRequired();
           

        }
    }
}
