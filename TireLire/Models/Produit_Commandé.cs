namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Produit_Commandé 
    {
        [Key]
        public int IdProduit_Commandé { get; set; }

        public int IdCommande { get; set; }

        public int? IdProduit { get; set; }

        public int Nb_Produit_Commandé { get; set; }

        [DataType(DataType.Currency)]
        public double Prix_Produit_Commandé { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
