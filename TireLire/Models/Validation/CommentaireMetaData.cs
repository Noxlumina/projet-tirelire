using System;
using System.ComponentModel.DataAnnotations;

namespace TireLire.Models
{
    [MetadataType(typeof(CommentaireMetaData))]
    public partial class Commentaire { }
    public class CommentaireMetaData
    {
        Client Client { get; set; }
        public string Commentaire1 { get; set; }
        DateTime Date_Avis { get; set; }
        public int Etat { get; set; }
        public int IdClient { get; set; }
        public int IdCommentaire { get; set; }
        public int IdProduit { get; set; }
        public double Note { get; set; }
        Produit Produit { get; set; }
    }
}