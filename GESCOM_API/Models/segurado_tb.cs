using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class segurado_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public segurado_tb()
        {
            cotacao_tb = new HashSet<cotacao_tb>();
        }

        [Key]
        public int segurado_id { get; set; }

        public int pessoa_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotacao_tb> cotacao_tb { get; set; }

        public virtual pessoa_tb pessoa_tb { get; set; }
    }
}
