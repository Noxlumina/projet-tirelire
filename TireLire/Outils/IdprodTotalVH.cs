using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TireLire.Outils
{
    public class IdprodTotalVH
    {
        public string NomProduit { get; set; }
        public string url { get; set; }
        public int IdProd { get; set; }

        public double Total { get; set; }
    }

    public class TotalListVH
    {
        public List<IdprodTotalVH> ListIds { get; set; }


    }
}