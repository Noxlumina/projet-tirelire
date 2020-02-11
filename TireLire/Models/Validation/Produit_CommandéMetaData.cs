using System.ComponentModel.DataAnnotations;

namespace TireLire.Models
{
    [MetadataType(typeof(Produit_CommandéMetaData))]
    public partial class Produit_Commandé { }
    public class Produit_CommandéMetaData
    {
        Commande Commande { get; set; }
        public int IdCommande { get; set; }
        public int? IdProduit { get; set; }
        public int IdProduit_Commandé { get; set; }
        public int Nb_Produit_Commandé { get; set; }
        [DataType(DataType.Currency)]
        public double Prix_Produit_Commandé { get; set; }
        Produit Produit { get; set; }
    }
}