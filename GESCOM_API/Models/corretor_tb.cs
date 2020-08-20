using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class corretor_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public corretor_tb()
        {
            cotacao_tb = new HashSet<cotacao_tb>();
            recibo_comissao_detalhe_tb = new HashSet<recibo_comissao_detalhe_tb>();
            recibo_comissao_detalhe_tb1 = new HashSet<recibo_comissao_detalhe_tb>();
        }

        [Key]
        public int corretor_id { get; set; }

        public int pessoa_id { get; set; }

        [StringLength(20)]
        public string codigo_susep { get; set; }

        public virtual pessoa_tb pessoa_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotacao_tb> cotacao_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo_comissao_detalhe_tb> recibo_comissao_detalhe_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo_comissao_detalhe_tb> recibo_comissao_detalhe_tb1 { get; set; }
    }
}
