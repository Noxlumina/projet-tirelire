namespace TireLire.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDMTirelire : DbContext
    {
        public EDMTirelire()
            : base("name=EDMTirelire")
        {
        }

        public virtual DbSet<Catégorie> Catégorie { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Commentaire> Commentaires { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Produit_Commandé> Produit_Commandé { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catégorie>()
                .HasMany(e => e.Produits)
                .WithRequired(e => e.Catégorie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commentaires)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.Total);

            modelBuilder.Entity<Commande>()
                .HasMany(e => e.Produit_Commandé)
                .WithRequired(e => e.Commande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fournisseur>()
                .HasMany(e => e.Produit)
                .WithRequired(e => e.Fournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Prix_Unitaire)
                ;

            modelBuilder.Entity<Produit>()
                .Property(e => e.Poids)
                ;

            modelBuilder.Entity<Produit>()
                .Property(e => e.Largeur)
                ;

            modelBuilder.Entity<Produit>()
              .Property(e => e.Longueur)
              ;

            modelBuilder.Entity<Produit>()
              .Property(e => e.Hauteur)
              ;

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Commentaires)
                .WithRequired(e => e.Produit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Produit_Commandé)
                .WithRequired(e => e.Produit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
               .Property(e => e.RoleAttribue)
               .IsFixedLength();
        }
    }
}
