using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TireLire.Models
{
    [MetadataType(typeof(CatégorieMetaData))]
    public partial class Catégorie { }
    public class CatégorieMetaData
    {
        public string Nom_Catégorie { get; set; }
        public int IdCatégorie { get; set; }
        public ICollection<Produit> Produits { get; set; }
        public int? Statut { get; set; }
        public string ImageCat { get; set; }

    }
}