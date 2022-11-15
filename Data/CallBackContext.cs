using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VersionTwo.Models;

namespace VersionTwo.Data
{
    public class CallBackContext : DbContext
    {
        public CallBackContext()
        {

        }
        public CallBackContext(DbContextOptions<CallBackContext> options)
            :base(options)
        {

        }
        public virtual DbSet<CallBack> CallBacks { get; set; } = null!;
        public virtual DbSet<Vlog> Vlogs { get; set; } = null!;
        
    }
}