using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class recibo_agenciamento_detalhe_tb
    {
        [Key]
        public int recibo_agenciamento_detalhe_id { get; set; }

        public int recibo_comissao_id { get; set; }

        public int agenciador_id { get; set; }

        public DateTime data_pagamento { get; set; }

        public decimal valor_pagamento { get; set; }

        public decimal percentual_comissao { get; set; }

        public int? status_pagamento { get; set; }

        public virtual agenciador_tb agenciador_tb { get; set; }

        public virtual recibo_comissao_tb recibo_comissao_tb { get; set; }
    }
}
