using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class recibo_comissao_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recibo_comissao_tb()
        {
            recibo_agenciamento_detalhe_tb = new HashSet<recibo_agenciamento_detalhe_tb>();
            recibo_comissao_detalhe_tb = new HashSet<recibo_comissao_detalhe_tb>();
            recibo_comissao_detalhe_tb1 = new HashSet<recibo_comissao_detalhe_tb>();
        }

        [Key]
        public int recibo_comissao_id { get; set; }

        public int proposta_id { get; set; }

        public decimal valor_bruto { get; set; }

        public decimal valor_liquido { get; set; }

        public decimal percentual_comissao { get; set; }

        public decimal percentual_imposto { get; set; }

        public virtual proposta_tb proposta_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo_agenciamento_detalhe_tb> recibo_agenciamento_detalhe_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo_comissao_detalhe_tb> recibo_comissao_detalhe_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo_comissao_detalhe_tb> recibo_comissao_detalhe_tb1 { get; set; }
    }
}
