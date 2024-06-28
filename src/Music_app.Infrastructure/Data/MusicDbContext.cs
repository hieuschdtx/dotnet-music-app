using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Music_app.Domain.Commons;
using Music_app.Domain.Entities;
using Music_app.Infrastructure.Data.EntityConfigurations;

namespace Music_app.Infrastructure.Data
{
    public class MusicDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options)
        {
        }

        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration

            modelBuilder.ApplyConfiguration(new AdministratorsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumsArtistsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistsSongsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenresEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistsArtistsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistsSongsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistsThemesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RolesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SongsGenresEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SongsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ThemesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserFollowSongsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsersFollowAlbumsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsersFollowArtistsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsersFollowPlaylistsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsersEntityTypeConfiguration());

            #endregion
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return null!;
            }

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(transaction);
            if (transaction != _currentTransaction)
            {
                throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
            }

            try
            {
                await SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }

        public IDbContextTransaction GetCurrentTransaction()
        {
            return _currentTransaction;
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }

        #region Generate Dbset

        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<AlbumsArtists> AlbumsArtists { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<ArtistsSongs> ArtistsSongs { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Playlists> Playlists { get; set; }
        public virtual DbSet<PlaylistsArtists> PlaylistsArtists { get; set; }
        public virtual DbSet<PlaylistsSongs> PlaylistsSongs { get; set; }
        public virtual DbSet<PlaylistsThemes> PlaylistsThemes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Songs> Songs { get; set; }
        public virtual DbSet<SongsGenres> SongsGenres { get; set; }
        public virtual DbSet<Themes> Themes { get; set; }
        public virtual DbSet<UserFollowSongs> UserFollowSongs { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersFollowAlbums> UsersFollowAlbums { get; set; }
        public virtual DbSet<UsersFollowArtists> UsersFollowArtists { get; set; }
        public virtual DbSet<UsersFollowPlaylists> UsersFollowPlaylists { get; set; }

        #endregion
    }
}