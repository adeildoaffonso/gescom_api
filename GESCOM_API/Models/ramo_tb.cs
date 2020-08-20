using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class ramo_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ramo_tb()
        {
            cotacao_tb = new HashSet<cotacao_tb>();
        }

        [Key]
        public int ramo_id { get; set; }

        [Required]
        [StringLength(10)]
        public string codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotacao_tb> cotacao_tb { get; set; }
    }
}
