using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class pessoa_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pessoa_tb()
        {
            agenciador_tb = new HashSet<agenciador_tb>();
            corretor_tb = new HashSet<corretor_tb>();
            segurado_tb = new HashSet<segurado_tb>();
            seguradora_tb = new HashSet<seguradora_tb>();
        }

        [Key]
        public int pessoa_id { get; set; }

        [Required]
        [StringLength(45)]
        public string nome { get; set; }

        [Required]
        [StringLength(15)]
        public string cpf_cnpj { get; set; }

        public int? tipo_pessoa { get; set; }

        [StringLength(75)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agenciador_tb> agenciador_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<corretor_tb> corretor_tb { get; set; }

        public virtual dados_bancarios_tb dados_bancarios_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<segurado_tb> segurado_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<seguradora_tb> seguradora_tb { get; set; }
    }
}
