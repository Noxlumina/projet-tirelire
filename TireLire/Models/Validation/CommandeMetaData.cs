using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TireLire.Models
{
    [MetadataType(typeof(CommandeMetaData))]
    public partial class Commande { }
    public class CommandeMetaData
    {
        Client Client { get; set; }
        DateTime Date_Commande { get; set; }
        public int? IdClient { get; set; }
        public int IdCommande { get; set; }
        ICollection<Produit_Commandé> Produit_Commandé { get; set; }
        public int Statut { get; set; }
        [DataType(DataType.Currency)]
        public double Total { get; set; }
    }
}