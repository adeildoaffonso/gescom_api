using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class proposta_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proposta_tb()
        {
            proposta_parcela_tb = new HashSet<proposta_parcela_tb>();
            recibo_comissao_tb = new HashSet<recibo_comissao_tb>();
        }

        [Key]
        public int proposta_id { get; set; }

        public int cotacao_id { get; set; }

        [Required]
        [StringLength(45)]
        public string codigo { get; set; }

        public DateTime data_proposta { get; set; }

        public DateTime data_emissao { get; set; }

        public int parcelamento { get; set; }

        public decimal premio_liquido { get; set; }

        public int agenciamento { get; set; }

        public virtual cotacao_tb cotacao_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proposta_parcela_tb> proposta_parcela_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recibo_comissao_tb> recibo_comissao_tb { get; set; }
    }
}
