using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TireLire.DataAcces
{
        public interface Repository<T>
        {
            //Liste de entités
            IEnumerable<T> Lister();

            //Trouver une entité
            T Trouver(int id);

            //Créer une entité
            T Ajouter(T entite);

            //Modifier une entité)
            T Modifier(T entite);

            //Supprimer une entité
            bool Supprimer(int id);

        }
    }



