namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Commande")]
    public partial class Commande 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            Produit_Commandé = new HashSet<Produit_Commandé>();
        }

        [Key]
        public int IdCommande { get; set; }

        public int? IdClient { get; set; }

        [DataType(DataType.Currency)]
        public double Total { get; set; }

        
        public DateTime Date_Commande { get; set; }

        [Required]
        public int Statut { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit_Commandé> Produit_Commandé { get; set; }
    }
}
