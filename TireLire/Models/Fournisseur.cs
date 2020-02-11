namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fournisseur")]
    public partial class Fournisseur 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fournisseur()
        {
            Produit = new HashSet<Produit>();
        }

        [Key]
        public int IdFournisseur { get; set; }

        [StringLength(50)]
        [Display(Name = "Fournisseur")]
        public string Nom { get; set; }

        [Display(Name = "Description du fournisseur")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produit { get; set; }

        public int? Statut { get; set; }
    }
}
