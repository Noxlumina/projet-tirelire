using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TireLire.DataAcces;
using TireLire.Models;

namespace TireLire.Controllers
{
    public class FournisseurController : Controller
    {

        //Instanciation du EFRepository pour l'entité Fournisseur
        Repository<Fournisseur> repFournisseur = new EFRepository<Fournisseur>();

        // GET: Fournisseur
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(repFournisseur.Lister());
        }

        // GET: Fournisseur/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View(repFournisseur.Trouver(id));
        }

        // GET: Fournisseur/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseur/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Fournisseur fournisseur)
        {
            try
            {
                repFournisseur.Ajouter(fournisseur);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repFournisseur.Trouver(id));
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Fournisseur fournisseur)
        {
            try
            {
                repFournisseur.Modifier(fournisseur);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(repFournisseur.Trouver(id));
        }

        // POST: Fournisseur/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Fournisseur fournisseurASupprimer = repFournisseur.Trouver(id);
                fournisseurASupprimer.Statut = 0;
                repFournisseur.Modifier(fournisseurASupprimer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}