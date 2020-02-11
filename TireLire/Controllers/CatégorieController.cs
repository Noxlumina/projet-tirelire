using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TireLire.DataAcces;
using TireLire.Models;

namespace TireLire.Controllers
{
    public class CategorieController : Controller
    {
        //Instanciation d'un Repository de type Categorie
        Repository<Catégorie> repCategorie = new EFRepository<Catégorie>();

        //Méthode de retour de la Galerie Produit pour les clients
        public ActionResult GalerieCat()
        {
            return View(repCategorie.Lister().Where(p => p.Statut == 1));
        }

        // GET: Categorie
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(repCategorie.Lister());
        }

        // GET: Categorie/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View(repCategorie.Trouver(id));
        }

        // GET: Categorie/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Catégorie categorie, HttpPostedFileBase fichier)
        {
            try
            {
                if (fichier != null)
                {
                    categorie.ImageCat = Path.GetFileName(fichier.FileName);
                }

                Catégorie nouveau = repCategorie.Ajouter(categorie);

                if (fichier != null)
                {
                    //L'Id du produit est ajouté pour éviter les doublons de noms de fichiers
                    string destination = string.Format("{0}\\{1}_{2}"
                        , System.Web.Hosting.HostingEnvironment.MapPath("~/Images")
                        , nouveau.IdCatégorie
                        , nouveau.ImageCat
                        );
                    fichier.SaveAs(destination);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorie/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(repCategorie.Trouver(id));
        }

        // POST: Categorie/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Catégorie categorie, HttpPostedFileBase fichier)
        {
            try
            {
                //Détermination du chemin précédent
                string anciennomfichier = categorie.ImageCat;

                if (fichier != null)
                {
                    categorie.ImageCat = Path.GetFileName(fichier.FileName);

                }

                Catégorie c = repCategorie.Modifier(categorie);

                if (fichier != null)
                {
                    //Reconstitution du chemin précédent
                    if (c.ImageCat != null)
                    {
                        string ancienfichier = string.Format("{0}\\{1}_{2}"
                            , Server.MapPath("~/Images")
                            , c.IdCatégorie
                            , anciennomfichier
                            );

                        if (System.IO.File.Exists(ancienfichier))
                        {
                            System.IO.File.Delete(ancienfichier);

                        }

                    }

                    string destination = string.Format("{0}\\{1}_{2}"
                       , System.Web.Hosting.HostingEnvironment.MapPath("~/Images")
                       , c.IdCatégorie
                       , c.ImageCat
                       );
                    fichier.SaveAs(destination);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorie/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(repCategorie.Trouver(id));
        }

        // POST: Categorie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Catégorie categorieASupprimer = repCategorie.Trouver(id);
                categorieASupprimer.Statut = 0;
                repCategorie.Modifier(categorieASupprimer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}