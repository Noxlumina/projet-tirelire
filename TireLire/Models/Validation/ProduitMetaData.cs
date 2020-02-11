using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TireLire.Models
{
    [MetadataType(typeof(ProduitMetaData))]
    public partial class Produit { }
    public class ProduitMetaData
    {
        public int? Capacité { get; set; }
        Catégorie Catégorie { get; set; }
        ICollection<Commentaire> Commentaires { get; set; }
        public string Description { get; set; }
        Fournisseur Fournisseur { get; set; }
        public int? IdCatégorie { get; set; }
        public int? IdFournisseur { get; set; }
        public int IdProduit { get; set; }
        public string Nom_Produit { get; set; }
        public decimal? Poids { get; set; }
        [DataType(DataType.Currency)]
        public double Prix_Unitaire { get; set; }
        ICollection<Produit_Commandé> Produit_Commandé { get; set; }
        public int? Statut { get; set; }
        public int Stock { get; set; }
        public double? Longueur { get; set; }
        public double? Largeur { get; set; }
        public double? Hauteur { get; set; }
        public string ImageUrl { get; set; }

    }
}