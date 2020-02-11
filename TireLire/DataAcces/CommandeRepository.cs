using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TireLire.Controllers;
using TireLire.Models;

namespace TireLire.DataAcces
{
    public class CommandeRepository : EFRepository<Commande>
    {
        public override Commande Ajouter(Commande entite)
        {
            //Utilisation de la clé externe vers Client et annulation de l'objet Client
            //pour éviter la création d'un Client supplémentaire par EF
            int? idclient = entite.Client.IdClient;
            entite.Client = null;
            entite.IdClient = idclient;

            //Parcours des détails de commande et affectation d'un IdProduit et suppression de l'objet Produit
            //pour éviter la création d'un Client supplémentaire par EF
            foreach (Produit_Commandé d in entite.Produit_Commandé)
            {
                int? idproduit = d.IdProduit;
                d.Produit = null;
                d.IdProduit = idproduit;
            }
            

            //Initialisation de l'état :
            entite.Statut = 1;



            return base.Ajouter(entite);
        }

    }
}