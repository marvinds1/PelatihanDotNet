﻿using Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseContext;

public class ApplicationDBContext : IdentityDbContext<User>
{

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    // Customize the ASP.NET Identity model and override the defaults if needed.
    //    // For example, you can rename the ASP.NET Identity table names and more.
    //    // Add your customizations after calling base.OnModelCreating(builder);
    //}
}
