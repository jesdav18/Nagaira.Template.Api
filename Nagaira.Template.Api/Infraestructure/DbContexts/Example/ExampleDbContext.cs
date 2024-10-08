﻿using Microsoft.EntityFrameworkCore;
using Nagaira.Template.Api.Features.Categories.Infraestructure.Maps;

namespace Nagaira.Template.Api.Infraestructure.DbContexts.Example
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
