using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TireLire.DataAcces;
using TireLire.Models;
using TireLire.Outils;

namespace TireLire.Controllers
{
    public class ProduitController : Controller
    {

        //Instanciation du EFRepository pour l'entité Produit
        Repository<Produit> repProduit = new EFRepository<Produit>();
        Repository<Produit_Commandé> repDetail = new EFRepository<Produit_Commandé>();



        //Fournir une list de SelectListItem pour alimentation des DropDownList Fournisseur
        private void FormerListeFournisseurs()
        {
            //Instanciation d'un repository pour les fournisseurs
            Repository<Fournisseur> repFournisseur = new EFRepository<Fournisseur>();

            ViewBag.IDFournisseur = repFournisseur.Lister()
                .Select(f =>
                new SelectListItem { Value = f.IdFournisseur.ToString(), Text = f.Nom })
                .ToList<SelectListItem>();
        }

        //Fournir une list de SelectListItem pour alimentation des DropDownList Categorie
        private void FormerListeCategories()
        {
            //Instanciation d'un repository pour les categories
            Repository<Catégorie> repCateg = new EFRepository<Catégorie>();

            ViewBag.IdCatégorie = repCateg.Lister()
                .Select(c =>
                new SelectListItem { Value = c.IdCatégorie.ToString(), Text = c.Description })
                .ToList<SelectListItem>();
        }

        //Méthode de retour de la Galerie Produit pour les clients
        public ActionResult Galerie()
        {
            return View(repProduit.Lister().Where(p => p.Statut == 1));
        }


        public ActionResult ProduitCat(int id)
        {
            return View(repProduit.Lister().Where(p => p.IdCatégorie == id).Where(p => p.Statut == 1));
        }

        


        // GET: Produit
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(repProduit.Lister());
        }

        // GET: Produit/Details/5
        [AllowAnonymous]
        [Route("Fiche/{id}")]
        [Route("TireLire/{id}")]
        [Route("Produit/Details/{id}")]
        public ActionResult Details(int id)
        {
            return View(repProduit.Trouver(id));
        }

        // GET: Produit/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            FormerListeCategories();
            FormerListeFournisseurs();
            return View();
        }


        // POST: Produit/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Produit produit, HttpPostedFileBase fichier)
        {
            try
            {
                if (fichier != null)
                {
                    produit.ImageUrl = Path.GetFileName(fichier.FileName);
                }

                Produit nouveau = repProduit.Ajouter(produit);

                if (fichier != null)
                {
                    //L'Id du produit est ajouté pour éviter les doublons de noms de fichiers
                    string destination = string.Format("{0}\\{1}_{2}"
                        , System.Web.Hosting.HostingEnvironment.MapPath("~/Images")
                        , nouveau.IdProduit
                        , nouveau.ImageUrl
                        );
                    fichier.SaveAs(destination);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                FormerListeFournisseurs();
                FormerListeCategories();
                return View();
            }
        }

        /// GET: Produit/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            FormerListeFournisseurs();
            FormerListeCategories();
            return View(repProduit.Trouver(id));
        }

        // POST: Produit/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Produit produit, HttpPostedFileBase fichier)
        {


            try
            {
                //Détermination du chemin précédent
                string anciennomfichier = produit.ImageUrl;

                if (fichier != null)
                {
                    produit.ImageUrl = Path.GetFileName(fichier.FileName);

                }

                Produit p = repProduit.Modifier(produit);

                if (fichier != null)
                {
                    //Reconstitution du chemin précédent
                    if (p.ImageUrl != null)
                    {
                        string ancienfichier = string.Format("{0}\\{1}_{2}"
                            , Server.MapPath("~/Images")
                            , p.IdProduit
                            , anciennomfichier
                            );

                        if (System.IO.File.Exists(ancienfichier))
                        {
                            System.IO.File.Delete(ancienfichier);

                        }

                    }

                    string destination = string.Format("{0}\\{1}_{2}"
                       , System.Web.Hosting.HostingEnvironment.MapPath("~/Images")
                       , p.IdProduit
                       , p.ImageUrl
                       );
                    fichier.SaveAs(destination);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                FormerListeFournisseurs();
                FormerListeCategories();
                return View();
            }
        }


        // GET: Produit/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(repProduit.Trouver(id));
        }

        // POST: Produit/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Produit ProduitASupprimer = repProduit.Trouver(id);
                ProduitASupprimer.Statut = 0;
                repProduit.Modifier(ProduitASupprimer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult _Topp()
        {


            var query = repDetail.Lister().GroupBy(x => x.IdProduit).Select(g => new { Idprod = g.Key, Total = g.Sum(x => x.Nb_Produit_Commandé) }).ToList().OrderByDescending(g => g.Total);

            List<IdprodTotalVH> listeidl = new List<IdprodTotalVH>();
            foreach (var itemquery in query)
            {
                IdprodTotalVH item = new IdprodTotalVH();
                item.IdProd = (int)itemquery.Idprod;
                item.Total = (int)itemquery.Total;
                item.NomProduit = repProduit.Trouver(item.IdProd).Nom_Produit;
                item.url = repProduit.Trouver(item.IdProd).ImageUrl;
                listeidl.Add(item);

            }

            TotalListVH model = new TotalListVH()
            {

                ListIds = listeidl
            };





            return PartialView(model);
        }
    }
}