using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TireLire.DataAcces;
using TireLire.Models;

namespace TireLire.Controllers
{
    [Authorize]
    public class PanierController : Controller
    {
        Commande Panier;

        public PanierController()
        {
            //Récupération du panier depuis le tableau Session
            Panier = (Commande)System.Web.HttpContext.Current.Session["Panier"];

            //Si nécessaire, association du client à son panier
            if (Panier.Client == null)
            {
                Panier.Client = (Client)System.Web.HttpContext.Current.Session["Client"];
                System.Web.HttpContext.Current.Session["Panier"] = Panier;
            }
        }

        // GET: Ajout au panier
        public ActionResult Ajouter(int id)
        {

            //Instanciation d'un Repository Produit pour l'accès au produit
            Repository<Produit> repProduit = new EFRepository<Produit>();


            //Detail concerné par l'ajout
            Produit_Commandé detail;


            //Recherche d'un produit déjà présent dans le panier, au quel cas, incrémentation de la quantité
            if (Panier.Produit_Commandé.Where(d => d.IdProduit == id).Count() > 0)
            {
                detail = Panier.Produit_Commandé.Where(d => d.IdProduit == id).First();
                detail.Nb_Produit_Commandé++;
            }
            else
            {
                detail = new Produit_Commandé { Produit = repProduit.Trouver(id), IdProduit = id, Nb_Produit_Commandé = 1 };
                Panier.Produit_Commandé.Add(detail);
            }

            //Sauvegarde du Panier
            Session["Panier"] = Panier;


            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {

            return View(Panier);
        }


        public ContentResult Incrementer(int id)
        {
            Produit_Commandé detailActif = Panier.Produit_Commandé.Where(d => d.IdProduit == id).First();

            int? nouvelleQuantite = ++detailActif.Nb_Produit_Commandé;
            return new ContentResult()
            {
                Content = string.Format("<span>{0}  |  {1} </span>"
                , detailActif.Nb_Produit_Commandé.ToString()
                , detailActif.Nb_Produit_Commandé * detailActif.Produit.Prix_Unitaire
                )
            };

        }

        public ContentResult Decrementer(int id)
        {
            Produit_Commandé detailActif = Panier.Produit_Commandé.Where(d => d.IdProduit == id).First();

            if (detailActif.Nb_Produit_Commandé > 1)
            {
                detailActif.Nb_Produit_Commandé--;


            }

            return new ContentResult()
            {
                Content = string.Format("<span>{0}    |     {1} </span>"
                , detailActif.Nb_Produit_Commandé.ToString()
                , detailActif.Nb_Produit_Commandé * detailActif.Produit.Prix_Unitaire
                )
            };

        }


        public ContentResult Supprimer(int id)
        {
            Panier.Produit_Commandé.Remove(Panier.Produit_Commandé.Where(d => d.IdProduit == id).First());
            return new ContentResult();
        }


        public ContentResult calculerTotal()
        {
            return new ContentResult
            {
                Content = Panier.Produit_Commandé
                .Select(d => new { montant = d.Produit.Prix_Unitaire * d.Nb_Produit_Commandé })
                .Sum(m => m.montant).ToString()
            };
        }

        public ContentResult calculerPoids()
        {
            return new ContentResult
            {
                Content = Panier.Produit_Commandé
                .Select(d => new { poids = d.Produit.Poids * d.Nb_Produit_Commandé })
                .Sum(m => m.poids).ToString()
                
            };
        }

    }
}