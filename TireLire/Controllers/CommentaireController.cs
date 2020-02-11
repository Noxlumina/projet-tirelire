using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TireLire.DataAcces;
using TireLire.Models;
using TireLire.Outils;

namespace TireLire.Controllers
{
    [Authorize(Roles = "Mod")]
    public class CommentaireController : Controller
    {

        //Instanciation du EFRepository pour l'entité Avis
        Repository<Commentaire> repAvis = new EFRepository<Commentaire>();

        // GET: Avis
        public ActionResult Index()
        {
            //Pour la modération, seul les avis nonValidés sont à exposer
            return View(repAvis.Lister().Where(a => a.Etat == (int)EtatsAvis.NonApprouve));
        }

        // GET: Avis/Details/5
        public ActionResult Details(int id)
        {
            return View(repAvis.Trouver(id));
        }

        



        // GET: Avis/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repAvis.Trouver(id));
        }

        // POST: Avis/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                repAvis.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ContentResult Approuver(int id)
        {
            Commentaire avisAApprouver = repAvis.Trouver(id);
            avisAApprouver.Etat = (int)EtatsAvis.Approuve;
            repAvis.Modifier(avisAApprouver);
            return new ContentResult { Content = ((EtatsAvis)avisAApprouver.Etat).ToString() };
        }


        public ContentResult Refuser(int id)
        {

            Commentaire avisARefuser = repAvis.Trouver(id);
            avisARefuser.Etat = (int)EtatsAvis.Rejete;
            repAvis.Modifier(avisARefuser);
            return new ContentResult { Content = ((EtatsAvis)avisARefuser.Etat).ToString() };
        }


    }
}
