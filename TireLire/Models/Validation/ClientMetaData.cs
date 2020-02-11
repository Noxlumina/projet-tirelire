using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TireLire.Models
{
    [MetadataType(typeof(ClientMetaData))]
    public partial class Client { }
    public class ClientMetaData
    {
        ICollection<Commande> Commandes { get; set; }
        ICollection<Commentaire> Commentaires { get; set; }
        [DisplayName("Email du Client")]
        public string Email { get; set; }
        public int IdClient { get; set; }
        [DisplayName("Nom du Client")]
        public string Nom { get; set; }
        [DisplayName("Prénom du Client")]
        public string Prénom { get; set; }
        public int Statut { get; set; }
        [DisplayName("Téléphone du Client")]
        public string Téléphone { get; set; }
        [DisplayName("Adresse du Client")]
        public string Adresse { get; set; }
        [DisplayName("Pays du Client")]
        public string Pays { get; set; }
        [DisplayName("Ville du Client")]
        public string Ville { get; set; }
        public string UserPhoto { get; set; }

    }
}