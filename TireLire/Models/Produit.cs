namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produit")]
    public partial class Produit 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            Commentaires = new HashSet<Commentaire>();
            Produit_Commandé = new HashSet<Produit_Commandé>();
        }

        [Key]
        public int IdProduit { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Produit")]
        public string Nom_Produit { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Prix unitaire")]
        public double? Prix_Unitaire { get; set; }

        public int IdCatégorie { get; set; }

        [Required]
        [Display(Name = "Stock (nb de pièces)")]
        public int Stock { get; set; }

        public int? Statut { get; set; }

        [Display(Name = "Poids en gramme")]
        public double? Poids { get; set; }

        [Display(Name = "Largeur en cm")]
        public double? Largeur { get; set; }

        [Display(Name = "Longueur en cm")]
        public double? Longueur { get; set; }

        [Display(Name = "Hauteur en cm")]
        public double? Hauteur { get; set; }

        [Display(Name = "Capacité en pièce d'un euro")]
        public int? Capacité { get; set; }

        public int? IdFournisseur { get; set; }

        public string Description { get; set; }

        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }

        public virtual Catégorie Catégorie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit_Commandé> Produit_Commandé { get; set; }
    }
}
