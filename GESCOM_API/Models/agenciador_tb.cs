using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class agenciador_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agenciador_tb()
        {
            recibo_agenciamento_detalhe_tb = new HashSet<recibo_agenciamento_detalhe_tb>();
        }

        [Key]
        public int agenciador_id { get; set; }

        public int pessoa_id { get; set; }

        public virtual pessoa_tb pessoa_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo_agenciamento_detalhe_tb> recibo_agenciamento_detalhe_tb { get; set; }
    }
}
