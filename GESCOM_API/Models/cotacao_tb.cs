using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class cotacao_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cotacao_tb()
        {
            proposta_tb = new HashSet<proposta_tb>();
        }

        [Key]
        public int cotacao_id { get; set; }

        public int segurado_id { get; set; }

        public int ramo_id { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo { get; set; }

        public decimal premio { get; set; }

        public DateTime data_inicio_vigencia { get; set; }

        public DateTime data_fim_vigencia { get; set; }

        public DateTime data_cotacao { get; set; }

        public int corretor_id { get; set; }

        public int seguradora_id { get; set; }

        public virtual corretor_tb corretor_tb { get; set; }

        public virtual ramo_tb ramo_tb { get; set; }

        public virtual segurado_tb segurado_tb { get; set; }

        public virtual seguradora_tb seguradora_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proposta_tb> proposta_tb { get; set; }
    }
}
