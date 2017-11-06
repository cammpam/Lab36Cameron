using Lab36Cameron.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab36Cameron.Data
{
    public class SongEntryDbContext : DbContext
    {
        public SongEntryDbContext(DbContextOptions<SongEntryDbContext> options) : base(options)
        {

        }

        public DbSet<SongItem> SongItem { get; set; }
        public DbSet<Contributors> Contributors { get; set; }
    }
}
