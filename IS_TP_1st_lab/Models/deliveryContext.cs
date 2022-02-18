using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IS_TP_1th_lab
{
    public partial class deliveryContext : DbContext
    {
        public deliveryContext()
        {
        }

        public deliveryContext(DbContextOptions<deliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addre> Addres { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Deliver> Delivers { get; set; } = null!;
        public virtual DbSet<DishList> DishLists { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= LAPTOP-POJHK8SM;Database=delivery; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addre>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Bulding)
                    .HasMaxLength(10)
                    .HasColumnName("bulding");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Flat).HasColumnName("flat");

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .HasColumnName("street");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Addres)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Client");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .HasColumnName("mail");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(8)
                    .HasColumnName("password")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CommentText).HasColumnName("comment_text");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("date")
                    .HasColumnName("posting_date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Client");
            });

            modelBuilder.Entity<Deliver>(entity =>
            {
                entity.ToTable("Deliver");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Transport)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<DishList>(entity =>
            {
                entity.ToTable("DishList");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FullPrice)
                    .HasColumnType("money")
                    .HasColumnName("full_price");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.DishLists)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DishList_Menu");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DishPrice)
                    .HasColumnType("money")
                    .HasColumnName("dish_price");

                entity.Property(e => e.DishTitle)
                    .HasMaxLength(100)
                    .HasColumnName("dish_title");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.Waight).HasColumnName("waight");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_Restaurant");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.DeliverId).HasColumnName("deliver_id");

                entity.Property(e => e.DishListId).HasColumnName("dish_list_id");

                entity.Property(e => e.StartLocation)
                    .HasMaxLength(50)
                    .HasColumnName("start_location");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Address");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Client");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_Orders_Comment");

                entity.HasOne(d => d.Deliver)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Deliver");

                entity.HasOne(d => d.DishList)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DishListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Dish_list");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.RestAdress)
                    .HasMaxLength(100)
                    .HasColumnName("rest_adress");

                entity.Property(e => e.RestTitle)
                    .HasMaxLength(100)
                    .HasColumnName("rest_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
