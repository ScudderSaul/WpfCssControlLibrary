using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace WpfCssControlLibrary.Model
{
    public partial class CssModel : DbContext
    {
        public CssModel() : base() 
        {
           
            
        }

        public virtual DbSet<CssAnimation> CssAnimations { get; set; }
        public virtual DbSet<CssColor> CssColors { get; set; }
        public virtual DbSet<CssColorType> CssColorTypes { get; set; }
        public virtual DbSet<CssStyle> CssStyles { get; set; }
        public virtual DbSet<CssStyleItem> CssStyleItems { get; set; }
        public virtual DbSet<CssTransition> CssTransitions { get; set; }

       

        


       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<CssColor>()
            //    .HasOne(e => e.CssColorType)
            //    .WithMany(e => e.CssColors)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<CssTransition>()
            //    .HasOne(e => e.CssStyle)
            //    .WithMany(e => e.CssTransitions)
            //    .HasForeignKey(e => e.StyleId);

            //modelBuilder.Entity<CssStyleItem>()
            //    .HasOne(e => e.CssStyle)
            //    .WithMany(e => e.CssStyleItems)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CssColorType>()
                .HasMany(e => e.CssColors)
                .WithOne(u => u.CssColorType);

            modelBuilder.Entity<CssStyle>()
                .HasMany(e => e.CssTransitions)
                .WithOne(k => k.CssStyle);

            modelBuilder.Entity<CssStyle>()
               .HasMany(e => e.CssStyleItems)
               .WithOne(j => j.CssStyle);

            modelBuilder.Entity<CssStyleItem>()
                .HasMany(e => e.CssColorTypes)
                .WithOne(w => w.CssStyleItem);

            modelBuilder.Entity<CssAnimation>()
               .HasMany(e => e.CssStyleItems)
               .WithOne(w => w.CssAnimation);


            //string connect = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\CssModel.sqlite";
            //Database.Connection.ConnectionString = connect;

            //var sqliteConnectionInitializer = new CssModelDbInitializer(modelBuilder);
            //Database.SetInitializer(sqliteConnectionInitializer);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\CssControl") == false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\CssControl");
            }
            string apath = "Filename=" + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\CssControl\\dbCssControl.db";
            optionsBuilder.UseSqlite(apath);
        }
    }

   

   

}
