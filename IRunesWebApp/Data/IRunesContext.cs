using System;
using System.Collections.Generic;
using System.Text;
using IRunesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace IRunesWebApp.Data
{
    public class IRunesContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums{ get; set; }

        public DbSet<TrackAlbum> TracksAlbums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-R4OGD90\SQLEXPRESS;
                                Database=IRunesApp;
                                Integrated Security=true").UseLazyLoadingProxies();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackAlbum>()
                .HasKey(ta => new { ta.AlbumId, ta.TrackId });
        }
    }
}
