namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Commandes = new HashSet<Commande>();
            Commentaires = new HashSet<Commentaire>();
        }

        [Key]
        public int IdClient { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string Prénom { get; set; }

        [StringLength(10)]
        public string Téléphone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public int Statut { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        [Required]
        [StringLength(50)]
        public string Ville { get; set; }

        [Required]
        [StringLength(50)]
        public string Pays { get; set; }

        [Display(Name = "UserPhoto")]
        [StringLength(255)]
        public string UserPhoto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commentaire> Commentaires { get; set; }
    }
}
