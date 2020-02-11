using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TireLire.DataAcces;
using TireLire.Models;
using TireLire.Outils;

namespace TireLire.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        //Instanciation d'un repository Commande 
        Repository<Commande> repCommande = new EFRepository<Commande>();
        Repository<Client> repClient = new EFRepository<Client>();


        // GET: Client
        public ActionResult ListerCommandes()
        {

            int id = ((Client)Session["Client"]).IdClient;
            return View(repCommande.Lister().Where(c => c.IdClient == id));
        }


        public ActionResult DetailCommande(int id)
        {

            return View(repCommande.Trouver(id));
        }

        //[HttpGet]
        //public ActionResult ListNote()
        //{

        //    List<SelectListItem> liste = new List<SelectListItem>();
        //    liste.Add(new SelectListItem() { Text = "0", Value = "1" });
        //    liste.Add(new SelectListItem() { Text = "1", Value = "2" });
        //    liste.Add(new SelectListItem() { Text = "2", Value = "3" });
        //    liste.Add(new SelectListItem() { Text = "3", Value = "4" });
        //    liste.Add(new SelectListItem() { Text = "4", Value = "5" });
        //    liste.Add(new SelectListItem() { Text = "5", Value = "6" });
        //    ViewBag.List = liste;
        //    return View();
        //}

    

        // GET: Produit
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(repClient.Lister());
        }

        // GET: Client/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(repClient.Trouver(id));
        }

        // POST: Produit/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Client ClientADesac = repClient.Trouver(id);
                ClientADesac.Statut = 0;
                repClient.Modifier(ClientADesac);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Reput(int id)
        {
            return View(repClient.Trouver(id));
        }

        // POST: Produit/Delete/5
        [HttpPost]
        [ActionName("Reput")]
        [Authorize(Roles = "Admin")]
        public ActionResult ReputConfirm(int id)
        {
            try
            {
                Client ClientAResac = repClient.Trouver(id);
                ClientAResac.Statut = 1;
                repClient.Modifier(ClientAResac);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeposerAvis(int id)
        {

            Commentaire nouvelAvis = new Commentaire
            {
                IdProduit = id
                ,
                IdClient = ((Client)Session["Client"]).IdClient
                ,
                Etat = (int)EtatsAvis.NonApprouve
                ,
                Date_Avis = DateTime.Now
            };

            return View(nouvelAvis);

        }

        [HttpPost]
        public ActionResult DeposerAvis(Commentaire avis)
        {
            //instanciation d'un repository Avis
            Repository<Commentaire> repAvis = new EFRepository<Commentaire>();
            repAvis.Ajouter(avis);

            return RedirectToAction("ListerCommandes", new { id = avis.IdClient });
        }

        public ActionResult Afficher()
        {
            //Client client = new Client
            //{
            //    Nom = ((Client)Session["Client"]).Nom,
            //    Prénom = ((Client)Session["Client"]).Prénom,
            //    Téléphone = ((Client)Session["Client"]).Téléphone,
            //    Email = ((Client)Session["Client"]).Email,
            //    Adresse = ((Client)Session["Client"]).Adresse,
            //    Ville = ((Client)Session["Client"]).Ville,
            //    Pays = ((Client)Session["Client"]).Pays

            //};
            //return View(client);
            int id = ((Client)Session["Client"]).IdClient;
            return View(repClient.Trouver(id));

        }

        /// GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {


            return View(repClient.Trouver(id));
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            try
            {

                repClient.Modifier(client);
                return RedirectToAction("Afficher");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult _Topp()
        //{


        //    var query = repCommande.Lister().GroupBy(x => x.IdClient).Select(g => new { IdCli = g.Key, Total = g.Sum(x => x.IdClient.) }).ToList().OrderByDescending(g => g.Total);

        //    List<IdprodTotalVH> listeidl = new List<IdprodTotalVH>();
        //    foreach (var itemquery in query)
        //    {
        //        IdprodTotalVH item = new IdprodTotalVH();
        //        item.IdProd = (int)itemquery.Idprod;
        //        item.Total = (int)itemquery.Total;
        //        item.NomProduit = repProduit.Trouver(item.IdProd).Nom_Produit;
        //        item.url = repProduit.Trouver(item.IdProd).ImageUrl;
        //        listeidl.Add(item);

        //    }

        //    TotalListVH model = new TotalListVH()
        //    {

        //        ListIds = listeidl
        //    };





        //    return PartialView(model);
        //}
    }
}