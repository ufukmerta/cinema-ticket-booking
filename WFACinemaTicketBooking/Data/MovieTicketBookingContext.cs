using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WFACinemaTicketBooking.Models;

namespace WFACinemaTicketBooking.Data;

public partial class MovieTicketBookingContext : DbContext
{
    public MovieTicketBookingContext()
    {
    }

    public MovieTicketBookingContext(DbContextOptions<MovieTicketBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieSession> MovieSessions { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Star> Stars { get; set; }

    public virtual DbSet<TicketBooking> TicketBookings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=MovieTicketBooking;Trusted_Connection=True;").LogTo(message => Debug.WriteLine(message));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK_movie_genre");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasMany(d => d.Directors).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieDirector",
                    r => r.HasOne<Director>().WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_MovieDirector_tbl_Director"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_MovieDirector_tbl_Movie"),
                    j =>
                    {
                        j.HasKey("MovieId", "DirectorId");
                        j.ToTable("movie_director");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movieID");
                        j.IndexerProperty<int>("DirectorId").HasColumnName("directorID");
                    });

            entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_MovieGenre_tbl_Genre"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_MovieGenre_tbl_Movie"),
                    j =>
                    {
                        j.HasKey("MovieId", "GenreId").HasName("PK_movie_genre_1");
                        j.ToTable("movie_genre");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movieID");
                        j.IndexerProperty<int>("GenreId").HasColumnName("genreID");
                    });

            entity.HasMany(d => d.Stars).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieStar",
                    r => r.HasOne<Star>().WithMany()
                        .HasForeignKey("StarId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_MovieStar_tbl_Star"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_MovieStar_tbl_Movie"),
                    j =>
                    {
                        j.HasKey("MovieId", "StarId");
                        j.ToTable("movie_star");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movieID");
                        j.IndexerProperty<int>("StarId").HasColumnName("starID");
                    });
        });

        modelBuilder.Entity<MovieSession>(entity =>
        {
            entity.HasOne(d => d.Hall).WithMany(p => p.MovieSessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_MovieSession_tbl_Hall");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieSessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_MovieSession_tbl_Movie");

            entity.HasOne(d => d.Session).WithMany(p => p.MovieSessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_MovieSession_tbl_Session");
        });

        modelBuilder.Entity<TicketBooking>(entity =>
        {
            entity.Property(e => e.TicketDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MovieSession).WithMany(p => p.TicketBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_TicketBooking_tbl_MovieSession");

            entity.HasOne(d => d.User).WithMany(p => p.TicketBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_BiletSatis_tbl_BiletSatis");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Auth)
                .HasDefaultValue("u")
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
