using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class proposta_parcela_tb
    {
        [Key]
        public int proposta_parcela_id { get; set; }

        public int proposta_id { get; set; }

        public int numero_parcela { get; set; }

        public DateTime data_vencimento { get; set; }

        public decimal premio_liquido { get; set; }

        public virtual proposta_tb proposta_tb { get; set; }
    }
}
