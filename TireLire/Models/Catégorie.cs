namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Catégorie 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catégorie()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        public int IdCatégorie { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Catégorie")]
        public string Nom_Catégorie { get; set; }


        [Display(Name = "Descriptif")]
        public string Description { get; set; }

        public int? Statut { get; set; }

        [Display(Name = "Photo")]
        public string ImageCat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
