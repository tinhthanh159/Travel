using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Travel.Models;

public partial class TravelTourContext : DbContext
{
    public TravelTourContext()
    {
    }

    public TravelTourContext(DbContextOptions<TravelTourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbAdminUser> TbAdminUsers { get; set; }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }

    public virtual DbSet<TbBooking> TbBookings { get; set; }

    public virtual DbSet<TbBookingDetail> TbBookingDetails { get; set; }

    public virtual DbSet<TbBookingStatus> TbBookingStatuses { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

    public virtual DbSet<TbDestination> TbDestinations { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbNews> TbNews { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbTour> TbTours { get; set; }

    public virtual DbSet<TbTourComment> TbTourComments { get; set; }

    public virtual DbSet<TbTourDetail> TbTourDetails { get; set; }

    public virtual DbSet<TbTourGuide> TbTourGuides { get; set; }

    public virtual DbSet<TbTourType> TbTourTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("tb_Account");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LastLogin)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.TbAccounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tb_Account_tb_Role");
        });

        modelBuilder.Entity<TbAdminUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tb_AdminUser");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("tb_Blog");

            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SeoDescription).HasMaxLength(500);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.Topic).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tb_Blog_tb_Account");
        });

        modelBuilder.Entity<TbBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_BlogComment");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Blog).WithMany(p => p.TbBlogComments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_tb_BlogComment_tb_Blog");
        });

        modelBuilder.Entity<TbBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId);

            entity.ToTable("tb_Booking");

            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.CreateBy).HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<TbBookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK_tb_BookingDetail_1");

            entity.ToTable("tb_BookingDetail");

            entity.Property(e => e.BookingDetailId).HasColumnName("BookingDetailID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.TourId).HasColumnName("TourID");

            entity.HasOne(d => d.Booking).WithMany(p => p.TbBookingDetails)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_BookingDetail_tb_Booking");
        });

        modelBuilder.Entity<TbBookingStatus>(entity =>
        {
            entity.HasKey(e => e.BookingStatusId);

            entity.ToTable("tb_BookingStatus");

            entity.Property(e => e.BookingStatusId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.BookingStatus).WithOne(p => p.TbBookingStatus)
                .HasForeignKey<TbBookingStatus>(d => d.BookingStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_BookingStatus_tb_Booking");
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("tb_Contact");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbDestination>(entity =>
        {
            entity.HasKey(e => e.DestinationId).HasName("PK__tb_Descr__A58A9FEBC48FC183");

            entity.ToTable("tb_Destination");

            entity.Property(e => e.DestinationId).HasColumnName("DestinationID");
            entity.Property(e => e.Country).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Destination).HasMaxLength(150);
            entity.Property(e => e.Image).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NumberTour).HasMaxLength(50);
            entity.Property(e => e.TourId).HasColumnName("TourID");

            entity.HasOne(d => d.Tour).WithMany(p => p.TbDestinations)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_Descri__TourI__30C33EC3");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tb_Menu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<TbNews>(entity =>
        {
            entity.HasKey(e => e.NewsId);

            entity.ToTable("tb_News");

            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SeoDescription).HasMaxLength(500);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Type).WithMany(p => p.TbNews)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_tb_News_tb_TourType");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tb_Role");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTour>(entity =>
        {
            entity.HasKey(e => e.TourId);

            entity.ToTable("tb_Tour");

            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Destination).HasMaxLength(500);
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.PriceSale).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.TourDuration).HasMaxLength(100);

            entity.HasOne(d => d.Type).WithMany(p => p.TbTours)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_Tour_tb_TourType");
        });

        modelBuilder.Entity<TbTourComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_TourComment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Tour).WithMany(p => p.TbTourComments)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_TourComment_tb_Tour1");
        });

        modelBuilder.Entity<TbTourDetail>(entity =>
        {
            entity.HasKey(e => e.TourDetailId).HasName("PK_tb_BookingDetail");

            entity.ToTable("tb_TourDetail");

            entity.Property(e => e.TourDetailId).HasColumnName("TourDetailID");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.HotelLevel).HasMaxLength(100);
            entity.Property(e => e.Request).HasMaxLength(1000);

            entity.HasOne(d => d.Tour).WithMany(p => p.TbTourDetails)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_BookingDetail_tb_Tour");
        });

        modelBuilder.Entity<TbTourGuide>(entity =>
        {
            entity.HasKey(e => e.GuideId).HasName("PK__tb_TourG__E77EE05EE83903E2");

            entity.ToTable("tb_TourGuide");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(300);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageSkills).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<TbTourType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("tb_TourType");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
