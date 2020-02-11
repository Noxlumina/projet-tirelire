using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TireLire.Models
{
    [MetadataType(typeof(FournisseurMetaData))]
    public partial class Fournisseur { }
    public class FournisseurMetaData
    {
        public string Description { get; set; }
        public int IdFournisseur { get; set; }
        public string Nom { get; set; }
        ICollection<Produit> Produit { get; set; }
        public int? Statut { get; set; }
    }
}