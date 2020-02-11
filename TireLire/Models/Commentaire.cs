namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Commentaire")]
    public partial class Commentaire 
    {
        [Key]
        public int IdCommentaire { get; set; }

        [Column("Commentaire")]
        [Required]
        [Display(Name = "Commentaire")]
        public string Commentaire1 { get; set; }

        public int IdClient { get; set; }

        public int IdProduit { get; set; }

        [Required]
        public int Etat { get; set; }

        public DateTime Date_Avis { get; set; }

        public double Note { get; set; }

        public virtual Client Client { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
