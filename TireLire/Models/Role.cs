namespace TireLire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string mail { get; set; }

        [Column("role")]
        [StringLength(10)]
        public string RoleAttribue { get; set; }
    }
}